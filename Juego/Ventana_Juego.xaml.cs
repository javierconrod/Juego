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

using System.Windows.Threading;

using System.Threading;
using System.Diagnostics;

namespace Juego
{
    /// <summary>
    /// Lógica de interacción para Ventana_Juego.xaml
    /// </summary>
    public partial class Ventana_Juego : Window
    {
        public List<Puntuacion> puntuaciones = new List<Puntuacion>();
        Stopwatch stopwatch;
        TimeSpan tiempoAnterior;
        enum EstadoJuego { GameplaySingle, GameplayCompetitivo, Menu };
        
        EstadoJuego EstadoJuegoActual = EstadoJuego.GameplaySingle;
        MainWindow mainWindow;
        Random rnd = new Random();

        enum Direccion { Izquierda, Derecha, Ninguna};
        Direccion direccionActual = Direccion.Ninguna;
        bool jugando = true;
        Fruta Fila1;
        Fruta Fila2;
        Fruta Fila3;
        Fruta Fila4;
        Puntuacion puntaje = new Puntuacion();

        int time = 60;
        DispatcherTimer Timer;

        public Ventana_Juego( MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            foreach(Puntuacion puntuacion in puntuaciones)
            {
                this.puntuaciones.Add(puntuacion);
            }
            puntaje.CantidadPuntos = 0;
            canvasJuegoSingle.Focus();

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            Fila1 = new Fruta(carril1);
            Fila1.Puntos = 30;
            Fila2 = new Fruta(carril2);
            Fila2.Puntos = 20;
            Fila3 = new Fruta(carril3);
            Fila3.Puntos = 10;
            Fila4 = new Fruta(carril4);
            Fila4.Puntos = 30;

            stopwatch = new Stopwatch();
            stopwatch.Start();

            ThreadStart threadStart = new ThreadStart(actualizar);
            Thread threadMoverEnemigos = new Thread(threadStart);
            

            threadMoverEnemigos.Start();
            
        }

        void moverJugador(double deltaTime)
        {
            
            switch(direccionActual)
            {
                case Direccion.Derecha:
                   
                    break;
                case Direccion.Izquierda:
                    
                    break;
                case Direccion.Ninguna:
                    break;
                default:
                    break;
            }
        }

