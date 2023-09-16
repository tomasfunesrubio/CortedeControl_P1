using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019_11_12_CortedeControl_P1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool _Agrega1 = false;
                bool _Agrega2 = false;
                decimal _TotalGeneral = 0;
                decimal _TotalVendedor = 0;
                decimal _TotalProducto = 0;
                int _TotalCantidadGeneral = 0;
                int _TotalCantidad = 0;
                int _CantidadProducto = 0;
                // Se verifica la existencia del archivo.
                if (File.Exists("Ventas.txt"))
                {
                    // Se genera un StreamReader para leer el archivo.
                    using (StreamReader sr = new StreamReader("Ventas.txt"))
                    {
                        string _S = sr.ReadLine();  
                        string[] _D = _S.Split(new char[] { ',' });

                        while (_S != null)
                        {
                          
                            string _Vendedor = _D[0];
                            dataGridView1.Rows.Add(new string[] { _D[0] });
                            while (_Vendedor == _D[0] && _S!=null)
                            {           
                                string _Producto = _D[1];
                                if (_Agrega1)
                                    dataGridView1.Rows.Add(new string[] { "", _D[1] });
                                else
                                { 
                                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1].Value = _D[1]; 
                                    _Agrega1 = true; 
                                }


                                while (_Vendedor == _D[0] && _Producto == _D[1] && _S!=null)
                                {
                                    _TotalProducto += decimal.Parse(_D[3]);
                                    _TotalVendedor += decimal.Parse(_D[3]);
                                    _TotalGeneral += decimal.Parse(_D[3]);
                                    _CantidadProducto += int.Parse(_D[2]);
                                    _TotalCantidad += int.Parse(_D[2]);
                                    _TotalCantidadGeneral += int.Parse(_D[2]);
                                    if (_Agrega2)
                                        dataGridView1.Rows.Add(new string[] { "", "", _D[2], _D[3] });
                                    else
                                    {
                                        dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[2].Value = _D[2];
                                        dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[3].Value = _D[3];
                                        _Agrega2 = true;
                                    }
                                   _S = sr.ReadLine();
                                    if (_S != null) { _D = _S.Split(new char[] { ',' }); }
                                 
                                }                                
                                
                                dataGridView1.Rows.Add(new string[] { "","Sub Tot =>", _CantidadProducto.ToString(),_TotalProducto.ToString()});
                                dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = Color.AliceBlue;
                                dataGridView1.Rows.Add(1);
                                _TotalProducto = 0;
                                _CantidadProducto = 0;
                                _Agrega2 = false;
                            }
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                            dataGridView1.Rows.Add(new string[] { "", "Cant Vendida =>", _TotalCantidad.ToString(),"Tot Vend =>", _TotalVendedor.ToString() });
                            dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = Color.Aquamarine;
                            dataGridView1.Rows.Add(1);
                            _TotalVendedor = 0; 
                            _TotalCantidad = 0;
                            _Agrega1 = false;
                        }
                       
                        dataGridView1.Rows.Add(new string[] { "", "", _TotalCantidadGeneral.ToString(), "Tot Vendido =>", _TotalGeneral.ToString() });
                        dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = Color.Cyan;

                        _TotalGeneral = 0;
                        _TotalCantidadGeneral = 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
    }
}
