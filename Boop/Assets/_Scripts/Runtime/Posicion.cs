using UnityEngine;

namespace Boop.Runtime
{
    public class Posicion : MonoBehaviour
    {
        [SerializeField] private Vector3 _posicionVisible;

        private Vector3 _position { get => transform.position; }

        public void PosicionObjeto(GameObject objeto)
        {
            objeto.transform.position = PosicionFinal();
        }

        private Vector3 PosicionFinal() => _position + _posicionVisible;

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(PosicionFinal(), 0.1f);
        }
    }
}
