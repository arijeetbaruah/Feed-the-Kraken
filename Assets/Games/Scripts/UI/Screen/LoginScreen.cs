using Baruah.Service;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Baruah.UI
{
    public class LoginScreen : MonoBehaviour
    {
        void Start()
        {
            ServiceManager.Add(new AuthSystem(success =>
            {
                if (success)
                {
                    SceneManager.LoadScene(2);
                }
            }));
        }
    }
}
