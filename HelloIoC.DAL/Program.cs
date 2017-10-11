using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Facade;
using HelloIoC.DAL.Query;
using HelloIoC.DAL.Repository;
using HelloIoC.DAL._Installer;

namespace HelloIoC.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Install(new DALInstaller());
            container.Install(new BLInstaller());

            var contactListApp = container.Resolve<ContactListApp>();
           
            contactListApp.App();

            container.Release(contactListApp);
        }
    }
}
