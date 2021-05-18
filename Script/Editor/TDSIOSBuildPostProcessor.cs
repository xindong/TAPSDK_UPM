#if UNITY_EDITOR && UNITY_IOS
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using TDSEditor;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
#endif
using UnityEngine;
namespace TDSEditor
{
 public class TDSIOSPostBuildProcessor : MonoBehaviour
    {
#if UNITY_IOS
        // 添加标签，unity导出工程后自动执行该函数
        [PostProcessBuild]
        public static void OnPostprocessBuild(BuildTarget BuildTarget, string path)
        {
            
            if (BuildTarget == BuildTarget.iOS)
            {   
                // 获得工程路径
                string projPath = PBXProject.GetPBXProjectPath(path);
                UnityEditor.iOS.Xcode.PBXProject proj = new PBXProject();
                proj.ReadFromString(File.ReadAllText(projPath));

                // 2019.3以上有多个target
#if UNITY_2019_3_OR_NEWER
                string unityFrameworkTarget = proj.GetUnityFrameworkTargetGuid();
                string target = proj.GetUnityMainTargetGuid();
#else
                string unityFrameworkTarget = proj.TargetGuidByName("Unity-iPhone");
                string target = proj.TargetGuidByName("Unity-iPhone");
#endif
                if (target == null)
                {
                    Debug.Log("target is null ?");
                    return;
                }

                // 编译配置
                proj.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");
                proj.AddBuildProperty(unityFrameworkTarget, "OTHER_LDFLAGS", "-ObjC");
                // Swift编译选项
                proj.SetBuildProperty(target, "ENABLE_BITCODE", "NO"); //bitcode  NO
                proj.SetBuildProperty(target,"ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES","YES");
                proj.SetBuildProperty(target, "SWIFT_VERSION", "5.0");
                proj.SetBuildProperty(target, "CLANG_ENABLE_MODULES", "YES");
                proj.SetBuildProperty(unityFrameworkTarget, "ENABLE_BITCODE", "NO"); //bitcode  NO
                proj.SetBuildProperty(unityFrameworkTarget,"ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES","NO");
                proj.SetBuildProperty(unityFrameworkTarget, "SWIFT_VERSION", "5.0");
                proj.SetBuildProperty(unityFrameworkTarget, "CLANG_ENABLE_MODULES", "YES");
                // add extra framework(s)
                // 参数: 目标targetGUID, framework,是否required:fasle->required,true->optional
                proj.AddFrameworkToProject(unityFrameworkTarget, "CoreTelephony.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "QuartzCore.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "Security.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "WebKit.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "Photos.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AdSupport.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AssetsLibrary.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AVKit.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AuthenticationServices.framework", true);
                proj.AddFrameworkToProject(unityFrameworkTarget, "LocalAuthentication.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "SystemConfiguration.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "Accelerate.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "SafariServices.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AVFoundation.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "MobileCoreServices.framework", false);
                proj.AddFrameworkToProject(unityFrameworkTarget, "AppTrackingTransparency.framework", true);
                // 动态库
                Debug.Log("添加framework成功");

                // 添加 tbd
                // 参数: 目标targetGUID, tdbGUID
                proj.AddFileToBuild(unityFrameworkTarget, proj.AddFile("usr/lib/libc++.tbd", "libc++.tbd",PBXSourceTree.Sdk));
                
                Debug.Log("添加tbd成功");
                
                // 添加资源文件，注意文件路径
                var resourcePath = Path.Combine(path, "TDSResource");

                string parentFolder = Directory.GetParent(Application.dataPath).FullName;

                if (Directory.Exists(resourcePath))
                {
                    Directory.Delete(resourcePath,true);
                }

                Directory.CreateDirectory(resourcePath);

                string remotePackagePath = TDSFileHelper.FilterFile(parentFolder + "/Library/PackageCache/","com.tds.sdk@");

                string localPackagePath = TDSFileHelper.FilterFile(parentFolder,"TapSDK");

                string tdsResourcePath = remotePackagePath !=null? remotePackagePath + "/Plugins/iOS/Resource" : localPackagePath + "/Plugins/iOS/Resource";
                
                if(Directory.Exists(tdsResourcePath)){
                    TDSFileHelper.CopyAndReplaceDirectory(tdsResourcePath, resourcePath);
                }

                FileInfo plistFile = TDSFileHelper.RecursionFilterFile(parentFolder + "/Assets/Plugins/","TDS-Info.plist");

                if(plistFile.Exists)
                {
                    plistFile.CopyTo(resourcePath + "/TDS-Info.plist");
                }
                
                List<string> names = new List<string>(); 
                names.Add("TDSCommonResource.bundle");
                names.Add("TDSMomentResource.bundle");
                foreach (var name in names)
                {
                    proj.AddFileToBuild(target, proj.AddFile(Path.Combine(resourcePath,name), Path.Combine(resourcePath,name), PBXSourceTree.Source));
                }
                Debug.Log("TapSDK添加resource成功");
                // rewrite to file  
                File.WriteAllText(projPath, proj.WriteToString());
                SetPlist(path,resourcePath + "/TDS-Info.plist");
                SetScriptClass(path);
                return;
            }

        }

