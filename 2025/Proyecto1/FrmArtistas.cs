using Proyecto1.Modelos;

namespace Proyecto1
{
    public partial class FrmArtistas : Form
    {

        private List<Artista> _listaArtistas = new List<Artista>();

        public FrmArtistas()
        {
            InitializeComponent();
        }

        private void cargarListado()
        {
            // Primero, limpiar la lista
            this.lstArtistas.Items.Clear();
            try
            {
                _listaArtistas = ControladorArtistas.ObternerArtistas();
                foreach (var artista in _listaArtistas)
                {
                    this.lstArtistas.Items.Add(artista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay artistas cargados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sincronizarListado()
        {
            // Primero, limpiar la lista
            this.lstArtistas.Items.Clear();
            try
            {
                // Trae directo de la memoria
                _listaArtistas = ControladorArtistas.getListaArtistas();
                foreach (var artista in _listaArtistas)
                {
                    this.lstArtistas.Items.Add(artista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay artistas cargados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // se toman los datos cargados en la UI
            string nombreCompleto = txtNombreCompleto.Text;
            string nombreArtistico = txtNombreArtistico.Text;
            int anioInicio = (int)nupAnioInicio.Value;
            string nacionalidad = String.Empty;
            if (cbxNacionalidad.SelectedItem.ToString() != String.Empty)
            {
                nacionalidad = cbxNacionalidad.SelectedItem.ToString();
            }
            string discografica = String.Empty;
            if (cbxDiscografica.SelectedItem.ToString() != String.Empty)
            {
                discografica = cbxDiscografica.SelectedItem.ToString();
            }
            ControladorArtistas.GuardarArtista(nombreCompleto, nombreArtistico, anioInicio, nacionalidad, discografica);
            sincronizarListado();
        }

        private void FrmArtistas_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lstArtistas.SelectedItems.Count > 0)
            {
                FrmDiscos frmDiscos = new FrmDiscos();
                frmDiscos.setArtista((Artista) lstArtistas.SelectedItem);
                frmDiscos.ShowDialog();
                sincronizarListado();
            }
        }
    }
}
