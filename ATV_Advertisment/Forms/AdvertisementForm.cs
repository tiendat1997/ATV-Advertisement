using ATV_Advertisment.Controllers;
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

namespace ATV_Advertisment.Forms
{
    public partial class AdvertisementForm : Form
    {
        private AdvertisementController _advertisementController;
        public AdvertisementForm()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            _advertisementController = new AdvertisementController();
            Advertisment advertisment = _advertisementController.GetById(1);
            string strContent = advertisment.Code + " " + advertisment.DurationMinute + " " + advertisment.Price;
            MessageBox.Show(strContent);
        }
    }
}
