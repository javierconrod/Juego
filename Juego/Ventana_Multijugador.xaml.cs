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
    /// Lógica de interacción para Ventana_Multijugador.xaml
    /// </summary>
    public partial class Ventana_Multijugador : Window
    {
        public Ventana_Multijugador(MainWindow mainWindow)
        {
            InitializeComponent();
            mainWindow.puntuaciones.Sort((q, p) => p.CantidadPuntos.CompareTo(q.CantidadPuntos));
            foreach (Puntuacion puntuacion in mainWindow.puntuaciones)
            {
                listNombreUsuario.Items.Add(new ListBoxItem()
                {
                    Content = puntuacion.Nombre
                }
                );
            }
            foreach (Puntuacion puntuacion in mainWindow.puntuaciones)
            {
                listCantidadPuntos.Items.Add(new ListBoxItem()
                {
                    Content = puntuacion.CantidadPuntos
                }
                );
            }

        }

        private void ListNombreUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            

        }
    }
}
