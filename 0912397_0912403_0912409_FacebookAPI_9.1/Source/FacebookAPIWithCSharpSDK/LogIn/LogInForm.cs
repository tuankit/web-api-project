using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class LogInForm : Form
    {
        private string access_token;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            webFacebook.Navigate(@"https://www.facebook.com/dialog/oauth?client_id=340494446046415&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token");
        }

        private void webFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webFacebook.Url.AbsoluteUri.Contains("access_token"))
            {
                string url1 = webFacebook.Url.AbsoluteUri;
                string url2 = url1.Substring(url1.IndexOf("access_token") + 13);
                access_token = url2.Substring(0, url2.IndexOf("&"));
            }
        }
    }
}
