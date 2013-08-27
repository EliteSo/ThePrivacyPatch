using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Facebook;

namespace The_Elite_Patcher
{
    public partial class NewSplash : Form
    {
        public NewSplash()
        {
            InitializeComponent();
        }

        private void NewSplash_Load(object sender, EventArgs e)
        {
            if (The_Elite_Patcher.Properties.Settings.Default.rememberme == true)
            {
                textBox5.Text = The_Elite_Patcher.Properties.Settings.Default.user;
                textBox8.Text = The_Elite_Patcher.Properties.Settings.Default.pass;
                checkBox1.Checked = true;
            }
            groupPanel2.Visible = false;
            groupPanel1.Visible = false;
            int topy = this.ClientSize.Height - 120;
            int botx = this.ClientSize.Width - 236;
            groupPanel1.Location = new Point(botx, topy);
            groupPanel2.Left = (this.ClientSize.Width - groupPanel2.Width) / 2;
            groupPanel2.Top = (this.ClientSize.Height - groupPanel2.Height) / 2;
            groupPanel3.Left = (this.ClientSize.Width - groupPanel3.Width) / 2;
            groupPanel3.Top = (this.ClientSize.Height - groupPanel3.Height) / 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://adminspot.net");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://elite.so");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
                if (progressBar1.Value > 99)
                {
                    progressBar1.Text = "                Please Wait...";
                }
                else
                {
                    progressBar1.Text = "                Loading... " + progressBar1.Value.ToString() + "%...";
                }
            }
            else
            {
                timer1.Stop();
                Form1 home = new Form1();
                home.Show();
                this.Dispose(false);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string hash3 = NiCoding_Development_Library.Forum_Tools.Xenforo.login("crazy-coderz.com", textBox5.Text, textBox8.Text, true);
            if (hash3.Contains("hash"))
            {
                string str3 = hash3.Remove(0, 9);
                hash3 = str3.Substring(0, str3.Length - 2);
                if (checkBox1.Checked == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                }
                The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                The_Elite_Patcher.Properties.Settings.Default.hash = hash3;
                The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                The_Elite_Patcher.Properties.Settings.Default.isCCAcc = true;
                The_Elite_Patcher.Properties.Settings.Default.site = "crazy-coderz.com";
                The_Elite_Patcher.Properties.Settings.Default.Save();
                groupPanel1.Visible = true;
                groupPanel2.Visible = true;
                groupPanel3.Visible = false;
                timer1.Start();
            }
            else
            {
                string mdpass = textBox8.Text;
                mdpass = mdpass.Replace("#", "gigahash");
                if (NiCoding_Development_Library.Forum_Tools.IPB.login(textBox5.Text, mdpass) == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.isAsAcc = true;
                    The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                    groupPanel2.Visible = true;
                    groupPanel3.Visible = false;
                    groupPanel1.Visible = true;
                    timer1.Start();
                }
                else
                {
                    string hash2 = NiCoding_Development_Library.Forum_Tools.Xenforo.login("royalhood.net", textBox5.Text, textBox8.Text, false);
                    if (hash2.Contains("hash"))
                    {
                        string str3 = hash2.Remove(0, 9);
                        hash2 = str3.Substring(0, str3.Length - 2);
                        if (checkBox1.Checked == true)
                        {
                            The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                        }
                        The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                        The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                        The_Elite_Patcher.Properties.Settings.Default.hash = hash2;
                        The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                        The_Elite_Patcher.Properties.Settings.Default.isRhAcc = true;
                        The_Elite_Patcher.Properties.Settings.Default.site = "royalhood.net";
                        The_Elite_Patcher.Properties.Settings.Default.Save();
                        groupPanel1.Visible = true;
                        groupPanel2.Visible = true;
                        groupPanel3.Visible = false;
                        timer1.Start();
                    }
                    else
                    {
                        string hash = NiCoding_Development_Library.Forum_Tools.Xenforo.login("elite.so", textBox5.Text, textBox8.Text, true);
                        if (hash.Contains("hash"))
                        {
                            string str3 = hash.Remove(0, 9);
                            hash = str3.Substring(0, str3.Length - 2);
                            if (checkBox1.Checked == true)
                            {
                                The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                            }
                            The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                            The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                            The_Elite_Patcher.Properties.Settings.Default.hash = hash;
                            The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                            The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                            The_Elite_Patcher.Properties.Settings.Default.site = "elite.so";
                            The_Elite_Patcher.Properties.Settings.Default.Save();
                            if (!checkUser("crazy-coderz.com", textBox5.Text))
                            {
                                string reg = NiCoding_Development_Library.Forum_Tools.Xenforo.register("crazy-coderz.com", textBox5.Text, textBox8.Text, NiCoding_Development_Library.Forum_Tools.Xenforo.getUserEmail("elite.so", textBox5.Text));
                                if (reg == "Success!")
                                {
                                    MessageBox.Show("Hello " + textBox5.Text + "!" + Environment.NewLine + "As Elite.So has merged with Crazy-Coderz.com, your account has been converted! Please check your email for an activation link! Your elite.so account will be deactivated after you close The Elite Patch.");
                                }
                            }
                            groupPanel1.Visible = true;
                            groupPanel2.Visible = true;
                            groupPanel3.Visible = false;
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show(hash);
                        }
                    }
                }
            }
        }

