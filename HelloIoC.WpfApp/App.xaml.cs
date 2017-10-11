using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using HelloIoC.DAL;
using HelloIoC.DAL._Installer;
using HelloIoC.WpfApp.ViewModels;

namespace HelloIoC.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var container = new WindsorContainer();

            container.Install(new DALInstaller());
            container.Install(new BLInstaller());

            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof(ViewModelBase)).WithServiceSelf().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(Window)).WithServiceSelf().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(ICommand)).WithServiceSelf().LifestyleTransient()
                );
            
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

        }


    }
}