        void actualizar()
        {
            while (jugando==true)
            {
                Dispatcher.Invoke(
                    () =>
                    {
                       
                        var tiempoActual = stopwatch.Elapsed;
                        var deltaTime = tiempoActual.TotalSeconds - tiempoAnterior.TotalSeconds;

                        int velocidadFruta = rnd.Next(100, 500);

                        if (EstadoJuegoActual == EstadoJuego.GameplaySingle)
                        {
                           

                            double yCarril1 = Canvas.GetTop(carril1);
                            double xCarril1 = Canvas.GetLeft(carril1);
                            Canvas.SetTop(carril1, yCarril1 + Fila1.velocidad * deltaTime);
                            if(yCarril1 >= 760)
                            {
                                Fila1.cambioFruta();
                                Canvas.SetTop(carril1, -135);
                            }

                            
                            double xCanasta = Canvas.GetLeft(jugadorUno);
                            double yCanasta = Canvas.GetTop(jugadorUno);

                            if (xCanasta + jugadorUno.Width >= xCarril1 && xCanasta <= xCarril1 + carril1.Width && yCanasta + jugadorUno.Height >= yCarril1 && yCanasta <= yCarril1 + carril1.Height)
                            {
                               colisiones(Fila1.Puntos);
                                Canvas.SetTop(carril1, -135);
                                Fila1.cambioFruta();
                                Fila1.velocidad += 15;
                            }
                            double yCarril2 = Canvas.GetTop(carril2);
                            double xCarril2 = Canvas.GetLeft(carril2);
                            Canvas.SetTop(carril2, yCarril2 + Fila2.velocidad * deltaTime);
                            if (yCarril2 >= 760)
                            {
                                Fila2.cambioFruta();
                                Canvas.SetTop(carril2, -135);
                            }

                            if (xCanasta + jugadorUno.Width >= xCarril2 && xCanasta <= xCarril2 + carril2.Width && yCanasta + jugadorUno.Height >= yCarril2 && yCanasta <= yCarril2 + carril2.Height)
                            {
                               colisiones(Fila2.Puntos);
                                Canvas.SetTop(carril2, -135);
                                Fila2.cambioFruta();
                                Fila2.velocidad += 18;
                            }
                            double yCarril3 = Canvas.GetTop(carril3);
                            double xCarril3 = Canvas.GetLeft(carril3);
                            Canvas.SetTop(carril3, yCarril3 + Fila3.velocidad * deltaTime);
                            if (yCarril3 >= 760)
                            {
                                Fila3.cambioFruta();
                                Canvas.SetTop(carril3, -135);
                            }

                            if (xCanasta + jugadorUno.Width >= xCarril3 && xCanasta <= xCarril3 + carril3.Width && yCanasta + jugadorUno.Height >= yCarril3 && yCanasta <= yCarril3 + carril3.Height)
                            {
                                colisiones(Fila3.Puntos);
                                Canvas.SetTop(carril3, -135);
                                Fila3.cambioFruta();
                                Fila3.velocidad += 10;
                            }
                            double yCarril4 = Canvas.GetTop(carril4);
                            double xCarril4 = Canvas.GetLeft(carril4);
                            Canvas.SetTop(carril4, yCarril4 + Fila4.velocidad * deltaTime);
                            if (yCarril4 >= 760)
                            {
                                Fila4.cambioFruta();
                                Canvas.SetTop(carril4, -135);
                            }

                            if (xCanasta + jugadorUno.Width >= xCarril4 && xCanasta <= xCarril4 + carril4.Width && yCanasta + jugadorUno.Height >= yCarril4 && yCanasta <= yCarril4 + carril4.Height)
                            {
                                colisiones(Fila4.Puntos);
                                Canvas.SetTop(carril4, -135);
                                Fila4.cambioFruta();
                                Fila4.velocidad += 20;
                            }
                        }
                        else if (EstadoJuegoActual == EstadoJuego.Menu)
                        {

                        }
                        tiempoAnterior = tiempoActual;

                    }   
                    );

            }
        }

        void colisiones(int puntos)
        {
            puntaje.CantidadPuntos += puntos;
            
            lblColision.Text = puntaje.CantidadPuntos.ToString();
        }

        private void canvasJuegoSingle_KeyDown(object sender, KeyEventArgs e)
        {
            double derechaJugadorUno = Canvas.GetLeft(jugadorUno);
            
            if (e.Key == Key.D)
            {
                if (derechaJugadorUno != 378)
                {
                    Canvas.SetLeft(jugadorUno, derechaJugadorUno + 117);
                }
            }
            if(e.Key == Key.A)
            {
                if (derechaJugadorUno != 27)
                {
                    Canvas.SetLeft(jugadorUno, derechaJugadorUno - 117);
                }
            }
        }

        private void canvasJuegoSingle_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)

            {
                if (time <= 10)

                {
                    TBcountdown.Foreground = Brushes.Red;
                    time--;
                    TBcountdown.Text = string.Format("00:0{0}:0{1}", time / 60, time % 60);
                }
                else
                {
                    time--;
                    TBcountdown.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);
                }
            }
            else
            {
                Timer.Stop();
                jugando = false;
                Canvas.SetTop(carril1, -135);
                Canvas.SetTop(carril2, -135);
                Canvas.SetTop(carril3, -135);
                Canvas.SetTop(carril4, -135);

                imgTiempoTerminado.Visibility = Visibility.Visible;
                txtNombreJugador.Visibility = Visibility.Visible;
                btnGuardar.Visibility = Visibility.Visible;
                Canvas.SetLeft(lblColision, 240);
                Canvas.SetTop(lblColision, 100);
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            mainWindow.puntuaciones.Add(new Puntuacion(txtNombreJugador.Text, puntaje.CantidadPuntos));
            this.Close();
        }

        private void TxtNombreJugador_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNombreJugador.Text = "";
        }
    }
}

