using System;
using System.Windows.Input;
using HelloIoC.DAL.DTO;

namespace HelloIoC.WpfApp.ViewModels
{
    public class OpenDetailCommand : ICommand
    {
        private readonly Func<ContactDetail> contactDetailFactory;

        public OpenDetailCommand(Func<ContactDetail> contactDetailFactory)
        {
            this.contactDetailFactory = contactDetailFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var contact = parameter as ContactDTO;

            var contactDetail = contactDetailFactory();
            contactDetail.Show(contact);
        }

        public event EventHandler CanExecuteChanged;
    }
}