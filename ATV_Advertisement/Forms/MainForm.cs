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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                if (!Login())
                {
                    this.Close();
                    return;
                }
            }
            catch (Exception e)
            {
                Utils.ShowError(e.Message);
            }
        }

        private bool Login()
        {
            LoginForm loginForm = null;
            bool result = false;

            try
            {
                loginForm = new LoginForm();

                if (Session.IsLogin())
                {
                    Utils.ShowMessage(CommonMessages.APPLICATION_IS_RUNNING);
                    result = false;
                }
                else
                {
                    loginForm.ShowDialog();
                    if (Session.IsLogin())
                    {
                        result = true;
                    }
                    loginForm.Close();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loginForm = null;
            }
        }
    }
}
