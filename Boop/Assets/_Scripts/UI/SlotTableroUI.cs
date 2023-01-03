using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;

namespace Boop.UI
{

    public class SlotTableroUI : SlotUI, IDropHandler
    {
        [SerializeField] private EventoVoid _eventoTerminarJugada;
        [SerializeField] private EventoVoid _eventoSiguente;

        [Space]

        [SerializeField] private EventoMovimiento _eventoMoverPieza;
        
        private int _posicionX, _posicionY;

        private PiezaUI _piezaUI;

        private void OnEnable()
        {
            if (_eventoMoverPieza != null)
                _eventoMoverPieza.Evento += MoverPieza;
        }

        private void OnDisable()
        {
            if (_eventoMoverPieza != null)
                _eventoMoverPieza.Evento -= MoverPieza;
        }

        public void Inicializar(int x, int y)
        {
            _posicionX = x;
            _posicionY = y;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject objeto = eventData.pointerDrag;
            if (!objeto.TryGetComponent(out _piezaUI))
                return;

            SetearPieza();
            _eventoTerminarJugada.Evento += InicializarPieza;
        }

        private void InicializarPieza()
        {
            _eventoTerminarJugada.Evento -= InicializarPieza;
            _piezaUI?.Inicializar(_posicionX, _posicionY);
            _eventoSiguente?.Invoke();
        }

        public override void Sacar()
        {
            _eventoTerminarJugada.Evento -= InicializarPieza;
            _piezaUI = null;
        }

        private void MoverPieza(PiezaUI piezaUI, int x, int y)
        {
            if (_posicionX != x || _posicionY != y)
                return;

            _piezaUI = piezaUI;
            SetearPieza();
            _piezaUI?.Inicializar(_posicionX, _posicionY);
        }

        private void SetearPieza()
        {
            _piezaUI.SetSlot(this);
            _piezaUI.ActualizarPadre();
        }
    }
}
