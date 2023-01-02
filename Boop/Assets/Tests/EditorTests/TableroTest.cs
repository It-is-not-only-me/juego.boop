using System;
using NUnit.Framework;
using Boop;

public class TableroTest
{
    

    public class PiezaGatoChicoPrueba : IPieza
    {
        public Action EventoBoop, EventoSacarDelTablero;
        public Action<ITablero, int, int> EventoEstablecerTablero;

        private PiezaGatoChico _pieza;

        public PiezaGatoChicoPrueba(IJugador jugador)
        {
            _pieza = new PiezaGatoChico(jugador);
        }

        public void Boop(IPieza pieza)
        {
            _pieza.Boop(pieza);
            EventoBoop?.Invoke();
        }

        public void Boop(PiezaGatoGrande pieza, int x, int y)
        {
            _pieza.Boop(pieza, x, y);
            EventoBoop?.Invoke();
        }

        public void Boop(PiezaGatoChico pieza, int x, int y)
        {
            _pieza.Boop(pieza, x, y);
            EventoBoop?.Invoke();
        }

        public void EstablecerTablero(ITablero tablero, int x, int y)
        {
            _pieza.EstablecerTablero(tablero, x, y);
            EventoEstablecerTablero?.Invoke(tablero, x, y);
        }

        public void SalirDelTablero()
        {
            _pieza.SalirDelTablero();
            EventoSacarDelTablero?.Invoke();
        }

        public bool EsIgual(IPieza pieza) => _pieza.EsIgual(pieza);
        public bool EsIgual(PiezaGatoGrande pieza) => _pieza.EsIgual(pieza);
        public bool EsIgual(PiezaGatoChico pieza) => _pieza.EsIgual(pieza);

        public bool PerteneceA(IJugador jugador) => _pieza.PerteneceA(jugador);
        public bool EsUpgradeable() => _pieza.EsUpgradeable();
    }

    private int _cantidadGatitos, _cantidadGatos;
    private IJugador _jugador;
    private int _ancho, _alto;

    public TableroTest()
    {
        _cantidadGatitos = 8;
        _cantidadGatos = 8;

        _jugador = new JugadorTest(_cantidadGatitos, _cantidadGatos);

        _ancho = 6;
        _alto = 6;
    }

    [Test]
    public void Test01AlAgregarUnGatoAlTableroSeEstableceLaPosicionYElTableroCorrecto()
    {
        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (tablero, x, y) => seEstableceCorrectamente = (x == posicionX && y == posicionY && tablero != null);

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsTrue(seEstableceCorrectamente);
    }

    [Test]
    public void Test02AlAgregarUnGatoAlTableroEnUnaPosicionAfueraDeRangoNoSeEstableceLaPosicionYElTablero()
    {
        int posicionX = 10, posicionY = 10;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (tablero, x, y) => seEstableceCorrectamente = true;

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsFalse(seEstableceCorrectamente);
    }

    [Test]
    public void Test03AlAgregarUnGatoAlTableroEnUnaPosicionYaOcupadaNoSeEstableceLaPosicionYElTablero()
    {
        int posicionX = 2, posicionY = 2;
        IPieza piezaOcupa = new PiezaGatoChico(_jugador);
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (tablero, x, y) => seEstableceCorrectamente = true;

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(piezaOcupa, posicionX, posicionY);
        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsFalse(seEstableceCorrectamente);
    }

    [Test]
    public void Test04AlAgregarUnGatoBoopeaAlGatoSiEstaAUnoDeDistancia()
    {
        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador);
        IPieza piezaBoopeadora = new PiezaGatoChico(_jugador);
        bool seBoopea = false;
        pieza.EventoBoop += () => seBoopea = true;

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX - 1, posicionY);

        Assert.IsTrue(seBoopea);
    }

    [Test]
    public void Test05AlSerBoopeadoDelTableroSeSaleDeEste()
    {
        int posicionX = 0, posicionY = 0;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador);
        IPieza piezaBoopeadora = new PiezaGatoChico(_jugador);
        bool seSacaDelTablero = false;
        pieza.EventoSacarDelTablero += () => seSacaDelTablero = true;

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX + 1, posicionY);

        Assert.IsTrue(seSacaDelTablero);
    }
}
