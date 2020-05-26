using System;
using JsonSchemas;
using Static;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace HelpersConcreteComponents
{
    public class SessionScrollListItem : MonoBehaviour
    {
        public TMP_Text SessionIdText;
        public TMP_Text SessionNameText;
        public TMP_Text PlayerCountText;
        public TMP_Text SessionStateText;

        private int _sessionId;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            PlayerPrefsWrapper.Set(IntPrefs.session_id, _sessionId);
        }

        public void VisualizeData(int sessionId, session data)
        {
            _sessionId = sessionId;
            SessionIdText.text = sessionId.ToString();
            SessionNameText.text = data.session_name;
            PlayerCountText.text = $"{data.players_uid.Count.ToString()} players";
            SessionStateText.text = data.state.ToString();
        }
    }
}