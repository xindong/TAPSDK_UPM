using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDSMoment
{
    public interface IMoment
    {
        
        void SetCallback(Action<int,string> callback);

        void OpenMoment(int orientation);

        void PublishMoment(int orientation, string[] imagePaths, string content);

        void PublishVideoMoment(int orientation, string[] videoPaths, string[] imagePaths, string title, string desc);
      
        void PublishVideoMoment(int orientation, string[] videoPaths, string title, string desc);

        void GetNoticeData();

        void CloseMoment();

        void CloseMoment(string title, string content);

        void SetUseAutoRotate(bool useAuto); 

    }
}