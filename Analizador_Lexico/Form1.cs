using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Analizador_Lexico
{
    public partial class Form1 : Form
    {
        List<string> _numeros = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
        List<string> _operadores = new List<string>(new string[] { "+", "-", "*", "/", "^" });
        List<string> _delimitadores = new List<string>(new string[] { "(",")", "[","]", "{", "}" });
        List<string> _palabras = new List<string>(new string[] { "if", "while", "return", "continue", "break", "do"});
        List<string> _variables = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s","t","v","w","x","y","z" });


        DataTable _tblResultados = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            _tblResultados.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tblResultados.Clear();

            List<string> _elementos = textBox1.Text.Split().ToList();
            if (_elementos.Count > 0)
            {
                DataRow _fila;
                foreach (string elemento in _elementos)
                {
                    _fila = _tblResultados.NewRow();

                    if (_numeros.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Número";
                    }
                    else if (_operadores.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Operadores";
                    }
                    else if (_palabras.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Palabra Reservada";
                    }
                    else if (_delimitadores.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Delimitadores";
                    }
                    else if (_variables.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Variables";
                    }
                    else
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Error";
                    }
                    _tblResultados.Rows.Add(_fila);
                }

                dataGridView1.DataSource = _tblResultados;
                dataGridView1.Refresh();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _tblResultados.Columns.Add("Token", typeof(string));
            _tblResultados.Columns.Add("Tipo", typeof(string));
        }
    }
}