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


namespace Juego
{
    class Fruta
    {

        

        public string Nombre { get; set; }
        
        public int Puntos { get; set; }

        Image Imagen { get; set; }

        public enum FrutaCayendo { Fresa, Manzana, Platano, Malo}
        FrutaCayendo frutaActual { get; set; }

        public double velocidad = 350;

        List<BitmapImage> fruta = new List<BitmapImage>();
        public Fruta(Image imagen)
        {
            Imagen = imagen;
            fruta.Add(new BitmapImage(new Uri("imagenes/fresas.png", UriKind.Relative)));
            fruta.Add(new BitmapImage(new Uri("imagenes/platanos.png", UriKind.Relative)));
            fruta.Add(new BitmapImage(new Uri("imagenes/manzanas.png", UriKind.Relative)));

            fruta.Add(new BitmapImage(new Uri("imagenes/malos.png", UriKind.Relative)));
           

        }
        public void cambioFruta ()
        {
            Random random = new Random();
            int frutaElegida = random.Next(0, 3);
            
            switch (frutaElegida)
            {
                case 0:
                    Imagen.Source = fruta[0];
                    Puntos = 50;
                    break;
                case 1:
                    Imagen.Source = fruta[3];
                    Puntos = -60;
                    break;
                case 2:
                    Imagen.Source = fruta[1];
                    Puntos = 30;
                    break;
                case 3:
                    Imagen.Source = fruta[2];
                    Puntos = 40;
                    break;
                default:
                    break;
            }
        }

        
    }

    
}
