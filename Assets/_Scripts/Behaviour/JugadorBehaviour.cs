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

        [SerializeField] private EventoVoid _eventoAgregarGatito;
        [SerializeField] private EventoVoid _eventoAgregarGato;

        [Space]

        [SerializeField] private EventoVoid _eventoSacarGatito;
        [SerializeField] private EventoVoid _eventoSacarGato;

        private Inventario _inventario;

        private void Awake()
        {
            _inventario = new Inventario(new ListaLimitada<PiezaGatoChico>(_configuracion.CantidadMaximaGatitos),
                                         new ListaLimitada<PiezaGatoGrande>(_configuracion.CantidadMaximaGatos));
        }

        private void OnEnable()
        {
            if (_eventoSacarGatito != null)
                _eventoSacarGatito.Evento += SacarGatito;

            if (_eventoSacarGato != null)
                _eventoSacarGato.Evento += SacarGato;
        }

        private void OnDisable()
        {
            if (_eventoSacarGatito != null)
                _eventoSacarGatito.Evento -= SacarGatito;

            if (_eventoSacarGato != null)
                _eventoSacarGato.Evento -= SacarGato;
        }

        public bool AgregarGatoChico(PiezaGatoChico pieza)
        {
            bool sePudoAgregar = _inventario.AgregarGatoChico(pieza);
            if (sePudoAgregar)
                _eventoAgregarGatito?.Invoke();
            return sePudoAgregar;
        }

        public bool AgregarGatoGrande(PiezaGatoGrande pieza)
        {
            bool sePudoAgregar = _inventario.AgregarGatoGrande(pieza);
            if (sePudoAgregar)
                _eventoAgregarGato?.Invoke();
            return sePudoAgregar;
        }

        private void SacarGatito() => EliminarGatoChico();
        public bool EliminarGatoChico() => _inventario.EliminarGatoChico();

        private void SacarGato() => EliminarGatoGrande();
        public bool EliminarGatoGrande() => _inventario.EliminarGatoGrande();
    }
}
