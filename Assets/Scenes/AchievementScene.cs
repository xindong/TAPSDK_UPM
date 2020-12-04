using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSAchievement;
using TDSCommon;

public class AchievementScene : MonoBehaviour, AchievementCallback, GetAchievementCallback
{
    // Start is called before the first frame update


    string reachId = "C13";

    string step = "10";

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
            fontSize = 30
        };

        GUI.depth = 0;


        if (GUI.Button(new Rect(50, 50, 200, 60), "初始化", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.registerCallback(this);
        }

        if (GUI.Button(new Rect(50, 150, 200, 60), "注册", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.initWithXD("71417", "530e765b00a825aefeccaa4ef819ca43");
        }

        if (GUI.Button(new Rect(50, 250, 200, 60), "获取所有成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.fetchAllAchievementList(this);
        }

        if (GUI.Button(new Rect(50, 350, 200, 60), "获取用户成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.fetchUserAchievementList(this);
        }

        if (GUI.Button(new Rect(50, 450, 200, 60), "返回", myButtonStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }   

        reachId = GUI.TextArea(new Rect(300,50,200,60),reachId);

        step = GUI.TextArea(new Rect(300,150,200,60),step);

        if (GUI.Button(new Rect(300, 250, 200, 60), "获取本地所有成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.getLocalAllAchievementList(this);
        }

        if (GUI.Button(new Rect(400, 350, 200, 60), "获取本地用户成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.getLocalUserAchievementList(this);
        }

        if (GUI.Button(new Rect(400, 450, 200, 60), "取得指定成就", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.reach(reachId);
        }

        if (GUI.Button(new Rect(400, 550, 200, 60), "指定成就+1", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.growSteps(reachId,  int.Parse(step));
        }

        if (GUI.Button(new Rect(400, 650, 400, 60), "到达指定成就:" + reachId, myButtonStyle))
        {
            TDSAchievement.TDSAchievement.makeSteps(reachId, int.Parse(step));
        }

        if (GUI.Button(new Rect(400, 750, 200, 60), "弹窗", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.showAchievementPage();
        }

        if (GUI.Button(new Rect(650, 50, 200, 60), "英文", myButtonStyle))
        {
            TDSCommon.TDSCommon.SetLanguage("en_US");
        }

        if (GUI.Button(new Rect(650, 150, 200, 60), "中文", myButtonStyle))
        {
            TDSCommon.TDSCommon.SetLanguage("zh_CN");
        }

        if (GUI.Button(new Rect(650, 250, 200, 60), "显示Toast", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.SetShowToast(true);
        }

        if (GUI.Button(new Rect(650, 350, 200, 60), "不显示Toast", myButtonStyle))
        {
            TDSAchievement.TDSAchievement.SetShowToast(false);
        }

        if (GUI.Button(new Rect(850, 350, 200, 60), "地区", myButtonStyle))
        {
            TDSCommon.TDSCommon.GetRegionCode((isMainland)=>{
                Debug.Log("isMainLand:" + isMainland);
            });
        }

    }

}
