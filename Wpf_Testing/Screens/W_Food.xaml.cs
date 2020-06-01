using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Wpf_OrganizeAparty
{
    /// <summary>
    /// Interaction logic for W_Food.xaml
    /// </summary>
    public partial class W_Food : Window
    {
        public W_Food()
        {
            InitializeComponent();
        }
        private void Btn_Decor_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Decorations();
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }
        private void Btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }
        private void ShowHideMenu(string storyboardhide, Button myButton, Button myButton2, StackPanel pnl)
        {
            Storyboard sb = Resources[storyboardhide] as Storyboard;
            sb.Begin(pnl);

            if (storyboardhide.Contains("Show"))
            {
                myButton.Visibility = System.Windows.Visibility.Visible;
                myButton2.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (storyboardhide.Contains("Hide"))
            {
                myButton.Visibility = System.Windows.Visibility.Hidden;
                myButton2.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_Foods.ItemsSource = App._foods;
        }

        private void Tbx_filterfood_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._foods where s.foodName.ToLower().Contains(filter) select s;
            Lbx_Foods.ItemsSource = lst;
        }

        private void Btn_AddFood_Click(object sender, RoutedEventArgs e)
        {
            Food fd = new Food { foodName = "Edit.." };
            App._foods.Add(fd);
            Lbx_Foods.SelectedItem = fd;
            Lbx_Foods.ScrollIntoView(fd);
        }

        private void Btn_DeleteFood_Click(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Foods.SelectedItem;

            if (itm == null)
            {
                MessageBox.Show("Please select an item to be deleted first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var toDelete = itm as Food;
            var res = MessageBox.Show($"Are you sure to delete {toDelete.foodName}?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._foods.Remove(toDelete);
        }
    }
}