        private bool checkUser(string site, string user)
        {
            string hash = NiCoding_Development_Library.Forum_Tools.Xenforo.login(site, textBox5.Text, textBox8.Text, true);
            if (!hash.Contains("hash"))
            {
                return false;
            }
            else if (hash.Contains("Bad Request"))
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://adminspot.net/index.php?app=core&module=global&section=register");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.crazy-coderz.com/register");
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button35_Click((object)sender, (EventArgs)e);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("http://crazy-coderz.com");
        }
        private const string AppId = "509817575770888";
        private const string ExtendedPermissions = "user_about_me,publish_stream,offline_access,email";
        private void button3_Click(object sender, EventArgs e)
        {
            // open the Facebook Login Dialog and ask for user permissions.
            var fbLoginDlg = new FacebookLoginDialog(AppId, ExtendedPermissions);
            fbLoginDlg.ShowDialog();

            // The user has taken action, either allowed/denied or cancelled the authorization,
            // which can be known by looking at the dialogs FacebookOAuthResult property.
            // Depending on the result take appropriate actions.
            TakeLoggedInAction(fbLoginDlg.FacebookOAuthResult);
        }
        private void TakeLoggedInAction(Facebook.FacebookOAuthResult facebookOAuthResult)
        {
            if (facebookOAuthResult == null)
            {
                // the user closed the FacebookLoginDialog, so do nothing.
                MessageBox.Show("Cancelled!");
                return;
            }

            // Even though facebookOAuthResult is not null, it could had been an 
            // OAuth 2.0 error, so make sure to check IsSuccess property always.
            if (facebookOAuthResult.IsSuccess)
            {
                // since our respone_type in FacebookLoginDialog was token,
                // we got the access_token
                // The user now has successfully granted permission to our app.
                // Let's ask them if they want to register for Crazy-Coderz!
                NiCoding_Development_Library.Forum_Tools.Xenforo.register("crazy-coderz.com", getFacebookUser(facebookOAuthResult.AccessToken), "pleasechangeme", getFacebookEmail(facebookOAuthResult.AccessToken));
                MessageBox.Show("Your account has been registered at Crazy-Coderz.com! Please keep the following info for your records." + Environment.NewLine + "Username: " + getFacebookUser(facebookOAuthResult.AccessToken) + Environment.NewLine + "Password: pleasechangeme" + Environment.NewLine + "Email: " + getFacebookEmail(facebookOAuthResult.AccessToken)+Environment.NewLine+"You can change your email/password at http://crazy-coderz.com/account");
                string hash3 = NiCoding_Development_Library.Forum_Tools.Xenforo.login("crazy-coderz.com", getFacebookUser(facebookOAuthResult.AccessToken), "pleasechangeme", true);
                if (!hash3.Contains("hash"))
                {
                    string str3 = hash3.Remove(0, 9);
                    hash3 = str3.Substring(0, str3.Length - 2);
                    if (checkBox1.Checked == true)
                    {
                        The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                    }
                    The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                    The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                    The_Elite_Patcher.Properties.Settings.Default.hash = hash3;
                    The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                    The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                    The_Elite_Patcher.Properties.Settings.Default.isCCAcc = true;
                    The_Elite_Patcher.Properties.Settings.Default.site = "crazy-coderz.com";
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                    groupPanel1.Visible = true;
                    groupPanel2.Visible = true;
                    groupPanel3.Visible = false;
                    timer1.Start();
                }
            }
            else
            {
                // for some reason we failed to get the access token.
                // most likely the user clicked don't allow.
                MessageBox.Show(facebookOAuthResult.ErrorDescription);
            }
        }
        private string getFacebookUser(string accessToken)
        {
            try
            {
                var fb = new FacebookClient(accessToken);
                // instead of casting to IDictionary<string,object> or IList<object>
                // you can also make use of the dynamic keyword.
                dynamic result = fb.Get("me");
                // You can either access it this way, using the .
                dynamic name = result.username;
                return name;
            }
            catch (FacebookApiException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        private string getFacebookEmail(string accessToken)
        {
            try
            {
                var fb = new FacebookClient(accessToken);
                // instead of casting to IDictionary<string,object> or IList<object>
                // you can also make use of the dynamic keyword.
                dynamic result = fb.Get("me");
                // You can either access it this way, using the .
                dynamic name = result.email;
                return name;
            }
            catch (FacebookApiException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        private void GetInfoAsync(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            // make sure to add the appropriate event handler
            // before calling the async methods.
            // GetCompleted     => GetAsync
            // PostCompleted    => PostAsync
            // DeleteCompleted  => DeleteAsync
            fb.GetCompleted += (o, e) =>
            {
                // incase you support cancellation, make sure to check
                // e.Cancelled property first even before checking (e.Error!=null).
                if (e.Cancelled)
                {
                    // for this example, we can ignore as we don't allow this
                    // example to be cancelled.

                    // you can check e.Error for reasons behind the cancellation.
                    var cancellationError = e.Error;
                }
                else if (e.Error != null)
                {
                    // error occurred
                    this.BeginInvoke(new MethodInvoker(
                                                 () =>
                                                 {
                                                     MessageBox.Show(e.Error.Message);
                                                 }));
                }
                else
                {
                    // the request was completed successfully

                    // now we can either cast it to IDictionary<string, object> or IList<object>
                    // depending on the type.
                    // For this example, we know that it is IDictionary<string,object>.
                    var result = (IDictionary<string, object>)e.GetResultData();

                    var firstName = (string)result["first_name"];
                    var lastName = (string)result["last_name"];

                    // since this is an async callback, make sure to be on the right thread
                    // when working with the UI.
                    this.BeginInvoke(new MethodInvoker(
                                         () =>
                                         {
                                             // lblFirstName.Text = "First Name: " + firstName;
                                         }));
                }
            };

            // additional parameters can be passed and 
            // must be assignable from IDictionary<string, object>
            var parameters = new Dictionary<string, object>();
            parameters["fields"] = "first_name,last_name";

            fb.GetAsync("me", parameters);
        }
        private void posttowall(string message, string accessToken)
        {
            /*var fb = new FacebookClient(accessToken);

            // make sure to add event handler for PostCompleted.
            fb.PostCompleted += (o, e) =>
            {
                // incase you support cancellation, make sure to check
                // e.Cancelled property first even before checking (e.Error!=null).
                if (e.Cancelled)
                {
                    // for this example, we can ignore as we don't allow this
                    // example to be cancelled.

                    // you can check e.Error for reasons behind the cancellation.
                    var cancellationError = e.Error;
                }
                else if (e.Error != null)
                {
                    // error occurred
                    this.BeginInvoke(new MethodInvoker(
                                                 () =>
                                                 {
                                                     MessageBox.Show(e.Error.Message);
                                                 }));
                }
            };

            dynamic parameters = new ExpandoObject();
            parameters.message = message;

            fb.PostAsync("me/feed", parameters);*/
        }
    }
}
