using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class TDSMoment
    {

        public static void SetCallback(Action<int, string> callback)
        {
            MomentImpl.GetInstance().SetCallback(callback);
        }

        public static void InitSDK(string clientId)
        {
            MomentImpl.GetInstance().InitSDK(clientId);
        }

        public static void OpenMoment(Orientation config)
        {
            MomentImpl.GetInstance().OpenMoment(config);
        }

        public static void PublishMoment(Orientation config, string[] imagePaths, string content)
        {
            MomentImpl.GetInstance().PublishMoment(config, imagePaths, content);
        }

        public static void PublishVideoMoment(Orientation config, string[] videoPaths, string[] imagePaths, string title, string desc)
        {
            MomentImpl.GetInstance().PublishVideoMoment(config, videoPaths, imagePaths, title, desc);
        }

        public static void PublishVideoMoment(Orientation config, string[] videoPaths, string title, string desc)
        {
            MomentImpl.GetInstance().PublishVideoMoment(config, videoPaths, title, desc);
        }

        public static void GetNoticeData()
        {
            MomentImpl.GetInstance().GetNoticeData();
        }

        public static void CloseMoment()
        {
            MomentImpl.GetInstance().CloseMoment();
        }

        public static void CloseMoment(string title, string desc)
        {
            MomentImpl.GetInstance().CloseMoment(title, desc);
        }

        public static void SetGameScreenAutoRotate(bool auto)
        {
            MomentImpl.GetInstance().SetUseAutoRotate(auto);
        }

        public static void OpenSceneEntryMoment(Orientation orientation,string sceneId)
        {
            MomentImpl.GetInstance().OpenSceneEntryMoment(orientation,sceneId);
        }

    }
}