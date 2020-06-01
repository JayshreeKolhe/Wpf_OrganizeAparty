using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_OrganizeAparty;

namespace Wpf_OrganizeAparty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ObservableCollection<Customer> _customers;
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        

        public static List<String> _genders = new List<string> { "m", "f", "d" };

        public static ObservableCollection<Food> _foods;

        public static ObservableCollection<Decoration> _decorations;
        public static ObservableCollection<Party> _parties;

        

        public App() { }



        private void Application_Startup(object sender, StartupEventArgs e)
        {


            //GenerateCustomers 
            _customers = MyStorage.ReadXml<ObservableCollection<Customer>>("customers.xml");
            if (_customers == null)
            {
                _customers = new ObservableCollection<Customer>();
                // _customers = GenerateCustomers(10);
            }

            //GenerateFood
            _foods = MyStorage.ReadXml<ObservableCollection<Food>>("foods.xml");
            if (_foods == null)
            {
                _foods = new ObservableCollection<Food>();
              //  _foods = GenerateFoods(5);
            }

            //GenerateDEcorations&Movables
           _decorations = MyStorage.ReadXml<ObservableCollection<Decoration>>("decorations.xml");
            if (_decorations == null)
            {
                _decorations = new ObservableCollection<Decoration>();
               // _decorations = GenerateDecorations(10);
            }
            //Generate Planned Parties
            _parties = MyStorage.ReadXml<ObservableCollection<Party>>("parties.xml");
            if (_parties == null)
            {
                _parties = new ObservableCollection<Party>();
                //_parties = GenerateParties(10);


            }




        }

        private ObservableCollection<Party> GenerateParties(int cnt)
        {
            List<String> rperson = new List<string> { };
            List<String> pdate = new List<string> { };
            List<String> ptype = new List<string> { };
            List<String> paddress = new List<string> { };
            List<String> pcatering = new List<string> { };
            List<String> pguest = new List<string> { };
            List<String> pchild = new List<string> { };
            List<String> pveg = new List<string> { };
            List<String> pnonveg = new List<string> { };
            List<String> pfooddata = new List<string> { };
            List<String> pdecordata = new List<string> { };
            List<String> pfoodtotal = new List<string> { };
            List<String> pdecortotal = new List<string> { };
            List<String> ppartytotal = new List<string> { };

            var lst = new ObservableCollection<Party>();

            for (int i = 0; i < cnt; i++)
            {
                int rpr = rnd.Next(rperson.Count);
                int pdt = rnd.Next(pdate.Count);
                int ptyp = rnd.Next(ptype.Count);
                int padd = rnd.Next(paddress.Count);
                int pcat = rnd.Next(pcatering.Count);
                int pgst = rnd.Next(pguest.Count);
                int pcld = rnd.Next(pchild.Count);
                int pvg = rnd.Next(pveg.Count);
                int pnvg = rnd.Next(pnonveg.Count);
                int pfdata = rnd.Next(pfooddata.Count);
                int pddata = rnd.Next(pdecordata.Count);
                int pftotal = rnd.Next(pfoodtotal.Count);
                int papdtotaldd = rnd.Next(pdecortotal.Count);
                int pptotal = rnd.Next(ppartytotal.Count);

                lst.Add(new Party
                {
                    responsibleperson = rperson[rpr],
                    partyDate = pdate[pdt],
                    partyType = ptype[ptyp],
                    partyAddress = paddress[padd],
                    cateringService = pcatering[pcat],
                    guest = pguest[pgst],
                    child = pchild[pcld],
                    veg = pveg[pvg],
                    nonVeg = pnonveg[pnvg],
                    fooddata = pfooddata[pfdata],
                    decordata = pdecordata[pddata],
                    foodtotal = pfoodtotal[pftotal],
                    decortotal = pdecortotal[papdtotaldd],
                    partytotal = ppartytotal[pptotal]

                });
            }
            return lst;

        }

        private ObservableCollection<Decoration> GenerateDecorations(int cnt)
        {
            List<String> dCategory = new List<string> { };
            List<String> dName = new List<string> { };
            List<String> dQuantity = new List<string> { };
            List<String> dCost = new List<string> { };
            var lst = new ObservableCollection<Decoration>();

            for (int i = 0; i < cnt; i++)
            {
                int dcat = rnd.Next(dCategory.Count);
                int dname = rnd.Next(dName.Count);
                int dquan = rnd.Next(dQuantity.Count);
                int dcost = rnd.Next(dCost.Count);

                lst.Add(new Decoration
                {
                    decorationCategory = dCategory[dcat],
                    decorationName = dName[dname],
                    decorationQuantity = dQuantity[dquan],
                    decorationCost = dCost[dcost]
                });
            }
            return lst;

        }

        private ObservableCollection<Food> GenerateFoods(int cnt)
        {
           
            List<String> fdCategory = new List<string> { };
            List<String> fdName = new List<string> { };
            List<String> fdQuantity = new List<string> { };
            List<String> fdCost = new List<string> { };
            List<String> fdAllergence = new List<string> { };
            var lst = new ObservableCollection<Food>();

            for (int i = 0; i < cnt; i++)
            {
                int fdcat = rnd.Next(fdCategory.Count);
                int fdname = rnd.Next(fdName.Count);
                int fdquantity = rnd.Next(fdQuantity.Count);
                int fdcost = rnd.Next(fdCost.Count);
                int fdallergence = rnd.Next(fdAllergence.Count);

                lst.Add(new Food
                {
                    category = fdCategory[fdcat],
                    foodName = fdName[fdname],
                    foodQuantity = fdQuantity[fdquantity],
                    foodCost = fdCost[fdcost],
                    foodAllergence = fdAllergence[fdallergence]
                });
            }
            return lst;
        }

        private ObservableCollection<Customer> GenerateCustomers(int cnt)
        {
            List<String> fnames = new List<String> { };
            List<String> lnames = new List<string> { };
            List<String> nemails = new List<string> { };
            List<String> telnum = new List<string> { };
            List<String> nadd = new List<string> { };
            var lst = new ObservableCollection<Customer>();

            for (int i = 0; i < cnt; i++)
            {
                int fno = rnd.Next(fnames.Count);
                int lno = rnd.Next(lnames.Count);
                var gndr = fno > 5 ? "m" : "f";
                int emo = rnd.Next(nemails.Count);
                int telno = rnd.Next(telnum.Count);
                int add = rnd.Next(nadd.Count);


                lst.Add(new Customer

                {
                    firstName = fnames[fno],
                    lastName = lnames[lno],
                    gender = gndr,
                    email = nemails[emo],
                    telNumber = telnum[telno],
                    address = nadd[add]

                });

            }
            return lst;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Customer>>(_customers, "customers.xml");
            MyStorage.WriteXml<ObservableCollection<Food>>(_foods, "foods.xml");
            MyStorage.WriteXml<ObservableCollection<Decoration>>(_decorations, "decorations.xml");
          // MyStorage.WriteXml < ObservableCollection >> (_parties, "parties.xml");


        }

    }
}
