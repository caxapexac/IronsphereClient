using MonoBehaviours;
using Static;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Singletons
{
    public class God : MonoBehaviour
    {
        public static God I = null;
        public static NetworkManager NetworkManager;

        private void Awake()
        {
            if (I)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            I = this;
            NetworkManager = GetComponent<NetworkManager>();
            // TODO
            PlayerPrefs.SetString(StrPrefs.server_ip.ToString(), "127.0.0.1:1109");
        }
    }
}