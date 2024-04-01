using praktos1111.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
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
using praktos1111.DataSet1TableAdapters;

namespace praktos1111
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        UsersTableAdapter users = new UsersTableAdapter();
        public Page1()
        {
            InitializeComponent();
            datasetik.ItemsSource = users.GetData();
            combo_datasetic.ItemsSource = users.GetData();
            combo_datasetic.DisplayMemberPath = "UserName";
        }

        

        private void combo_datasetic_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            object cell = (combo_datasetic.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(cell.ToString());
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(Convert.ToInt32(Nametbx.Text), Nametbx2.Text, Nametbx3.Text);
            datasetik.ItemsSource = users.GetData();

        }

        private void Button_delete(object sender, RoutedEventArgs e)
        {
            object id = (datasetik.SelectedItem as DataRowView).Row[0];
            users.DeleteQuery(Convert.ToInt32(id));
            datasetik.ItemsSource = users.GetData();
        }

        private void Button_cahnge(object sender, RoutedEventArgs e)
        {
            object id = (datasetik.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(Convert.ToInt32(Nametbx.Text), Nametbx2.Text, Nametbx3.Text, Convert.ToInt32(id));
            datasetik.ItemsSource = users.GetData();    
        }

        private void datasetik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datasetik.SelectedItem != null)
            {
                DataRowView row = datasetik.SelectedItem as DataRowView;
                if (row != null)
                {
                    Nametbx.Text = row.Row["UserID"].ToString();
                    Nametbx2.Text = row.Row["UserName"].ToString();
                    Nametbx3.Text = row.Row["Email"].ToString();
                    
                }
            }
        }
    }
}
