using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using PhoneBook.Core.Data;
using PhoneBook.Core.Model;

namespace PhoneBook.Form
{
    public partial class SetCard : System.Windows.Forms.Form
    {
        private readonly PhoneBookUnitOfWork _unitOfWork;
        private Card _card;

        public SetCard()
        {
            InitializeComponent();
        }

        public SetCard(PhoneBookUnitOfWork unitOfWork, Card card = null) : base()
        {
            _unitOfWork = unitOfWork;
            _card = card ?? new Card();
            
            var offsetY = 0;
            for (int i = 0; i < _card.GetType().GetProperties().Length; i++)
            {
                var prop = _card.GetType().GetProperties()[i];
                offsetY = (i + 1) * 25;
                var lbl = new Label
                {
                    Name = $"lbl_{prop.Name}",
                    Text = prop.GetCustomAttribute<CardDisplayAttribute>().DisplayName,
                    AutoSize = true,
                    Location = new Point(10, offsetY)
                };
                Controls.Add(lbl);

                var txt = new TextBox
                {
                    Name = $"txt_{prop.Name}",
                    AutoSize = true,
                    Location = new Point(lbl.Location.X + lbl.Width + 10, offsetY),
                    Text = prop.GetValue(_card)?.ToString()
                };
                Controls.Add(txt);
            }

            var btnAddCardCancel = new Button
            {
                Text = @"Cancel",
                Anchor = AnchorStyles.Bottom & AnchorStyles.Left,
                Location = new Point(10, offsetY + 50)
            };
            btnAddCardCancel.Click += (sender, args) => { Close(); Dispose(); };
            Controls.Add(btnAddCardCancel);

            var btnAddOrEditCardOk = new Button
            {
                Text = @"Ok",
                Anchor = AnchorStyles.Bottom & AnchorStyles.Left,
                Location = new Point(btnAddCardCancel.Location.X + btnAddCardCancel.Width + 10, offsetY + 50)
            };
            btnAddOrEditCardOk.Click += AddOrEditCardValid;
            Controls.Add(btnAddOrEditCardOk);

        }


        private void AddOrEditCardValid(object sender, EventArgs e)
        {
            var c = Controls.OfType<TextBox>().ToList();
            if (c.Any() && c.Any(x => !string.IsNullOrEmpty(x.Text)))
            {
                var nCard = new Card();
                foreach (var property in nCard.GetType().GetProperties())
                {
                    property.SetValue(nCard, c.First(t => t.Name == $"txt_{property.Name}")?.Text);
                }
                if (_card != null)
                {
                    _unitOfWork.CardsRepository.Delete(_card);
                }
                _unitOfWork.CardsRepository.Insert(nCard);
                _unitOfWork.Save();
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show(@"Can't be saved. All necessary datas must be completed.");
            }
        }

    }
}
