using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK;

public class TapDBScene : MonoBehaviour
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
            TapSDK.TDSTapDB.Init("FwFdCIr6u71WQDQwQN", "channel", "gameVersion");
        }
        if (GUI.Button(new Rect(50, 200, 200, 60), "设置User", myButtonStyle))
        {
            TapSDK.TDSTapDB.SetUser("userId");
        }
        if (GUI.Button(new Rect(50, 300, 200, 60), "设置UserParams", myButtonStyle))
        {
            TapSDK.TDSTapDB.SetUser("userId","loginType");
        }
        if (GUI.Button(new Rect(50, 400, 200, 60), "设置名字", myButtonStyle))
        {
            TapSDK.TDSTapDB.SetName("name");
        }
        if (GUI.Button(new Rect(50, 500, 200, 60), "设置level", myButtonStyle))
        {
            TapSDK.TDSTapDB.SetLevel(1);
        }
        if (GUI.Button(new Rect(300, 100, 200, 60), "设置server", myButtonStyle))
        {
            TapSDK.TDSTapDB.SetServer("server");
        }
        if (GUI.Button(new Rect(300, 200, 200, 60), "onCharge", myButtonStyle))
        {
            TapSDK.TDSTapDB.OnCharge("orderId", "productId", "amount", "currencyType", "payment");
        }
        if (GUI.Button(new Rect(300, 300, 200, 60), "onEvent", myButtonStyle))
        {
            TapSDK.TDSTapDB.OnEvent("eventCode", "properties");
        }
        if (GUI.Button(new Rect(300, 400, 200, 60), "返回", myButtonStyle))
        {
            TapSDK.TDSTapDB.OnEvent("eventCode", "properties");
        }

    }

}
