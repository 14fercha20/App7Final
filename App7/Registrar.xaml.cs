using App7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registrar()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasena = Contrasena.Text };
            con.InsertAsync(DatosRegistro);
            limpiarFormulario();
        }

        void limpiarFormulario()
        {
            Nombre.Text = " ";
            Usuario.Text = " ";
            Contrasena.Text = " ";
            DisplayAlert("Alerta", "Se agreg{o correctamente", "ok");
        }
    }
}