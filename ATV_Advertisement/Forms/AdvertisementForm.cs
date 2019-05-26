using ATV_Advertisement.Controllers;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisement.Forms
{
    public partial class AdvertisementForm : Form
    {
        private AdvertisementController _advertisementController;

        public AdvertisementForm()
        {
            InitializeComponent();
        }

        private void btnGetAds1_Click(object sender, EventArgs e)
        {
            try
            {
                _advertisementController = new AdvertisementController();
                Advertisement advertisment = _advertisementController.GetById(1);
                string strContent = advertisment.Code + " " + advertisment.Price + " " + advertisment.DurationMinute;

                MessageBox.Show(strContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _advertisementController = null;
            }
        }
    }
}
