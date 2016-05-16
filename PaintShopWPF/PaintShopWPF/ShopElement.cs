using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Brush = System.Windows.Media.Brush;
using System.Windows.Shapes;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;
using Orientation = System.Windows.Controls.Orientation;
namespace PaintShopWPF
{
    class ShopElement : Grid
    {
        public string Header { get; }
        public string Brand { get; }
        public double Price { get; }
        public string Type { get; }
        public int Id { get; }
        protected readonly TextBlock _nameBlock;
        protected Image Image { get; set; } = new Image();
        //Position in array (if exists)
        protected readonly TextBlock _brandBlock;
        protected readonly TextBlock _priceBlock;
        protected readonly TextBlock _typeBlock;
        //protected readonly WrapPanel _host;
        //Displayer
        protected Rectangle r;
        public static BrushConverter Bc = new BrushConverter();
        public ShopElement(int id, string name, string brand, string type, double price, int i = 0, int j = 0, BitmapImage image = null)
        {
            //Setting defaul image (if there is no given one) 
            image = image ?? new BitmapImage(new Uri("pack://application:,,,/Icons/DefaultImage.png"));

            //Setting properties
            Image.Source = image;
            Header = name;
            Brand = brand;
            Price = price;
            Type = type;
            Id = id;
            #region  Grid Definition
            Height = 240;
            Width = 200;
            Background = (Brush)new BrushConverter().ConvertFrom("#FFDFFBF9");
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            if (i == 0)
            {
                if (j == 0)
                {
                    Margin = new Thickness(33, 20, 0, 10);
                }
                else
                {
                    Margin = new Thickness(33, 0, 0, 10);
                }
            }
            else
            {
                if (j == 0)
                {
                    Margin = new Thickness(33, 20, 0, 10);
                }
                else
                {
                    Margin = new Thickness(33, 20, 0, 10);
                }
            }
            MouseEnter += ElMouseEnter;
            MouseLeave += ElMouseLeave;
            MouseDown += ElMouseDown;
            MouseUp += ElMouseUp;
            #endregion
            #region Element Definition
            r = new Rectangle();
            r.Height = 240;
            r.Width = 200;
            r.Fill = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F");
            r.RadiusX = 10;
            r.RadiusY = 10;
            r.Margin = new Thickness(0, 0, 0, 0);
            Children.Add(r);
            #endregion
            #region InfoHost Definition
            StackPanel infoHost = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Background = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F"),
                Margin = new Thickness(4, 4, 4, 4)

            };
            infoHost.Background.Opacity = 0;
            Children.Add(infoHost);
            #endregion
            #region Type Definition
            _typeBlock = new TextBlock();
            _typeBlock.Height = double.NaN;
            _typeBlock.Width = double.NaN;
            _typeBlock.HorizontalAlignment = HorizontalAlignment.Left;
            _typeBlock.Margin = new Thickness(5, 5, 0, 5);
            _typeBlock.VerticalAlignment = VerticalAlignment.Center;
            _typeBlock.Text = Type;
            _typeBlock.FontFamily = MainWindow.GlobalFontFamily;
            _typeBlock.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF004445");
            _typeBlock.Background = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F");
            _typeBlock.Background.Opacity = 0;
            _typeBlock.FontSize = 12;
            infoHost.Children.Add(_typeBlock);
            #endregion
            #region Image Definition (all further elements will be added to infoHost)

            //Border br = new Border()
            //{
            //    Width = 100,
            //    Height = 100,
            //    Margin = new Thickness(0, 10, 0, 5),
            //    VerticalAlignment = VerticalAlignment.Top,
            //    BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F"),
            //    BorderThickness = new Thickness(0.1),
            //    CornerRadius = new CornerRadius(50)
            //};

            
            Image.Height = 100;
            Image.Width = 240;
            Image.Margin = new Thickness(0, 0, 0, 0);
            SetColumnSpan(Image, 1);
            SetRowSpan(Image, 1);
            Image.Clip = new EllipseGeometry() {Center = new Point(50, 50), RadiusX = 50, RadiusY = 50};
            Image.HorizontalAlignment = HorizontalAlignment.Center;
            infoHost.Children.Add(Image);
            #endregion
            #region Name label Definition
            _nameBlock = new TextBlock();
            _nameBlock.Height = 55;
            _nameBlock.Width = double.NaN;
            _nameBlock.HorizontalAlignment = HorizontalAlignment.Center;
            _nameBlock.VerticalAlignment = VerticalAlignment.Top;
            _nameBlock.TextWrapping = TextWrapping.WrapWithOverflow;
            _nameBlock.Text = Header;
            _nameBlock.Margin = new Thickness(10, 0, 10, 0);
            _nameBlock.FontFamily = MainWindow.GlobalFontFamily;
            _nameBlock.Foreground = (Brush)new BrushConverter().ConvertFrom("#021c1e");
            _nameBlock.Background = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F");
            _nameBlock.Background.Opacity = 0;
            _nameBlock.FontSize = 15;
            
