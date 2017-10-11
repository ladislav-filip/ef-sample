using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelloIoC.WpfApp.Annotations;

namespace HelloIoC.WpfApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}