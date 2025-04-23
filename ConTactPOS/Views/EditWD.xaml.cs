using ConTactPOS.ViewModels;
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
using System.Windows.Shapes;

namespace ConTactPOS.Views
{
    /// <summary>
    /// Interaction logic for EditWD.xaml
    /// </summary>
    public partial class EditWD : Window
    {
        public EditWD(Models.Product pd)
        {
            InitializeComponent();
            DataContext = new EditVM(pd); 
        }
    }
}