            //_nameBlock.Effect = new DropShadowEffect()
            //{
            //    ShadowDepth = 1,
            //    BlurRadius = 0,
            //    Color = Colors.White,
            //    Direction = 330
            //};

            infoHost.Children.Add(_nameBlock);
            #endregion
            #region BrandBlock Definition


            _brandBlock = new TextBlock();
            _brandBlock.Height = double.NaN;
            _brandBlock.Width = double.NaN;
            _brandBlock.HorizontalAlignment = HorizontalAlignment.Center;
            _brandBlock.VerticalAlignment = VerticalAlignment.Bottom;
            _brandBlock.Text = Brand;
            _brandBlock.FontFamily = MainWindow.GlobalFontFamily;
            _brandBlock.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF004445");
            _brandBlock.Background = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F");
            _brandBlock.Background.Opacity = 0;
            _brandBlock.FontSize = 12;
            _priceBlock = new TextBlock();
            _priceBlock.Height = double.NaN;
            _priceBlock.Width = double.NaN;
            _priceBlock.HorizontalAlignment = HorizontalAlignment.Center;
            _priceBlock.VerticalAlignment = VerticalAlignment.Top;
            _priceBlock.Text = Convert.ToString(Price + " грн.");
            _priceBlock.Margin = new Thickness(0, 0, 0, 0);
            _priceBlock.FontFamily = MainWindow.GlobalFontFamily;
            _priceBlock.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF004445");
            _priceBlock.Background = (Brush)new BrushConverter().ConvertFrom("#FF6FB98F");
            _priceBlock.Background.Opacity = 0;
            _priceBlock.FontSize = 12;
            //brandBlock.Effect = new DropShadowEffect()
            //{
            //    ShadowDepth = 1,
            //    BlurRadius = 0,
            //    Color = Colors.White,
            //    Direction = 330
            //};
            infoHost.Children.Add(_brandBlock);
            infoHost.Children.Add(_priceBlock);


            #endregion
        }
        #region Actions
        protected void ElMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            r.Fill = (Brush)Bc.ConvertFrom("#2c7873");

        }
        protected void ElMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            r.Fill = (Brush)Bc.ConvertFrom("#6fb98f");
            _typeBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _brandBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _priceBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _nameBlock.Foreground = (Brush)Bc.ConvertFrom("#021c1e");

        }
        protected void ElMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            r.Fill = (Brush)Bc.ConvertFrom("#FF004445");
            _typeBlock.Foreground = (Brush)Bc.ConvertFrom("#FFDFFBF9");
            _brandBlock.Foreground = (Brush)Bc.ConvertFrom("#FFDFFBF9");
            _priceBlock.Foreground = (Brush)Bc.ConvertFrom("#FFDFFBF9");
            _nameBlock.Foreground = (Brush)Bc.ConvertFrom("#FFDFFBF9");
        }

        protected void ElMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _typeBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _brandBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _priceBlock.Foreground = (Brush)Bc.ConvertFrom("#FF004445");
            _nameBlock.Foreground = (Brush)Bc.ConvertFrom("#021c1e");
            r.Fill = (Brush)Bc.ConvertFrom("#2c7873");
            FrameworkElement parent = (FrameworkElement)((Grid)sender).Parent;
            string pathn = System.IO.Path.Combine(Environment.CurrentDirectory);
            string customerName = System.IO.File.ReadAllText(pathn + "\\LastCustomer.txt");

            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
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
            string query = $"INSERT into MyOrders (Product_name, Quantity, Cost, Customer_Name, Price, Brand,Type, UniqueNum) values('{Header}', '1', '228','{customerName}','{Price}','{Brand}','{Type}','{MainWindow.GlobalIterator++}')";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        #endregion
    }
}
