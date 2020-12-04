using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 50
        };

        GUI.depth = 0;

        if (GUI.Button(new Rect(50, 100, 200, 60), "登陆", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(3);
        }

        if (GUI.Button(new Rect(50, 300, 200, 60), "成就", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
        }


        if(GUI.Button(new Rect(50,250,200,60),"动态",myButtonStyle)){
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2);
        }

    }
}
