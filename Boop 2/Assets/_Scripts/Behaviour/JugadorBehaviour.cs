using UnityEngine;
using Boop.Modelo;
using Boop.Configuracion;
using Boop.Evento;
using Boop.UI;

namespace Boop.Bahaviour
{
    public class JugadorBehaviour : MonoBehaviour, IJugador, IReiniciable
    {
        [SerializeField] private ConfiguracionInventario _configuracion;
        [SerializeField] private TableroBehaviour _tablero;

        [Space]

        [SerializeField] private EventoVoid _eventoAgregarGatito;
        [SerializeField] private EventoVoid _eventoAgregarGato;

        [Space]

        [SerializeField] private EventoVoid _eventoSacarGatito;
        [SerializeField] private EventoVoid _eventoSacarGato;

        [Space]

        [SerializeField] private EventoVoid _eventoReiniciar;

        private Inventario _inventario;

        private void Awake() => Inicializar();

        private void OnEnable()
        {
            if (_eventoSacarGatito != null)
                _eventoSacarGatito.Evento += SacarGatito;

            if (_eventoSacarGato != null)
                _eventoSacarGato.Evento += SacarGato;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento += Reiniciar;
        }

        private void OnDisable()
        {
            if (_eventoSacarGatito != null)
                _eventoSacarGatito.Evento -= SacarGatito;

            if (_eventoSacarGato != null)
                _eventoSacarGato.Evento -= SacarGato;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento -= Reiniciar;
        }

        private void Inicializar()
        {
            _inventario = new Inventario(new ListaLimitada<PiezaGatoChico>(_configuracion.CantidadMaximaGatitos),
                                         new ListaLimitada<PiezaGatoGrande>(_configuracion.CantidadMaximaGatos));
        }

        public void Reiniciar() => Inicializar();

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
