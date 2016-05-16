using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        #region Exit button actions
        private void Exit_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Exit_Button.Fill = (Brush)bc.ConvertFrom("#dd2f2f");
        }

        private void Exit_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Exit_Button.Fill = (Brush)bc.ConvertFrom("#004445");
        }

        private void Exit_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            Exit_Button.Fill = (Brush)bc.ConvertFrom("#021c1e");

        }

        private void Exit_Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            Exit_Button.Fill = (Brush)bc.ConvertFrom("#004445");

            this.Close();
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
            string _pathn = System.IO.Path.Combine(Environment.CurrentDirectory);
            System.IO.File.WriteAllText(_pathn + "\\LastCustomer.txt", name.Text);
            Close();
        }
        #endregion

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
