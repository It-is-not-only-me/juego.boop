using System.Collections.Generic;
using Boop;

public class JugadorTest : IJugador
{
    private Inventario _inventario;

    public JugadorTest(int cantidadMaximaGatitos, int cantidadMaximaGatos)
    {
        ListaLimitada<PiezaGatoChico> listaGatitos = new ListaLimitada<PiezaGatoChico>(new List<PiezaGatoChico>(), cantidadMaximaGatitos);
        ListaLimitada<PiezaGatoGrande> listaGatos = new ListaLimitada<PiezaGatoGrande>(new List<PiezaGatoGrande>(), cantidadMaximaGatos);

        _inventario = new Inventario(listaGatitos, listaGatos);
    }

    public bool AgregarGatoChico(PiezaGatoChico pieza) => _inventario.AgregarGatoChico(pieza);

    public bool AgregarGatoGrande(PiezaGatoGrande pieza) => _inventario.AgregarGatoGrande(pieza);

    public bool EliminarGatoChico() => _inventario.EliminarGatoChico();

    public bool EliminarGatoGrande() => _inventario.EliminarGatoGrande();
}
