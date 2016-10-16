using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Models
{
    public class UserModel: INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private byte[] photo;
		private int id;

	
       
        public UserModel()
        {
            Name = "Name";
            LastName = "LastName";
        }

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public byte[] Photo
        {
            get { return photo; }

            set 
            {
                photo = value;
                OnPropertyChanged("Photo");
            }
        }

		public int Id
		{
			get { return id; }
			set
			 {
			  id = value; 
			  OnPropertyChanged("Id");
			  }
		}

       


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
