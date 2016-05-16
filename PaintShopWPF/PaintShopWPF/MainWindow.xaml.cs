using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        public static int GlobalIterator;
        private string _pathn;
        private BrushConverter _bc;
        public static FontFamily GlobalFontFamily;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalFontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Ubuntu Light");
            headLabel.FontFamily = GlobalFontFamily;
            mainLabel1.FontFamily = GlobalFontFamily;
            shopLabel.FontFamily = GlobalFontFamily;
            cartLabel.FontFamily = GlobalFontFamily;
            contactLabel.FontFamily = GlobalFontFamily;
            adminLabel.FontFamily = GlobalFontFamily;
            mainIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/HomeIcon.png"));
            shopIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/ShopIcon.png"));
            cartIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/CartIcon.png"));
            contactIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/HelpIcon.png"));
            adminIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/AdminIcon.png"));
            nameTextBox.TextAlignment = TextAlignment.Center;
            _pathn = System.IO.Path.Combine(Environment.CurrentDirectory);
            nameTextBox.Text = System.IO.File.ReadAllText(_pathn + "\\LastCustomer.txt");
            GlobalIterator = Convert.ToInt16(System.IO.File.ReadAllText(_pathn + "\\LastSession.txt"));
            Host.Children.Add(new ShopPage());
            _bc = new BrushConverter();


        }
        #region Moving form
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        #endregion
        #region Exit button actions
        private void Exit_Button_MouseEnter(object sender, MouseEventArgs e)
        {

            Exit_Button.Fill = (Brush)_bc.ConvertFrom("#dd2f2f");
        }

        private void Exit_Button_MouseLeave(object sender, MouseEventArgs e)
        {

            Exit_Button.Fill = (Brush)_bc.ConvertFrom("#004445");
        }

        private void Exit_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Exit_Button.Fill = (Brush)_bc.ConvertFrom("#021c1e");

        }

        private void Exit_Button_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Exit_Button.Fill = (Brush)_bc.ConvertFrom("#004445");
            System.IO.File.WriteAllText(_pathn + "\\LastSession.txt", Convert.ToString(GlobalIterator));
            Environment.Exit(0);
        }
        #endregion
        #region Main item actions
        private void mainItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            mainItem.Background = (Brush)_bc.ConvertFrom("#021c1e");
        }

        private void mainItem_MouseEnter(object sender, MouseEventArgs e)
        {

            mainItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
        }

        private void mainItem_MouseLeave(object sender, MouseEventArgs e)
        {

            mainItem.Background = (Brush)_bc.ConvertFrom("#6fb98f");
        }

        private void mainItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

            mainItem.Background = (Brush)_bc.ConvertFrom("#2c7873");

            Host.Children.Add(new MainPage());
        }
        #endregion
        #region Shop item actions
        private void shopItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            shopItem.Background = (Brush)_bc.ConvertFrom("#021c1e");
        }

        private void shopItem_MouseEnter(object sender, MouseEventArgs e)
        {

            shopItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
        }

        private void shopItem_MouseLeave(object sender, MouseEventArgs e)
        {

            shopItem.Background = (Brush)_bc.ConvertFrom("#6fb98f");
        }

        private void shopItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

            shopItem.Background = (Brush)_bc.ConvertFrom("#2c7873");



            Host.Children.Add(new ShopPage());
        }
        #endregion
        #region Cart item actions
        private void cartItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            cartItem.Background = (Brush)_bc.ConvertFrom("#021c1e");
        }

        private void cartItem_MouseEnter(object sender, MouseEventArgs e)
        {

            cartItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
        }

        private void cartItem_MouseLeave(object sender, MouseEventArgs e)
        {

            cartItem.Background = (Brush)_bc.ConvertFrom("#6fb98f");
        }

        private void cartItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

            cartItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
            Host.Children.Add(new CartPage());
        }
        #endregion
        #region Contact item actions
        private void contactItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            contactItem.Background = (Brush)_bc.ConvertFrom("#021c1e");
        }

        private void contactItem_MouseEnter(object sender, MouseEventArgs e)
        {

            contactItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
        }

        private void contactItem_MouseLeave(object sender, MouseEventArgs e)
        {

            contactItem.Background = (Brush)_bc.ConvertFrom("#6fb98f");
        }

        private void contactItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

            contactItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
            Host.Children.Add(new HelpPage());
        }
        #endregion
        #region Admin item actions
        private void adminItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            adminItem.Background = (Brush)_bc.ConvertFrom("#021c1e");
        }

        private void adminItem_MouseEnter(object sender, MouseEventArgs e)
        {

            adminItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
        }

        private void adminItem_MouseLeave(object sender, MouseEventArgs e)
        {

            adminItem.Background = (Brush)_bc.ConvertFrom("#6fb98f");
        }

        private void adminItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

            adminItem.Background = (Brush)_bc.ConvertFrom("#2c7873");
            Host.Children.Add(new AdminLogin());
        }
        #endregion


        #region Changing name
        private void nameTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                string customerName = System.IO.File.ReadAllText(_pathn + "\\LastCustomer.txt");
                if (customerName != nameTextBox.Text)
                {
                    //GlobalHost.Effect = new GrayscaleEffect.GrayscaleEffect() { DesaturationFactor = 0.9 };
                    Mwind.Effect = new BlurEffect() { Radius = 10 };
                    new Login().ShowDialog();
                    nameTextBox.Text=System.IO.File.ReadAllText(_pathn + "\\LastCustomer.txt");
                    //GlobalHost.Effect = new GrayscaleEffect.GrayscaleEffect() { DesaturationFactor = 0.001 };
                    Mwind.Effect = new BlurEffect() { Radius = 0 };

                    System.IO.File.WriteAllText(_pathn + "\\LastCustomer.txt", nameTextBox.Text);
                    string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
                    customerName = System.IO.File.ReadAllText(_pathn + "\\LastCustomer.txt");
                    System.IO.File.WriteAllText(_pathn + "\\LastSession.txt", Convert.ToString(0));
                    System.IO.File.ReadAllText(_pathn + "\\LastCustomer.txt");
                    GlobalIterator = Convert.ToInt16(System.IO.File.ReadAllText(_pathn + "\\LastSession.txt"));
                    String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                        "Persist Security Info = False;";
                    OleDbConnection conn = new OleDbConnection(connstring);
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Here");
                    }
                    string query = $"DELETE FROM MyOrders WHERE Customer_Name<>'{customerName}'";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    //OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    // adapter.SelectCommand = cmd;
                    conn.Close();
                }

            }
        }

        #endregion


    }
}
