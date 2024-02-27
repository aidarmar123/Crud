using Crud.Models;
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

namespace Crud.Pages
{
    /// <summary>
    /// Логика взаимодействия для Primary.xaml
    /// </summary>
    public partial class Primary : Page
    {
        public Primary()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            DgUsers.ItemsSource = App.DB.User.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add(new User()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(DgUsers.SelectedItem is User user)
            {
                NavigationService.Navigate(new Add(user));
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem is User user)
            {
                App.DB.User.Remove(user);
                App.DB.SaveChanges();
                Refresh();  
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
