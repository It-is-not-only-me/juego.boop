using Boop;
using NUnit.Framework;
using System;

public class GatosTest
{
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

    private int _cantidadGatitos, _cantidadGatos;
    private IJugador _jugador;
    private int _ancho, _alto;

    public GatosTest()
    {
        _cantidadGatitos = 8;
        _cantidadGatos = 8;
        
        _jugador = new JugadorTest(_cantidadGatitos, _cantidadGatos);

        _ancho = 6;
        _alto = 6;
    }

    [Test]
    public void Test01GatoChicoEsEmpujadoPorGatoGrande()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        bool seMueve = false;
        tablero.EventoMoverPieza += (pudoMoverPieza) => seMueve = pudoMoverPieza;

        IPieza gatoChico = new PiezaGatoChico(_jugador);
        IPieza gatoGrande = new PiezaGatoGrande(_jugador);

        tablero.AgregarPieza(gatoChico, 1, 3);
        tablero.AgregarPieza(gatoGrande, 2, 2);

        Assert.IsTrue(seMueve);
    }

    [Test]
    public void Test02GatoChicoEsEmpujadoAfueraDelTableroPorGatoGrande()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        bool seMueve = false, seElimina = false;
        
        tablero.EventoMoverPieza += (pudoMoverPieza) => seMueve = pudoMoverPieza;
        tablero.EventoEliminarPieza += (pudoEliminarPieza) => seElimina = pudoEliminarPieza;

        IPieza gatoChico = new PiezaGatoChico(_jugador);
        IPieza gatoGrande = new PiezaGatoGrande(_jugador);

        tablero.AgregarPieza(gatoChico, 0, 0);
        tablero.AgregarPieza(gatoGrande, 1, 1);

        Assert.IsFalse(seMueve);
        Assert.IsTrue(seElimina);
    }

    [Test]
    public void Test03GatoChicoNoPuedeEmpujarAGatoGrande()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        bool seMueve = false;
        tablero.EventoMoverPieza += (pudoMoverPieza) => seMueve = pudoMoverPieza;

        IPieza gatoChico = new PiezaGatoChico(_jugador);
        IPieza gatoGrande = new PiezaGatoGrande(_jugador);

        tablero.AgregarPieza(gatoGrande, 2, 2);
        tablero.AgregarPieza(gatoChico, 1, 3);

        Assert.IsFalse(seMueve);
    }

    [Test]
    public void Test04GatoGrandeEsEmpujadoPorGatoGrande()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        bool seMueve = false;
        tablero.EventoMoverPieza += (pudoMoverPieza) => seMueve = pudoMoverPieza;

        IPieza gatoGrande = new PiezaGatoGrande(_jugador);
        IPieza gatoGrande2 = new PiezaGatoGrande(_jugador);

        tablero.AgregarPieza(gatoGrande, 1, 3);
        tablero.AgregarPieza(gatoGrande2, 2, 2);

        Assert.IsTrue(seMueve);
    }

    [Test]
    public void Test05GatoChicoNoEsEmpujadoPorGatoChicoSiYaHayUnGatoEnEsaDireccion()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        bool seMueve = false;
        tablero.EventoMoverPieza += (pudoMoverPieza) => seMueve = pudoMoverPieza;

        IPieza gatoChico = new PiezaGatoChico(_jugador);
        IPieza gatoChico2 = new PiezaGatoChico(_jugador);
        IPieza gatoGrande = new PiezaGatoGrande(_jugador);

        tablero.AgregarPieza(gatoGrande, 0, 4);
        tablero.AgregarPieza(gatoChico, 1, 3);
        tablero.AgregarPieza(gatoChico2, 2, 2);

        Assert.IsFalse(seMueve);
    }
}