        // 修改pilist
        private static void SetPlist(string pathToBuildProject,string infoPlistPath)
        {
            //添加info
            string _plistPath = pathToBuildProject + "/Info.plist";
            PlistDocument _plist = new PlistDocument();
            _plist.ReadFromString(File.ReadAllText(_plistPath));
            PlistElementDict _rootDic = _plist.root;

            List<string> items = new List<string>()
            {
                "tapsdk",
                "tapiosdk",
            };
            PlistElementArray _list = _rootDic.CreateArray("LSApplicationQueriesSchemes");
            for (int i = 0; i < items.Count; i++)
            {
                _list.AddString(items[i]);
            }
                        
            if(!string.IsNullOrEmpty(infoPlistPath))
            {   
                Dictionary<string, object> dic = (Dictionary<string, object>)TDSEditor.Plist.readPlist(infoPlistPath);
                string taptapId = null; 

                foreach (var item in dic)
                {
                    if(item.Key.Equals("taptap")){
                        Dictionary<string,object> taptapDic = (Dictionary<string,object>) item.Value;
                        foreach (var taptapItem in taptapDic)
                        {
                            if(taptapItem.Key.Equals("client_id")){
                                taptapId = "tt" + (string) taptapItem.Value;
                            }
                        }
                    } else {
                        //Copy TDS-Info.plist中的数据
                        _rootDic.SetString(item.Key.ToString(),item.Value.ToString());
                    }
                }
                //添加url
                PlistElementDict dict = _plist.root.AsDict();
                PlistElementArray array = dict.CreateArray("CFBundleURLTypes");
                PlistElementDict dict2 = array.AddDict();
                if(taptapId!=null)
                {
                    Debug.Log("修改TapTapClientId:" + taptapId + " 成功");
                    dict2.SetString("CFBundleURLName", "TapTap");
                    PlistElementArray array2 = dict2.CreateArray("CFBundleURLSchemes");
                    array2.AddString(taptapId);
                }    
            }

            File.WriteAllText(_plistPath, _plist.WriteToString());
            Debug.Log("修改添加info文件成功");
        }


        // 添加appdelegate处理
        private static void SetScriptClass(string pathToBuildProject)
        {
            string unityAppControllerPath = pathToBuildProject + "/Classes/UnityAppController.mm";
            TDSEditor.TDSScriptStreamWriterHelper UnityAppController = new TDSEditor.TDSScriptStreamWriterHelper(unityAppControllerPath);
            UnityAppController.WriteBelow(@"#import <OpenGLES/ES2/glext.h>", @"#import <TapSDK/TapLoginHelper.h>");
            UnityAppController.WriteBelow(@"id sourceApplication = options[UIApplicationOpenURLOptionsSourceApplicationKey], annotation = options[UIApplicationOpenURLOptionsAnnotationKey];",@"if(url){[TapLoginHelper handleTapTapOpenURL:url];}");
            Debug.Log("修改代码成功");
        }
    }

}    
#endif
#endif
