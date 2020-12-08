using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK;

public class LoginScene : MonoBehaviour, TapSDK.LoginCallback
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

    public void LoginSuccess(TapSDK.TDSAccessToken accessToken)
    {
        this.label = accessToken.toJSON();
    }

    public void LoginCancel()
    {
        this.label = "登陆取消";
    }

    public void LoginError(string error)
    {
        this.label = error;
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

        GUI.Label(new Rect(400, 400, 400, 300), label, myLabelStyle);

        GUI.Toggle(new Rect(50, 50, 100, 30), isCN, "国内");

        GUI.Toggle(new Rect(50, 100, 100, 30), isCorner, "圆角");

        if (GUI.Button(new Rect(50, 200, 200, 60), "初始化", myButtonStyle))
        {
            TapSDK.TDSLogin.Init("CqBgq73t1JdHFE3Rk3");
        }

        if (GUI.Button(new Rect(50, 300, 200, 60), "带参初始化", myButtonStyle))
        {
            TapSDK.TDSLogin.Init("CqBgq73t1JdHFE3Rk3", isCN, isCorner);
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
                Debug.Log("accessToken:" + accessToken.toJSON());
                this.label = accessToken.toJSON();
            });
        }

        if (GUI.Button(new Rect(300, 50, 200, 60), "获取profile", myButtonStyle))
        {
            TapSDK.TDSLogin.GetCurrentProfile((profile) =>
            {
                Debug.Log("profile:" + profile.toJSON());
                this.label = profile.toJSON();
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
                Debug.Log("profile:" + profile.toJSON());
                this.label = profile.toJSON();
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
