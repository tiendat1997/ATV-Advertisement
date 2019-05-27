using ATV_Advertisement.Common.Auth;
using ATV_Advertisement.Common.Utilities;
using DataService.Services;
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
                LoadMainMenu();
            }
            catch (Exception e)
            {
                Utils.ShowError(e.Message);
            }
        }

        private void LoadMainMenu()
        {
            MenuItemService menuItemService = null;
            MenuItem menuItem = null;
            MenuItem menuItemParent = null;
            MenuItem menuItemChild = null;
            List<DataService.Model.MenuItem> listMenuItems = null;
            List<MenuItem> formMenu = null;
            List<MenuItem> sortedMenu = null;

            try
            {
                menuItemService = new MenuItemService();
                listMenuItems = menuItemService.GetAllByRole(Session.GetRole());
                formMenu = new List<MenuItem>();
                sortedMenu = new List<MenuItem>();

                foreach (var mi in listMenuItems)
                {
                    if(mi.Level == 0)
                    {
                        menuItem = new MenuItem(mi.Name);
                    } else
                    {
                        menuItem = new MenuItem(mi.Name, menuItem_Click);
                    }
                    formMenu.Add(menuItem);

                    //Loads to constaint
                    Utils.MenuItemNames.Add(mi.Name, mi.Name);
                }

                foreach (var mi in listMenuItems)
                {
                    if(mi.Level != 0)
                    {
                        menuItemParent = formMenu.Where(f => f.Text == mi.ParentName).FirstOrDefault();
                        menuItemChild = formMenu.Where(f => f.Text == mi.Name).FirstOrDefault();
                        menuItemParent.MenuItems.Add(menuItemChild);
                    }
                }

                foreach (var mi in listMenuItems)
                {
                    if(mi.Level == 0)
                    {
                        sortedMenu.Add(formMenu.Where(f => f.Text == mi.Name).FirstOrDefault());
                    }
                }

                foreach (var item in sortedMenu)
                {
                    CreateMenuItems(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                menuItemService = null;
                menuItem = null;
                listMenuItems = null;
                formMenu = null;
                sortedMenu = null;
            }
        }

        public void CreateMenuItems(MenuItem menuItem)
        {
            this.mainMenu.MenuItems.Add(menuItem);
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
                    Utils.OpenFormByName(formName);
                }
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

        public void MinimizeAllChildForms(Form parent)
        {
            foreach (Form f in parent.OwnedForms)
            {
                f.WindowState = FormWindowState.Minimized;
                MinimizeAllChildForms(f);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                MinimizeAllChildForms(this);
            }
        }
    }
}
