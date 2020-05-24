using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mgr : MonoBehaviour
{
    public Button ButtonPrefab;
    public RectTransform ButtonParent;
    
    private void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            string sceneName = SceneManager.GetSceneAt(i).name;
            Button b = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, ButtonParent);
            b.name = sceneName;
            b.GetComponentInChildren<Text>().text = sceneName;
            b.onClick.AddListener(() => ButEvent(b));
        }
    }

    private void ButEvent(Button but)
    {
        Debug.Log(but.name + " Clicked!");
        SceneManager.LoadScene(but.name);
    }

}