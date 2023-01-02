using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Boop;

public class TableroTest
{
    public class PiezaGatoChicoPrueba : IPieza
    {
        public Action EventoBoop, EventoSacarDelTablero;
        public Action<ITablero, int, int> EventoEstablecerTablero;

        private PiezaGatoChico _pieza;

        public PiezaGatoChicoPrueba()
        {
            _pieza = new PiezaGatoChico();
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
    }

    private int _ancho = 6, _alto = 6;

    [Test]
    public void Test01AlAgregarUnGatoAlTableroSeEstableceLaPosicionYElTableroCorrecto()
    {
        int posicionX = 2, posicionY = 2;
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba();
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
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba();
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
        IPieza piezaOcupa = new PiezaGatoChico();
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba();
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
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba();
        IPieza piezaBoopeadora = new PiezaGatoChico();
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
        PiezaGatoChicoPrueba pieza = new PiezaGatoChicoPrueba();
        IPieza piezaBoopeadora = new PiezaGatoChico();
        bool seSacaDelTablero = false;
        pieza.EventoSacarDelTablero += () => seSacaDelTablero = true;

        ITablero tablero = new Tablero(_ancho, _alto);

        tablero.AgregarPieza(pieza, posicionX, posicionY);
        tablero.AgregarPieza(piezaBoopeadora, posicionX + 1, posicionY);

        Assert.IsTrue(seSacaDelTablero);
    }
}
