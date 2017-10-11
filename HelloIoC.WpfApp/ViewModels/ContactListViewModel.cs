using System.Collections.ObjectModel;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Facade;

namespace HelloIoC.WpfApp.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        public OpenDetailCommand OpenDetailCommand { get; }

        private readonly ContactListFacade facade;
        private ObservableCollection<ContactDTO> contacts;

        public ObservableCollection<ContactDTO> Contacts
        {
            get { return contacts; }
            set
            {
                if (Equals(value, contacts)) return;
                contacts = value;
                OnPropertyChanged();
            }
        }

        public ContactListViewModel(ContactListFacade facade, OpenDetailCommand openDetailCommand)
        {
            OpenDetailCommand = openDetailCommand;
            this.facade = facade;
        }

        public void Load()
        {
            Contacts = new ObservableCollection<ContactDTO>(facade.GetAllContacts());
        }
    }
}