using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : UserControl
    {
        public static TextBlock priceL=new TextBlock();
        public CartPage()
        {
            GC.Collect();
            InitializeComponent();
            FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Ubuntu Light");
        }

        public static double price = 0;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            price = 0;
            textBlock1.TextAlignment = TextAlignment.Center;
            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";
            OleDbConnection conn = new OleDbConnection(connstring);
            try
            {
                conn.Open();
            }
            catch (Exception )
            {
                MessageBox.Show("Here");
            }
            string query = "Select* FROM MyOrders";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DependencyPropertyDescriptor dp = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            dp.AddValueChanged(priceL, (object a, EventArgs b) =>
            {
                priceLabel.Text = Convert.ToString($"Стоимость заказа: {price} грн.");
            });
                adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int j = 0;
            int iterator = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (j >= 3)
                {
                    j = 0;
                }
                price += (double)dt.Rows[i][5];
                CartElementsHost.Children.Add(new CartElement((int)dt.Rows[i][8], (string)dt.Rows[i][1], (string)dt.Rows[i][6], (string)dt.Rows[i][7], (double)dt.Rows[i][5],CartElementsHost, i, j));
                j++;
                iterator++;
            }
            conn.Close();
            priceLabel.Text = $"Стоимость заказа: {price} грн";
        }

        #region paintType Actions
        private void paintType_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush)bc.ConvertFrom("#021c1e");
        }

        private void paintType_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush)bc.ConvertFrom("#FF004445");
        }

        private void paintType_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush)bc.ConvertFrom("#FF2C7873");
        }

        private void paintType_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush)bc.ConvertFrom("#FF004445");

            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";
            OleDbConnection conn = new OleDbConnection(connstring);
            try
            {
                conn.Open();
            }
            catch (Exception )
            {
                MessageBox.Show("Here");
            }
            string query = "Select* FROM MyOrders";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            OleDbConnection conn2 = new OleDbConnection(connstring);

            try
            {
                conn2.Open();
            }
            catch (Exception )
            {

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                query = $"INSERT into Orders (Product_name, Customer_Name, Cost, Brand_name) values('{dt.Rows[i][1]}','{dt.Rows[i][4]}','{dt.Rows[i][5]}','{dt.Rows[i][6]}')";
                OleDbCommand cmd2 = new OleDbCommand(query, conn2);
                cmd2.ExecuteNonQuery();

            }
            conn2.Close();
            CartElementsHost.Children.Clear();
            String connstring3 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";
            OleDbConnection conn3 = new OleDbConnection(connstring3);
            try
            {
                conn3.Open();
            }
            catch (Exception )
            {
                MessageBox.Show("Here");
            }
            string query3 = "DELETE* FROM MyOrders";
            OleDbCommand cmd3 = new OleDbCommand(query3, conn3);
            cmd3.ExecuteNonQuery();
            conn3.Close();
        }
        #endregion
    }
}
