using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{   

    public enum CallbackCode : int
    {
        CALLBACK_CODE_INIT_SUCCESS = 40000,
        CALLBACK_CODE_INIT_FAIL = 40100,
        CALLBACK_CODE_ClOSE_CANCEL = 50000,
        CALLBACK_CODE_ClOSE_CONFIRM = 50100,
        CALLBACK_CODE_LOGIN_SUCCESS = 60000,
        CALLBACK_CODE_MOMENT_APPEAR = 30000,
        CALLBACK_CODE_MOMENT_DISAPPEAR = 30100,

        CALLBACK_CODE_PUBLISH_SUCCESS = 10000,
        CALLBACK_CODE_PUBLISH_FAIL = 10100,
        CALLBACK_CODE_PUBLISH_CANCEL = 10200,

        CALLBACK_CODE_GET_NOTICE_SUCCESS = 20000,
        CALLBACK_CODE_GET_NOTICE_FAIL = 20100,
        CALLBACK_CODE_ON_STOP = 500,
        CALLBACK_CODE_ON_RESUME = 600
    }

    public enum Orientation : int
    {
        ORIENTATION_DEFAULT = -1,
        ORIENTATION_LANDSCAPE = 0,
        ORIENTATION_PORTRAIT = 1
    }

    public interface IMoment
    {

        void SetCallback(Action<int, string> callback);

        void InitSDK(string clientId);

        void OpenMoment(Orientation orientation);

        void PublishMoment(Orientation orientation, string[] imagePaths, string content);

        void PublishVideoMoment(Orientation orientation, string[] videoPaths, string[] imagePaths, string title, string desc);

        void PublishVideoMoment(Orientation orientation, string[] videoPaths, string title, string desc);

        void GetNoticeData();

        void CloseMoment();

        void CloseMoment(string title, string content);

        void SetUseAutoRotate(bool useAuto);
        
        void OpenSceneEntryMoment(Orientation orientation,string sceneId);

    }
}