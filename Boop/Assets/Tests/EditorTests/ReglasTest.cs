using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Boop.Modelo;
using System;

public class ReglasTest
{
    private int _cantidadGatitos, _cantidadGatos;
    private int _ancho, _alto;

    public ReglasTest()
    {
        _cantidadGatitos = 8;
        _cantidadGatos = 8;

        _ancho = 6;
        _alto = 6;
    }

    [Test]
    public void Test01EnUnTableroVacioNoSeAplicaLaRegla()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        JugadorPrueba jugador1 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);
        JugadorPrueba jugador2 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        bool seAplicaRegla = false;

        Action<bool> seAplicaReglaAccion = (seEliminaPieza) => seAplicaRegla = true;

        tablero.EventoEliminarPieza += seAplicaReglaAccion;

        jugador1.EventoAgregaGatito += seAplicaReglaAccion;
        jugador2.EventoAgregaGatito += seAplicaReglaAccion;

        jugador1.EventoAgregaGato += seAplicaReglaAccion;
        jugador2.EventoAgregaGato += seAplicaReglaAccion;


        IRegla regla = new ReglaUpgradeGatitos(tablero, jugador1, jugador2);
        
        for (int i = 0; i < _ancho; i++)
            for (int j = 0; j < _ancho; j++)
                regla.Aplicar(tablero[i, j], i, j);

        Assert.IsFalse(seAplicaRegla);
    }

    [Test]
    public void Test02EnUnTableroConUnSoloGatitoNoSeAplicaLaRegla()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho, _alto);
        JugadorPrueba jugador1 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);
        JugadorPrueba jugador2 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        bool seAplicaRegla = false;

        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 2, 2);

        Action<bool> seAplicaReglaAccion = (seEliminaPieza) => seAplicaRegla = true;

        tablero.EventoEliminarPieza += seAplicaReglaAccion;

        jugador1.EventoAgregaGatito += seAplicaReglaAccion;
        jugador2.EventoAgregaGatito += seAplicaReglaAccion;

        jugador1.EventoAgregaGato += seAplicaReglaAccion;
        jugador2.EventoAgregaGato += seAplicaReglaAccion;


        IRegla regla = new ReglaUpgradeGatitos(tablero, jugador1, jugador2);

        for (int i = 0; i < _ancho; i++)
            for (int j = 0; j < _ancho; j++)
                regla.Aplicar(tablero[i, j], i, j);

        Assert.IsFalse(seAplicaRegla);
    }

    [Test]
    public void Test03EnUnTableroCon3GatitosDelMismoJugadorSeAplicaLaRegla()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho * 2, _alto * 2);
        JugadorPrueba jugador1 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);
        JugadorPrueba jugador2 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        bool seAplicaRegla = false;

        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 1, 2);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 3, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 4);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 5, 4);

        Action<bool> seAplicaReglaAccion = (seEliminaPieza) => seAplicaRegla = true;

        tablero.EventoEliminarPieza += seAplicaReglaAccion;

        jugador1.EventoAgregaGatito += seAplicaReglaAccion;
        jugador2.EventoAgregaGatito += seAplicaReglaAccion;

        jugador1.EventoAgregaGato += seAplicaReglaAccion;
        jugador2.EventoAgregaGato += seAplicaReglaAccion;


        IRegla regla = new ReglaUpgradeGatitos(tablero, jugador1, jugador2);

        for (int i = 0; i < _ancho; i++)
            for (int j = 0; j < _ancho; j++)
                regla.Aplicar(tablero[i, j], i, j);

        Assert.IsTrue(seAplicaRegla);
    }

    [Test]
    public void Test04EnUnTableroCon2GatitosYUnoGrandeDelMismoJugadorNoSeAplicaLaRegla()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho * 2, _alto * 2);
        JugadorPrueba jugador1 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);
        JugadorPrueba jugador2 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        bool seAplicaRegla = false;

        tablero.AgregarPieza(new PiezaGatoGrande(jugador1, tablero), 1, 2);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 3, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 4);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 5, 4);

        Action<bool> seAplicaReglaAccion = (seEliminaPieza) => seAplicaRegla = true;

        tablero.EventoEliminarPieza += seAplicaReglaAccion;

        jugador1.EventoAgregaGatito += seAplicaReglaAccion;
        jugador2.EventoAgregaGatito += seAplicaReglaAccion;

        jugador1.EventoAgregaGato += seAplicaReglaAccion;
        jugador2.EventoAgregaGato += seAplicaReglaAccion;


        IRegla regla = new ReglaUpgradeGatitos(tablero, jugador1, jugador2);

        for (int i = 0; i < _ancho; i++)
            for (int j = 0; j < _ancho; j++)
                regla.Aplicar(tablero[i, j], i, j);

        Assert.IsFalse(seAplicaRegla);
    }

    [Test]
    public void Test05EnUnTableroCon2GatitosDelMismoJugadorYUnoDeOtroNoSeAplicaLaRegla()
    {
        TableroPrueba tablero = new TableroPrueba(_ancho * 2, _alto * 2);
        JugadorPrueba jugador1 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);
        JugadorPrueba jugador2 = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

        bool seAplicaRegla = false;

        tablero.AgregarPieza(new PiezaGatoChico(jugador2, tablero), 1, 2);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 3, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 4);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 4, 3);
        tablero.AgregarPieza(new PiezaGatoChico(jugador1, tablero), 5, 4);

        Action<bool> seAplicaReglaAccion = (seEliminaPieza) => seAplicaRegla = true;

        tablero.EventoEliminarPieza += seAplicaReglaAccion;

        jugador1.EventoAgregaGatito += seAplicaReglaAccion;
        jugador2.EventoAgregaGatito += seAplicaReglaAccion;

        jugador1.EventoAgregaGato += seAplicaReglaAccion;
        jugador2.EventoAgregaGato += seAplicaReglaAccion;


        IRegla regla = new ReglaUpgradeGatitos(tablero, jugador1, jugador2);

        for (int i = 0; i < _ancho; i++)
            for (int j = 0; j < _ancho; j++)
                regla.Aplicar(tablero[i, j], i, j);

        Assert.IsFalse(seAplicaRegla);
    }
}
