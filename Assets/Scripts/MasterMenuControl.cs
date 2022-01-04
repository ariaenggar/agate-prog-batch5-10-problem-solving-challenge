using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterMenuControl : MonoBehaviour
{
    public Button[] buttons;
    public Button buttonExit;
    void Start()
    {
        for (int i = 0; i <= 8; i++)
        {
            string sceneName = "Problem" + (i + 1);
            
            if (sceneName == "Problem9") sceneName += "AttentionScene";
            
            buttons[i].onClick.AddListener(delegate { LoadScene(sceneName); });
        }
        
        buttonExit.onClick.AddListener(Application.Quit);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
