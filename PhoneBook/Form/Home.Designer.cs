namespace PhoneBook.Form
{
    internal sealed partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.notifySystrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txt_InputSearch = new System.Windows.Forms.TextBox();
            this.ts_Menu = new System.Windows.Forms.ToolStrip();
            this.btn_AddCard = new System.Windows.Forms.ToolStripButton();
            this.btn_EditCard = new System.Windows.Forms.ToolStripButton();
            this.btn_DeleteCard = new System.Windows.Forms.ToolStripButton();
            this.blb_InputSearch = new System.Windows.Forms.Label();
            this.lstView_Results = new System.Windows.Forms.ListView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.ts_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifySystrayIcon
            // 
            this.notifySystrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifySystrayIcon.Icon")));
            this.notifySystrayIcon.Text = "PhoneBook";
            this.notifySystrayIcon.Visible = true;
            this.notifySystrayIcon.DoubleClick += new System.EventHandler(this.notifySystrayIcon_DoubleClick);
            // 
            // txt_InputSearch
            // 
            this.txt_InputSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_InputSearch.Location = new System.Drawing.Point(80, 43);
            this.txt_InputSearch.Name = "txt_InputSearch";
            this.txt_InputSearch.Size = new System.Drawing.Size(447, 20);
            this.txt_InputSearch.TabIndex = 0;
            this.txt_InputSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_InputSearch_KeyPress);
            // 
            // ts_Menu
            // 
            this.ts_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_AddCard,
            this.btn_EditCard,
            this.btn_DeleteCard});
            this.ts_Menu.Location = new System.Drawing.Point(0, 0);
            this.ts_Menu.Name = "ts_Menu";
            this.ts_Menu.Size = new System.Drawing.Size(694, 25);
            this.ts_Menu.TabIndex = 1;
            this.ts_Menu.Text = "Menu";
            // 
            // btn_AddCard
            // 
            this.btn_AddCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddCard.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddCard.Image")));
            this.btn_AddCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddCard.Name = "btn_AddCard";
            this.btn_AddCard.Size = new System.Drawing.Size(63, 22);
            this.btn_AddCard.Text = "New Card";
            this.btn_AddCard.Click += new System.EventHandler(this.btn_AddCard_Click);
            // 
            // btn_EditCard
            // 
            this.btn_EditCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_EditCard.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditCard.Image")));
            this.btn_EditCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_EditCard.Name = "btn_EditCard";
            this.btn_EditCard.Size = new System.Drawing.Size(59, 22);
            this.btn_EditCard.Text = "Edit Card";
            this.btn_EditCard.Click += new System.EventHandler(this.btn_EditCard_Click);
            // 
            // btn_DeleteCard
            // 
            this.btn_DeleteCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_DeleteCard.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteCard.Image")));
            this.btn_DeleteCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_DeleteCard.Name = "btn_DeleteCard";
            this.btn_DeleteCard.Size = new System.Drawing.Size(72, 22);
            this.btn_DeleteCard.Text = "Delete Card";
            this.btn_DeleteCard.Click += new System.EventHandler(this.btn_DeleteCard_Click);
            // 
            // blb_InputSearch
            // 
            this.blb_InputSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blb_InputSearch.AutoSize = true;
            this.blb_InputSearch.Location = new System.Drawing.Point(33, 46);
            this.blb_InputSearch.Name = "blb_InputSearch";
            this.blb_InputSearch.Size = new System.Drawing.Size(41, 13);
            this.blb_InputSearch.TabIndex = 2;
            this.blb_InputSearch.Text = "Search";
            // 
            // lstView_Results
            // 
            this.lstView_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView_Results.FullRowSelect = true;
            this.lstView_Results.Location = new System.Drawing.Point(12, 97);
            this.lstView_Results.MultiSelect = false;
            this.lstView_Results.Name = "lstView_Results";
            this.lstView_Results.Size = new System.Drawing.Size(670, 299);
            this.lstView_Results.TabIndex = 3;
            this.lstView_Results.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.Location = new System.Drawing.Point(549, 35);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(85, 35);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 408);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.lstView_Results);
            this.Controls.Add(this.blb_InputSearch);
            this.Controls.Add(this.ts_Menu);
            this.Controls.Add(this.txt_InputSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "PhoneBook";
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.ts_Menu.ResumeLayout(false);
            this.ts_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifySystrayIcon;
        private System.Windows.Forms.TextBox txt_InputSearch;
        private System.Windows.Forms.ToolStrip ts_Menu;
        private System.Windows.Forms.Label blb_InputSearch;
        private System.Windows.Forms.ListView lstView_Results;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ToolStripButton btn_AddCard;
        private System.Windows.Forms.ToolStripButton btn_EditCard;
        private System.Windows.Forms.ToolStripButton btn_DeleteCard;
    }
}