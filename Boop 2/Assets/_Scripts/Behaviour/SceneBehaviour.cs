using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boop.Bahaviour
{
    public class SceneBehaviour : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }
}
