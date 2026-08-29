using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace C1_040924_Parte_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string appPath = "";
        string[] data = ["Hola mundo", "Esto es un ejemplo", "De cómo escribir un archivo"];

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                appPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Se establece el nombre del archivo a escribir
            string fileName = Path.Combine(this.appPath, "datos.txt");
            if (!File.Exists(fileName))
            {
                // Se crea y escribe el archivo ya que no existe
                // Se genera un StreamWriter para controlar la escritura de datos
                using (StreamWriter archivoSalida = new StreamWriter(fileName))
                {
                    // Se recorre la colección de cadenas de caracteres y se escribe al archivo
                    foreach (string line in data)
                        archivoSalida.WriteLine(line);
                }
            }
            else
            {
                // Se añaden datos al archivo ya que existe, para eso se establece el segundo parámetro
                using (StreamWriter archivoSalida = new StreamWriter(fileName, true))
                {
                    archivoSalida.WriteLine("Nuevos datos en una nueva línea");
                }
            }
        }
    }
}
