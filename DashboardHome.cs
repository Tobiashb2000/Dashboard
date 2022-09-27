using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Net.Mail;

namespace Login_and_Register_system
{
    public partial class DashboardHome : Form  
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
         int nLeftRect,
         int nTopRect,
         int nRightRect,
         int nBottomRect,
         int nWidthEllipse,
         int nHeightEllipse
       );


        public DashboardHome()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if (txtmail.Text == "  Email")
            {
                txtmail.Clear();
                txtmail.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            if (txtmail.Text == "")
            {
                txtmail.ForeColor = Color.FromArgb(200, 200, 200);
                txtmail.Text = "  Email";
            }
        }

        private void txtmess_Enter(object sender, EventArgs e)
        {
            if (txtmess.Text == "  Message")
            {
                txtmess.Clear();
                txtmess.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtmess_Leave(object sender, EventArgs e)
        {
            if (txtmess.Text == "")
            {
                txtmess.ForeColor = Color.FromArgb(200, 200, 200);
                txtmess.Text = "  Message";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmail.Text == "" || txtmail.Text == "  Email")
            {
                MessageBox.Show("please enter Email", "Send fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                string to, from, pass, messageBody;
                MailMessage message = new MailMessage();
                to = txtmail.Text;
                from = "fguitservice@gmail.com";
                pass = "gpcykqigsunfbrxj";
                messageBody = txtmess.Text;
                message.To.Add(to);
                message.From = new MailAddress(from);

                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                try
                {
                    smtp.Send(message);
                    DialogResult code = MessageBox.Show("Email Sent Successfully", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (code == DialogResult.OK)
                    {
                        txtmail.Clear();

                        txtmess.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      
        
    }
}
