using System;
using MonoBehaviours;
using Static;
using UnityEngine;


namespace GuiComponents
{
    public class SceneLoaderOnPlayerPrefs : MonoBehaviour
    {
        public Scenes SceneName;
        public IntPrefs KeyShouldExist;

        private void Awake()
        {
            PlayerPrefsWrapper.IntPrefsChanged += ValueChanged;
        }
        
        private void ValueChanged(object sender, (IntPrefs, int) data)
        {
            if (data.Item1 == KeyShouldExist && data.Item2 != 0) UnityWrapper.LoadScene(SceneName);
        }

        private void OnDestroy()
        {
            PlayerPrefsWrapper.IntPrefsChanged -= ValueChanged;
        }
    }
}