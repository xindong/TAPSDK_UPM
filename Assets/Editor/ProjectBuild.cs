using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

class ProjectBuild : Editor
{
    //在这里找出你当前工程所有的场景文件，假设你只想把部分的scene文件打包 那么这里可以写你的条件判断 总之返回一个字符串数组。
    static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();
        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if (e == null)
                continue;
            if (e.enabled)
                names.Add(e.path);
        }
        return names.ToArray();
    }

    static void BuildForAndroid()
    {   

        float time = Time.realtimeSinceStartup;

        // 签名文件配置，若不配置，则使用Unity默认签名
        PlayerSettings.Android.keyaliasName = "wxlogin";
        PlayerSettings.Android.keyaliasPass = "111111";
        PlayerSettings.Android.keystoreName = Application.dataPath.Replace("/Assets", "") + "/sign_password_111111.keystore";
        PlayerSettings.Android.keystorePass = "111111";

        // APK路径、名字配置
        string apkName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string path = Application.dataPath.Replace("/Assets", "") + "/" + "TapSDKUnity_" + apkName + ".apk";
        try{
            BuildPipeline.BuildPlayer(GetBuildScenes(), path, BuildTarget.Android, BuildOptions.None);
        }catch(System.Exception e)
        {
            Debug.LogError(e.Message);
        }
        time = Time.realtimeSinceStartup - time;
        Debug.Log("Android打包完成，共计耗时" + time);
    }

    static void BuildForIOS()
    {
        
        string path = Application.dataPath.Replace("/Assets", "") + "/TapSDKUnity";

        float time = Time.realtimeSinceStartup;

        AssetDatabase.Refresh();
        try
        {
            BuildPipeline.BuildPlayer(GetBuildScenes(), path, BuildTarget.iOS, BuildOptions.None);
        }
        catch (System.Exception m)
        {
            Debug.LogError(m.Message);
        }
        time = Time.realtimeSinceStartup - time;
        Debug.Log("IOS打包完成，共计耗时" + time);
    }

}