using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MomentScene : MonoBehaviour
{
    private string imagePath = "hello,world";
    private string videoPath = "输入 VideoPath";

    private string tapToken = "Please input tap token";

    private string cliendId = "d4bjgwom9zk84wk";

    private void OnGUI()
    {
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 30
        };
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20
        };
        GUIStyle inputStyle = new GUIStyle(GUI.skin.textField)
        {
            fontSize = 20
        };

        string desc = "普通动态描述";

        string title = "title";

        if (GUI.Button(new Rect(50, 50, 250, 60), "设置回调", buttonStyle))
        {
            TapSDK.TDSMoment.SetCallback((action, msg) =>
            {
                Debug.Log("GetMomentCallback action = " + action + " ,msg = " + msg);

            });
        }

        tapToken = GUI.TextArea(new Rect(50, 150, 250, 60), tapToken, inputStyle);

        cliendId = GUI.TextArea(new Rect(50, 350, 250, 60), cliendId, inputStyle);

        if (GUI.Button(new Rect(50, 450, 250, 60), "设置ClientId", buttonStyle))
        {
            TapSDK.TDSMoment.InitSDK(cliendId);
        }

        imagePath = GUI.TextArea(new Rect(400, 100, 250, 60), imagePath, inputStyle);

        if (GUI.Button(new Rect(400, 200, 250, 60), "发布图片动态", buttonStyle))
        {
            TapSDK.TDSMoment.PublishMoment(TapSDK.Orientation.ORIENTATION_DEFAULT, imagePath.Split(','), desc);
        }

        videoPath = GUI.TextArea(new Rect(400, 300, 250, 60), videoPath, inputStyle);

        if (GUI.Button(new Rect(400, 400, 250, 60), "发布视频动态", buttonStyle))
        {
            TapSDK.TDSMoment.PublishVideoMoment(TapSDK.Orientation.ORIENTATION_DEFAULT, videoPath.Split(','), imagePath.Split(','), title, desc);
        }

        if (GUI.Button(new Rect(50, 550, 250, 60), "打开动态", buttonStyle))
        {
            TapSDK.TDSMoment.OpenMoment(TapSDK.Orientation.ORIENTATION_DEFAULT);
        }

        if (GUI.Button(new Rect(700, 300, 250, 60), "获取通知", buttonStyle))
        {
            TapSDK.TDSMoment.GetNoticeData();
        }

        if (GUI.Button(new Rect(700, 100, 250, 60), "10s直接关闭", buttonStyle))
        {
            Invoke("closeMoment", 10.0f);
        }

        if (GUI.Button(new Rect(700, 200, 250, 60), "10s弹窗关闭", buttonStyle))
        {
            Invoke("closeMomentWithDialog", 10.0f);
        }

    }

    void closeMoment()
    {
        TapSDK.TDSMoment.CloseMoment();
    }

    void closeMomentWithDialog()
    {
        TapSDK.TDSMoment.CloseMoment("标题", "内容");
    }

}
