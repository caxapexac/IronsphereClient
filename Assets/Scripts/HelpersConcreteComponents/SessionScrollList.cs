using System;
using System.Collections.Generic;
using JsonSchemas;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;


namespace HelpersConcreteComponents
{
    public class SessionScrollList : MonoBehaviour
    {
        public SessionScrollListItem ItemPrefab;

        private RectTransform _contentTransform;

        private static SessionScrollList _instance;

        private Dictionary<int, session> _sessions;

        private float _lastUpdateTime;

        private void Awake()
        {
            _instance = this;
            _contentTransform = GetComponent<ScrollRect>().content;
            _sessions = null;
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
            in_server_info.Send();
        }

        public static void DrawScrollList(Dictionary<int, session> sessions)
        {
            if (!_instance) return;
            foreach (Transform child in _instance._contentTransform.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (KeyValuePair<int, session> session in sessions)
            {
                Instantiate(_instance.ItemPrefab, _instance._contentTransform).VisualizeData(session.Key, session.Value);
            }
        }

        public static session GetSessionByID(int id)
        {
            if (!_instance) return null;
            if (_instance._sessions == null) return null;
            if (!_instance._sessions.ContainsKey(id)) return null;
            return _instance._sessions[id];
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}