using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku
{
    public class Metodos_Soduko : Form1
    {
        Random rnd = new Random(); 
        //METODOS DEL DATAGIRDVIEW
        public DataGridView limpiar_datagird(DataGridView Tabla)
        {
            Tabla.Columns.Clear();
            Tabla.Rows.Clear();
            Tabla.ClearSelection();
            return Tabla;
        }

        public DataGridView crear_filas_datagird(DataGridView Tabla, int N_fil)
        {
            for (int x=0;x<N_fil;x++)
            {
                Tabla.Rows.Add();
            }
            return Tabla;
        }

        public DataGridView crear_columnas_datagird(DataGridView Tabla , int N_colu)
        {
            for (int x = 0; x < N_colu; x++)
            {
                Tabla.Columns.Add(Convert.ToString(x),null);
            }
            return Tabla;
        }

        public DataGridView pintar_datagird(DataGridView Tabla, int Col_final, int fila_final, int Col_inicial, int fila_inicial, bool rojo)
        {
            if (rojo == true)
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        Tabla.Rows[x].Cells[y].Style.BackColor = Color.Green;
                    }

                }
            }
            else
            {
                for (int x = fila_inicial; x < fila_final; x++)
                {
                    for (int y = Col_inicial; y < Col_final; y++)
                    {
                        Tabla.Rows[x].Cells[y].Style.BackColor = Color.White;
                    }

                }
            }
            return Tabla;
        }

        public DataGridView Llenar_datagird(DataGridView Tabla)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Tabla.Rows[x].Cells[y].Value = Convert.ToString(random());
                }

            }
            return Tabla;
        }

        public int contador_datos(DataGridView Tabla)
        {
            int contador = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() != string.Empty)
                    {
                        contador++;
                    }
                }

            }
            return contador;
        }


        //Metodo de Cronometro

        void Parar_tiempo()
        {
            
        }

        //METODOS RANDOM 
        int random()
        {
            int a = rnd.Next(1,10);
            return a;
        }

        //reglas del sudoku

            //regla 1: las regiones 3 x 3 no tiene que haber ningun numero pepetido 
        public DataGridView regla1(DataGridView Tabla, int Col_inicial, int Col_final, int fila_inicial, int fila_final)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = fila_inicial; x < fila_final; x++)
                    {
                        for (int y = Col_inicial; y < Col_final; y++)
                        {
                            if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                            {
                                contador++;
                            }
                            if (contador > 1)
                            {
                                Tabla.Rows[x].Cells[y].Style.BackColor = Color.Red;
                                contador = 1;
                            }
                        }

                    }
                    contador = 0;
                }     
            return Tabla;
        }


        public DataGridView regla1_llenado(DataGridView Tabla, int Col_inicial, int Col_final, int fila_inicial, int fila_final)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
           for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = fila_inicial; x < fila_final; x++)
                    {
                        for (int y = Col_inicial; y < Col_final; y++)
                        {
                            if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                            {
                                contador++;
                            }
                            if (contador > 1)
                            {
                                Tabla.Rows[x].Cells[y].Value = string.Empty;
                                contador = 1;
                            }
                        }

                    }
                    contador = 0;
                }
           return Tabla;
        }
        
        
        //regla 2: En ninguna columna tiene que estar el mismo numero 2 veces 
        public DataGridView regla2(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                            contador = 1;
                        }
                    }
                    contador = 0;
                }       
            
            return Tabla;
        }

        public DataGridView regla2_llenado(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (Tabla.Rows[x].Cells[y].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[x].Cells[y].Value = string.Empty;
                            contador = 1;
                        }
                    }
                    contador = 0;
                }
            return Tabla;
        }


        //regla 3: En ninguna fila tiene que estar el mismo numero 2 veces 
        public DataGridView regla3(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (Tabla.Rows[y].Cells[x].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[y].Cells[x].Style.BackColor = Color.Orange;
                            contador = 1;
                        }
                    }
                    contador = 0;
                }          

            return Tabla;
        }

        public DataGridView regla3_llenado(DataGridView Tabla, int y)
        {
            int casilla = 0;  //la variable ayuda a buscar de 1 en 1 si se repite
            int contador = 0; //cuenta el numero de veces que se petie un numero
            for (casilla = 1; casilla < 10; casilla++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (Tabla.Rows[y].Cells[x].Value.ToString() == Convert.ToString(casilla))
                        {
                            contador++;
                        }
                        if (contador > 1)
                        {
                            Tabla.Rows[y].Cells[x].Value = string.Empty;
                            contador = 1;
                        }
                    }
                    contador = 0;
                }
            return Tabla;
        }


        //regla 4: No puede tener casilla vacias 
        public DataGridView regla4(DataGridView Tabla)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Tabla.Rows[y].Cells[x].Value.ToString() == string.Empty)
                    {
                        Tabla.Rows[y].Cells[x].Style.BackColor = Color.Purple;
                    }
                    
                }
        
            }

            return Tabla;
        }
    }
}
