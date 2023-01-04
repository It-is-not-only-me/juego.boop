using Boop.Configuracion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Boop.Manager
{
    [CreateAssetMenu(fileName = "Escena manager", menuName = "Boop/Manager/Escena")]
    public class EscenaManager : ScriptableObject
    {
        public void CambiarAEscena(ConfiguracionEscena escena)
        {
            SceneManager.LoadScene(escena.Indice);
        }
    }
}