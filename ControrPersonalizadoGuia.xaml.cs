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
using Microsoft.Win32;
using Path = System.IO.Path;
using System.Xml;
using System.IO;

namespace GUI_RutaOrnitologica
{
    /// <summary>
    /// Lógica de interacción para ControrPersonalizadoGuia.xaml
    /// </summary>
    public partial class ControrPersonalizadoGuia : UserControl
    {
        private GuiaTuristico guiaSeleccionado;
        private Image imgIdiomaGuia;
        private Label nombreGuia;
        private Label apellidoGuia;
        private Label telefonoGuia;
        private Label correoGuia;

        public ControrPersonalizadoGuia(GuiaTuristico GuiaSeleccionado, Image ImgIdiomaGuia, 
            Label lblNombreGuia, Label lblApellidoGuia, Label lblTelefonoGuia, Label lblCorreoElectronicoGuia)
        {

            imgIdiomaGuia = ImgIdiomaGuia;
            nombreGuia = lblNombreGuia;
            apellidoGuia = lblApellidoGuia;
            telefonoGuia = lblTelefonoGuia;
            correoGuia = lblCorreoElectronicoGuia;
            InitializeComponent();
            guiaSeleccionado = GuiaSeleccionado;
            if (! (guiaSeleccionado == null && imgIdiomaGuia == null && nombreGuia == null && apellidoGuia == null 
                && telefonoGuia == null && correoGuia == null)) 
            { 
                CargarImagenGuia(guiaSeleccionado); 
            }
               
        }

        public void CargarImagenGuia(GuiaTuristico guiaSeleccionado)
        {           
            try
            {
                lblNombre.Text = guiaSeleccionado.Nombre;
                var bitmap = new BitmapImage(guiaSeleccionado.Perfil);
                imgUsuario.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen del guia " + ex.Message);
            }
            
        }

        private void verInformacion(object sender, RoutedEventArgs e)
        {
            try
            {
                if (guiaSeleccionado == null && imgIdiomaGuia == null && nombreGuia == null && apellidoGuia == null
                && telefonoGuia == null && correoGuia == null)
                {
                    guiaSeleccionado = new GuiaTuristico(new Uri("/Imagenes/Usuario.png", UriKind.Relative), lblNombre.Text, "", "", "", new Uri("Imagenes/BanderaInglesa.png", UriKind.Relative));
                    imgIdiomaGuia = new Image();
                    nombreGuia = new Label();
                    apellidoGuia = new Label();
                    telefonoGuia = new Label();
                    correoGuia = new Label();
                }
                
                 var bitmap = new BitmapImage(guiaSeleccionado.Idiomas);
                imgIdiomaGuia.Source = bitmap;
                lblNombre.Text = guiaSeleccionado.Nombre;
                nombreGuia.Content = guiaSeleccionado.Nombre;
                apellidoGuia.Content = guiaSeleccionado.Apellido;
                telefonoGuia.Content = guiaSeleccionado.Telefono;
                correoGuia.Content = guiaSeleccionado.CorreoElectronico;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la informacion del guia " + ex.Message);
            }
        }

        private void CargarImagenGuia(object sender, RoutedEventArgs e)
        {
           var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    imgUsuario.Source = bitmap;
                    lblNombre.Text = Path.GetFileName(abrirDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}
