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
    public partial class AdminForm : MaterialSkin.Controls.MaterialForm
    {
        public AdminForm()
        {
            if (!Session.CheckAuthorize(RoleConstants.ADMIN))
            {
                Utils.ShowMessage(CommonMessages.UNAUTHORIZED);
            }
            InitializeComponent();
            adminMenu.Items.Add("Hello", null, menuItem_Click);
        }

        public void menuItem_Click(object sender, EventArgs e)
        {
            string formName = "";
            if (sender is MenuItem)
            {
                var menuItem = sender as MenuItem;
                if (menuItem.Name != null)
                {
                    formName = menuItem.Text;
                    MessageBox.Show(formName);
                }
            }
        }
    }
}
