using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintShopWPF
{
    internal class DropOption : Grid
    {
        private TextBlock temp;
        private TextBlock temp2;
        private string _name;
                     
        private DependencyPropertyDescriptor dp;
        private DependencyPropertyDescriptor dpr;
        public DropOption(string name, string role, ShopPage host)
        {
           
            //Definition and property filling
            Width = 160;
            Height = 45;
            Background = (Brush)new BrushConverter().ConvertFrom("#FF2C7873");
            _name = name;

            //Label
            TextBlock optionName = new TextBlock();
            optionName.Height = Double.NaN;
            optionName.Width = Double.NaN;
            optionName.Text = name;
            optionName.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFDFFBF9");
            optionName.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            optionName.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            optionName.TextWrapping = TextWrapping.Wrap;
            optionName.FontSize = 13;
            Children.Add(optionName);

            //Kostyli (The Beginning) Cloud be solved by redefining EventHandlers
            temp = new TextBlock();
            temp2 = new TextBlock();

            //Mouse events definition
            MouseEnter += new System.Windows.Input.MouseEventHandler(ElMouseEnter);
            MouseLeave += new System.Windows.Input.MouseEventHandler(ElMouseLeave);
            MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(ElMouseDown);
            MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(ElMouseUp);
            MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(ElRightMouseDown);
            MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(ElRightMouseUp);

            //TextBlocks property changed capturers definiton
            dp = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            dpr = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            #region Right mouse button click (textblock property changed)
            //Right mouse button specific click
            dpr.AddValueChanged(temp2, (object a, EventArgs b) =>
            {
                

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
                if (role == "brand")
                {
                    host.FillShop(conn, host.baseQuery, "brand", temp2.Text);
                    host.brandOptions.Visibility = Visibility.Hidden;
                    host.clicked2 = false;
                }
                else
                {
                    host.FillShop(conn, host.baseQuery, "type", temp2.Text);
                    host.paintOptions.Visibility = Visibility.Hidden;
                    host.clicked1 = false;
                }
            });
            #endregion
            #region Left mouse button click (textblock property changed)
            //Left mouse button specific click
            dp.AddValueChanged(temp, (object a, EventArgs b) =>
        {
            string query;

            string path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "DBs");
            String connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + "\\PaintsCatalog.accdb;" +
                                "Persist Security Info = False;";
            if (name == "Все")
            {
                query = "SELECT*\n FROM PAINTS";
                OleDbConnection conn = new OleDbConnection(connstring);
                try
                {
                    conn.Open();
                }
                catch (Exception )
                {
                    MessageBox.Show("Here");
                }
                host.brandOptions.Visibility = Visibility.Hidden;
                host.clicked2 = false;
                host.FillShop(conn, query);
            }
            else
            {
                if (role == "brand")
                {
                    query = "SELECT*  FROM PAINTS  WHERE (Brand =\"" + temp.Text + "\")";
                    host.brandOptions.Visibility = Visibility.Hidden;
                    host.clicked2 = false;
                }
                else
                {

                    query = "SELECT* FROM PAINTS WHERE (Type =\"" + temp.Text + "\")";
                    host.paintOptions.Visibility = Visibility.Hidden;
                    host.clicked1 = false;
                }

                OleDbConnection conn = new OleDbConnection(connstring);
                try
                {
                    conn.Open();
                }
                catch (Exception )
                {
                    MessageBox.Show("Here");
                }
                host.FillShop(conn, query);
            }

        });
            #endregion
        }
        #region Actions
        private void ElMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#FF004445");

        }
        private void ElMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#FF2C7873");

        }
        private void ElMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#021c1e");
        }

        private void ElMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#FF004445");
           
            temp.Text = null;
            temp.Text = _name;


        }
        private void ElRightMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#021c1e");
        }

        private void ElRightMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            temp2.Text = null;
            temp2.Text = _name;
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#FF004445");
           
        }
        #endregion

    }
}
