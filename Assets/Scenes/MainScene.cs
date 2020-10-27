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

        if (GUI.Button(new Rect(50, 100, 300, 100), "成就", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
        }

    }
}
