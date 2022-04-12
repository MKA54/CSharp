﻿using System;
using System.Windows.Input;

namespace WpfApp19
{
    internal class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);
    }
}
