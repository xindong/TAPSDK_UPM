using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TDSMoment;

public class MomentScene : MonoBehaviour
{
    private string imagePath = "";
    private string videoPath = "";
    private void OnGUI()
    {
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 50
        };
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 25
        };
        GUIStyle inputStyle = new GUIStyle(GUI.skin.textField)
        {
            fontSize = 30
        };

        string desc = "普通动态描述";

        string title = "title";

        if (GUI.Button(new Rect(50, 100, 300, 100), "设置回调", buttonStyle))
        {
            TDSMoment.TDSMoment.SetCallback((action, msg) =>
            {
                Debug.Log("GetMomentCallback action = " + action + " ,msg = " + msg);

            });
        }

        if (GUI.Button(new Rect(50, 250, 300, 100), "初始化", buttonStyle))
        {
            //d4bjgwom9zk84wk evnn72tle1sgkgo a4d6xky5gt4c80s
            // xdsdk.XDSDK.InitSDK("2isp77irl1c0gc4", 1, "UnityXDSDK", "0.0.0", true);

            //#if !UNITY_EDITOR && !UNITY_STANDALONE_OSX && !UNITY_STANDALONE_WIN
            //            com.xdsdk.xdtrafficcontrol.XDTrafficControlListener.Init();
            //#endif


        }

        if (GUI.Button(new Rect(50, 400, 300, 100), "登录", buttonStyle))
        {

            // com.xdsdk.xdlive.XDLiveListener.Init();
        }


        //if (GUI.Button(new Rect(50, 400, 380, 100), "设置动态回调", buttonStyle))
        //{
        //    TapMomentSDK.TapMoment.SetCallback((action, msg) =>
        //    {
        //        if (TapMomentSDK.CallbackCode.CALLBACK_CODE_MOMENT_APPEAR.Equals(action))
        //        {

        //        }
        //    });
        //}


        imagePath = GUI.TextArea(new Rect(500, 100, 380, 100), imagePath);


        videoPath = GUI.TextArea(new Rect(500, 250, 380, 100), videoPath);

        if (GUI.Button(new Rect(50, 550, 380, 100), "打开动态", buttonStyle))
        {
            TDSMoment.TDSMoment.OpenMoment(TDSMoment.Orientation.ORIENTATION_DEFAULT);

        }
        if (GUI.Button(new Rect(50, 700, 380, 100), "登出", buttonStyle))
        {

        }

        if (GUI.Button(new Rect(500, 400, 380, 100), "发布动态", buttonStyle))
        {
            TDSMoment.TDSMoment.PublishMoment(TDSMoment.Orientation.ORIENTATION_DEFAULT, imagePath.Split(','), desc);
        }

        if (GUI.Button(new Rect(500, 550, 380, 100), "发布视频动态", buttonStyle))
        {
            TDSMoment.TDSMoment.PublishVideoMoment(TDSMoment.Orientation.ORIENTATION_DEFAULT, videoPath.Split(','), imagePath.Split(','), title, desc);
        }

        if (GUI.Button(new Rect(500, 700, 380, 100), "获取通知", buttonStyle))
        {
            TDSMoment.TDSMoment.GetNoticeData();
        }

        if (GUI.Button(new Rect(500, 850, 380, 100), "用户中心", buttonStyle))
        {

        }

        if (GUI.Button(new Rect(1000, 100, 380, 100), "10s直接关闭", buttonStyle))
        {
            Invoke("closeMoment", 10.0f);
        }

        if (GUI.Button(new Rect(1000, 250, 380, 100), "10s弹窗关闭", buttonStyle))
        {
            Invoke("closeMomentWithDialog", 10.0f);
        }

        if (GUI.Button(new Rect(1000, 400, 380, 100), "论坛", buttonStyle))
        {
        }

        //TapMomentSDK.TapMoment.PublishVideoMoment(momentConfig, videoPaths, title, desc);

    }

    void closeMoment()
    {
        TDSMoment.TDSMoment.CloseMoment();
    }

    void closeMomentWithDialog()
    {
        TDSMoment.TDSMoment.CloseMoment("提示", "");
    }

}
