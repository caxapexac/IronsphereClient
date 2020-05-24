using System;
using MonoBehaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace MonoHelpers
{
    public class InputFieldToPlayerPrefsBinder : MonoBehaviour
    {
        public StrPrefs Key;

        public void Awake()
        {
            TMP_InputField inputField = GetComponent<TMP_InputField>();
            inputField.text = PlayerPrefs.GetString(Key.ToString(), inputField.text);
            PlayerPrefs.SetString(Key.ToString(), inputField.text);
            inputField.onValueChanged.AddListener(ValueChanged);
        }

        private void ValueChanged(string text)
        {
            PlayerPrefs.SetString(Key.ToString(), text);
        }
    }
}