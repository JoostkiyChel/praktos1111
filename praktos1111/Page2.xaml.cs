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

namespace praktos1111
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        AddressesTableAdapter Addresses = new AddressesTableAdapter();
        public Page2()
        {
            InitializeComponent();
            datasetik.ItemsSource = Addresses.GetData();
            combo_datasetic.ItemsSource = Addresses.GetData();
            combo_datasetic.DisplayMemberPath = "City";
        }

        private void combo_datasetic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (combo_datasetic.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(cell.ToString());
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            Addresses.InsertQuery(Convert.ToInt32(Nametbx.Text), Convert.ToInt32(Nametbx2.Text), Nametbx3.Text, Nametbx4.Text, Nametbx5.Text);
            datasetik.ItemsSource = Addresses.GetData();
        }

        private void button_delete(object sender, RoutedEventArgs e)
        {
            object id = (datasetik.SelectedItem as DataRowView).Row[0];
            Addresses.DeleteQuery(Convert.ToInt32(id));
            datasetik.ItemsSource = Addresses.GetData();
        }

        private void button_change(object sender, RoutedEventArgs e)
        {
            object id = (datasetik.SelectedItem as DataRowView).Row[0];
                Addresses.UpdateQuery(Convert.ToInt32(Nametbx.Text), Convert.ToInt32(Nametbx2.Text), Nametbx3.Text, Nametbx4.Text, Nametbx5.Text, Convert.ToInt32(id));
            datasetik.ItemsSource = Addresses.GetData();
        }

        private void datasetik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datasetik.SelectedItem != null)
            {
                DataRowView row = datasetik.SelectedItem as DataRowView;
                if (row != null)
                {
                    Nametbx.Text = row.Row["AddressID"].ToString();
                    Nametbx2.Text = row.Row["UserId"].ToString();
                    Nametbx3.Text = row.Row["AddressLine"].ToString();
                    Nametbx4.Text = row.Row["City"].ToString();
                    Nametbx5.Text = row.Row["PostalCode"].ToString();
                }
            }
        }
    }
}
