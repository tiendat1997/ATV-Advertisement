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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            if (!Session.CheckAuthorize(RoleConstants.ADMIN))
            {
                Utils.ShowMessage(CommonMessages.UNAUTHORIZED);
            }
            InitializeComponent();
        }
    }
}
