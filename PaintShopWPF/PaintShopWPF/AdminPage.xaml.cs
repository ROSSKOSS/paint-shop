using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.OleDb;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : UserControl
    {
        public AdminPage()
        {
            InitializeComponent();
            DBdisplayer.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Ubuntu Light");


        }

        private DataTable dt;
        private DataTable dt2;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";

            OleDbConnection conn = new OleDbConnection(connstring);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            OleDbCommand cmd = new OleDbCommand("SELECT*\n FROM PAINTS", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            DBdisplayer.DataContext = dt.DefaultView;
            OleDbCommand cmd2 = new OleDbCommand("SELECT*\n FROM Orders", conn);
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd);
            dt2 = new DataTable();
            adapter2.SelectCommand = cmd2;
            adapter2.Fill(dt2);
            Ordersdisplayer.DataContext = dt2.DefaultView;
        }
        #region Actions
        private void paintType_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush) bc.ConvertFrom("#021c1e");
        }

        private void paintType_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush) bc.ConvertFrom("#FF004445");
        }

        private void paintType_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush) bc.ConvertFrom("#FF2C7873");
        }

        private void paintType_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            paintType.Background = (Brush) bc.ConvertFrom("#FF004445");
            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";
            OleDbConnection conn = new OleDbConnection(connstring);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            OleDbCommand cmd = new OleDbCommand("DELETE * FROM PAINTS",conn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("SELECT * FROM PAINTS", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            dt = ((DataView)DBdisplayer.ItemsSource).ToTable();
            OleDbCommandBuilder ocmd = new OleDbCommandBuilder(adapter);
            adapter.UpdateCommand = ocmd.GetUpdateCommand();
            adapter.Update(dt);

            OleDbCommand cmd2 = new OleDbCommand("DELETE * FROM Orders",conn);
            cmd2.ExecuteNonQuery();

            cmd2 = new OleDbCommand("SELECT * FROM Orders", conn);
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd2);
            dt2 = ((DataView)Ordersdisplayer.ItemsSource).ToTable();
            
            OleDbCommandBuilder ocmd2 = new OleDbCommandBuilder(adapter2);
            adapter2.UpdateCommand = ocmd2.GetUpdateCommand();
            adapter2.Update(dt2);
            DBdisplayer.DataContext = dt.DefaultView;
            Ordersdisplayer.DataContext = dt2.DefaultView;
        }

        #endregion
    }
}
