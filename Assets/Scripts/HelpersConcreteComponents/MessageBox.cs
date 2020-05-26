using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace HelpersConcreteComponents
{
    public class MessageBox : MonoBehaviour
    {
        public GameObject ContentObject;
        public TMP_Text HeaderText;
        public TMP_Text DataText;
        public Button OkButton;

        private static MessageBox _instance;
        private Vector2 _startMousePosition;
        private Vector2 _startMessageBoxPosition;

        private void Awake()
        {
            _instance = this;
            OkButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ContentObject.SetActive(false);
        }

        public static void ShowInfo(string message)
        {
            Show("INFO", message);
        }
        
        public static void ShowError(string message)
        {
            Show("ERROR", message);
        }
        
        public static void Show(string header, string message)
        {
            if (_instance == null) return;
            _instance.HeaderText.text = header;
            _instance.DataText.text = message;
            _instance.ContentObject.SetActive(true);
        }

        private void OnMouseDown()
        {
            _startMousePosition = Input.mousePosition;
            _startMessageBoxPosition = transform.position;
        }

        private void OnMouseOver()
        {
            transform.position = _startMessageBoxPosition + (Vector2)Input.mousePosition - _startMousePosition;
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}