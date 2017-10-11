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
using System.Windows.Shapes;
using HelloIoC.DAL.DTO;
using HelloIoC.WpfApp.ViewModels;

namespace HelloIoC.WpfApp
{
    /// <summary>
    /// Interaction logic for ContactDetail.xaml
    /// </summary>
    public partial class ContactDetail : Window
    {
        private readonly ContactDetailViewModel viewModel;

        public ContactDetail(ContactDetailViewModel viewModel)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }

        internal void Show(ContactDTO contact)
        {
            viewModel.Load(contact);
            Show();
        }
    }
}
