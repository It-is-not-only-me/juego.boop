using Boop.Configuracion;
using Boop.Evento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.UI
{
    public class TableroUI : MonoBehaviour, IReiniciable
    {
        [SerializeField] private EventoCoordenada _eventoSacarPieza;
        [SerializeField] private EventoTransladar _eventoTransladar;

        [Space]

        [SerializeField] private ConfiguracionGrilla _configuracion;
        [SerializeField] private List<SlotTableroUI> _slots = new List<SlotTableroUI>();

        [Space]

        [SerializeField] private EventoVoid _eventoReiniciar;

        private SlotTableroUI[,] _tablero;

        private void Awake()
        {
            _tablero = new SlotTableroUI[_configuracion.Filas, _configuracion.Columnas];

            for (int i = 0, k = 0; i < _configuracion.Filas; i++)
                for (int j = 0; j < _configuracion.Columnas; j++, k++)
                {
                    _tablero[j, i] = _slots[k];
                    _tablero[j, i].Inicializar(j, i);
                }
        }

        private void OnEnable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;

            if (_eventoTransladar != null)
                _eventoTransladar.Evento += TransladarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento += Reiniciar;
        }

        private void OnDisable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento -= SacarPieza;

            if (_eventoTransladar != null)
                _eventoTransladar.Evento -= TransladarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento -= Reiniciar;
        }

        private void SacarPieza(int x, int y)
        {
            _tablero[x, y].Eliminar();
        }

        private void TransladarPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
        {
            _tablero[xOriginal, yOriginal].Transladar(_tablero[xFinal, yFinal]);
        }

        public void Reiniciar()
        {
            _slots.ForEach(slot => slot.Reiniciar());
        }
    }
}
