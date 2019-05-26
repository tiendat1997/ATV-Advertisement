using ATV_Advertisement.Common.Auth;
using ATV_Advertisement.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisement.Common.Constants.Constants;

namespace ATV_Advertisement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = "";
            try
            {
                Session.Login(txtUsername.Text, txtPassword.Text);
                if (Session.IsLogin())
                {
                    role = Session.GetRole();

                    if (role == RoleConstants.ADMIN)
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (role == RoleConstants.STAFF)
                    {
                        AdvertisementForm advertisementForm = new AdvertisementForm();
                        advertisementForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
                        advertisementForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
