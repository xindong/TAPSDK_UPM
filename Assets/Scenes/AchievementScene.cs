using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSAchievement;
using TDSCommon;

public class AchievementScene : MonoBehaviour, AchievementCallback, GetAchievementCallback
{
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onAchievementSDKInitSuccess()
    {
        Debug.Log("初始化成功");
    }

    public void onAchievementInitFail(int errrorCode)
    {
        Debug.Log("初始化失败：" + errrorCode);
    }

    public void onAchievementStatusUpdate(AchievementBean bean, int errorCode)
    {
        if (errorCode != 0)
        {
            Debug.Log("更新成就状态错误：" + errorCode);
            return;
        }

        Debug.Log("更新成就状态：" + JsonUtility.ToJson(bean));
    }

    public void GetAchievementCallback(List<AchievementBean> list, int errorCode)
    {
        if (errorCode != 0)
        {
            Debug.Log("获取成就错误" + errorCode);
            return;
        }
        foreach (AchievementBean achievement in list)
        {
            Debug.Log("获取成就" + JsonUtility.ToJson(achievement));
        }
    }

    private void OnGUI()
    {

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 50
        };

        GUI.depth = 0;

        

        if (GUI.Button(new Rect(50, 100, 300, 100), "初始化", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.registerCallback(this);
        }

        if (GUI.Button(new Rect(50, 250, 300, 100), "注册", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.initWithXD("71417", "530e765b00a825aefeccaa4ef819ca43");
        }

        if (GUI.Button(new Rect(50, 400, 300, 100), "获取所有成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.fetchAllAchievementList(this);
        }

        if (GUI.Button(new Rect(50, 550, 300, 100), "获取用户成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.fetchUserAchievementList(this);
        }   

        if (GUI.Button(new Rect(50, 700, 300, 100), "返回", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }   


        if (GUI.Button(new Rect(400, 100, 300, 100), "获取本地所有成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.getLocalAllAchievementList(this);
        }

        if (GUI.Button(new Rect(400, 250, 300, 100), "获取本地用户成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.getLocalUserAchievementList(this);
        }


        if (GUI.Button(new Rect(400, 400, 300, 100), "取得指定成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.reach("C14");
        }

        if (GUI.Button(new Rect(400, 550, 300, 100), "指定成就+1", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.growSteps("C63",1);
        }

        if (GUI.Button(new Rect(400, 700, 400, 100), "到达指定成就：100", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.makeSteps("C63",100);
        }

        if (GUI.Button(new Rect(400, 850, 300, 100), "弹窗", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.showAchievementPage();
        }


        if (GUI.Button(new Rect(750, 100, 300, 100), "英文", myButtonStyle))
        {
            TDSCommon.TDSLanguage.GetInstance().SetLanguage("en_US");
        }

        if (GUI.Button(new Rect(750, 250, 300, 100), "中文", myButtonStyle))
        {
            TDSCommon.TDSLanguage.GetInstance().SetLanguage("zh_CN");
        }

    }

}
