using Boop;
using NUnit.Framework;

public class GatosTest
{
    private int _cantidadGatitos, _cantidadGatos;
    private IJugador _jugador;
    private int _ancho, _alto;

    public GatosTest()
    {
        _cantidadGatitos = 8;
        _cantidadGatos = 8;
        
        _jugador = new JugadorPrueba(_cantidadGatitos, _cantidadGatos);

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
