using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK;

public class CoreScene : MonoBehaviour
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
            fontSize = 20
        };

        GUI.depth = 0;

        if (GUI.Button(new Rect(50, 100, 200, 60), "初始化", myButtonStyle))
        {
            TapSDK.TDSCore.Init("clientId");
        }
        if (GUI.Button(new Rect(50, 200, 200, 60), "开启TapDB", myButtonStyle))
        {
            TapSDK.TDSCore.EnableTapDB("gameVersion","gamenChannel");
        }
        if (GUI.Button(new Rect(50, 300, 200, 60), "开启Moment", myButtonStyle))
        {
            TapSDK.TDSCore.EnableMoment();
        }
        if (GUI.Button(new Rect(50, 400, 200, 60), "返回", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }
    }

}
