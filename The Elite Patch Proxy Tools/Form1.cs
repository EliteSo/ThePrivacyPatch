using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace The_Elite_Patch_Proxy_Tools
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                The_Elite_Patch_Proxy_Tools.Properties.Settings.Default.subcheck = true;
                subdomain.Visible = true;
                label37.Visible = true;
            }
            else
            {
                The_Elite_Patch_Proxy_Tools.Properties.Settings.Default.subcheck = false;
                subdomain.Visible = false;
                label37.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupPanel3.Visible = true;
            groupPanel4.Visible = false;
            createConf(comboBox1.SelectedText, textBox1.Text);
        }

        private string createService(string loc, string nginxloc)
        {
            string file = loc+@"\nginx";
            File.AppendAllText(file, "#! /bin/sh" + Environment.NewLine +
            "ulimit -n 65535" + Environment.NewLine +
            "# Description: Startup script for nginx webserver on Debian. Place in /etc/init.d and" + Environment.NewLine +
            "# run 'sudo update-rc.d nginx defaults', or use the appropriate command on your" + Environment.NewLine +
            "# distro." + Environment.NewLine +
            "#" + Environment.NewLine +
            "#chkconfig: 2345 55 25" + Environment.NewLine +
            "#" + Environment.NewLine +
            "# Author:       Ryan Norbauer <ryan.norbauer@gmail.com>" + Environment.NewLine +
            "# Modified:     Geoffrey Grosenbach http://topfunky.com" + Environment.NewLine +
            "set -e" + Environment.NewLine +
            "PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin" + Environment.NewLine +
            "DESC=\"nginx daemon\"" + Environment.NewLine +
            "NAME=nginx" + Environment.NewLine +
            "DAEMON="+nginxloc+"$NAME" + Environment.NewLine +
            "CONFIGFILE="+nginxloc+"conf/nginx.conf" + Environment.NewLine +
            "PIDFILE="+nginxloc+"logs/$NAME.pid" + Environment.NewLine +
            "SCRIPTNAME=/etc/init.d/$NAME" + Environment.NewLine +
            "# Gracefully exit if the package has been removed." + Environment.NewLine +
            "test -x $DAEMON || exit 0" + Environment.NewLine +
            "d_start() {" + Environment.NewLine +
            "  $DAEMON -c $CONFIGFILE || echo -n \" already running\"" + Environment.NewLine +
            "}" + Environment.NewLine +
            "d_stop() {" + Environment.NewLine +
            "  kill -INT `cat $PIDFILE` || echo -n \" not running\"" + Environment.NewLine +
            "}" + Environment.NewLine +
            "waitforexit() {" + Environment.NewLine +
            " count=${2:-30}" + Environment.NewLine +
            " while [ 0$count -gt 0 ]" + Environment.NewLine +
            " do" + Environment.NewLine +
            "   PIDS=`ps -C$NAME --no-heading e | grep $DAEMON` || break" + Environment.NewLine +
            "   PIDS=`echo \"$PIDS\" | awk '{print $1}' | tr '\n' ' '`" + Environment.NewLine +
            "   echo Remaining processes: $PIDS" + Environment.NewLine +
            "   d_stop" + Environment.NewLine +
            "   sleep 2" + Environment.NewLine +
            "   count=`expr $count - 1`" + Environment.NewLine +
            " done" + Environment.NewLine +
            " if [ 0$count -eq 0 ];" + Environment.NewLine +
            " then" + Environment.NewLine +
            "   echo Remaining processes: $PIDS" + Environment.NewLine +
            "   return 1" + Environment.NewLine +
            " fi" + Environment.NewLine +
            " return 0" + Environment.NewLine +
            "}" + Environment.NewLine +
            "d_reload() {" + Environment.NewLine +
            "  kill -HUP `cat $PIDFILE` || echo -n \" can't reload\"" + Environment.NewLine +
            "}" + Environment.NewLine +
            "case \"$1\" in" + Environment.NewLine +
            "  start|startssl|sslstart|start-SSL)" + Environment.NewLine +
            "        echo -n \"Starting $DESC: $NAME\"" + Environment.NewLine +
            "        d_start" + Environment.NewLine +
            "        echo \".\"" + Environment.NewLine +
            "        ;;" + Environment.NewLine +
            "  stop)" + Environment.NewLine +
            "        echo -n \"Stopping $DESC: $NAME\"" + Environment.NewLine +
            "        d_stop" + Environment.NewLine +
            "        echo \".\"" + Environment.NewLine +
            "        ;;" + Environment.NewLine +
            "  graceful)" + Environment.NewLine +
            "        echo -n \"Reloading $DESC configuration...\"" + Environment.NewLine +
            "        d_reload" + Environment.NewLine +
            "        echo \"reloaded.\"" + Environment.NewLine +
            "  ;;" + Environment.NewLine +
            "  restart)" + Environment.NewLine +
            "        echo -n \"Restarting $DESC: $NAME\"" + Environment.NewLine +
            "	waitforexit \"nginx\" 20" + Environment.NewLine +
            "        d_start" + Environment.NewLine +
            "        echo \".\"" + Environment.NewLine +
            "        ;;" + Environment.NewLine +
            "  *)" + Environment.NewLine +
            "        echo \"Usage: $SCRIPTNAME {start|stop|restart|reload}\" >&2" + Environment.NewLine +
            "        exit 3" + Environment.NewLine +
            "        ;;" + Environment.NewLine +
            "esac" + Environment.NewLine +
            "exit 0" + Environment.NewLine);
            return "Success!";
        }
        private string createConf(string cores, string location)
        {
            string loctowin = location;
            loctowin = Directory.GetCurrentDirectory() +@"\Upload" + loctowin.Replace(@"/", @"\");
            The_Elite_Patch_Proxy_Tools.Properties.Settings.Default.folderloc = loctowin;
            string initd = Directory.GetCurrentDirectory() + @"\Upload\etc\init.d\";
            if (Directory.Exists(loctowin))
            {
                Directory.Delete(loctowin, true);
            }
            if (Directory.Exists(initd))
            {
                Directory.Delete(initd, true);
            }
            if (!Directory.Exists(initd))
            {
                Directory.CreateDirectory(initd);
            }
            if (!Directory.Exists(loctowin))
            {
                Directory.CreateDirectory(loctowin);
            }
            if (!Directory.Exists(loctowin + @"\vhosts"))
            {
                Directory.CreateDirectory(loctowin + @"\vhosts");
            }
            if (!Directory.Exists(loctowin + @"\logs"))
            {
                Directory.CreateDirectory(loctowin + @"\logs");
            }
            createService(initd, location);
            string fil = loctowin+@"\nginx.conf";
            File.AppendAllText(fil, "user  nobody;" + Environment.NewLine +
    "# no need for more workers in the proxy mode" + Environment.NewLine +
    "worker_processes  "+cores+";" + Environment.NewLine +
    "error_log "+location+"logs/error.log info;" + Environment.NewLine +
    "worker_rlimit_nofile 20480;" + Environment.NewLine +
    "events {" + Environment.NewLine +
    " worker_connections 5120; # increase for busier servers " + Environment.NewLine +
    " use epoll; # you should use epoll here for Linux kernels 2.6.x" + Environment.NewLine +
    "}" + Environment.NewLine +
    "http {" + Environment.NewLine +
    " server_name_in_redirect off;" + Environment.NewLine +
    " server_names_hash_max_size 10240;" + Environment.NewLine +
    " server_names_hash_bucket_size 1024;" + Environment.NewLine +
    " include    mime.types;" + Environment.NewLine +
    " default_type  application/octet-stream;" + Environment.NewLine +
    " server_tokens off;" + Environment.NewLine +
    "# remove/commentout disable_symlinks if_not_owner;if you get Permission denied error" + Environment.NewLine +
    "# disable_symlinks if_not_owner; " + Environment.NewLine +
    " sendfile on;" + Environment.NewLine +
    " tcp_nopush on;" + Environment.NewLine +
    " tcp_nodelay on;" + Environment.NewLine +
    " keepalive_timeout  5;" + Environment.NewLine +
    " gzip on;" + Environment.NewLine +
    " gzip_vary on;" + Environment.NewLine +
    " gzip_disable \"MSIE [1-6]\\.\";" + Environment.NewLine +
    " gzip_proxied any;" + Environment.NewLine +
    " gzip_http_version 1.1;" + Environment.NewLine +
    " gzip_min_length  1000;" + Environment.NewLine +
    " gzip_comp_level  6;" + Environment.NewLine +
    " gzip_buffers  16 8k;" + Environment.NewLine +
    "# You can remove image/png image/x-icon image/gif image/jpeg if you have slow CPU" + Environment.NewLine +
    " gzip_types    text/plain text/xml text/css application/x-javascript application/xml image/png image/x-icon image/gif image/jpeg application/xml+rss text/javascript application/atom+xml;" + Environment.NewLine +
    " ignore_invalid_headers on;" + Environment.NewLine +
    " client_header_timeout  3m;" + Environment.NewLine +
    " client_body_timeout 3m;" + Environment.NewLine +
    " send_timeout     3m;" + Environment.NewLine +
    " reset_timedout_connection on;" + Environment.NewLine +
    " connection_pool_size  256;" + Environment.NewLine +
    " client_header_buffer_size 256k;" + Environment.NewLine +
    " large_client_header_buffers 4 256k;" + Environment.NewLine +
    " client_max_body_size 200M; " + Environment.NewLine +
    " client_body_buffer_size 128k;" + Environment.NewLine +
    " request_pool_size  32k;" + Environment.NewLine +
    " output_buffers   4 32k;" + Environment.NewLine +
    " postpone_output  1460;" + Environment.NewLine +
    " proxy_temp_path  /tmp/nginx_proxy/;" + Environment.NewLine +
    " client_body_in_file_only on;" + Environment.NewLine +
    " log_format bytes_log \"$msec $bytes_sent .\";" + Environment.NewLine +
    " include \""+location+"conf/vhosts/*\";" + Environment.NewLine +
    "}");

            return "Success";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string location = The_Elite_Patch_Proxy_Tools.Properties.Settings.Default.folderloc;
            genVhost(site.Text, subdomain.Text, ip.Value.ToString(), The_Elite_Patch_Proxy_Tools.Properties.Settings.Default.subcheck, location);
            if (checkBox3.Checked == false)
            {
                groupPanel3.Visible = false;
                MessageBox.Show("Explorer will open after this message closes. Please upload the folder marked 'Upload' to your server's root drive. Then restart nginx. Feel free to submit your proxy to Elite.So for inclusion in The Elite Patch!", "Complete!");
                Process.Start(Directory.GetCurrentDirectory());
            }
            else
            {
                site.Text = "site.com";
                subdomain.Text = "sub.domain.com";
                ip.Value = "192.168.1.1";
                checkBox1.Checked = false;
            }
        }
        public static string genVhost(string site, string subdomain, string ip, bool isSub, string location)
        {
            site = site.Replace("www.", "");
            site = site.Replace("http://", "");
            subdomain = subdomain.Replace("http://", "");
            subdomain = subdomain.Replace("www.", "");
            string subSite = "";
            if (isSub == true)
            {
                subSite = location+@"\vhosts\"+subdomain;
            }
            else
            {
                subSite = location + @"\vhosts\" + site;
            }
            File.AppendAllText(subSite, "server {" + Environment.NewLine);
            File.AppendAllText(subSite, "listen " + ip + ":80;" + Environment.NewLine);
            if (isSub == true)
            {
                File.AppendAllText(subSite, "server_name " + subdomain + " www." + subdomain + " " + site + " www." + site + ";" + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(subSite, "server_name  " + site + " www." + site + ";" + Environment.NewLine);
            }
            File.AppendAllText(subSite, "location / {" + Environment.NewLine);
            File.AppendAllText(subSite, "proxy_pass             http://" + site + "/;" + Environment.NewLine);
            File.AppendAllText(subSite, "proxy_set_header       Host " + site + ";" + Environment.NewLine);
            File.AppendAllText(subSite, "}" + Environment.NewLine);
            File.AppendAllText(subSite, "}" + Environment.NewLine);
            return "Generated file: " + subSite;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (!String.IsNullOrEmpty(textBox4.Text))
                {
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        if (!String.IsNullOrEmpty(ipAddressInput1.Text))
                        {
                            if (!String.IsNullOrEmpty(textBox2.Text))
                            {
                                try
                                {
                                    var fromAddress = new MailAddress("proxies.elite.so@gmail.com", textBox4.Text);
                                    var toAddress = new MailAddress("harmfulmonk@gmail.com", "Gigawiz");
                                    string fromPassword = CryptorEngine.Decrypt("G4DGJpNcp7A2H0bXen+Ug37zi47ZX622FcFHHRwy7WjVcJTjN6Gm20xurTGMgnQXrrdgSM0BBll+GFYeZcB8fNzfwvNiqWIRkuXSc779Vgs/3U/MaCGKYnUswg2zP1DuMrR+ACogeKE=");
                                    string subject = "Elite.SO - Proxy Submission from -" + textBox4.Text;
                                    string body = "Submission from " + textBox4.Text + Environment.NewLine + "Proxy Site: " + textBox2.Text + Environment.NewLine + "Proxy IP: " + ipAddressInput1.Value + Environment.NewLine
                                        + "Bug Report Email: " + textBox3.Text + Environment.NewLine + "Extra Notes: " + textBox5.Text;

                                    var smtp = new SmtpClient
                                               {
                                                   Host = "smtp.gmail.com",
                                                   Port = 587,
                                                   EnableSsl = true,
                                                   DeliveryMethod = SmtpDeliveryMethod.Network,
                                                   UseDefaultCredentials = false,
                                                   Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                                               };
                                    using (var message = new MailMessage(fromAddress, toAddress)
                                                         {
                                                             Subject = subject,
                                                             Body = body
                                                         })
                                    {
                                        smtp.Send(message);
                                    }
                                    MessageBox.Show("Submitted Successfully!");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Submission Failed! Extended Error: " + ex.Message, "Submission Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("You didn't enter a proxy url!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("You didn't enter a proxy IP!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You didn't enter an email for bug reports!");
                    }
                }
                else
                {
                    MessageBox.Show("You didn't enter an internet handle!");
                }
            }
            else
            {
                MessageBox.Show("You must agree to the terms and conditions before submitting!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.elite.so/threads/eso-proxy-submission-terms-of-service.283/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.elite.so/threads/eso-proxy-submission-guidelines.282/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupPanel5.Visible = true;
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupPanel4.Visible = true;
            groupPanel5.Visible = false;
            if (radioButton1.Checked == true)
            {
                textBox1.Text = "/nginx/conf";
            }
            else
            {
                textBox1.Text = "/usr/local/nginx";
            }
        }
    }
}
