using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication3.ViewModels
{
    public class StudentSearchViewModel
    {
        public string SearchValue
        {
            get
            {
                return string.Empty;
            }

            set
            {
                if (Application.Current.Properties.Contains("StudentId"))
                {
                    Application.Current.Properties["StudentId"] = value;
                }
                else
                {
                    Application.Current.Properties.Add("StudentId", value);
                }

            }
        }
    }
}
