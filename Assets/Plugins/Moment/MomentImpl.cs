using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSMoment
{
    public class MomentImpl : IMoment
    {
        private static string CLZ_NAME = "com.taptap.sdk.ttos.moment.warpper.TDSMomentService";

        private static string IMP_NAME = "com.taptap.sdk.ttos.moment.warpper.TDSMomentServiceImpl";

        private static string SERVICE_NAME = "TDSMomentService";

        public ScreenOrientation requestOrientation = 0;
        public ScreenOrientation originOrientation = 0;
        public int autorotateToLandscapeLeft;
        public int autorotateToLandscapeRight;
        public int autorotateToPortrait;
        public int autorotateToPortraitUpsideDown;
        public bool useAutoRotate = true; //游戏是否旋转

        private MomentImpl()
        {
            TDSCommon.EngineBridge.GetInstance().Register(CLZ_NAME, IMP_NAME);
        }

        private volatile static MomentImpl sInstance;

        private static readonly object locker = new object();

        public static MomentImpl GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new MomentImpl();
                }
            }
            return sInstance;
        }

        public void SetCallback(Action<int, string> callback)
        {
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("serCallback", null, true), (result) =>
              {
                  if (result.code != Result.RESULT_SUCCESS)
                  {
                      return;
                  }

                  if (string.IsNullOrEmpty(result.content))
                  {
                      return;
                  }

                  MomentCallbackBean bean = new MomentCallbackBean(result.content);
                  if (bean != null)
                  {
                      if (TDSCommon.Platform.isAndroid())
                      {
                          AndroidOrientationInterceptor(bean.code);
                      }
                      callback(bean.code, bean.message);
                  }
              });
        }

        public void OpenMoment(Orientation orientation)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("config", (int)orientation);
            InitOrientationSetting((int)orientation);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("openTapMoment", dic, true));
        }

        public void PublishMoment(Orientation orientation, string[] imagePaths, string content)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("config", (int)orientation);
            dic.Add("imagePaths", imagePaths);
            dic.Add("content", content);
            InitOrientationSetting((int)orientation);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("publishMoment", dic, true));
        }

        public void PublishVideoMoment(Orientation orientation, string[] videoPaths, string[] imagePaths, string title, string desc)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("config", (int)orientation);
            dic.Add("imagePaths", imagePaths);
            dic.Add("videoPaths", videoPaths);
            dic.Add("title", title);
            dic.Add("desc", desc);
            InitOrientationSetting((int)orientation);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("publishVideoImageMoment", dic, true));
        }

        public void PublishVideoMoment(Orientation orientation, string[] videoPaths, string title, string desc)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("config", (int)orientation);
            dic.Add("videoPaths", videoPaths);
            dic.Add("title", title);
            dic.Add("desc", desc);
            InitOrientationSetting((int)orientation);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("publishVideoMoment", dic, true));
        }

        public void GetNoticeData()
        {
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("getNoticeData", null, true));
        }

        public void CloseMoment()
        {
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("closeMoment", null, true));
        }

        public void CloseMoment(string title, string content)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("title", title);
            dic.Add("content", content);

            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("closeMomentWithArgs", dic, true));
        }

        public void SetUseAutoRotate(bool useAuto)
        {
            if (TDSCommon.Platform.isAndroid())
            {
                this.useAutoRotate = useAuto;
            }
        }

        private void AndroidOrientationInterceptor(int code)
        {
            if (code == (int)CallbackCode.CALLBACK_CODE_MOMENT_APPEAR)
            {
                ScreenOrientation orientation = requestOrientation;
                Debug.Log("APPERAR SET REQUEST ORIENTATION = " + orientation);
                Screen.orientation = orientation;
                if (orientation == ScreenOrientation.AutoRotation || orientation == ScreenOrientation.LandscapeLeft)
                {
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    Screen.autorotateToLandscapeLeft = true;
                    Screen.autorotateToLandscapeRight = true;
                    Screen.autorotateToPortrait = (orientation != ScreenOrientation.LandscapeLeft);
                    Screen.autorotateToPortraitUpsideDown = (orientation != ScreenOrientation.LandscapeLeft);
                }
            }
            else if (code == (int)CallbackCode.CALLBACK_CODE_MOMENT_DISAPPEAR)
            {
                ScreenOrientation orientation = originOrientation;
                Debug.Log("APPERAR SET ORIGIN ORIENTATION = " + orientation);
                if (orientation == ScreenOrientation.AutoRotation || useAutoRotate)
                {
                    Screen.orientation = orientation;//返回初始方向
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    Screen.autorotateToLandscapeLeft = autorotateToLandscapeLeft > 0;
                    Screen.autorotateToLandscapeRight = autorotateToLandscapeRight > 0;
                    Screen.autorotateToPortrait = autorotateToPortrait > 0;
                    Screen.autorotateToPortraitUpsideDown = autorotateToPortraitUpsideDown > 0;
                }
                else
                {
                    Screen.orientation = orientation;
                }
            }
        }

        private void InitOrientationSetting(int config)
        {
            originOrientation = Screen.orientation;
            autorotateToPortraitUpsideDown = Screen.autorotateToPortraitUpsideDown ? 1 : 0;
            autorotateToPortrait = Screen.autorotateToPortrait ? 1 : 0;
            autorotateToLandscapeRight = Screen.autorotateToLandscapeRight ? 1 : 0;
            autorotateToLandscapeLeft = Screen.autorotateToLandscapeLeft ? 1 : 0;
            GetRequestOrientation(config);
            Debug.Log("orgin orientation = " + originOrientation);
            Debug.Log("request orientation = " + requestOrientation);
            Debug.Log(" autoPd = " + autorotateToPortraitUpsideDown + " autoP = " + autorotateToPortrait +
                " autoLl = " + autorotateToLandscapeLeft + " autolr = " + autorotateToLandscapeRight);
        }

        private void GetRequestOrientation(int config)
        {
            int orientation = config;
            switch (orientation)
            {
                case (int)Orientation.ORIENTATION_DEFAULT:
                    requestOrientation = ScreenOrientation.AutoRotation;
                    break;
                case (int)Orientation.ORIENTATION_LANDSCAPE:
                    requestOrientation = ScreenOrientation.LandscapeLeft;
                    break;
                case (int)Orientation.ORIENTATION_PORTRAIT:
                    requestOrientation = ScreenOrientation.Portrait;
                    break;
            }
        }

        private Command ConstructorCommand(string method, Dictionary<string, object> dic, bool callbackEnable)
        {
            return new Command(SERVICE_NAME, method, callbackEnable, System.Guid.NewGuid().ToString(), dic);
        }


    }
}