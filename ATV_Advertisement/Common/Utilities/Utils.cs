using ATV_Advertisement.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisement.Common.Constants.Constants;

namespace ATV_Advertisement.Common.Utilities
{
    public static class Utils
    {
        public static Hashtable OpenedForms = new Hashtable();
        public static Hashtable MenuItemNames = new Hashtable();

        public static void ShowMessage(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static Form OpenFormByName(string formName)
        {
            Form form = null;

            if (!string.IsNullOrWhiteSpace(formName))
            {
                formName = formName.Trim();

                //Check if form is opened
                if (OpenedForms.Contains(formName))
                {
                    form = (Form)OpenedForms[formName];
                    form.Dispose();
                    if (form.IsDisposed)
                    {
                        OpenedForms.Remove(formName);
                        form = null;
                    }
                }

                switch (formName)
                {
                    case "Advertisement":
                        AdvertisementForm advertisementForm = new AdvertisementForm();
                        form = (Form)advertisementForm;
                        break;
                    case "Exit":
                        Application.Exit();
                        break;

                }

                if (form != null)
                {
                    form.Owner = MainForm.ActiveForm;
                    form.MdiParent = MainForm.ActiveForm;
                    form.ShowInTaskbar = true;
                    form.BringToFront();
                    form.TopMost = true;
                    form.MinimizeBox = true;
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.CenterScreen;

                    form.Show();

                    if (!OpenedForms.Contains(formName))
                    {
                        OpenedForms.Add(formName, form);
                    }
                }
            }
            return form;
        }
    }
}
