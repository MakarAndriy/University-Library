using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3.ViewModels;

namespace WpfApplication3.Pages
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Page
    {
        public StudentDetails()
        {
            InitializeComponent();
            var studentId = Application.Current.Properties["StudentId"] as string;
            var viewModel = new StudentDetailsViewModel(studentId);
            DataContext = viewModel;
        }
    }
}
