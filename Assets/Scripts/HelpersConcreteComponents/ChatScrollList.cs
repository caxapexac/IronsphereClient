using System.Collections.Generic;
using JsonSchemas;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;


namespace HelpersConcreteComponents
{
    public class ChatScrollList : MonoBehaviour
    {
        public ChatScrollListItem ItemPrefab;

        private RectTransform _contentTransform;

        private static ChatScrollList _instance;

        private float _lastUpdateTime;

        private void Awake()
        {
            _instance = this;
            _contentTransform = GetComponent<ScrollRect>().content;
            _lastUpdateTime = Time.time;
        }

        private void Start()
        {
            UpdateData();
        }

        private void Update()
        {
            if (Time.time - _lastUpdateTime > Constants.SlowUpdateDelay)
            {
                _lastUpdateTime = Time.time;
                UpdateData();
            }
        }

        public static void UpdateData()
        {
            in_read_chat.Send();
        }

        public static void DrawScrollList(List<chat_message> messages)
        {
            if (!_instance) return;
            foreach (Transform child in _instance._contentTransform.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (chat_message message in messages)
            {
                Instantiate(_instance.ItemPrefab, _instance._contentTransform).VisualizeData(message);
            }
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}