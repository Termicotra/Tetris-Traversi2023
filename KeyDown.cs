using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        // Maneja los inputs - por cada presion de tecla
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!CheckGameOver() & ((e.KeyCode == Keys.Left | e.KeyCode == Keys.A) & TestMovimiento("left") == true))
            { //Comprueba que no se termino el juego, y que se presiono la flecha izquierda o la A, y testea si se puede hacer el mov a la izquierda
                MoverPieza("left");
            }
            else if (!CheckGameOver() & ((e.KeyCode == Keys.Right | e.KeyCode == Keys.D) & TestMovimiento("right") == true))
            {//Comprueba que no se termino el juego, y que se presiono la flecha derecha o la D, y testea si se puede hacer el mov a la derecha
                MoverPieza("right");
            }
            else if ((e.KeyCode == Keys.Down | e.KeyCode == Keys.S) & TestMovimiento("down") == true)
            {//Comprueba que se presiono la flecha abajo o la S, y testea si se puede hacer el mov abajo
                MoverPieza("down");
            }
            else if (e.KeyCode == Keys.Up | e.KeyCode == Keys.W) //Comprueba si se presiono la flechita arriba o la W
            {
                //Se obtiene las posiciones de cada cuadrito de la pieza

                int square1Col = grid.GetColumn(PiezaActiva[0]);
                int square1Row = grid.GetRow(PiezaActiva[0]);

                int square2Col = grid.GetColumn(PiezaActiva[1]);
                int square2Row = grid.GetRow(PiezaActiva[1]);

                int square3Col = grid.GetColumn(PiezaActiva[2]);
                int square3Row = grid.GetRow(PiezaActiva[2]);

                int square4Col = grid.GetColumn(PiezaActiva[3]);
                int square4Row = grid.GetRow(PiezaActiva[3]);

                if (piezaActual == 0) //La pieza I
                {
                    //Testea si la pieza esta cerca de uno de los bordes del grid
                    if (rotaciones == 0 & (square1Col == 0 | square1Col == 1 | square1Col == 9))
                    {
                        return; //Si es que esta cerca del borde, no retorna nada y acaba la funcion principal de deteccion de tecla
                    }
                    else if (rotaciones == 1 & (square3Col == 0 | square3Col == 1 | square3Col == 9))
                    {
                        return;
                    }

                    //Si paso el test se rota la pieza
                    if (rotaciones == 0) //Si todavia no se roto
                    {   //Se carga en el array de control de mov de la pieza, cada cuadrito con su nueva posicion
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col - 2, square1Row); 
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col - 1, square2Row - 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row - 2);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row - 3);

                        //Testea si la nueva rotacion choca con alguna pieza y si es asi cancela la rotacion
                        if (TestColision() == true)
                        {
                            rotaciones++; //Si no choca con nada se aumenta el contador de rotacion
                        }
                        else
                        {
                            return; //SI no se deja asi como estaba
                        }
                    }
                    else if (rotaciones == 1) //Si ya se habia rotado
                    {   //Se vuelve a cargar el array de control de mov, con los cuadritos en sus nuevas posiciones
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 2, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col + 1, square2Row + 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row + 2);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col - 1, square4Row + 3);

                        if (TestColision() == true) //De nuevo se comprueba si choca o no
                        {
                            rotaciones = 0; //Si no choca se dice que volvio a su posicion original ya que es la pieza I
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (piezaActual == 1) //La pieza L 
                {
                    //Testea si la pieza esta cerca del borde
                    if (rotaciones == 0 & (square1Col == 8 | square1Col == 9))
                    {
                        return;
                    }
                    else if (rotaciones == 2 & (square1Col == 9))
                    {
                        return;
                    }

                    //Si pasa el test, se rota la pieza
                    if (rotaciones == 0)
                    {   //Si se sabe que no tiene todavia una rotacion, se cargan los cuadraditos y su nueva posicion en el array de movimiento
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row + 2);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col + 1, square2Row + 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col + 2, square3Row);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row - 1);

                        //Controla si choca o no, para decidir si cancelar la rotacion
                        if (TestColision() == true)
                        {
                            rotaciones++; //Si no choca se dice que ya se roto una vez
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 1) //Si ya estaba rotada una vez
                    {   //Se carga en el array de mov, las nuevas posiciones de los cuadraditos
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 1, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row - 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row - 2);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col - 2, square4Row - 1);

                        //Controla si choca con algo, si es asi se cancela
                        if (TestColision() == true)
                        {
                            rotaciones++; //Se dice que aumento una rotacion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 2) //Si ya estaba rotada por segunda vez
                    {   //Se vuelve a cargar en el array de movimiento, los cuadritos con su nuevas posiciones
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 1, square1Row - 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row + 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row + 2);

                        //SI choca con algo, se cancela la rotacion
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 3) //Si ya se roto 3 veces
                    {   //Se carga
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col - 2, square1Row - 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col - 1, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row + 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row);

                        //Se comprueba
                        if (TestColision() == true)
                        {
                            rotaciones = 0; //Se dice que llego a su posicion normal
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (piezaActual == 2) //La J
                {
                    //Controla si la pieza esta cerca del borde
                    if (rotaciones == 0 & (square1Col == 0 | square1Col == 1))
                    {
                        return;
                    }
                    else if (rotaciones == 2 & square1Col == 0)
                    {
                        return;
                    }

                    //Si se pasa el test, se rota la pieza
                    if (rotaciones == 0)
                    {  //Se carga el array
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col - 2, square1Row + 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col - 1, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row - 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row);

                        //Controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 1) //Si ya se roto una vez
                    {   //Se carga
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 1, square1Row + 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row - 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row - 2);

                        //Si choca se cancela la rotacion
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 2) //Si ya se roto 2 veces
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 1, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row + 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row + 2);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col - 2, square4Row + 1);

                        //Si choca se cancela la rotacion
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 3) //Si ya se roto 3 veces
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row - 2);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col + 1, square2Row - 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col + 2, square3Row);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row + 1);

                        //Controla si choca para cancelar o no
                        if (TestColision() == true)
                        {
                            rotaciones = 0; //Se dice que llego a la posicion normal
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (piezaActual == 3) //La S
                {
                    //Testea si se esta cerca del borde
                    if (rotaciones == 0 & (square1Row == 1 | square1Col == 9))
                    {
                        return;
                    }
                    else if (rotaciones == 1 & square1Col == 0)
                    {
                        return;
                    }

                    //Si pasa el test, se rota la pieza
                    if (rotaciones == 0)
                    {

                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col + 1, square1Row - 2);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row - 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col + 1, square3Row);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row + 1);


                        //Controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 1) //Si ya se roto una vez
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col - 1, square1Row + 2);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row + 1);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row - 1);

                        //Controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones = 0; //Vuelve a su posicion normal
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (piezaActual == 4) //La pieza Z
                {
                    //Controla si se esta cerca del borde
                    if (rotaciones == 1 & square1Col == 8)
                    {
                        return;
                    }

                    //Si pasa el test, se rota
                    if (rotaciones == 0)
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row + 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col - 1, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row - 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col - 1, square4Row - 2);

                        //Se controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 1) //Si ya se roto una vez
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row - 1);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col + 1, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col, square3Row + 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 1, square4Row + 2);

                        //Controla que no choca con nada
                        if (TestColision() == true)
                        {
                            rotaciones = 0;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (piezaActual == 5) //Pieza O
                {
                    //El cuadrado no se puede rotar
                    return;
                }
                else if (piezaActual == 6) //Pieza T
                {
                    //Controla si se esta cerca del borde
                    if (rotaciones == 1 & square1Col == 9)
                    {
                        return;
                    }
                    else if (rotaciones == 3 & square1Col == 0)
                    {
                        return;
                    }

                    //Si pasa el test, se rota la pieza
                    if (rotaciones == 0)
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row - 2);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row - 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col - 2, square4Row);

                        //Controla si choca con algo para cancelar o no
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 1) //Si ya se roto una vez
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col + 2, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col + 1, square3Row - 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row - 2);

                        //Controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 2) //Si ya se roto 2 veces
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col, square2Row + 2);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col + 1, square3Row + 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col + 2, square4Row);

                        //Controla si choca con algo
                        if (TestColision() == true)
                        {
                            rotaciones++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (rotaciones == 3) //Si ya se roto 3 veces
                    {
                        PiezaActiva2[0] = grid.GetControlFromPosition(square1Col, square1Row);
                        PiezaActiva2[1] = grid.GetControlFromPosition(square2Col - 2, square2Row);
                        PiezaActiva2[2] = grid.GetControlFromPosition(square3Col - 1, square3Row + 1);
                        PiezaActiva2[3] = grid.GetControlFromPosition(square4Col, square4Row + 2);

                        //Controla que no choca
                        if (TestColision() == true)
                        {
                            rotaciones = 0; //Vuelve a su posicion normal
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                //Hace que la antigua posicion antes de la rotacion se convierta en el color del grid
                foreach (PictureBox square in PiezaActiva)
                {
                    square.BackColor = Color.White; //Pinta cada cuadradito en blanco
                }

                DibujarFantasma(); //Por cada deteccion de tecla se vuelve a dibujar al fantasma abajo

                //Todos los cuadraditos con sus nuevas posiciones los pone del color de la pieza
                int x = 0;
                foreach (PictureBox square in PiezaActiva2)
                {
                    square.BackColor = colorList[piezaActual]; //Obtiene el color segun el nro de pieza y lo pinta
                    PiezaActiva[x] = square; //Asigna la posicion a el array de la pieza original
                    x++;
                }
            }
            else if (!CheckGameOver() & e.KeyCode == Keys.X) //Comprueba si el juego ya acabo, y si se presiono la tecla de X
            {
                // Si se presiono x se hace un drop de la ficha, osea un hard drop
                for (int x = 0; x < 4; x++) //Por cada cuadradito
                {
                    Fantasma[x].BackColor = colorList[piezaActual]; //Ya que sabemos que el fantasma esta en la ultima fila posible, lo pintamos del color de la pieza
                    PiezaActiva[x].BackColor = Color.White; //DOnde estaba la pieza lo pintamos del color del tablero
                }
                if (CheckFilasLlenas() > -1) //Comprobamos si hay filas llenas
                {
                    ClearFilaLlena(); //Si es asi se limpia
                }
                SoltarNuevaPieza(); //Y se construye una nueva pieza para lanzar
            }
            else if (!CheckGameOver() & e.KeyCode == Keys.Space) //Comprueba si el juego ya acabo, y si se presiono la tecla de X
            {
                // Si se presiono x se hace un drop de la ficha, osea un hard drop
                for (int x = 0; x < 4; x++) //Por cada cuadradito
                {
                    Fantasma[x].BackColor = colorList[piezaActual]; //Ya que sabemos que el fantasma esta en la ultima fila posible, lo pintamos del color de la pieza
                    PiezaActiva[x].BackColor = Color.White; //DOnde estaba la pieza lo pintamos del color del tablero
                }
                if (CheckFilasLlenas() > -1) //Comprobamos si hay filas llenas
                {
                    ClearFilaLlena(); //Si es asi se limpia
                }
                SoltarNuevaPieza(); //Y se construye una nueva pieza para lanzar
            }
        }
    }
}