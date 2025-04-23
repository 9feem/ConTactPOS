using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ConTactPOS.Models;
using ConTactPOS.Services;
using System.Linq;
using System.Windows;

namespace ConTactPOS.ViewModels
{
    public partial class EditVM : ObservableObject
    {
        private Product product;

        public EditVM(Product product)
        {
            Name = product.Name;
            Price = product.Price.ToString();
            MoreInfo = product.MoreInfo;
            this.product = product;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string price;

        [ObservableProperty]
        private string moreInfo;

        [RelayCommand]
        public void Update()
        {
            var db = new DbConnnect();

            product.Name = Name;
            product.Price = decimal.Parse(Price);
            product.MoreInfo = MoreInfo;

            db.Update(product);       

            WeakReferenceMessenger.Default.Send(product);  

            var window = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this);
            window?.Close();       
        }

    }
}
