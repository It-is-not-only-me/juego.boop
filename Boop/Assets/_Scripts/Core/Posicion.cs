using UnityEngine;

namespace Boop.Core
{
    public struct Posicion
    {
        public uint Columna, Fila;

        public Posicion(uint columna, uint fila)
        {
            Columna = columna;
            Fila = fila;
        }

        public Posicion Transladar(int moverColumnas, int moverFilas)
        {
            uint nuevaColumna = (uint)Mathf.Max(0, Columna + moverColumnas);
            uint nuevaFila = (uint)Mathf.Max(0, Fila + moverFilas);
            return new Posicion(nuevaColumna, nuevaFila);
        }
    }
}
