using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSMoment
{
    public enum CallbackCode : int
    {
        CALLBACK_CODE_MOMENT_APPEAR = 30000,
        CALLBACK_CODE_MOMENT_DISAPPEAR = 30100,

        CALLBACK_CODE_PUBLISH_SUCCESS = 10000,
        CALLBACK_CODE_PUBLISH_FAIL = 10100,
        CALLBACK_CODE_PUBLISH_CANCEL = 10200,

        CALLBACK_CODE_GET_NOTICE_SUCCESS = 20000,
        CALLBACK_CODE_GET_NOTICE_FAIL = 20100
    }

    public enum Orientation : int
    {
        ORIENTATION_DEFAULT = -1,
        ORIENTATION_LANDSCAPE = 0,
        ORIENTATION_PORTRAIT = 1
    }

    public class TDSMoment
    {

        public static void SetCallback(Action<int, string> callback)
        {
            MomentImpl.GetInstance().SetCallback(callback);
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

        public static void SetGameScreenAutoRotate(Boolean auto)
        {
            MomentImpl.GetInstance().SetUseAutoRotate(auto);
        }

    }
}