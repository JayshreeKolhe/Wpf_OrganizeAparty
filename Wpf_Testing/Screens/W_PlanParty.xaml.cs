using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Text.RegularExpressions;

namespace Wpf_OrganizeAparty
{
    /// <summary>
    /// Interaction logic for W_PlanParty.xaml
    /// </summary>
    public partial class W_PlanParty : Window
    {
        public static ObservableCollection<Food> foods;
        public static ObservableCollection<Food> _foodLists;
        public static ObservableCollection<Decoration> decorations;
        public static ObservableCollection<Decoration> _decorationList;
        public static ObservableCollection<Customer> customers;
        //public static ObservableCollection<PlannedParty> parties;
        //public static ObservableCollection<PlannedParty> _partiesList;
       

        public static string cstName;
      
        
        //catching the object passed by the constructor by  MainWindow
        public W_PlanParty(string CustrName)
        {
            cstName = CustrName;
            InitializeComponent();
        }

        public W_PlanParty()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CoBx_responsiblePerson.ItemsSource = new List<String> { "Employee Name 1", "Employee Name 2", "Employee Name 3", "Employee Name 4" };
            CoBx_catering.ItemsSource = new List<string> { "Sit-Down", "Buffet" };
            CoBx_partyType.ItemsSource = new List<String> { "Birthday", "Anniversary" };
            CoBx_foodCategory.ItemsSource = new List<String> { "Main Course", "Drinks", "Dessert" };
            CoBx_decorCategory.ItemsSource = new List<String> { "Movables", "Decorations" };
            Tbl_name.Text = cstName;   //Constructor customer
            

            foods = MyStorage.ReadXml<ObservableCollection<Food>>("foods.xml");
            decorations = MyStorage.ReadXml<ObservableCollection<Decoration>>("decorations.xml");
            customers = MyStorage.ReadXml<ObservableCollection<Customer>>("customers.xml");
            //_parties = MyStorage.ReadXml<ObservableCollection<Party>>("paties.xml");
            


        }
        private void Btn_back_Click(object sender, RoutedEventArgs e)
        { 
            var win = new MainWindow();
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }
        private void Btn_AddDetails_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //---Food Details---
        private void Btn_foodCartDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = Lbx_foodCart.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please select an item", "Error");
                return;
            }
            _foodLists.Remove(item as Food);
        }

        private void CoBx_foodCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cst1 = from p in foods where p.category == CoBx_foodCategory.SelectedItem.ToString() select p;
            CoBx_foodItem.ItemsSource = cst1;
        }

        private void CoBx_foodItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoBx_foodItem.SelectedItem == null)
                return;

            var cst2 = from f in foods where f.foodName == CoBx_foodItem.SelectedItem.ToString() select f;

            Lbx_foodCart.ItemsSource = cst2;

            Food result = CoBx_foodItem.SelectedItem as Food;

            if (_foodLists != null)
            {
                _foodLists.Add(result);
            }
            else
            {
                _foodLists = new ObservableCollection<Food>();
                _foodLists.Add(result);
            }
            Lbx_foodCart.ItemsSource = _foodLists;
          
        }


        private void Lbx_foodCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
        private void Tbx_foodQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
                //int cnt;
            
           
                //if ((sender as TextBox).Text == "") { cnt = 1; }   
                //else { cnt = Convert.ToInt32((sender as TextBox).Text); }
                //Lbx_foodCart.Items.Clear();
                //foreach (Food i in Lbx_foodCart.Items)
                //{
                //    Lbx_foodCart.Items.Add(((i.foodCost)  * (i.foodQuantity) );
                //}
                ////Lbx_Ingredients.Items

           

            //var qun = Tbx_foodQuantity.Text;
            //if (_foodLists != null)
            //{
            //    var result = _foodLists.Single(c => c.foodName == Tbx_foodItem.Text.ToString());
            //  //  if (Convert.ToInt32(Tbx_foodQuantity.Text))
            //    {
            //        int qty = Convert.ToInt32(Tbx_foodQuantity.Text);

            //        int foodcost = Convert.ToInt32(result.foodCost) * qty;
            //        result.foodCost = (foodcost).ToString();
            //        result.foodQuantity = qty.ToString();
            //    }
            //}
            ////Lbx_decorCart.ItemsSource = null;
            //Lbx_decorCart.ItemsSource = _foodLists;


            //    var result = foods.Single(c => c.foodName == Tbx_foodItem.Text.ToString());
            //    //from f in foods where f.foodName == Tbx_foodItem.Text.ToString() select f;

            //    if (Convert.ToInt32(Tbx_foodQuantity.Text) > 1)
            //    {
            //        var x = Lbx_foodCart.Items;
            //        foreach (var item in Lbx_foodCart.Items)
            //        {
            //            result.foodCost = (Convert.ToInt32(result.foodCost) * Convert.ToInt32(result.foodQuantity)).ToString();
            //            // item = (Lbx_foodCart) result;
            //        }

            //    }

        }
        

        private void Tbx_totfoodCost_TextChanged(object sender, TextChangedEventArgs e)
        {

           //var qun = Convert.ToInt32(Tbx_foodQuantity.Text )* 2;
        }


        //---Decorations Details---
        private void CoBx_decorCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cs1 = from p in decorations where p.decorationCategory == CoBx_decorCategory.SelectedItem.ToString() select p;
            CoBx_decorItem.ItemsSource = cs1;
        }

        private void CoBx_decorItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoBx_decorItem.SelectedItem == null)
                return;
            var cs2 = from f in decorations where f.decorationName == CoBx_decorItem.SelectedItem.ToString() select f;

            Lbx_decorCart.ItemsSource = cs2;

            Decoration result = CoBx_decorItem.SelectedItem as Decoration;
            if (_decorationList != null)
                _decorationList.Add(result);
            else
            {
                _decorationList = new ObservableCollection<Decoration>();
                _decorationList.Add(result);
            }
            Lbx_decorCart.ItemsSource = _decorationList;
        }

        private void Btn_decorCartDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = Lbx_decorCart.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please select an item", "Error");
                return;
            }
            _decorationList.Remove(item as Decoration);
        }

        private void Tbx_foodQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
