using Baruah.Config;
using Baruah.Service;
using Baruah.UserState;
using System.IO;
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
            ServiceManager.Add(new UserStateService(Path.Combine(Application.persistentDataPath, "UserState")));
            ServiceManager.Add(new PlayerService());

            SceneManager.LoadScene(1);
        }
    }
}
