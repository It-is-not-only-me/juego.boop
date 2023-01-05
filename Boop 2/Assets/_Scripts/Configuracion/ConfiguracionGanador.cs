using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion ganador", menuName = "Boop/Configuracion/Ganador")] 
    public class ConfiguracionGanador : ScriptableObject
    {
        [SerializeField] private string _nombreGanador1, _nombreGanador2;

        private string _nombreGanador;
        public string Ganador => _nombreGanador;

        public void GanoJugador1() => _nombreGanador = _nombreGanador1;

        public void GanoJugador2() => _nombreGanador = _nombreGanador2;
    }
}