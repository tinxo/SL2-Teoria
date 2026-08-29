using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Demo_persistencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string path = "";
        private string[] data = new string[] { "Hola mundo", "Esto es un ejemplo", "de persistencia" };
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (dlgRuta.ShowDialog() == DialogResult.OK)
            {
                path = dlgRuta.SelectedPath;
                lblRuta.Text = $"Ubicación seleccionada: {path}";
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string fullPath = Path.Combine(path, "datos.txt");
            if (!File.Exists(fullPath))
            {
                // El archivo no existe
                using (StreamWriter outputFile = new StreamWriter(fullPath))
                {
                    // Escribir el contenido del archivo línea a línea
                    foreach (var linea in data)
                    {
                        outputFile.WriteLine(linea);
                    }
                }
                MessageBox.Show("Archivo creado y datos guardados correctamente.");
            } 
            else
            {
                // El archivo ya existe, agregamos el mismo contenido
                using (StreamWriter outputFile = new StreamWriter(fullPath, true))
                {
                    // Escribir el contenido del archivo línea a línea
                    foreach (var linea in data)
                    {
                        outputFile.WriteLine($"add: {linea}");
                    }
                }
                MessageBox.Show("Archivo actualizado correctamente.");
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = Path.Combine(path, "datos.txt");
                // Open the text file using a stream reader.
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    // Read the stream as a string.
                    string text = reader.ReadToEnd();

                    MessageBox.Show(text);
                }

                
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
