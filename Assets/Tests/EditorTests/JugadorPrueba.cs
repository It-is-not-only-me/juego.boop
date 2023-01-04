using System;
using System.Collections.Generic;
using Boop.Modelo;

public class JugadorPrueba : IJugador
{
    public Action<bool> EventoAgregaGatito, EventoAgregaGato;
    public Action<bool> EventoEliminarGatito, EventoEliminarGato;

    private Inventario _inventario;

    public JugadorPrueba(int cantidadMaximaGatitos, int cantidadMaximaGatos)
    {
        ListaLimitada<PiezaGatoChico> listaGatitos = new ListaLimitada<PiezaGatoChico>(cantidadMaximaGatitos);
        ListaLimitada<PiezaGatoGrande> listaGatos = new ListaLimitada<PiezaGatoGrande>(cantidadMaximaGatos);

        _inventario = new Inventario(listaGatitos, listaGatos);
    }

    public bool AgregarGatoChico(PiezaGatoChico pieza)
    {
        bool sePudoAgregar = _inventario.AgregarGatoChico(pieza);
        EventoAgregaGatito?.Invoke(sePudoAgregar);
        return sePudoAgregar;
    }

    public bool AgregarGatoGrande(PiezaGatoGrande pieza)
    {
        bool sePudoAgregar = _inventario.AgregarGatoGrande(pieza);
        EventoAgregaGato?.Invoke(sePudoAgregar);
        return sePudoAgregar;
    }

    public bool EliminarGatoChico()
    {
        bool sePudoEliminar = _inventario.EliminarGatoChico();
        EventoEliminarGatito?.Invoke(sePudoEliminar);
        return sePudoEliminar;
    }

    public bool EliminarGatoGrande()
    {
        bool sePudoEliminar = _inventario.EliminarGatoGrande();
        EventoAgregaGato?.Invoke(sePudoEliminar);
        return sePudoEliminar;
    } 
}
