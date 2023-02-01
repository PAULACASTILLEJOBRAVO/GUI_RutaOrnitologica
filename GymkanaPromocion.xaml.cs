using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Net.Mail;
using System.Net;

namespace GUI_RutaOrnitologica
{
    /// <summary>
    /// Lógica de interacción para GymkanaPromocion.xaml
    /// </summary>
    public partial class GymkanaPromocion : Window
    {
        private Home home;
        private GuiasTuristicos guiasTuristico;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private Documentacion.InformaciónAutor infoAutor;
        private Documentacion.Enviar envio;
        public GymkanaPromocion()
        {
            InitializeComponent();
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }

        private void IrAHome(object sender, RoutedEventArgs e)
        {
            home = new Home();
            home.Show();
            Close();
        }

        private void IrAGuiasTuristicos(object sender, RoutedEventArgs e)
        {
            guiasTuristico = new GuiasTuristicos();
            guiasTuristico.Show();
            Close();
        }
        private void opciones(object sender, RoutedEventArgs e)
        {
            btnInformacion.Visibility = Visibility.Visible;
            lbPerfil.Visibility = Visibility.Visible;
            user.Visibility = Visibility.Visible;
            lbInformacion.Visibility = Visibility.Visible;
            lbAyuda.Visibility = Visibility.Visible;
            ayuda.Visibility = Visibility.Visible;
            lbIdioma.Visibility = Visibility.Visible;
            idioma.Visibility = Visibility.Visible;
            lbSalida.Visibility = Visibility.Visible;
            salir.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
            lbAutor.Visibility = Visibility.Visible;
            btnAutor.Visibility = Visibility.Visible;
        }
        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)Idioma.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP"))
                && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
                cambiarBandera("es-ES");
            }
            else if (selectedText.Equals("EN") || selectedText.Equals("IN")
                && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("en-US"));
                cambiarBandera("en-US");
            }
        }
        private void cambiarBandera(string idioma)
        {
            imgIdioma.Source = idioma.Equals("en-US")
            ? new BitmapImage(new Uri("Imagenes/BanderaInglesa.png",
            UriKind.Relative))
            : new BitmapImage(new Uri("Imagenes/BanderaEspañola.png",
            UriKind.Relative));
        }

        private void AbandonarAplicacion(object sender, RoutedEventArgs e)
        {
            abandonarAplicacion = new Documentacion.AbandonarAplicacion();
            abandonarAplicacion.Show();
        }

        public void FechaUltimaVez()
        {
            lbUltimaVez.Content = DateTime.Now.ToShortDateString();
        }

        private void EnviarEmail(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage correoElectronico = new MailMessage();
                correoElectronico.From = new MailAddress(LbDesde.Content.ToString());
                correoElectronico.To.Add(TbPara.Text);
                correoElectronico.Subject = TbAsunto.Text;
                correoElectronico.Body = TbMensaje.Text;

                SmtpClient clienteCorreo = new SmtpClient("smtp.office365.com",587);
                clienteCorreo.Credentials = new NetworkCredential(LbDesde.Content.ToString(), "Paula2002");
                clienteCorreo.EnableSsl = true;
                clienteCorreo.Send(correoElectronico);

                envio = new Documentacion.Enviar();
                envio.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo " + ex.Message);
            }
        }
        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            infoAutor = new Documentacion.InformaciónAutor();
            infoAutor.Show();
        }
    }
}
