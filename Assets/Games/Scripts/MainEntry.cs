using Baruah.Config;
using Baruah.Service;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Baruah
{
    public class MainEntry : MonoBehaviour
    {
        [SerializeField] private ConfigRegistry configRegistry;

        void Start()
        {
            ServiceManager.Add(new ConfigService(configRegistry));
            
            SceneManager.LoadScene(1);
        }
    }
}
