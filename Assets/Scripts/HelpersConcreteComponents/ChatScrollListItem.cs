using JsonSchemas;
using Singletons;
using TMPro;
using UnityEngine;


namespace HelpersConcreteComponents
{
    public class ChatScrollListItem : MonoBehaviour
    {
        public TMP_Text PlayerNameText;
        public TMP_Text MessageText;

        public void VisualizeData(chat_message message)
        {
            PlayerNameText.text = God.NetworkManager.GetUsernameById(message.player_uid);
            MessageText.text = message.message;
        }
    }
}