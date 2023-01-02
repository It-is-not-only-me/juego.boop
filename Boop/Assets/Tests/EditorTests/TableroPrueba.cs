using Boop.Modelo;
using System;
public class TableroPrueba : ITablero
{
    public Action<bool> EventoAgregarPieza, EventoEliminarPieza, EventoMoverPieza;

    private ITablero _tablero;

    public TableroPrueba(int ancho, int alto)
    {
        _tablero = new Tablero(ancho, alto);
    }

    public IPieza this[int x, int y] => _tablero[x, y];

    public int Ancho => _tablero.Ancho;

    public int Alto => _tablero.Alto;

    public bool AgregarPieza(IPieza pieza, int x, int y)
    {
        bool pudoAgregarPieza = _tablero.AgregarPieza(pieza, x, y);
        EventoAgregarPieza?.Invoke(pudoAgregarPieza);
        if (pudoAgregarPieza)
            pieza.EstablecerTablero(this, x, y);
        return pudoAgregarPieza;
    }

    public bool EliminarPieza(int x, int y)
    {
        bool pudoEliminarPieza = _tablero.EliminarPieza(x, y);
        EventoEliminarPieza?.Invoke(pudoEliminarPieza);
        return pudoEliminarPieza;
    }

    public bool MoverPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
    {
        bool pudoMoverPieza = _tablero.MoverPieza(xOriginal, yOriginal, xFinal, yFinal);
        EventoMoverPieza?.Invoke(pudoMoverPieza);
        return pudoMoverPieza;
    }

    public bool HayPiezaEn(int x, int y) => _tablero.HayPiezaEn(x, y);

    public bool EnRango(int x, int y) => _tablero.EnRango(x, y);
}
