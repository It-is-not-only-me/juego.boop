using System;
using NUnit.Framework;
using Boop.Modelo;

public class TableroTest
{
    public class PiezaGatoChicoPrueba : IPieza
    {
        public Action EventoBoop, EventoSacarDelTablero;
        public Action<int, int> EventoEstablecerTablero;

        private PiezaGatoChico _pieza;
        private IJugador _jugador;

        public PiezaGatoChicoPrueba(IJugador jugador, ITablero tablero)
        {
            _jugador = jugador;
            _pieza = new PiezaGatoChico(jugador, tablero);
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

        public void EstablecerTablero(int x, int y)
        {
            _pieza.EstablecerTablero(x, y);
            EventoEstablecerTablero?.Invoke(x, y);
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

        public void VolverAlJugador() => _jugador.AgregarGatoChico(_pieza);
    }

    private int _cantidadGatitos, _cantidadGatos;
    private IJugador _jugador;
    private int _ancho, _alto;

    public TableroTest()
    {
        _cantidadGatitos = 8;
        _cantidadGatos = 8;

        _jugador = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        _ancho = 6;
        _alto = 6;
    }

    [Test]
    public void Test01AlAgregarUnGatoAlTableroSeEstableceLaPosicionYElTableroCorrecto()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (x, y) => seEstableceCorrectamente = (x == posicionX && y == posicionY);


        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsTrue(seEstableceCorrectamente);
    }

    [Test]
    public void Test02AlAgregarUnGatoAlTableroEnUnaPosicionAfueraDeRangoNoSeEstableceLaPosicionYElTablero()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 10, posicionY = 10;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (x, y) => seEstableceCorrectamente = true;


        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsFalse(seEstableceCorrectamente);
    }

    [Test]
    public void Test03AlAgregarUnGatoAlTableroEnUnaPosicionYaOcupadaNoSeEstableceLaPosicionYElTablero()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 2, posicionY = 2;
        IPieza piezaOcupa = new PiezaGatoChico(_jugador, tablero);
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        bool seEstableceCorrectamente = false;
        pieza.EventoEstablecerTablero += (x, y) => seEstableceCorrectamente = true;


        tablero.AgregarPieza(piezaOcupa, posicionX, posicionY);
        tablero.AgregarPieza(pieza, posicionX, posicionY);

        Assert.IsFalse(seEstableceCorrectamente);
    }

    [Test]
    public void Test04AlAgregarUnGatoBoopeaAlGatoSiEstaAUnoDeDistancia()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        IPieza piezaBoopeadora = new PiezaGatoChico(_jugador, tablero);
        bool seBoopea = false;
        pieza.EventoBoop += () => seBoopea = true;


        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX - 1, posicionY);

        Assert.IsTrue(seBoopea);
    }

    [Test]
    public void Test05AlSerBoopeadoDelTableroSeSaleDeEste()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 0, posicionY = 0;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        IPieza piezaBoopeadora = new PiezaGatoChico(_jugador, tablero);
        bool seSacaDelTablero = false;
        pieza.EventoSacarDelTablero += () => seSacaDelTablero = true;


        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX + 1, posicionY);

        Assert.IsTrue(seSacaDelTablero);
    }

    [Test]
    public void Test06SeBoopeaDespuesDeSerBoopeado()
    {
        ITablero tablero = new Tablero(_ancho, _alto);

        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba(_jugador, tablero);
        IPieza piezaBoopeadora = new PiezaGatoChico(_jugador, tablero);
        bool seBoopea = false;


        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX - 1, posicionY);

        pieza.EventoBoop += () => seBoopea = true;
        tablero.AgregarPieza(piezaBoopeadora, posicionX, posicionY);

        Assert.IsTrue(seBoopea);
    }
}
