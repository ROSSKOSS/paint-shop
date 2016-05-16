using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : UserControl
    {
        private static string loginstr;
        private static string passwordstr;
        public AdminLogin()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Ubuntu Light");
            loginstr = null;
            passwordstr = null;
            login.Text = "admin";
           password.Password = "admin";
        }
        #region Login button actions
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void adminItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            adminRect.Fill = (Brush)bc.ConvertFrom("#021c1e");
        }

        private void adminItem_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            adminRect.Fill = (Brush)bc.ConvertFrom("#FF003030");
        }

        private void adminItem_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            adminRect.Fill = (Brush)bc.ConvertFrom("#FF2C7873");
        }

        private void adminItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            adminRect.Fill = (Brush)bc.ConvertFrom("#FF003030");
            // Getting login/pass. Coparison with 'admin'
            loginstr = login.Text;
            passwordstr = password.Password;
            if (loginstr == "admin" && passwordstr == "admin")
            {
                host.Children.Add(new AdminPage());
            }
        }
        #endregion
    }
}
