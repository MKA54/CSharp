using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp19.Model;

namespace WpfApp19.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private double _radius;
        private double _result;
        public ICommand AddCommand { get; }

        public double Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                OnPropertyChanged();
            }
        }

        public double Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnAddCommandExecute(object parameter)
        {
            Result = Ariph.Circumference(Radius);
        }

        private bool CanAddCommandExecute(object parameter)
        {
            return Radius > 0;
        }
    }
}
