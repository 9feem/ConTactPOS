using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTactPOS.ViewModels
{
    public partial class MainVM:ObservableObject
    {
        [ObservableProperty]
        private object contentsView;

        private ProductVM productVM {  get; }
        private ShowVM showVM { get; }


        public MainVM()
        {
            showVM = new ShowVM();
            productVM = new ProductVM();

            ContentsView = productVM;

        }


        [RelayCommand]
        public void Dasebord()
        {
            ContentsView = showVM;
        }

        [RelayCommand]
        public void Add()
        {
            ContentsView = productVM;
        }




    }
}
