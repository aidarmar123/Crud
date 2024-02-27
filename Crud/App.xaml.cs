using Crud.Models;
using Crud.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Crud
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CrudEntities DB = new CrudEntities();

       public App()
        {
            RegisterAllDescriptor();
        }

        private void AddDesciptor<T, A>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T), typeof(A));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T));
        }
        private void RegisterAllDescriptor()
        {
            AddDesciptor<User, UserMetadata>();
        }
    }
}
