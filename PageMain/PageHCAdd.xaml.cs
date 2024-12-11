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
    /// Логика взаимодействия для PageHCAdd.xaml
    /// </summary>
    public partial class PageHCAdd : Page
    {
        private HomeClothes _currentHomeClothes = new HomeClothes();
        public PageHCAdd()
        {
            InitializeComponent();
            DataContext = _currentHomeClothes;
            ComboBrend.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
            ComboColor.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
            ComboRazmer.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHomeClothes.naimenov))
                errors.AppendLine("Укажите название товара");
           
            if (_currentHomeClothes.RazmerTable == null)
                errors.AppendLine("Выберите размер");
            if (_currentHomeClothes.ColorTable == null)
                errors.AppendLine("Выберите цвет");
            if (_currentHomeClothes.BrendTable == null)
                errors.AppendLine("Выберите бренд");
            if (_currentHomeClothes.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равно 0");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHomeClothes.ID == 0)
                HomeClothesEntities.GetContext().HomeClothes.Add(_currentHomeClothes);
            try
            {
                HomeClothesEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
