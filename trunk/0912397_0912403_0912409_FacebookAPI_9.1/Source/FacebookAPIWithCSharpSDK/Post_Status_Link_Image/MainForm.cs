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
        public bool isLogIn = false;
        public string user;
        public MainForm()
        {
            InitializeComponent();
        }

        public void setInfor(string username)
        {
            FacebookClient fb = new FacebookClient(AppSettings.Default.AccessToken);
            if (username.ToUpper().Equals("ME"))
            {
                friendListbox.Items.Clear();

                dynamic friendList = fb.Get("/me/friends");

                int count = (int)friendList.data.Count;

                for (int i = 0; i < count; i++)
                {
                    friendListbox.Items.Add(friendList.data[i].name);
                }
                dynamic myInfor = fb.Get("/me");
                info.Text = myInfor.name + "'s Information";
                image.ImageLocation = String.Format("http://graph.facebook.com/{0}/picture", myInfor.id);
                name.Text = myInfor.name;

                try
                {
                    location.Text = myInfor.location.name;
                }
                catch (System.Exception ex)
                {
                    location.Text = null;
                }

                try
                {
                    homeTown.Text = myInfor.hometown.name;
                }
                catch (System.Exception ex)
                {
                    homeTown.Text = null;
                }

                try
                {
                    link.Text = myInfor.link;
                }
                catch (System.Exception ex)
                {
                    link.Text = null;
                }
            }
            else
            {
                dynamic friendsList = fb.Get("/me/friends?fields=name, location, hometown, link");


                int count = (int)friendsList.data.Count;

                for (int i = 0; i < count; i++)
                {
                    if(friendsList.data[i].name.Equals(username))
                        count = i;
                }

                info.Text = friendsList.data[count].name + "'s Information";
                image.ImageLocation = String.Format("http://graph.facebook.com/{0}/picture", friendsList.data[count].id);
                name.Text = friendsList.data[count].name;   

                try
                {
                    location.Text = friendsList.data[count].location.name;
                }
                catch (System.Exception ex)
                {
                    location.Text = null;
                }

                try
                {
                    homeTown.Text = friendsList.data[count].hometown.name;
                }
                catch (System.Exception ex)
                {
                    homeTown.Text = null;
                }

                try
                {
                    link.Text = friendsList.data[count].link;
                }
                catch (System.Exception ex)
                {
                    link.Text = null;
                }
            }

        }

        private void logIn_Click(object sender, EventArgs e)
        {
            if (!isLogIn)
            {
                LogInWithConfirmPermissions logIn = new LogInWithConfirmPermissions(this);
                logIn.ShowDialog();
            }
            else
            {
                setInfor("me");
                user = "me";
            }
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

                    fbClient.Post(String.Format("{0}/feed", user), postArgs);
                }
                else
                {
                    FacebookClient fbClient = new FacebookClient(AppSettings.Default.AccessToken);

                    var imgStream = File.OpenRead(picturePath.Text);

                    string mess = status.Text + "\n" + linkText.Text;

                    fbClient.Post(String.Format("{0}/photos", user), new 
                        {
                            message = mess,
                            file = new FacebookMediaStream
                            {
                                ContentType = "image/jpg",
                                FileName = Path.GetFileName(picturePath.Text)
                            }.SetValue(imgStream)
                        });
                }
                string name = "your";
                if (!user.ToUpper().Equals("ME"))
                    name = friendListbox.SelectedItem.ToString() + "'s";
                MessageBox.Show("Post to " + name + " wall successful.", "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void friendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            setInfor(friendListbox.SelectedItem.ToString());
            FacebookClient fbClient = new FacebookClient(AppSettings.Default.AccessToken);
            dynamic friendsList = fbClient.Get("/me/friends");


            int count = (int)friendsList.data.Count;

            for (int i = 0; i < count; i++)
            {
                if (friendsList.data[i].name.Equals(friendListbox.SelectedItem.ToString()))
                {
                    user = friendsList.data[i].id;
                    return;
                }
            }
        }
    }
}
