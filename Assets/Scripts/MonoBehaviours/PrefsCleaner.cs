using System;
using System.Collections.Generic;
using Static;
using UnityEngine;


namespace MonoBehaviours
{
    public class PrefsCleaner : MonoBehaviour
    {
        public List<StrPrefs> StrPrefsesToClean;
        public List<IntPrefs> IntPrefsesToClean;

        private void Awake()
        {
            foreach (StrPrefs prefs in StrPrefsesToClean)
            {
                PlayerPrefsWrapper.Take(prefs);
            }
            foreach (IntPrefs prefs in IntPrefsesToClean)
            {
                PlayerPrefsWrapper.Take(prefs);
            }
        }
    }
}