using PM02MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM02MVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new OrdenesViewModel();
        }



        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new inicio());
        }
    }
}

