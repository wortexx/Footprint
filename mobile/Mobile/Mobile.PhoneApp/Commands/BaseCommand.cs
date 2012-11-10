using System;
using System.Windows.Input;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.Commands
{
    public abstract class BaseCommand<T> : ICommand where T : BaseViewModel
    {
        private readonly T viewModel;

        protected BaseCommand(T viewModel)
        {
            this.viewModel = viewModel;
        }

        public T ViewModel
        {
            get { return viewModel; }
        }

        public void RaiseCanExecuteChanged()
        {
            var temp = CanExecuteChanged;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }


        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
        public event EventHandler CanExecuteChanged;
    }
}