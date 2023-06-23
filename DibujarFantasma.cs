using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {   /////////////////////////////////////////////////////////////////////////////
        // Despliega una previsualizacion gris de la posicion de soltar la pieza   //
        /////////////////////////////////////////////////////////////////////////////
        private void DibujarFantasma()
        {   //////////////////////////////////////////////////////////////////////////////////
            // Fantasma2 es la posicion de testeo del fantasma asi como la pieza activa 2   //
            // El array Fantasma es la posicion del fantasma luego del testeo               //
            //////////////////////////////////////////////////////////////////////////////////
            Control[] Fantasma2 = { null, null, null, null };
            bool fantasmaEncontrado = false;
            //////////////////////////////////////
            // Borra el fantasma previo         //
            //////////////////////////////////////
            foreach (Control x in Fantasma) //Por cada cuadradito en el array del fantasma
            {
                if (x != null) //Comprueba que no este vacio
                {
                    if (x.BackColor == Color.LightGray) //Si es gris que es el color del fantasma
                    {
                        x.BackColor = Color.White; //Lo pone del color del grid
                    }
                }
            }
            //////////////////////////////////////////////
            // Copia la pieza activa al fantasma2       //
            //////////////////////////////////////////////
            for (int x = 0; x < 4; x++) //Debido a los 4 cuadritos de la pieza
            {
                Fantasma2[x] = PiezaActiva2[x]; //Almacena el cuadrito segun la posicion
            }
            //////////////////////////////////////////
            // Test del fantasma2 en cada fila      //
            //////////////////////////////////////////
            for (int x = 21; x > 1; x--)
            {
                // El fantasma2 empieza en la ultima fila y se obtiene una posicion
                //Se controla cual es la pieza actual
                //////////////////////////////////////////////////////////////////////////////////////////////
                if (piezaActual == 0) //I pieza
                {   //Se controla cuantas rotaciones hizo
                    if (rotaciones == 0)
                    {
                        if (x == 2)
                        {
                            Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                        }
                        else
                        {
                            Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                            Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 2);
                            Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 3);
                        }
                    }
                    else if (rotaciones == 1)
                    {
                        if (x == 2) //Se ignora
                        {
                            Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                        }

                        else 
                        {
                            Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                            Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                            Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                            Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 1) // L pieza
                {
                    if (rotaciones == 0)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 2);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                    else if (rotaciones == 1)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 1);
                    }
                    else if (rotaciones == 2)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 2);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 2);
                    }
                    else if (rotaciones == 3)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 1);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 2) // J pieza
                {
                    if (rotaciones == 0)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 2);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                    else if (rotaciones == 1)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 1);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                    else if (rotaciones == 2)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 2);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 2);
                    }
                    else if (rotaciones == 3)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 1);
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 3) // S pieza
                {
                    if (rotaciones == 0)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 1);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 1);
                    }
                    else if (rotaciones == 1)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 2);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 1);
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 4) // Z pieza
                {
                    if (rotaciones == 0)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                    else if (rotaciones == 1)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 1);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 2);
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 5) // O pieza
                {
                    Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                    Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                    Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                    Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                }
                //////////////////////////////////////////////////////////////////////////////////////////////
                else if (piezaActual == 6) //T pieza
                {
                    if (rotaciones == 0)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                    else if (rotaciones == 1)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 2);
                    }
                    else if (rotaciones == 2)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x - 1);
                    }
                    else if (rotaciones == 3)
                    {
                        Fantasma2[0] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[0]), x - 1);
                        Fantasma2[1] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[1]), x - 1);
                        Fantasma2[2] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[2]), x - 2);
                        Fantasma2[3] = grid.GetControlFromPosition(grid.GetColumn(Fantasma2[3]), x);
                    }
                }
                //////////////////////////////////
                //  Si no se tiene fantasma     //
                //////////////////////////////////
                if (fantasmaEncontrado == false)
                {
                    // Si todos los cuadritos en el fantasma2 son blancos,
                    if (
                        (Fantasma2[0].BackColor == Color.White | PiezaActiva.Contains(Fantasma2[0])) &
                        (Fantasma2[1].BackColor == Color.White | PiezaActiva.Contains(Fantasma2[1])) &
                        (Fantasma2[2].BackColor == Color.White | PiezaActiva.Contains(Fantasma2[2])) &
                        (Fantasma2[3].BackColor == Color.White | PiezaActiva.Contains(Fantasma2[3]))
                        )
                    {
                        ///////////////////////////////////////////////
                        // Se guarda el fantasma
                        fantasmaEncontrado = true;
                        for (int y = 0; y < 4; y++)
                        {
                            Fantasma[y] = Fantasma2[y]; //Se guarda cada cuadradito del fantasma2 en el fantasma original
                        }
                    }
                    ///////////////////////////////////////////////
                    // Si no todos son blancos (y no se guardo nada) checkea la fila arriba
                    else
                    {
                        continue; //Se continua cambiando de fila
                    }
                }
                //////////////////////////////////////
                //  Si se guardo un fantasma        //
                //////////////////////////////////////
                else if (fantasmaEncontrado == true)
                {
                    ///////////////////////////////////////////////
                    //Y no todos los cuadritos son blancos
                    if (Fantasma2[0].BackColor != Color.White | Fantasma2[1].BackColor != Color.White | Fantasma2[2].BackColor != Color.White | Fantasma2[3].BackColor != Color.White)
                    {
                        ///////////////////////////////////////////////
                        //Si la pieza que cae es menor la fila
                        if (grid.GetRow(PiezaActiva[0]) >= x | grid.GetRow(PiezaActiva[1]) >= x | grid.GetRow(PiezaActiva[2]) >= x | grid.GetRow(PiezaActiva[3]) >= x)
                        {
                            continue; //Se continua cambiando de fila
                        }

                        ///////////////////////////////////////////////
                        //Se resetea el fantasma
                        fantasmaEncontrado = false;
                        for (int y = 0; y < 4; y++) //Por cada cuadradito
                        {
                            Fantasma[y] = null; //Se vacia el array
                        }
                        ///////////////////////////////////////////////
                        continue;//Se sigue recorriendo filas
                    }
                }
            }
            //////////////////////////////////
            //      Dibujar fantasma        //
            //////////////////////////////////
            if (fantasmaEncontrado == true) //Si el fantasma ya esta en las filas
            {
                for (int x = 0; x < 4; x++) //Por cada cuadradito
                {
                    Fantasma[x].BackColor = Color.LightGray; //Se dibuja el fantasma de color gris
                }
            }
        }
    }
}