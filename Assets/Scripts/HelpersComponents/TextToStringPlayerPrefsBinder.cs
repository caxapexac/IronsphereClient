using Static;
using TMPro;
using UnityEngine;


namespace HelpersComponents
{
    [ExecuteAlways]
    public class TextToStringPlayerPrefsBinder : MonoBehaviour
    {
        public StrPrefs Key;

        private TMP_Text _inputField;

        public void Awake()
        {
            _inputField = GetComponent<TMP_Text>();
            _inputField.text = PlayerPrefs.GetString(Key.ToString(), _inputField.text);
            PlayerPrefsWrapper.StringPrefsChanged += PrefsChanged;
        }

        private void PrefsChanged(object sender, (StrPrefs, string) data)
        {
            if (data.Item1 == Key) _inputField.text = data.Item2;
        }

        private void OnDestroy()
        {
            PlayerPrefsWrapper.StringPrefsChanged -= PrefsChanged;
        }
    }
}