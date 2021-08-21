using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PM02MVVM.Main;
using PM02MVVM.Models;
using SQLite;
using Xamarin.Forms;

namespace PM02MVVM.ViewModels
{
    public class ListaOrdenesViewModel : BaseViewModel
    {
        Crud crud = new Crud();
        private ObservableCollection<Personas> _persons;

        public ObservableCollection<Personas> Persons
        {
            get { return _persons; }
            set { _persons = value; OnPropertyChanged(); }
        }

        private Personas _selectedPersona;

        public Personas SelectedPersona
        {
            get { return _selectedPersona; }
            set { _selectedPersona = value; OnPropertyChanged(); }
        }

        public ICommand IrInformacionCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListaOrdenesViewModel(INavigation navigation)
        {
            Navigation = navigation;
            IrInformacionCommand = new Command<Type>(async (pageType) => await IrInformacion(pageType));

            Persons = new ObservableCollection<Personas>();

            mostrar();

        }


        public async void mostrar()
        {
            try
            {
                var personasList = await crud.getReadPersonas();
                foreach (var persons in personasList)
                {
                    Persons.Add(new Personas
                    {
                        id = persons.id,
                        name = persons.name,
                        apellido = persons.apellido,
                        correo = persons.correo,
                        direccion = persons.direccion,
                        edad = persons.edad,
                        puesto = persons.puesto,

                    });
                }



            }
            catch (SQLiteException e)
            {


            }
        }

        async Task IrInformacion(Type pageType)
        {
            if (SelectedPersona != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new OrdenesViewModel()
                {
                    Id = SelectedPersona.id,
                    Name = SelectedPersona.name,
                    Apellido = SelectedPersona.apellido,
                    Edad = SelectedPersona.edad,
                    Puesto = SelectedPersona.puesto,
                    Correo = SelectedPersona.correo,
                    Direccion = SelectedPersona.direccion

                };

                await Navigation.PushModalAsync(page);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione Persona", "ok");
            }
        }

    }
}
