using System;
using MonoBehaviours;
using Static;
using TMPro;
using UnityEngine;


namespace HelpersComponents
{
    [ExecuteAlways]
    public class InputFieldToPlayerPrefsBinder : MonoBehaviour
    {
        public StrPrefs Key;

        private TMP_InputField _inputField;

        public void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _inputField.text = PlayerPrefs.GetString(Key.ToString(), _inputField.text);
            PlayerPrefsWrapper.Set(Key, _inputField.text);
            _inputField.onValueChanged.AddListener(ValueChanged);
            PlayerPrefsWrapper.StringPrefsChanged += PrefsChanged;
        }

        private void ValueChanged(string text)
        {
            PlayerPrefsWrapper.Set(Key, text);
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