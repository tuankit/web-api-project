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

namespace GetFriendsList
{
    public partial class GetFriendsListForm : Form
    {
        private string access_token = "";

        public string Access_token
        {
            get { return access_token; }
            set { access_token = value; }
        }

        public GetFriendsListForm()
        {
            InitializeComponent();
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            LogInForm logIn = new LogInForm(this);
            logIn.ShowDialog();
        }

        private void getFriends_Click(object sender, EventArgs e)
        {
            if (access_token != "")
            {
                FacebookClient fb = new FacebookClient(access_token);

                dynamic FriendList = fb.Get("/me/friends");

                int count = (int)FriendList.data.Count;

                for (int i = 0; i < count; i++)
                {
                    friendList.Items.Add(FriendList.data[i].name);
                }
            }
           
        }
    }
}
