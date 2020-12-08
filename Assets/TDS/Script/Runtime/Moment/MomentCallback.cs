using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public interface IMoment
    {

        void SetCallback(Action<int, string> callback);

        void InitSDK(string clientId);

        void SetLoginToken(string accessToken);

        void OpenMoment(Orientation orientation);

        void PublishMoment(Orientation orientation, string[] imagePaths, string content);

        void PublishVideoMoment(Orientation orientation, string[] videoPaths, string[] imagePaths, string title, string desc);

        void PublishVideoMoment(Orientation orientation, string[] videoPaths, string title, string desc);

        void GetNoticeData();

        void CloseMoment();

        void CloseMoment(string title, string content);

        void SetUseAutoRotate(bool useAuto);

    }
}