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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Wpf_OrganizeAparty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string language;
        //bool firstTime;
        public MainWindow()
        {
            //language = Properties.Settings.Default.language;
            //firstTime = true;
            //CultureInfo.CurrentCulture = new CultureInfo(language);
            //CultureInfo.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_Customers.ItemsSource = App._customers;
            CoBx_gender.ItemsSource = App._genders;
            //Dgr_history.ItemsSource = App._parties;

            //var lst = new List<string> { "de Deutsch", "en English" };
            //CoBx_Lang.ItemsSource = lst;



            //var itm = (from l in lst where l.Contains(language) select l).FirstOrDefault();
            //CoBx_Lang.SelectedItem = itm;

        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._customers where s.lastName.ToLower().Contains(filter) select s;
            Lbx_Customers.ItemsSource = lst;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer { firstName = "Edit..", lastName = "Edit..", };
            App._customers.Add(cust);
            Lbx_Customers.SelectedItem = cust;
            Lbx_Customers.ScrollIntoView(cust);
        }


        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Customers.SelectedItem;

            if (itm == null)
            {
                MessageBox.Show("Please select an item to be deleted first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var toDelete = itm as Customer;
            var res = MessageBox.Show($"Are you sure to delete {toDelete.firstName} {toDelete.lastName}?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._customers.Remove(toDelete);
        }



        private void Btn_PLanParty_Click(object sender, RoutedEventArgs e)
        {
            string custName = Tbx_custFirstName.Text.ToString() + " " + Tbx_custLastName.Text.ToString();
            if (Lbx_Customers.SelectedItem == null)
            {
                MessageBox.Show("Please Select a customer first", "Error");
                
                return;
            }
           

            var win = new W_PlanParty(custName);
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
    
        }

        private void Btn_food_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Food();
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }

        private void Btn_Decor_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Decorations();
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

        private void Dgr_history_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CoBx_Lang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (firstTime)
            //{
            //    firstTime = false;
            //    return;
            //}



            //language = CoBx_Lang.SelectedItem.ToString().Substring(0, 2);    //from 0, first two characters fetch
            //Properties.Settings.Default.language = language;
            //Properties.Settings.Default.Save();
            //Process.Start(Application.ResourceAssembly.Location);
            //App.Current.Shutdown();  //kill running one
        }
    }
}
