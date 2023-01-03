using UnityEngine;
using Boop.Modelo;
using Boop.Configuracion;
using Boop.Evento;

namespace Boop.Bahaviour
{
    public class JugadorBehaviour : MonoBehaviour, IJugador
    {
        [SerializeField] private ConfiguracionInventario _configuracion;
        [SerializeField] private TableroBehaviour _tablero;

        [Space]

        [SerializeField] private EventoPieza _agregarGatito;
        [SerializeField] private EventoPieza _agregarGato;

        private Inventario _inventario;

        private void Start()
        {
            _inventario = new Inventario(new ListaLimitada<PiezaGatoChico>(_configuracion.CantidadMaximaGatitos),
                                         new ListaLimitada<PiezaGatoGrande>(_configuracion.CantidadMaximaGatos));

            for (int i = 0; i < _configuracion.CantidadDeGatitos; i++)
                AgregarGatoChico(new PiezaGatoChico(this, _tablero));

            for (int i = 0; i < _configuracion.CantidadDeGatos; i++)
                AgregarGatoGrande(new PiezaGatoGrande(this, _tablero));
        }

        public bool AgregarGatoChico(PiezaGatoChico pieza)
        {
            bool sePudoAgregar = _inventario.AgregarGatoChico(pieza);
            if (sePudoAgregar)
                _agregarGatito?.Invoke(pieza);
            return sePudoAgregar;
        }

        public bool AgregarGatoGrande(PiezaGatoGrande pieza)
        {
            bool sePudoAgregar = _inventario.AgregarGatoGrande(pieza);
            if (sePudoAgregar)
                _agregarGato?.Invoke(pieza);
            return sePudoAgregar;
        }

        public bool EliminarGatoChico() => _inventario.EliminarGatoChico();

        public bool EliminarGatoGrande() => _inventario.EliminarGatoGrande();
    }
}
