using MonoBehaviours;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Static
{
    public static class UnityWrapper
    {
        public static void LoadScene(Scenes sceneName)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(sceneName.ToString());
        }
    }
}