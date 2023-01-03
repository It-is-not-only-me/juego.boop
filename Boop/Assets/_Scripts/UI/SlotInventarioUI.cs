using Boop.Evento;
using Boop.Modelo;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.UI
{
    public class SlotInventarioUI : SlotUI
    {
        [SerializeField] private EventoPieza _eventoAgregarPieza;
        [SerializeField] private EventoVoid _eventoTerminarJugada;
        [SerializeField] private GameObject _piezaPrefab;
        [SerializeField] private Transform _posicion;

        [Space]

        [SerializeField] private EventoVoid _eventoSeAgregaPieza;
        [SerializeField] private EventoVoid _eventoSeSacaPieza;

        private List<IPieza> _piezas = new List<IPieza>();
        private bool _seNecesitaRegenerar = false;

        private int _cantidad => _piezas.Count;

        private void OnEnable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento += Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento += RegenerarPieza;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento -= Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento -= RegenerarPieza;
        }

        private void Agregar(IPieza pieza)
        {
            _piezas.Add(pieza);
            if (_cantidad == 1)
                CrearPieza(pieza);

            _seNecesitaRegenerar = false;
            _eventoSeAgregaPieza?.Invoke();
        }

        public override void Sacar()
        {
            _piezas.RemoveAt(_cantidad - 1);
            _seNecesitaRegenerar = true;
            _eventoSeSacaPieza?.Invoke();
        }

        private void RegenerarPieza()
        {
            if (_cantidad > 0 && _seNecesitaRegenerar)
                CrearPieza(_piezas[_cantidad - 1]);
            _seNecesitaRegenerar = false;
        }

        private void CrearPieza(IPieza pieza)
        {
            GameObject piezaUIGameObject = Instantiate(_piezaPrefab, _posicion);
            PiezaUI piezaUI = piezaUIGameObject.GetComponent<PiezaUI>();
            piezaUI.EstablecerPieza(pieza);
            piezaUI.SetSlot(this);
        }
    }
}
