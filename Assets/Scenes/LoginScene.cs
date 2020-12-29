using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK;

public class LoginScene : MonoBehaviour, LoginCallback
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private string label;

    private bool isCN = true;

    private bool isCorner = true;

    public void LoginSuccess(TDSAccessToken accessToken)
    {
        this.label = accessToken.ToJSON();
    }

    public void LoginCancel()
    {
        this.label = "登陆取消";
    }

    public void LoginError(TDSAccountError error)
    {
        this.label = "账户报错:" + error.ToJSON();
        Debug.Log("账户报错:" + error.ToJSON());
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

        GUIStyle myToggleStyle = new GUIStyle(GUI.skin.toggle)
        {
            fontSize = 20
        };

        GUI.Label(new Rect(400, 600, 400, 300), label, myLabelStyle);

        GUI.Toggle(new Rect(50, 50, 100, 30), isCN, "国内",myToggleStyle);

        GUI.Toggle(new Rect(50, 100, 100, 30), isCorner, "圆角",myToggleStyle);

        if (GUI.Button(new Rect(50, 200, 200, 60), "初始化", myButtonStyle))
        {
            TapSDK.TDSLogin.Init("FwFdCIr6u71WQDQwQN");
        }

        if (GUI.Button(new Rect(50, 300, 200, 60), "带参初始化", myButtonStyle))
        {
            TapSDK.TDSLogin.Init("FwFdCIr6u71WQDQwQN", isCN, isCorner);
        }

        if (GUI.Button(new Rect(50, 400, 200, 60), "注册回调", myButtonStyle))
        {
            TapSDK.TDSLogin.RegisterLoginCallback(this);
        }

        if (GUI.Button(new Rect(50, 500, 200, 60), "开始登陆", myButtonStyle))
        {
            string[] permissions = { "public_profile" };
            TapSDK.TDSLogin.StartLogin(permissions);
        }

        if (GUI.Button(new Rect(50, 600, 200, 60), "获取token", myButtonStyle))
        {
            TapSDK.TDSLogin.GetCurrentAccessToken((accessToken) =>
            {
                Debug.Log("accessToken:" + accessToken.ToJSON());
                this.label = accessToken.ToJSON();
            });
        }

        if (GUI.Button(new Rect(50, 700, 200, 60), "取消注册", myButtonStyle))
        {
            TapSDK.TDSLogin.UnRegisterLoginCallback();
            this.label = "取消注册回调";
        }

        if (GUI.Button(new Rect(300, 50, 200, 60), "获取profile", myButtonStyle))
        {
            TapSDK.TDSLogin.GetCurrentProfile((profile) =>
            {
                Debug.Log("profile:" + profile.ToJSON());
                this.label = profile.ToJSON();
            });
        }

        if (GUI.Button(new Rect(300, 150, 200, 60), "退出登录", myButtonStyle))
        {
            TapSDK.TDSLogin.Logout();
        }

        if (GUI.Button(new Rect(300, 250, 200, 60), "remote profile", myButtonStyle))
        {
            TapSDK.TDSLogin.FetchProfileForCurrentAccessToken((profile) =>
            {
                Debug.Log("profile:" + profile.ToJSON());
                this.label = profile.ToJSON();
            }, (errorMsg) =>
            {
                this.label = errorMsg;
            });
        }

        if(GUI.Button(new Rect(300,350,200,60),"返回",myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }
        
    }

}
