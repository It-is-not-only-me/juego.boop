namespace Boop
{
    public interface IJugador
    {
        public bool AgregarGatoChico(PiezaGatoChico pieza);

        public bool EliminarGatoChico();

        public bool AgregarGatoGrande(PiezaGatoGrande pieza);

        public bool EliminarGatoGrande();
    }
}