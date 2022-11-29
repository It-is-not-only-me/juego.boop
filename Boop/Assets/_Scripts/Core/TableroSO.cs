using Boop.Configuracion;
using Boop.Evento;
using UnityEngine;

namespace Boop.Core
{
    [CreateAssetMenu(fileName = "Tablero", menuName = "Boop/Core/Tablero")]
    public class TableroSO : ScriptableObject
    {
        [Header("Configuraciones")]
        [SerializeField] private ConfiguracionDimensionSO _dimensiones;

        [Space]

        [Header("Eventos")]
        [SerializeField] private EventoPosicion _sacarPieza, _agregarPieza;

        public IPieza this[int i, int j] { get => PosicionValida(new Vector2Int(i, j)) ? _piezas[i, j] : null; }

        private IPieza[,] _piezas;

        private void Awake()
        {
            if (_dimensiones == null)
            {
                Debug.LogError("No hay dimensiones para el juego");
                return;
            }
            _piezas = new IPieza[_dimensiones.Ancho, _dimensiones.Alto];
        }

        private void OnEnable()
        {
            if (_sacarPieza != null)
                _sacarPieza.Evento += SacarPieza;

            if (_agregarPieza != null)
                _agregarPieza.Evento += AgregarPieza;
        }

        private void OnDisable()
        {
            if (_sacarPieza != null)
                _sacarPieza.Evento -= SacarPieza;

            if (_agregarPieza != null)
                _agregarPieza.Evento -= AgregarPieza;
        }

        private void SacarPieza(Vector2Int posicion, IPieza pieza)
        {
            if (!PosicionValida(posicion))
                return;

            _piezas[posicion.x, posicion.y] = null;
        }

        private void AgregarPieza(Vector2Int posicion, IPieza pieza)
        {
            if (!PosicionValida(posicion))
                return;

            _piezas[posicion.x, posicion.y] = pieza;
        }

        private bool PosicionValida(Vector2Int posicion)
        {
            return posicion.x >= 0 && posicion.y >= 0 && posicion.x < _dimensiones.Ancho && posicion.y < _dimensiones.Alto;
        }
    }
}
