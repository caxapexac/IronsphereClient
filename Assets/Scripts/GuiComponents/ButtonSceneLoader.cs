using MonoBehaviours;
using Static;
using UnityEngine;
using UnityEngine.UI;


namespace GuiComponents
{
    public class ButtonSceneLoader : MonoBehaviour
    {
        public Scenes SceneName;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            UnityWrapper.LoadScene(SceneName);
        }
    }
}