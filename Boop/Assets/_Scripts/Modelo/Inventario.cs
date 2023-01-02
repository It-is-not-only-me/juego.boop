namespace Boop
{
    public class Inventario
    {
        private ListaLimitada<PiezaGatoChico> _piezasGatosChicos;
        private ListaLimitada<PiezaGatoGrande> _piezasGatosGrandes;

        public Inventario(ListaLimitada<PiezaGatoChico> piezasGatosChicos, ListaLimitada<PiezaGatoGrande> piezasGatosGrandes)
        {
            _piezasGatosChicos = piezasGatosChicos;
            _piezasGatosGrandes = piezasGatosGrandes;
        }

        public bool AgregarGatoChico(PiezaGatoChico pieza) => _piezasGatosChicos.Agregar(pieza);

        public bool EliminarGatoChico() => _piezasGatosChicos.Eliminar();

        public bool AgregarGatoGrande(PiezaGatoGrande pieza) => _piezasGatosGrandes.Agregar(pieza);

        public bool EliminarGatoGrande() => _piezasGatosGrandes.Eliminar();
    }
}