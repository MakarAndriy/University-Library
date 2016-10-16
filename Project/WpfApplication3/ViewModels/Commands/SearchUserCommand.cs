using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication3.ViewModels.Commands
{
    public class SearchUserCommand: ICommand
    {
        private StudentDetailsViewModel _viewModel;

        public SearchUserCommand(StudentDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            var searchValue = parameter as string;
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return false;
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //var searchValue = parameter as string;
            //_viewModel.ExecuteSearch(searchValue);
        }
    }
}
