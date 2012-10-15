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
using System.IO;

namespace Post_Status_Link_Image
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            LogInWithConfirmPermissions logIn = new LogInWithConfirmPermissions(this);
            logIn.ShowDialog();
        }

        private void post_Click(object sender, EventArgs e)
        {
            try
            {
                if (picturePath.Text.Length == 0)
                {
                    FacebookClient fbClient = new FacebookClient(AppSettings.Default.AccessToken);

                    Dictionary<string, object> postArgs = new Dictionary<string, object>();

                    postArgs["message"] = status.Text;

                    if (linkText.Text.Length > 0)
                        postArgs["link"] = linkText.Text;

                    fbClient.Post("/me/feed", postArgs);
                }
                else
                {
                    FacebookClient fbClient = new FacebookClient(AppSettings.Default.AccessToken);

                    var imgStream = File.OpenRead(picturePath.Text);

                    string mess = status.Text + "\n" + linkText.Text;

                    fbClient.Post("/me/photos", new
                        {
                            message = mess,
                            file = new FacebookMediaStream
                            {
                                ContentType = "image/jpg",
                                FileName = Path.GetFileName(picturePath.Text)
                            }.SetValue(imgStream)
                        });
                }

                MessageBox.Show("Post successful.", "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post failed: " + ex.Message + ".\nPlease try again!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Exit confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                Close();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PNG Images|*.png|JPG Images|*.jpg";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.FileName.ToString().Length != 0)
            {
                picturePath.Text = openFile.FileName;
            }
        }
    }
}
