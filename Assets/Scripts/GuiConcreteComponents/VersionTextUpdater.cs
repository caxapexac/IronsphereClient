using MonoBehaviours;
using TMPro;
using UnityEngine;


namespace GuiConcreteComponents
{
    [ExecuteAlways]
    public class VersionTextUpdater : MonoBehaviour
    {
        public string Prefix;
        
        public void Start()
        {
            TextMeshProUGUI versionText = GetComponent<TextMeshProUGUI>();
            versionText.text = Prefix + Constants.Version;
        }
        
    }
}