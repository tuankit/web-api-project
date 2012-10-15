namespace GetFriendsList
{
    partial class GetFriendsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetFriendsListForm));
            this.logIn = new System.Windows.Forms.Button();
            this.getFriends = new System.Windows.Forms.Button();
            this.friendList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logIn
            // 
            this.logIn.BackColor = System.Drawing.Color.Transparent;
            this.logIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logIn.BackgroundImage")));
            this.logIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logIn.Location = new System.Drawing.Point(12, 293);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(75, 29);
            this.logIn.TabIndex = 0;
            this.logIn.Text = "Log in";
            this.logIn.UseVisualStyleBackColor = false;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // getFriends
            // 
            this.getFriends.BackColor = System.Drawing.Color.Transparent;
            this.getFriends.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("getFriends.BackgroundImage")));
            this.getFriends.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.getFriends.Enabled = false;
            this.getFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getFriends.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.getFriends.Location = new System.Drawing.Point(93, 293);
            this.getFriends.Name = "getFriends";
            this.getFriends.Size = new System.Drawing.Size(114, 29);
            this.getFriends.TabIndex = 1;
            this.getFriends.Text = "Get Friends List";
            this.getFriends.UseVisualStyleBackColor = false;
            this.getFriends.Click += new System.EventHandler(this.getFriends_Click);
            // 
            // friendList
            // 
            this.friendList.FormattingEnabled = true;
            this.friendList.HorizontalScrollbar = true;
            this.friendList.Location = new System.Drawing.Point(12, 12);
            this.friendList.Name = "friendList";
            this.friendList.Size = new System.Drawing.Size(194, 264);
            this.friendList.TabIndex = 2;
            // 
            // GetFriendsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 334);
            this.Controls.Add(this.friendList);
            this.Controls.Add(this.getFriends);
            this.Controls.Add(this.logIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetFriendsListForm";
            this.Text = "Friends List";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button logIn;
        public System.Windows.Forms.Button getFriends;
        private System.Windows.Forms.ListBox friendList;
    }
}