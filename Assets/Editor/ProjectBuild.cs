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
        // 签名文件配置，若不配置，则使用Unity默认签名
        PlayerSettings.Android.keyaliasName = "wxlogin";
        PlayerSettings.Android.keyaliasPass = "111111";
        PlayerSettings.Android.keystoreName = Application.dataPath.Replace("/Assets", "") + "/sign_password_111111.keystore";
        PlayerSettings.Android.keystorePass = "111111";

        // APK路径、名字配置
        string apkName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string path = Application.dataPath + "/" + "TapSDKUnity_" + apkName + ".apk";
        BuildPipeline.BuildPlayer(GetBuildScenes(), path, BuildTarget.Android, BuildOptions.None);
    }
}