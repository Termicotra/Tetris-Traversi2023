using System;
using System.Collections.Generic;
using System.Drawing;   //Usamos la libreria para colorear y dibujar
using System.Linq;      //Libreria para manipular mas sencillamente las colecciones de datos
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        ////////////////////////////////
        //      Ventana Principal     //
        ////////////////////////////////
                                                            // Inicializamos las variables Globales
                                                            // Control[] hace referencia a un tipo de objeto que representa una pieza en un juego
        Control[] PiezaActiva = { null, null, null, null }; //Inicializamos el array para almacenar la pieza activa 
        Control[] PiezaActiva2 = { null, null, null, null };//Inicializamos el array para testear la posicion de la pieza activa
        Control[] PiezaSigt = { null, null, null, null };   //Inicializamos el array para la pieza siguiente
        Control[] Fantasma = { null, null, null, null };    //Inicializamos el array para el bloque fantasma
        List<int> SecuenciaPieza = new List<int>();         //Creamos una lista para poder almacenar las secuencias de las piezas
        int time = 0;                                       //Creamos una variable para ir controlando el tiempo de juego
        int piezaActual;                                    //Creamos un entero para controlar que pieza es la actual
        int sigtPiezaInt;                                   //Creamos un entero para controlar que pieza es la siguiente
        int rotaciones = 0;                                 //Creamos un entero para controlar las rotaciones
        Color piezaColor = Color.White;                     //Creamos una variable de color para darle un color inicial a la pieza
        int combo = 0;                                      //Creamos una variable para guardar la cantidad de combos
        int score = 0;                                      //Creamos una variable para controlar el score
        int clears = 0;                                     //Creamos una variable para saber las filas limpiadas
        int nivel = 0;                                      //Creamos una variable para controlar el nivel actual
        bool gameOver = false;                              //Creamos una variable booleana para controlar el final del juego
        int SecuenciaIteracionPieza = 0;                    //Creamos una variable para poder controlar las secuencias de iteracion de una pieza
        ///////////////////////////////////////////////
        readonly Color[] colorList =  //Creamos un array de solo lectura que almacenas los colores de los tetriminos
        {
            Color.Red,      // I pieza
            Color.Yellow,   // L pieza
            Color.Magenta,  // J pieza
            Color.Blue,     // S pieza
            Color.Green,    // Z pieza
            Color.Cyan,     // O pieza
            Color.Gray      // T pieza
        };
        ///////////////////////////////////////////////
        public MainWindow()     //Constructor
        {
            InitializeComponent();
        }
        ///////////////////////////////////////////////
        public void SoltarNuevaPieza()
        {
            // Resetea el numero de veces que la pieza se roto
            rotaciones = 0;

            // Hace que la que era nueva pieza, se convierta en la pieza actual
            piezaActual = sigtPiezaInt;

            // Si se llego al maximo de iteraciones de secuencia, se genera una nueva
            if (SecuenciaIteracionPieza == 7)
            {
                SecuenciaIteracionPieza = 0;

                // Se vuelve a cargar las secuencias de piezas
                SecuenciaPieza.Clear();
                System.Random random = new System.Random();
                while (SecuenciaPieza.Count < 7)
                {
                    int x = random.Next(7);
                    if (!SecuenciaPieza.Contains(x))
                    {
                        SecuenciaPieza.Add(x);
                    }
                }
            }
            //////////////////////////////////////////////
            // Selecciona una nueva pieza de la lista   //
            //////////////////////////////////////////////
            sigtPiezaInt = SecuenciaPieza[SecuenciaIteracionPieza]; //Segun el contador de cuantas veces se hizo el bucle
            SecuenciaIteracionPieza++;                              //Osea la lista se llena y se vacia constantemente de piezas
            ///////////////////////////////////////////////////////////////////////////
            // Si no es el primer movimiento, se limpia el panel de pieza siguiente  //
            ///////////////////////////////////////////////////////////////////////////
            if (PiezaSigt.Contains(null) == false)  //Se comprueba que tenga null para saber si es el primer movimiento
            {
                foreach (Control x in PiezaSigt)    //Si no por cada variable de control 
                {
                    x.BackColor = Color.White;      //Va a limpiar esa variable, poniendole el color original de inicio que es blanco
                }
            }
            ////////////////////////////////////////////////
            // Opciones de diseno para la pieza siguiente //
            ////////////////////////////////////////////////
            Control[,] SigtPiezaArray =     //Aca se guardan las posiciones que ocuparan en las box, las piezas correspondientes
            {
                { box203, box207, box211, box215 }, // I pieza      //Por ejemplo la pieza i ocupara todo una linea del panel de siguiente pieza
                { box202, box206, box210, box211 }, // L pieza
                { box203, box207, box211, box210 }, // J pieza
                { box206, box207, box203, box204 }, // S pieza
                { box202, box203, box207, box208 }, // Z pieza
                { box206, box207, box210, box211 }, // O pieza
                { box207, box210, box211, box212 }  // T pieza
            };
            //////////////////////////////////////////////
            // Recuperar diseno de la siguiente pieza   //
            //////////////////////////////////////////////
            for (int x = 0; x < 4; x++) //Sabiendo que la piezas tienen 4 bloquesitos
            {
                PiezaSigt[x] = SigtPiezaArray[sigtPiezaInt, x]; //Se va cargando en el array de pieza siguiente, segun que pieza mediante su valor int
            }                                                    //Y segun que bloquecito carga del array de disenos de piezas
            //////////////////////////////////////////////////////////////////
            // Rellena el panel de pieza siguiente con el color correcto    //
            //////////////////////////////////////////////////////////////////
            foreach (Control square in PiezaSigt)   //Por cada bloquesito
            {
                square.BackColor = colorList[sigtPiezaInt]; //Se carga el color en el box, de la lista de colores, segun el nro de pieza
            }
            ///////////////////////////////////////////////
            // Opciones de diseno para la pieza cayendo  //
            ///////////////////////////////////////////////
            Control[,] PiezaActivaArray =       //Se guarda el diseno de cada pieza en el tablero actual
            {
                { box6, box16, box26, box36 }, // I pieza   //Por ejemplo se sabe que la pieza i va a ocupar una linea de colores del tablero 
                { box4, box14, box24, box25 }, // L pieza
                { box5, box15, box25, box24 }, // J pieza
                { box14, box15, box5, box6 },  // S pieza
                { box5, box6, box16, box17 },  // Z pieza
                { box5, box6, box15, box16 },  // O pieza
                { box6, box15, box16, box17 }  // T pieza
            };
            ///////////////////////////////////////////////
            // Pieza caida seleccionada
            for (int x = 0; x < 4; x++) //Ya que sabemos que hay 4 bloquecitos por pieza
            {
                PiezaActiva[x] = PiezaActivaArray[piezaActual, x];  //Cargamos en el array de pieza actual, el diseno segun el array de disenos de piezas activas
            }                                                       //Dependiendo de que nro de pieza es y que box ocupara

            // Esto es necesario para la funcion de dibujar al fantasma
            for (int x = 0; x < 4; x++) //Sabiendo tambien que hay 4 bloquecitos
            {
                PiezaActiva2[x] = PiezaActivaArray[piezaActual, x]; //Cargamos el bloque asi como hicimos solo que ahora en el array del bloque fantasma
            }
            //////////////////////////////////////
            // Controla que el juego no acabo   //
            //////////////////////////////////////
            foreach (Control box in PiezaActiva) //Por cada box que hay en el array de pieza activa
            {
                if (box.BackColor != Color.White & box.BackColor != Color.LightGray) //Controlamos que el color del box es distinto a los colores de la grilla, se dice que se alcanzo el tope
                {
                    //Si no se cumplio se declara un Game over!
                    SpeedTimer.Stop();  //Se detiene ambos temporizadores del juego
                    GameTimer.Stop();
                    gameOver = true;    //Se carga un valor verdadero en la variable booleana
                    MessageBox.Show("Game over!");  //Se muestra al usuario que perdio
                    bPlay.Visible = true;
                    return; //Termina el programa
                }
            }
            ///////////////////////////////////////////////////////////
            // Se llama a la funcion para dibujar la pieza fantasma  //
            ///////////////////////////////////////////////////////////
            DibujarFantasma();
            //////////////////////////////////////////////////////////////////////////////////
            // Rellena los cuadritos del tablero con el color correcto de la pieza activa   //
            //////////////////////////////////////////////////////////////////////////////////
            foreach (Control square in PiezaActiva)
            {
                square.BackColor = colorList[piezaActual]; //Segun el int de la pieza actual se elige el color en la lista y se rellena
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Se testea que un movimiento (left/right/down) va a estar afuera del grid o se colapsa con una pieza      //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool TestMovimiento(string direction) //FUncion que devuelve true o false segun si se puede o no hacer un movimiento, y recibe la direccion
        {
            int filaAltaActual = 21;    
            int filaBajaActual = 0;
            int columnaIzqActual = 9;
            int columnaDerActual = 0;

            int sigtCuadrado = 0;  //variable para controlar cual es  el sigt cuadrado

            Control nuevoCuadrado = new Control(); //Variable del tipo control para el nuevo cuadrado

            //////////////////////////////////////////////////////////////////////////////////////////////
            // Determina la fila mas alta, mas baja,columnas, izquierda y derecha para el movimiento    //
            //////////////////////////////////////////////////////////////////////////////////////////////
            foreach (Control square in PiezaActiva) //Por cada cuadradito en el array de pieza activa
            {
                if (grid.GetRow(square) < filaAltaActual) //Controla que al obtener la fila donde esta la ficha sea menor a la fila mas alta
                {
                    filaAltaActual = grid.GetRow(square);   //Si es asi le asigna a esa fila como la mas alta
                }
                if (grid.GetRow(square) > filaBajaActual)   //Controla que la fila obtenida de la pieza sea mayor a la fila mas baja
                {
                    filaBajaActual = grid.GetRow(square);   //Si es asi le asigna a la fila mas baja
                }
                if (grid.GetColumn(square) < columnaIzqActual)  //Controla que la columna de la pieza sea menor a la columna actual
                {
                    columnaIzqActual = grid.GetColumn(square); //Si es asi le asigna a esa columna
                }
                if (grid.GetColumn(square) > columnaDerActual)  //Compueba que la columna de la pieza sea mayor a la columna actual
                {
                    columnaDerActual = grid.GetColumn(square);  //Si es asi le asigna esa columna
                }
            }
            //////////////////////////////////////////////////////////////
            // Controla si cada cuadrito no se va a pasar del grid      //
            //////////////////////////////////////////////////////////////
            foreach (Control square in PiezaActiva)
            {
                int squareFila = grid.GetRow(square);  //Asigna la fila del cuadrito
                int squareColum = grid.GetColumn(square);   //Asigna la columna del cuadrito

                // Dado el movimiento de flecha a la izquierda
                if (direction == "left" & squareColum > 0) //Si la direccion es a izquierda y la columna es mayor a cero
                {
                    nuevoCuadrado = grid.GetControlFromPosition(squareColum - 1, squareFila);   //Mueve el nuevo cuadrado una columna atras
                    sigtCuadrado = columnaIzqActual;        //Guarda que el sigt cuadradito esta en la columna izquierda actual
                }
                else if (direction == "left" & squareColum == 0) //Controla que si el mov es de izquierda y ya se alcanzo el limite a la izquierda del grid
                {
                    // El movimiento a la izquierda va a estar a fuera de la grilla
                    return false;   //Retorna que no se puede efectuar el movimiento
                }

                // Dado el movimiento de flecha a la derecha
                else if (direction == "right" & squareColum < 9) //Si el movimiento es a la derecha y es menor al limite de la grilla por derecha
                {
                    nuevoCuadrado = grid.GetControlFromPosition(squareColum + 1, squareFila); //Se mueve el cuadrado a una columna a la derecha
                    sigtCuadrado = columnaDerActual;    //Se guarda cual es la columna derecha actual
                }
                else if (direction == "right" & squareColum == 9) //Si el mov es a la derecha pero ya se alcanzo el limite de la grilla por derecha
                {
                    // El movimiento de derecha esta fuera de la grilla
                    return false; //Se retorna que el mov no fue valido
                }

                // Dado el movimiento de flechita abajo
                else if (direction == "down" & squareFila < 21) //Si el movimiento fue abajo y es menor al limite de fila de la grilla
                {
                    nuevoCuadrado = grid.GetControlFromPosition(squareColum, squareFila + 1); //Se mueve el cuadrado una fila por debajo
                    sigtCuadrado = filaBajaActual;  //Se guarda la fila baja actual
                }
                else if (direction == "down" & squareFila == 21)    //Si el movimiento es de abajo y ya se alcanzo el limite de fila de la grilla
                {
                    return false; //Se retorna que el mov no es valido
                    // El movimiento de abajo estara afuera de la grilla
                }

                // Controla que el movimiento no se solape con otra pieza
                if ((nuevoCuadrado.BackColor != Color.White & nuevoCuadrado.BackColor != Color.LightGray) //Si el nuevo movimiento del cuadrado tiene un color distinto que de la grilla
                    & PiezaActiva.Contains(nuevoCuadrado) == false & sigtCuadrado > 0) //Si el nuevo cuadradito no esta en la pieza activa y el valor del sigt cuadrado es mayor a cero
                {
                    return false; //Se retorna que el movimiento no es valido
                }

            }
            // Se controlaron que se pueden hacer los movimientos
            return true; //Entonces se retorna true
        }
        //////////////////////////////////////////////////////////////
        // Funcion para mover la pieza recibiendo la direccion      //
        //////////////////////////////////////////////////////////////
        public void MoverPieza(string direction) 
        {
            // Borra la vieja posicion de la pieza
            // Y determina la nueva posicion segun la direccion
            int x = 0; //Variable para controlar la posicion dentro del array
            foreach (PictureBox square in PiezaActiva) //Por cada imagen en el box de la pieza activa
            {
                square.BackColor = Color.White;  //Se pinta el box de blanco
                int squareFila = grid.GetRow(square); //Obtiene y asigna la fila del cuadrado
                int squareColum = grid.GetColumn(square); //Obtiene y asigna la columna del cuadrado
                int nuevoCuadradoFila = 0; //Creamos una variable para saber la nueva fila
                int nuevoCuadradoColum = 0; //Creamos una variable para saber la nueva columna
                if (direction == "left") //Si la direccion es a la izquierda
                {
                    nuevoCuadradoColum = squareColum - 1; //Se mueve una columna a la izquierda
                    nuevoCuadradoFila = squareFila;       //Se mantiene la fila
                }
                else if (direction == "right")  //Si la direccion es a la derecha
                {
                    nuevoCuadradoColum = squareColum + 1; //Se aumenta una columna a la derecha
                    nuevoCuadradoFila = squareFila;  //Se mantiene la fila
                }
                else if (direction == "down") //Sie el movimiento es abajo
                {
                    nuevoCuadradoColum = squareColum;   //Se mantiene la columna
                    nuevoCuadradoFila = squareFila + 1; //Y se baja una fila abajo
                }

                PiezaActiva2[x] = grid.GetControlFromPosition(nuevoCuadradoColum, nuevoCuadradoFila);  //Se obtiene el control que esta en la nueva posicion
                x++;   //Se mueve el array                                                     //del cuadrado y se asigna al array de la posicion del bloque
            }
            //////////////////////////////////////////////////////
            // Se copia el bloque de respaldo al bloque activo  //
            //////////////////////////////////////////////////////
            x = 0; //Variable para controlar la posicion dentro del array
            foreach (PictureBox square in PiezaActiva2) //Por cada imagen o box en el array del bloque de posicion
            {

                PiezaActiva[x] = square; //Asiganamos ese cuadradito al array de la pieza activa segun la posicion
                x++;
            }
            //////////////////////////////////////
            // Dibujar el bloque fantasma       //
            //////////////////////////////////////
            DibujarFantasma();
            //////////////////////////////////////////////
            // Dibuja la nueva posicion de la pieza     //
            //////////////////////////////////////////////
            x = 0; //se controla la posicion en el array
            foreach (PictureBox square in PiezaActiva2) //Por cada box en el array de posicion de la pieza
            {
                square.BackColor = colorList[piezaActual]; //Se pinta el cuadradito segun el color de la pieza actual
                x++;
            }
        }
        //////////////////////////////////////////////////////////
        // Testea si la rotacion va a chocar con alguna pieza   //
        //////////////////////////////////////////////////////////
        private bool TestColision()
        {
            foreach (PictureBox square in PiezaActiva2) //Por cada box dentro del array de la pieza de respaldo
            {
                if ((square.BackColor != Color.White & square.BackColor != Color.LightGray) & PiezaActiva.Contains(square) == false)
                {   //Si los colores del cuadrado son distintos al grid y la piezaactiva no contiene el cuadradito actual
                    return false; //Si es asi se retorna falso ya que no se puede rotar
                }
            }
            return true; //Sino se retorna true para dar valido la rotacion
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        // Timer para la velocidad de movimiento de la pieza - aumenta con el nivel del juego       //
        // La velocidad se controla con la funcion LevelUp()                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////
        private void SpeedTimer_Tick(object sender, EventArgs e) 
        {
            if (CheckGameOver() == true) //Si el juego se acabo
            {
                SpeedTimer.Stop();  //Se detiene ambos timers y se imprime el game over
                GameTimer.Stop();
                MessageBox.Show("Game over!");
                bPlay.Visible = true;
            }

            else
            {       //Sino se termino el juego
                //Mueve la pieza abajo, o tira una nueva pieza si no se puede mover
                if (TestMovimiento("down") == true) //Llama a la funcion para controlar si se puede mover abajo
                {
                    MoverPieza("down"); //Da la indicacion de mover la pieza 
                }
                else //Si no se puede mover
                {
                    if (CheckGameOver() == true)    //Se vuelve a chequear si acaba el juego
                    {
                        SpeedTimer.Stop();  //Si se acaba, se detiene ambos timers y se imprime el game over
                        GameTimer.Stop();
                        MessageBox.Show("Game over!");
                        bPlay.Visible = true;
                    }
                    if (CheckFilasLlenas() > -1)  //Llama a la funcion para comprobar si hay filas llenas
                    {
                        ClearFilaLlena(); //Limpia la fila llena
                    }
                    SoltarNuevaPieza(); //Llama a la funcion para crear una nueva pieza y soltarla
                }
            }
        }
        /////////////////////////////////////
        //  Tiempo de juego en segundos    //
        /////////////////////////////////////
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            time++; //Aumenta la variable del tiempo
            TimeLabel.Text = "Tiempo: " + time.ToString(); //Asigna el valor al label del tiempo
        }
        //////////////////////////////////////
        // Limpia la fila llena mas baja    //
        //////////////////////////////////////
        private void ClearFilaLlena()
        {
            int filaCompleta = CheckFilasLlenas();

            //Convierte esa fila en el color del grid
            for (int x = 0; x <= 9; x++) //Segun las columnas
            {
                Control z = grid.GetControlFromPosition(x, filaCompleta); //Se obtiene el control que esta en esa posicion
                z.BackColor = Color.White;  //Se cambia su color
            }

            //Mueve el resto de piezas abajo
            for (int x = filaCompleta - 1; x >= 0; x--) //Por cada fila arriba de la fila completa
            {
                //Por cada cuadradito en la fila
                for (int y = 0; y <= 9; y++) //Segun las columnas
                {
                    //Obtiene la posicion del cuadradito actual
                    Control z = grid.GetControlFromPosition(y, x);

                    //Obtiene la posicion del cuadradito una fila abajo
                    Control zz = grid.GetControlFromPosition(y, x + 1);

                    zz.BackColor = z.BackColor; //Cambiar el color del cuadradito de la fila de abajo con el color del cuadradito actual
                    z.BackColor = Color.White;  //Cambia el que era el cuadradito actual al color del grid
                }
            }
            ///////////////////////////////////////////////
            UpdateScore(); //Actualiza el score
            ///////////////////////////////////////////////
            clears++; //Aumenta el contador de filas limpias
            ClearsLabel.Text = "Filas Limpias: " + clears; //Actualiza el label de las filas limpias
            ///////////////////////////////////////////////
            if (clears % 10 == 0) //Si se limpiaron 10 filas
            {
                LevelUp();  //Se aumenta de nivel
            }
            ///////////////////////////////////////////////    
            if (CheckFilasLlenas() > -1) //Comprueba de nuevo Si hay filas llenas
            {
                ClearFilaLlena(); //Se llama a limpiar la fila
            }
        }
        //////////////////////////////////////////
        //  Funcion para actualizar el score    //
        //////////////////////////////////////////
        private void UpdateScore() 
        {
            // de 1 a 3 lineas limpias tiene valor de 100 por linea
            // Un no combo de cuatro lineas limpiadas equivale a 800
            // Un combo de dos o mas de 4 lineas equivalen a 1200 

            bool skipComboReset = false; //Variable bool para skipear el reset del combo

            // Una sola limpiada
            if (combo == 0)
            {
                score += 100; //Se aumenta a 100
                ScoreUpdateLabel.Text = "+100"; //Se actualiza el label del score que se gano
            }

            // Si se limpio 2
            else if (combo == 1)
            {
                score += 100; //se aumenta a 100
                ScoreUpdateLabel.Text = "+200"; //Se actualiza el label del score que se gano
            }

            // Si se limpio 3
            else if (combo == 2)
            {
                score += 100; //se aumenta a 100
                ScoreUpdateLabel.Text = "+300"; //Se actualiza el label del score que se gano
            }

            // Cuando se limpio cuatro, se empieza a contar el combo
            else if (combo == 3)
            {
                score += 500; //Se aumenta a 500
                ScoreUpdateLabel.Text = "+800"; //Se actualiza el label del score que se gano
                skipComboReset = true; //Se actualiza el valor de la variable que controla el combo
            }

            // Una limpieza solo, con el combo roto
            else if (combo > 3 && combo % 4 == 0) //COntrola que si se paso el limite antes del combo y tambien si el combo dividido la cantidad de filas es cero
            {
                score += 100; //Se Aumenta en 100
                ScoreUpdateLabel.Text = "+100"; //Se actualiza el label del score que se gano
            }

            // Dos linea limpiada, con combo roto
            else if (combo > 3 && ((combo - 1) % 4 == 0)) //Comprueba que si se paso el limite antes del combo y tambien comprueba si el combo menos 1 fila dividido la cantidad del como da cero
            {
                score += 100; //Se aumenta en 100
                ScoreUpdateLabel.Text = "+200";//Se actualiza el label del score que se gano
            }

            // Si se limpia 3 filas, con el combo roto
            else if (combo > 3 && ((combo - 2) % 4 == 0)) //Comprueba que si se paso el limite antes del combo y tambien comprueba si el combo menos 2 fila dividido la cantidad del como da cero
            {
                score += 100; //Se aumenta 100
                ScoreUpdateLabel.Text = "+300";//Se actualiza el label del score que se gano
            }

            // Limpieza de 4 lineas, con el combo activo
            else if (combo > 3 && ((combo - 3) % 4 == 0))//Comprueba que si se paso el limite antes del combo y tambien comprueba si el combo menos 3 fila dividido la cantidad del como da cero
            {
                score += 900; //Aumenta el score en 900
                ScoreUpdateLabel.Text = "+1200";//Se actualiza el label del score que se gano
                skipComboReset = true;
            }
            ///////////////////////////////////////////////
            if (CheckFilasLlenas() == -1 && skipComboReset == false) //Si no hay mas filas llenas y el combo se rompio
            {
                // de 1 a 3 lineas limpias
                combo = 0; //Se asigna cero para indicar fin del combo
            }
            else
            {
                // Si se hace una cuadruple eliminacion de fila
                combo++;
            }
            ///////////////////////////////////////////////
            ScoreLabel.Text = "Score: " + score.ToString(); //Se actualiza el label del score 
            ScoreUpdateTimer.Start(); //Se inicia el timer del actualizador del score
        }
        //////////////////////////////////////////////////
        // Retorna el numero de la fila llena mas baja  //
        // Si no hay filas llenas retorna -1            //
        //////////////////////////////////////////////////
        private int CheckFilasLlenas()
        {
            // Por cada fila
            for (int x = 21; x >= 2; x--) //Segun las filas, a partir de las utilizables
            {
                // Por cada cuadradito en la fila
                for (int y = 0; y <= 9; y++) //Segun las columnas
                {
                    Control z = grid.GetControlFromPosition(y, x); //Se obtiene el cuadrito de la posicion segun la fila y columna
                    if (z.BackColor == Color.White) //Si el cuadrito es del color del grid
                    {
                        break;  //Rompe el for de la columna
                    }
                    if (y == 9) //Si se llego a la ultima columna y se sabe que en cada una hay colores
                    {
                        // Retorna la fila que esta llena
                        return x;
                    }
                }
            }   //Si no hay filas retorna -1
            return -1; // "null"
        }
        //////////////////////////////////////
        // Aumenta la velocidad de caida    //
        //////////////////////////////////////
        private void LevelUp()
        {
            nivel++; //Se aumenta el nivel
            LevelLabel.Text = "Nivel: " + nivel.ToString(); //Actualiza el label del nivel

            // Milliseconds por cuadrito en caida
            // Nivel 1 = 800 ms por cuadrito, nivel 2 = 716 ms por cuadrito, etc.
            int[] VelocidadNivel =
            {
                800, 716, 633, 555, 466, 383, 300, 216, 133, 100, 083, 083, 083, 066, 066,
                066, 050, 050, 050, 033, 033, 033, 033, 033, 033, 033, 033, 033, 033, 016
            };

            // La velocidad no cambia despues del nivel 29
            if (nivel <= 29)
            {
                SpeedTimer.Interval = VelocidadNivel[nivel]; //Aumenta el timer de la velocidad segun el nivel 
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        // El juego acaba cuando la siguiente pieza toca la fila con la que salen nuevas piezas     //
        //////////////////////////////////////////////////////////////////////////////////////////////
        private bool CheckGameOver() //La funcion devuelve un valor boolean
        {
            Control[] topFila = { box1, box2, box3, box4, box5, box6, box7, box8, box9, box10 }; //Array para saber las posiciones de la fila tope

            foreach (Control box in topFila) //Por cada cuadradito en la fila tope
            {
                if ((box.BackColor != Color.White & box.BackColor != Color.LightGray) & !PiezaActiva.Contains(box))
                {  //Si en esta fila se tiene un cuadradito con el color distinto al grid y a la vez no es la pieza activa
                    //Game over!
                    bPlay.Visible = true;
                    return true; //Se retorna true para declarar un game over
                }
            }
            ///////////////////////////////////////////////
            if (gameOver == true) //Si ya la variable global se dio como acabada antes
            {
                bPlay.Visible = true;
                return true;    //Igual se devuelve true
            }

            return false; //Si no se devuelve falso
        }
        ////////////////////////////////////////////////////////////////
        // Limpia el label que actualiza el score cada 2 segundos     //
        ////////////////////////////////////////////////////////////////
        private void ScoreUpdateTimer_Tick(object sender, EventArgs e)
        {
            ScoreUpdateLabel.Text = ""; //Limpia el label
            ScoreUpdateTimer.Stop();    //Detiene el timer
        }
        //////////////////////////////////////////
        //  Cuando se cierra el formulario      //
        //////////////////////////////////////////
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();     //Cuando el form se cierra, se termina la aplicacion
        }
        /////////////////////////////////////////////
        //      Cuando se le da al boton play      //
        /////////////////////////////////////////////
        private void bPlay_Click(object sender, EventArgs e)    
        {
            bPlay.Visible = false;
            ScoreUpdateLabel.Text = ""; //Reseteamos el label que actualiza el score
            SpeedTimer.Start();         //Inicializa el temporizador para controlar la velocidad de las piezas
            GameTimer.Start();          //Inicializa el temporizador para controlar el tiempo de juego
            ///////////////////////////////////////////
            // Inicializa/reset pieza fantasma       //
            // Del box1 al box4 son invisibles       //
            ///////////////////////////////////////////
            PiezaActiva2[0] = box1; //Se almacenan los boxes
            PiezaActiva2[1] = box2;
            PiezaActiva2[2] = box3;
            PiezaActiva2[3] = box4;
            //////////////////////////////////////////
            // Generamos la secuencia de pieza      //
            //////////////////////////////////////////
            System.Random random = new System.Random(); //Genera un numero random
            while (SecuenciaPieza.Count < 7)  //Hasta que haya 7 piezas
            {
                int x = random.Next(7); //Se carga un nro random hasta 7
                if (!SecuenciaPieza.Contains(x)) //Si la lista ya contiene a la numero de pieza entonces no se cumple 
                {
                    SecuenciaPieza.Add(x); //Si no se anade el nro de pieza
                }
            }
            ////////////////////////////////////////////
            // Agarra la primera pieza aleatoria      //
            ////////////////////////////////////////////
            sigtPiezaInt = SecuenciaPieza[0]; //Se almacena cual sera la siguiente pieza
            SecuenciaIteracionPieza++;  //Se aumenta para controlar que ya se hizo la secuencia de iteracion
            ///////////////////////////////////////////////
            SoltarNuevaPieza(); //Se le llama a la funcion que suelta la nueva pieza
        }

    }
}
