using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication3.Models;
using WpfApplication3.Repository;
using WpfApplication3.ViewModels.Commands;

namespace WpfApplication3.ViewModels
{
    public class StudentDetailsViewModel : BaseViewModel
    {

        private readonly UserRepository _userRepository;
        //Review DM: I'll use int value here.
        private readonly string _studentId;
        private UserModel _user;

        public StudentDetailsViewModel(string studentId)
        {
            _studentId = studentId;
            _userRepository = new UserRepository();
            User = _userRepository.LoadUserDetails(studentId);
        }

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

#region Old Code
		
/*
        private SearchUserCommand searchCommand;

        public SearchUserCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        } 

        private Visibility _userVisibility;

        public StudentDetailsViewModel()
        {
            //Application.Current.
            //User = new UserModel();
            UserVisibility = Visibility.Collapsed;
            searchCommand = new SearchUserCommand(this);
            _userRepository = new UserRepository();
        }



        public Visibility UserVisibility
        {
            get { return _userVisibility; }
            set 
            {
                _userVisibility = value;
                OnPropertyChanged("UserVisibility");   
            }
        }

        public void ExecuteSearch(string searchValue)
        {
            User = _userRepository.LoadUserDetails(searchValue);
            UserVisibility = Visibility.Visible;
        }
        */
 
	#endregion    
    }
}
