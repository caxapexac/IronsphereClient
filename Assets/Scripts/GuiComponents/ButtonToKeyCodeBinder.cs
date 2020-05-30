using System;
using UnityEngine;
using UnityEngine.UI;


namespace GuiComponents
{
    public class ButtonToKeyCodeBinder : MonoBehaviour
    {
        public KeyCode ClickCode;

        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (!_button.interactable) return;
            if (Input.GetKeyDown(ClickCode)) _button.onClick.Invoke();
        }
    }
}