using System.Windows.Input;

namespace PWR_VI_PodPro.Core
{
    class RelayCommand: ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add{ CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Funkcja sprawdzająca czy można wykonać polecenie
        /// </summary>
        /// <param name="parameter">Obiekt do sprawdzenia</param>
        /// <returns>Bool: czy można wykonać polecenie</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Funkcja wykonanująca polecenia
        /// </summary>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
