using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace Post_Status_Link_Image
{
    public partial class LogInWithConfirmPermissions : Form
    {
        private MainForm main;
        public LogInWithConfirmPermissions(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            webFacebook.Navigate(@"https://www.facebook.com/dialog/oauth?client_id=" +
                AppSettings.Default.AppID +
                "&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&scope=" +
                AppSettings.Default.Scope);
        }

        private void webFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webFacebook.Url.AbsoluteUri.Contains("access_token"))
            {
                string url1 = webFacebook.Url.AbsoluteUri;
                string url2 = url1.Substring(url1.IndexOf("access_token") + 13);
                AppSettings.Default.AccessToken = url2.Substring(0, url2.IndexOf("&"));
                main.logIn.Text = "Home";
                main.post.Enabled = true;
                main.please.Visible = false;

                main.isLogIn = true;
                main.user = "me";
                main.setInfor("me");
                Close();
            }
        }
    }
}
