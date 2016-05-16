using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.IO;

namespace PaintShopWPF
{
    /// <summary>
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : UserControl
    {
        public bool clicked1, clicked2;
        private DataTable res;
        public string baseQuery;
        private System.Windows.Forms.Timer tim;
        private List<BitmapImage> imlist;
        private DataTable timDT;
        private int j = 0;
        private int iterator = 0;
        private int i = 0;
        private Random r;
        public ShopPage()
        {
            InitializeComponent();
            FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Ubuntu Light");
            GC.Collect();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tim = new System.Windows.Forms.Timer();
            tim.Interval = 20;
            tim.Tick += LoadElements;
            r = new Random();
            imlist = new List<BitmapImage>();
            int count = 0;
            foreach (string filename in Directory.GetFiles(System.IO.Path.Combine(Environment.CurrentDirectory, "Paints")))
            {
                try
                {
                    imlist.Insert(count, new BitmapImage(new Uri($"{filename}", UriKind.Absolute)));
                }
                catch(Exception)
                {
                    
                    
                }

                count++;
            }

            //Location DB
            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");

            //Defining connection string 
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";

            //Creating connection and trying to Open()
            OleDbConnection conn = new OleDbConnection(connstring);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Default query
            string query = "SELECT*\n FROM PAINTS";
            baseQuery = query;

            //Default call
            FillShop(conn, query);

            //Hiding first/second Option list when second/first is clicked
            clicked1 = false;
            clicked2 = false;
            #region Dynamically filling the paintOptions
            bool same = false;
            int t = 0;
            string[] types = new string[20];
            for (int i = 0; i < res.Rows.Count; i++)
            {
                same = false;
                foreach (var type in types)
                {
                    if (type == Convert.ToString(res.Rows[i][1]))
                    {
                        same = true;
                    }
                }
                if (same == false)
                {
                    types[t] = Convert.ToString(res.Rows[i][1]);
                    t++;
                }
            }
            //Creationg DropOption for each paint type in DB
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] != null)
                {
                    paintOptions.Children.Add(new DropOption(types[i], "type", this));
                }
            }
            #endregion
            #region Dynamically filling the brandOptions
            same = false; //flag
            t = 0; //sub iterator
            string[] brands = new string[20]; //maximum number of brands is 20
            for (int i = 0; i < res.Rows.Count; i++)
            {
                same = false;
                foreach (var brand in brands)
                {
                    if (brand == Convert.ToString(res.Rows[i][2]))
                    {
                        same = true;
                    }
                }
                if (same == false)
                {
                    brands[t] = Convert.ToString(res.Rows[i][2]);
                    t++;
                }
            }
            //Creating DropOptions for each brand in DB
            for (int i = 0; i < brands.Length; i++)
            {
                if (brands[i] != null)
                {
                    brandOptions.Children.Add(new DropOption(brands[i], "brand", this));
                }
            }

            //Showing all paints
            brandOptions.Children.Add(new DropOption("Все", "brand", this));
            #endregion
        }
        private DataTable Run_Query(string query, OleDbConnection conn)
        {
            DataTable dt = new DataTable();
            try
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public void FillShop(OleDbConnection conn, string query, string role = null, string filter = null)
        {
            baseQuery = query;
            //elementsHost.Children.Clear();
            elementsHost.Children.Clear();

            res = Run_Query(query, conn);
            ShopElement[][] shel = new ShopElement[res.Rows.Count][];
            #region Default call condition "if (role == null && filter == null)"
            if (role == null && filter == null)
            {
                j = 0;
                iterator = 0;
                i = 0;
                timDT = res;
                tim.Start();
            }
            #endregion
            #region if (role == "brand" && filter != null)
            if (role == "brand" && filter != null)
            {
                for (int i = 0; i < res.Rows.Count; i++)
                {
                    shel[i] = new ShopElement[3];
                }
                j = 0;

                iterator = 0;
                for (int i = 0; i < res.Rows.Count; i++)
                {
                    if ((string)res.Rows[i][2] == filter)
                    {
                        if (j == 3)
                        {
                            j = 0;
                        }


                        elementsHost.Children.Add(new ShopElement(iterator, Convert.ToString(res.Rows[i][3]),
                    Convert.ToString(res.Rows[i][2]), Convert.ToString(res.Rows[i][1]), Convert.ToDouble(res.Rows[i][4]),
                     i, j));
                        j++;
                        iterator++;
                    }

                }
            }
            #endregion
            #region if (role == "type" && filter != null)
            if (role == "type" && filter != null)
            {
                j = 0;

                iterator = 0;

                for (int i = 0; i < res.Rows.Count; i++)
                {
                    if ((string)res.Rows[i][1] == filter)
                    {
                        if (j == 3)
                        {
                            j = 0;
                        }
                        //iterator = 0;
                        elementsHost.Children.Add(new ShopElement(iterator, Convert.ToString(res.Rows[i][3]),
                    Convert.ToString(res.Rows[i][2]), Convert.ToString(res.Rows[i][1]), Convert.ToDouble(res.Rows[i][4]),
                    i, j));
                        // timDT.Rows[0]=res.Rows[];
                        //tim.Start();
                        j++;
                        iterator++;
                    }

                }
            }
            #endregion
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
            if (!clicked1)
            {
                paintOptions.Visibility = Visibility.Visible;
                clicked1 = true;
                clicked2 = false;
                brandOptions.Visibility = Visibility.Hidden;
            }
            else
            {
                paintOptions.Visibility = Visibility.Hidden;
                clicked1 = false;
            }

        }
        #endregion
        #region brandType Actions
        private void brandType_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            brandType.Background = (Brush)bc.ConvertFrom("#021c1e");
        }

        private void brandType_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            brandType.Background = (Brush)bc.ConvertFrom("#FF004445");
        }

        private void brandType_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            brandType.Background = (Brush)bc.ConvertFrom("#FF2C7873");
        }



        private void brandType_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            brandType.Background = (Brush)bc.ConvertFrom("#FF004445");
            if (!clicked2)
            {
                brandOptions.Visibility = Visibility.Visible;
                clicked2 = true;
                clicked1 = false;
                paintOptions.Visibility = Visibility.Hidden;
            }
            else
            {
                brandOptions.Visibility = Visibility.Hidden;
                clicked2 = false;
            }
        }

        #endregion

        private void LoadElements(object sender, EventArgs e)
        {

            
            if (i < timDT.Rows.Count)
            {
                if (j >= 3)
                {
                    j = 0;
                }

                elementsHost.Children.Add(new ShopElement(iterator, Convert.ToString(timDT.Rows[i][3]),
                    Convert.ToString(timDT.Rows[i][2]), Convert.ToString(timDT.Rows[i][1]), Convert.ToDouble(timDT.Rows[i][4]),
                     i, j, imlist[r.Next(0, imlist.Count)]));
                j++;
                i++;
                iterator++;
            }

            if (i == timDT.Rows.Count - 1)
            {
                j = 0;
                iterator = 0;
                i = 0;
                tim.Stop();
            }


        }

    }

}


