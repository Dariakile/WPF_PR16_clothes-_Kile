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
using WPF_PR16_clothes__Kile.ApplicationData;

namespace WPF_PR16_clothes__Kile.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageHCEditAdd.xaml
    /// </summary>
    public partial class PageHCEditAdd : Page
    {
        private HomeClothes _currentHomeClothes = new HomeClothes();
        public PageHCEditAdd(HomeClothes selectedHomeClothes)
        {
            InitializeComponent();

            if (selectedHomeClothes != null)
                _currentHomeClothes = selectedHomeClothes;

            DataContext = _currentHomeClothes;
            ComboBrend.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
            ComboColor.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
            ComboRazmer.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
        }
    }
}
