using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ConTactPOS.Models;
using ConTactPOS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConTactPOS.ViewModels
{
    public partial class ProductVM : ObservableRecipient, IRecipient<Product>
    {
        public ProductVM()
        {
            IsActive = true; 
        }


        public void Receive(Product message)
        {
            UpdateFieldsFromProduct(message);
            MessageBox.Show("ข้อมูลได้รับการอัปเดต", "อัปเดตสำเร็จ", MessageBoxButton.OK);
        }

        private void UpdateFieldsFromProduct(Product product)
        {
            Reset();
        }

        [ObservableProperty]
        private string name;


        [ObservableProperty]
        private string price;

        [ObservableProperty]
        private string moreInfo;



        [RelayCommand]
        public void Reset()
        {
            Name = string.Empty;
            Price = string.Empty;
            MoreInfo = string.Empty;
        }


        [RelayCommand]
        public void Add(Product messange)
        {
            var dbconn = new DbConnnect();
            var products = new ObservableCollection<Product>();
            var data = new Product
            {
                Name = Name,
                Price = decimal.Parse(Price),
                MoreInfo = MoreInfo,
            };
            products.Add(data);
            dbconn.Insertdb(data);
            MessageBoxResult result = MessageBox.Show("Data Inserted", "Insert", MessageBoxButton.OK);
            dbconn.Selectdb();
            Reset();

        }
        

    }
}
