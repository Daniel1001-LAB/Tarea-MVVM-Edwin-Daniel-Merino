using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM02MVVM
{
    public partial class inicio : ContentPage
    {
       
        public inicio()
        {
            InitializeComponent();

            OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ViewModels.ListaOrdenesViewModel(Navigation);
        }

        private void menuToolbar_Clicked(object sender, EventArgs e)
        {

        }






    }

}

