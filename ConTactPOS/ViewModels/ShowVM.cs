using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ConTactPOS.Models;
using ConTactPOS.Services;
using ConTactPOS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConTactPOS.ViewModels
{
    public partial class ShowVM:ObservableObject
    {

        private DbConnnect dbconn;

        [ObservableProperty]
        private ObservableCollection<Product> producets;

        public ShowVM()
        {
            dbconn = new DbConnnect();
            Producets =  dbconn.Selectdb();
            dbconn.Selectdb();
        }


        [RelayCommand]
        public void Delete(Product pd)
        {
            if (pd != null && MessageBox.Show("Delete","Del",MessageBoxButton.OKCancel ) == MessageBoxResult.OK)
            {
                dbconn.Deletedb((int)pd.Id);

            }

            Producets = dbconn.Selectdb();

        }
        [RelayCommand]
        public void Edit(Product pd)
        {
            var edit = new EditWD(pd); 
            edit.ShowDialog();
            ShowVM show = new ShowVM();
        }



    }
}
