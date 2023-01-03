using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.UI
{
    public class SlotUI : MonoBehaviour, IDropHandler
    {
        [SerializeField] private EventoVoid EventoInicializar;
        
        private int _columna, _fila;

        private PiezaUI _piezaUI;

        public void Inicializar(int columna, int fila)
        {
            _columna = columna;
            _fila = fila;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject objeto = eventData.pointerDrag;
            if (!objeto.TryGetComponent(out _piezaUI))
                return;

            _piezaUI.SetSlot(this);
            EventoInicializar.Evento += InicializarPieza;
        }

        private void InicializarPieza()
        {
            _piezaUI.Inicializar(_columna, _fila);

        }

        public void Sacar()
        {
            _piezaUI = null;
            EventoInicializar.Evento -= InicializarPieza;
        }
    }
}
