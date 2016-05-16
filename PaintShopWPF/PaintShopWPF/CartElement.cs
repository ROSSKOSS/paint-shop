using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintShopWPF
{
    class CartElement : ShopElement
    {
        public int Quantity { get; set; }
        public CartElement(int id, string name, string brand, string type, double price, WrapPanel host, int quantity, int i = 0, int j = 0, BitmapImage image = null) : base(id, name, brand, type, price, i, j, image)
        {
            Quantity = quantity;
            MouseUp += (sender, e) => { ElMouseUp(sender, e, Price, host); };
        }

        protected void ElMouseUp(object sender, System.Windows.Input.MouseEventArgs e, double price, WrapPanel host)
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
            string query = $"DELETE FROM MyOrders WHERE UniqueNum={Id}";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            CartPage.price -= price;
            CartPage.priceL.Text = Convert.ToString(CartPage.price);
            host.Children.Remove(this);
        }
    }
}
