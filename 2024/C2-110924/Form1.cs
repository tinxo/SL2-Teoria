namespace C2_110924
{
    public partial class Form1 : Form
    {
        // Colección de productos para usar
        private List<Producto> _listaProductos = new List<Producto>();
        // Un producto en particular para usar
        private Producto _unProducto;

        public Form1()
        {
            InitializeComponent();
        }

        private void sincronizarListado()
        {
            // Este método carga todos los productos al lisbox de la ui
            this.lstProductos.Items.Clear();
            // List<Producto> listaProductos = new List<Producto>();
            try
            {
                _listaProductos = ProductosController.LeerProductos();
                foreach (var producto in _listaProductos)
                {
                    this.lstProductos.Items.Add(producto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error  en la lectura de productos.");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Guardar un producto
            string idProducto = this.txtID.Text;
            string nombreProducto = this.txtNombre.Text;
            int cantidadInicial = int.Parse(this.nupCantidad.Text); // Esto se tiene que eliminar

            Producto unProducto = new Producto(idProducto, nombreProducto, cantidadInicial);

            ProductosController.GuardarProducto(unProducto);
            sincronizarListado();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sincronizarListado();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            sincronizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Ejecución para guardar un Movimiento

            // Ejemplo de ID para un movimiento que se compone de fecha + hora sin símbolos
            MessageBox.Show(DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ",""));
            // El uso se debería hacer a partir de acá para el uso del constructor de Movimientos
            if (this.lstProductos.SelectedIndex != -1)
            {
                // Hay algo seleccionado
                // Se necesita un movimiento seleccionado
                _unProducto = this._listaProductos[this.lstProductos.SelectedIndex];
                // Se va a cargar un movimiento nuevo
                int cantidadIngresada = (int)this.nupCantidadMovimineto.Value;
                // string observacionesMovimiento = this.txtObservaciones.Text;
                if (this.cbxTipoMovimiento.SelectedIndex == 0)
                {
                    // TODO: reemplazar ID del movimiento por la opción de arriba (fecha como string) u otra
                    // Ingreso
                    Movimiento unMovimiento = _unProducto.agregarUnidades("123", cantidadIngresada, DateTime.Now);
                    ProductosController.AgregarMovimiento(_unProducto, unMovimiento);
                }
                else
                {
                    // TODO: reemplazar ID del movimiento por la opción de arriba (fecha como string) u otra
                    // Egreso
                    try
                    {
                        Movimiento unMovimiento = _unProducto.restarUnidades("123", cantidadIngresada, DateTime.Now);
                        ProductosController.AgregarMovimiento(_unProducto, unMovimiento);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                // Se actualiza en el listbox la visualización
                this.sincronizarListado();
            }
            else
            {
                MessageBox.Show("Se tiene que seleccionar un Producto desde la lista.");
            }
        }
    }
}
