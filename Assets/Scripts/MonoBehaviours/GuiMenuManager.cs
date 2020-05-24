using HybridWebSocket;
using JsonSchemas;
using Network;
using UnityEngine;


namespace MonoBehaviours
{
    public class GuiMenuManager : MonoBehaviour
    {
        public void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
        
    }
}