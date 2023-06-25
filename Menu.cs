using System;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Menu : Form
    {
        //////////////////////////////////////////////////////////////////
        MainWindow mainWindow = new MainWindow();   //Se crea el objeto, para luego llamarlo
        //////////////////////////////////////////////////////////////////
        public Menu()   //Constructor
        {
            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////
        private void buttonCloseAdmin_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Se cierra la Aplicacion
        }
        //////////////////////////////////////////////////////////////////
        private void bJugar_Click(object sender, EventArgs e)   //Cuando se clickea en el boton de jugar
        {
            this.Hide();
            mainWindow.Show();  //Se esconde este formulario de menu, y se muestra el de la ventana principal
        }
        //////////////////////////////////////////////////////////////////
        private void bReglas_Click(object sender, EventArgs e)      //Al darle al boton de Reglas
        {
            MessageBox.Show("El jugador no puede impedir la caída de los tetriminos, pero puede decidir la rotación de la pieza" +
                "\r\n(0°, 90°, 180°, 270°) y en qué lugar debe caer. Cuando una línea horizontal se completa, esa" +
                "\r\nlínea desaparece y todas las piezas que están por encima descienden una posición, liberando" +
                "\r\nespacio de juego y por tanto facilitando la tarea de situar nuevas piezas. La caída de las piezas se" +
                "\r\nacelera progresivamente. El juego acaba cuando las piezas se amontonan hasta llegar a lo más" +
                "\r\nalto, interfiriendo la creación de más piezas y finalizando el juego.");   //Se muestran las reglas del tp
        }   
        //////////////////////////////////////////////////////////////////
        private void bAutor_Click(object sender, EventArgs e)   //Al darle al boton de autor
        {
            MessageBox.Show("Creador: Federico Traversi");  //Se muestra el autor
        }
    }
}
