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
    /// Interaction logic for W_Decorations.xaml
    /// </summary>
    public partial class W_Decorations : Window
    {
        public W_Decorations()
        {
            InitializeComponent();
        }
        private void Btn_food_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Food();
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
            Lbx_Decor.ItemsSource = App._decorations;

        }

        private void Tbx_filterDecor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._decorations where s.decorationName.ToLower().Contains(filter) select s;
            Lbx_Decor.ItemsSource = lst;
        }

        private void Btn_AddDecor_Click(object sender, RoutedEventArgs e)
        {
            Decoration fd = new Decoration { decorationName = "Edit.." };
            App._decorations.Add(fd);
            Lbx_Decor.SelectedItem = fd;
            Lbx_Decor.ScrollIntoView(fd);
        }

        private void Btn_DeleteDecor_Click(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Decor.SelectedItem;

            if (itm == null)
            {
                MessageBox.Show("Please select an item to be deleted first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var toDelete = itm as Decoration;
            var res = MessageBox.Show($"Are you sure to delete {toDelete.decorationName}?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._decorations.Remove(toDelete);
        }
    }
}
