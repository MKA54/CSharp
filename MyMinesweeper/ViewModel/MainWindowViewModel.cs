using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyMinesweeper.Model;

namespace MyMinesweeper.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(Window window)
        {
            Map.Window = window;
            Map.Init(16, 16, 30);

            NewGameCommand = new RelayCommand(OnNewGameCommandExecute, CanNewGameCommandExecuted);
            BeginnerCommand = new RelayCommand(OnBeginnerCommandExecute, CanBeginnerCommandExecuted);
            IntermediateCommand = new RelayCommand(OnIntermediateCommandExecute, CanIntermediateCommandExecuted);
            ExpertCommand = new RelayCommand(OnExpertCommandExecute, CanExpertCommandExecuted);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private StackPanel _dataProvider;

        public StackPanel DataProvider
        {
            get => _dataProvider;
            set
            {
                _dataProvider = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewGameCommand { get; }
        public ICommand BeginnerCommand { get; }
        public ICommand IntermediateCommand { get; }
        public ICommand ExpertCommand { get; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnNewGameCommandExecute(object parameter)
        {
            if(Map.GamePanel == null)
            {
                NewGame(16, 16, 30);
            }

            Map.Restart();
        }

        private bool CanNewGameCommandExecuted(object parameter)
        {
            return true;
        }

        private void OnBeginnerCommandExecute(object parameter)
        {
            NewGame(9, 9, 10);
        }

        private bool CanBeginnerCommandExecuted(object parameter)
        {
            return true;
        }

        private void OnIntermediateCommandExecute(object parameter)
        {
            NewGame(16, 16, 30);
        }

        private bool CanIntermediateCommandExecuted(object parameter)
        {
            return true;
        }

        private void OnExpertCommandExecute(object parameter)
        {
            NewGame(30, 16, 70);
        }

        private bool CanExpertCommandExecuted(object parameter)
        {
            return true;
        }

        private void NewGame(int width, int height, int bombsCount)
        {
            Map.Init(width, height, bombsCount);

            DataProvider = Map.GamePanel;
        }
    }
}