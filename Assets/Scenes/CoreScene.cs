using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK;

public class CoreScene : MonoBehaviour,LoginCallback
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private string label = "";

    public void LoginSuccess(TDSAccessToken token)
    {
        this.label = token.ToJSON();
    }

    public void LoginCancel()
    {
        this.label = "登陆取消";
    }

    public void LoginError(TDSAccountError error)
    {
        this.label = error.ToJSON();
    }

    private void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 20
        };

        GUI.depth = 0;

        GUIStyle myLabelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20
        };

        GUI.Label(new Rect(400, 100, 400, 300), label, myLabelStyle);

        if (GUI.Button(new Rect(50, 100, 200, 60), "初始化", myButtonStyle))
        {
            TapSDK.TDSCore.Init("FwFdCIr6u71WQDQwQN");
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
