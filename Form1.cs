using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Recursividad_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la ruta ingresada por el usuario desde el TextBox.
            string directorio = textBox1.Text;

            if (Directory.Exists(directorio))
            {
                // Limpiar el ListBox antes de listar los archivos.
                listBox1.Items.Clear();

                // Llamar a la función recursiva para listar los archivos.
                ListarArchivosRecursivamente(directorio);
            }
            else
            {
                MessageBox.Show("El directorio no existe.", "Directorio no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ListarArchivosRecursivamente(string directorio)
        {
            string[] archivos = Directory.GetFiles(directorio);

            foreach (string archivo in archivos)
            {
                string nombreArchivo = Path.GetFileName(archivo);
                string extension = Path.GetExtension(archivo);
                listBox1.Items.Add($"Archivo: {nombreArchivo}, Extensión: {extension}");
            }

            string[] subdirectorios = Directory.GetDirectories(directorio);

            foreach (string subdirectorio in subdirectorios)
            {
                // Llamar recursivamente a la función para explorar los subdirectorios.
                ListarArchivosRecursivamente(subdirectorio);
            }
        }
    }
}
