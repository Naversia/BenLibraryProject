using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BenEliLibraryProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using (var db = new LibrayDBContext())
            {
                if (!db.Database.Exists()) db.Database.Create();
            }
        }
    }
}