using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneBook.Core.Data;
using PhoneBook.Core.Model;

namespace PhoneBook.Form
{
    internal sealed partial class Home : System.Windows.Forms.Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        const int MyactionHotkeyId = 1;
        private readonly string _jsonDataPath = Application.StartupPath + "\\Resource\\phoneBookData.json";
        private readonly PhoneBookUnitOfWork _uow;

        private PhoneBookUnitOfWork Uow => _uow ?? new PhoneBookUnitOfWork(_jsonDataPath);
        
        #region constructor

        internal Home(string[] getCommandLineArgs)
        {
            InitializeComponent();
            RegisterHotKey(Handle, MyactionHotkeyId, 6, 'P');
            try
            {
                _uow = new PhoneBookUnitOfWork(_jsonDataPath);

                var c = new Card();
                foreach (
                    var prop in
                    c.GetType().GetProperties().OrderBy(x => x.GetCustomAttribute<CardDisplayAttribute>().Column))
                    lstView_Results.Columns.Add(prop.Name, prop.GetCustomAttribute<CardDisplayAttribute>().DisplayName,
                        100);
                
                if (getCommandLineArgs.Length > 1)
                {
                    txt_InputSearch.Text = getCommandLineArgs[1];
                    LaunchSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        #endregion

        #region resize

        private void Home_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifySystrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Maximize();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MyactionHotkeyId && btn_Search.Enabled)
            {
                Maximize();
                txt_InputSearch.Focus();
            }
            if (m.Msg == SingleInstance.WmSettext)
            {
                Maximize(Marshal.PtrToStringAuto(m.LParam));
            }
            base.WndProc(ref m);
        }

        private void Maximize(string param = null)
        {
            Show();
            WindowState = FormWindowState.Normal;
            if (param != null)
                txt_InputSearch.Text = param;
            if (!string.IsNullOrEmpty(txt_InputSearch.Text))
                LaunchSearch();
            LaunchSearch();
        }
        #endregion

        #region search
        private void txt_InputSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter && !string.IsNullOrEmpty(txt_InputSearch.Text))
            {
                LaunchSearch();
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_InputSearch.Text))
                LaunchSearch();
        }

        private async void LaunchSearch()
        {
            if (!btn_Search.Enabled) return;
            btn_Search.Enabled = false;
            btn_Search.Text = @"Searching...";

            var result = await Task.Factory.StartNew(() => Uow.CardsRepository.FindInAllProperties(txt_InputSearch.Text));

            DisplayCards(result.Where(x => x != null).Distinct());

            btn_Search.Enabled = true;
            btn_Search.Text = @"Search";
        }
        #endregion

        #region display
        private void DisplayCards(IEnumerable<Card> cards)
        {
            lstView_Results.View = View.Details;
            lstView_Results.Items.Clear();

            foreach (var card in cards.OrderBy(c => c.InternalPhoneNumber).ThenBy(c => c.Department).ThenBy(c => c.FirstName))
            {
                var newItem =
                    card.GetType().GetProperties()
                        .OrderBy(x => x.GetCustomAttribute<CardDisplayAttribute>().Column)
                        .Select(x => x.GetValue(card).ToString()).ToArray();

                lstView_Results.Items.Add(new ListViewItem(newItem));
            }

            txt_InputSearch.Text = "";
        }

        #endregion

        private void btn_AddCard_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var frmAddCard = new SetCard(Uow) { Text = @"Add new card" };
            frmAddCard.FormClosed += (o, args) => { Enabled = true; };
            frmAddCard.BringToFront();

            frmAddCard.Show();
        }

        private void btn_EditCard_Click(object sender, EventArgs e)
        {
            if (lstView_Results.SelectedItems.Count != 1) return;
            Enabled = false;

            var frmEditCard = new SetCard(Uow, SetCardFromListItem(lstView_Results.SelectedItems[0])) { Text = @"Edit card" };
            frmEditCard.FormClosed += (o, args) => { Enabled = true; };
            frmEditCard.BringToFront();

            frmEditCard.Show();
        }

        private void btn_DeleteCard_Click(object sender, EventArgs e)
        {
            if (lstView_Results.SelectedItems.Count == 1 &&
                MessageBox.Show(@"Do you really want to delete ?", @"Comfirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Uow.CardsRepository.Delete(SetCardFromListItem(lstView_Results.SelectedItems[0]));
            }
        }

        private static Card SetCardFromListItem(ListViewItem selectedItem)
        {
            var nCard = new Card();
            for (var i = 0; i < nCard.GetType().GetProperties().Length; i++)
            {
                var prop = nCard.GetType().GetProperties().OrderBy(x => x.GetCustomAttribute<CardDisplayAttribute>().Column).ToArray()[i];
                prop.SetValue(nCard, selectedItem.SubItems[i].Text);
            }
            return nCard;
        }
    }
}
