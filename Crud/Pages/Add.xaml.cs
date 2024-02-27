using Crud.Models;
using Crud.Models.Metadata;
using Crud.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>

    public partial class Add : Page
    {
        User contextUser;
        public Add(Models.User user)
        {
            InitializeComponent();
            contextUser = user;
            DataContext = contextUser;
            CBRole.ItemsSource = App.DB.Role.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if(ValidationLine.Validation(contextUser).Length>0)
            {
                MessageBox.Show(ValidationLine.Validation(contextUser).ToString());
            }

            //if (Validation().Length > 0)
            //{
            //    MessageBox.Show(Validation().ToString());

            //}
            else
            {
                if (contextUser.Id == 0)
                    App.DB.User.Add(contextUser);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }

           
        }

        private StringBuilder Validation()
        {
            var error = new StringBuilder();
            if (contextUser.Role == null)
                error.AppendLine("Error");
            if (contextUser.Name == null)
                error.AppendLine("Error");

            return error;
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddDescriptor<T, A>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T), typeof(A));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T));
        }

        private void RegisterAllDescriptors()
        {
            AddDescriptor<User, UserMetadata>();
        }
    }
}
