using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        static Metodos_Soduko sudoku = new Metodos_Soduko();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label_milesimas.Text = "00";
            label_segundos.Text = "00";
            label_minutos.Text = "00";
            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Selecciona Una dificultad");
            }            
            else
            {
                sudoku.limpiar_datagird(dgvTabla);
                dgvTabla = sudoku.crear_columnas_datagird(dgvTabla, 9);
                dgvTabla = sudoku.crear_filas_datagird(dgvTabla, 8);
                //regiones pintada
                try
                {
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                    //region 2 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                    //region 3 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                    //region 4 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                    //region 5 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                    //region 6 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                    //region 7 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                    //region 8 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                    //region 9 pintada
                    dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
                }
                catch (Exception) { }
                //llenar la matriz
                int cuenta = 0;
                if (comboBox1.Text == "Facil")
                {
                    cuenta = 0;
                    do
                    {
                        dgvTabla = sudoku.Llenar_datagird(dgvTabla);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 6, 9);
                        int x;
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla2_llenado(dgvTabla, x);
                        }
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla3_llenado(dgvTabla, x);
                        }
                        cuenta = sudoku.contador_datos(dgvTabla);
                    } while (cuenta <= 27);
                }
                if (comboBox1.Text == "Normal")
                {
                    cuenta = 0;
                    do
                    {
                        dgvTabla = sudoku.Llenar_datagird(dgvTabla);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 6, 9);
                        int x;
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla2_llenado(dgvTabla, x);
                        }
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla3_llenado(dgvTabla, x);
                        }
                        cuenta = sudoku.contador_datos(dgvTabla);
                    } while (cuenta <= 29);
                }
                if (comboBox1.Text == "Dificil")
                {
                    cuenta = 0;
                    do
                    {
                        dgvTabla = sudoku.Llenar_datagird(dgvTabla);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 0, 3);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 3, 6);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 0, 3, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 3, 6, 6, 9);
                        dgvTabla = sudoku.regla1_llenado(dgvTabla, 6, 9, 6, 9);
                        int x;
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla2_llenado(dgvTabla, x);
                        }
                        for (x = 0; x < 9; x++)
                        {
                            dgvTabla = sudoku.regla3_llenado(dgvTabla, x);
                        }
                        cuenta = sudoku.contador_datos(dgvTabla);
                    } while (cuenta >= 31);
                }

                MessageBox.Show("existen " + sudoku.contador_datos(dgvTabla) + " Datos");
                timer1.Start();
                button1.Enabled = true;
                button3.Enabled = true;
                btnVerificar.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                //region 2 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                //region 3 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                //region 4 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                //region 5 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                //region 6 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                //region 7 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                //region 8 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                //region 9 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
            }
            catch (Exception) { }
            //llenar la matriz
            int x;
            dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 0, 3);
            dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 0, 3);
            dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 0, 3);
            dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 3, 6);
            dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 3, 6);
            dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 3, 6);
            dgvTabla = sudoku.regla1(dgvTabla, 0, 3, 6, 9);
            dgvTabla = sudoku.regla1(dgvTabla, 3, 6, 6, 9);
            dgvTabla = sudoku.regla1(dgvTabla, 6, 9, 6, 9);

            for (x = 0; x < 9; x++)
            {
                dgvTabla = sudoku.regla2(dgvTabla, x);
            }
            for (x=0;x<9;x++)
            {
                dgvTabla = sudoku.regla3(dgvTabla, x);
            }

            dgvTabla = sudoku.regla4(dgvTabla);
            timer1.Stop();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.Tables[0].WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlReader xmlFile = XmlReader.Create(ofd.FileName, new XmlReaderSettings());
                    ds.ReadXml(xmlFile);
                    dgvTabla.DataSource = ds.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            int milesima, segundo, minuto;
            milesima = Convert.ToInt32(label_milesimas.Text);
            milesima += 1;
            label_milesimas.Text = milesima.ToString();
            if (milesima == 60)
            {
                segundo = Convert.ToInt32(label_segundos.Text);
                segundo += 1;
                label_segundos.Text = segundo.ToString();
                label_milesimas.Text = "00";
                if (segundo == 60)
                {
                    minuto = Convert.ToInt32(label_minutos.Text);
                    minuto += 1;
                    label_minutos.Text = minuto.ToString();
                    label_segundos.Text = "00";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 3, 0, 0, false);
                //region 2 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 3, 3, 0, true);
                //region 3 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 3, 6, 0, false);
                //region 4 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 6, 0, 3, true);
                //region 5 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 6, 3, 3, false);
                //region 6 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 6, 6, 3, true);
                //region 7 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 3, 9, 0, 6, false);
                //region 8 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 6, 9, 3, 6, true);
                //region 9 pintada
                dgvTabla = sudoku.pintar_datagird(dgvTabla, 9, 9, 6, 6, false);
            }
            catch (Exception) { }
            //llenar la matriz
        }
    }
}
