using HelloIoC.DAL.DTO;

namespace HelloIoC.WpfApp.ViewModels
{
    public class ContactDetailViewModel : ViewModelBase
    {
        private ContactDTO contact;

        public ContactDTO Contact
        {
            get { return contact; }
            private set
            {
                if (Equals(value, contact)) return;
                contact = value;
                OnPropertyChanged();
            }
        }

        public void Load(ContactDTO contact)
        {
            Contact = contact;
        }
    }
}