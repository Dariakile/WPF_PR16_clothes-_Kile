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
    /// Логика взаимодействия для PageHC.xaml
    /// </summary>
    public partial class PageHC : Page
    {
        public PageHC()
        {
            InitializeComponent();
            DGHomeClothes.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageHCAdd());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HomeClothesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGHomeClothes.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageHCEditAdd((sender as Button).DataContext as HomeClothes));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DGHomeClothes.SelectedItems.Cast<HomeClothes>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HomeClothesEntities.GetContext().HomeClothes.RemoveRange(tovarForRemoving);
                    HomeClothesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGHomeClothes.ItemsSource = HomeClothesEntities.GetContext().HomeClothes.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
