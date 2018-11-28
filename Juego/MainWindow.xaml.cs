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

using System.Threading;
using System.Diagnostics;


namespace Juego
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  List<Puntuacion> puntuaciones = new List<Puntuacion>();

        public MainWindow()
        {
            puntuaciones.Add(new Puntuacion("El Cacas", 3000));
            puntuaciones.Add(new Puntuacion("Masiosare", 1200));
            puntuaciones.Add(new Puntuacion("El Jojo", 800));

            InitializeComponent();

        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_JugadorUno_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Juego ventana_Juego = new Ventana_Juego(this);

            Hide();
            ventana_Juego.Show();
        }

        private void btn_Multijugador_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Multijugador ventana_Multijugador = new Ventana_Multijugador(this);
            ventana_Multijugador.Show();
        }

        private void Btn_Competitivo_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Juego ventana_Competitivo = new Ventana_Juego(this);
            ventana_Competitivo.Show();
        }
    }
}
