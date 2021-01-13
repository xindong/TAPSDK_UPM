using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class MomentImpl : IMoment
    {
        private static string CLZ_NAME = "com.tds.moment.wrapper.TDSMomentService";

        private static string IMP_NAME = "com.tds.moment.wrapper.TDSMomentServiceImpl";

        private static string SERVICE_NAME = "TDSMomentService";

        public ScreenOrientation requestOrientation = 0;
        public ScreenOrientation originOrientation = 0;
        public int autorotateToLandscapeLeft;
        public int autorotateToLandscapeRight;
        public int autorotateToPortrait;
        public int autorotateToPortraitUpsideDown;
        public bool useAutoRotate = true; //游戏是否旋转
        public bool IsAppear = false;

        public int nativeOrientation = -1;

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
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("setMomentCallback", null, true), (result) =>
              {

                  Debug.Log("Moment Callback:" + result.toJSON());
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
                          if (AndroidOrientationInterceptor(bean.code))
                          {
                              callback(bean.code, bean.message);
                          }
                      }
                      else
                      {
                          callback(bean.code, bean.message);
                      }
                  }
              });
        }

        public void InitSDK(string clientId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("clientId", clientId);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("initSDK", dic, true));
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

        public void SetAndroidRequestOrientation(int orientation)
        {   
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("orientation", orientation);
            TDSCommon.EngineBridge.GetInstance().CallHandler(ConstructorCommand("setRequestOrientation", dic, false));
        }

        public void SetUseAutoRotate(bool useAuto)
        {
            if (TDSCommon.Platform.isAndroid())
            {
                this.useAutoRotate = useAuto;
            }
        }

        private bool AndroidOrientationInterceptor(int code)
        {
            if (code == (int)CallbackCode.CALLBACK_CODE_MOMENT_APPEAR)
            {
                setRequestOrientation(false);
                IsAppear = true;
                return true;
            }
            if (code == (int)CallbackCode.CALLBACK_CODE_MOMENT_DISAPPEAR)
            {
                setOriginOrientation();
                IsAppear = false;
                return true;
            }

            if (code == (int)CallbackCode.CALLBACK_CODE_ON_RESUME)
            {
                if (IsAppear)
                {
                    setRequestOrientation(true);
                }
                return false;
            }
            else if (code == (int)CallbackCode.CALLBACK_CODE_ON_STOP)
            {
                if (IsAppear)
                {
                    setOriginOrientation();
                }
                return false;
            }
            return true;
        }

        private void InitOrientationSetting(int config)
        {
            if (!Platform.isAndroid())
            {
                return;
            }
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
            if (!Platform.isAndroid())
            {
                return;
            }
            nativeOrientation = config;
            switch (nativeOrientation)
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

        private void setRequestOrientation(bool isResume)
        {   
            if(!Platform.isAndroid())
            {
                return;
            }

            ScreenOrientation orientation = this.requestOrientation;
            ScreenOrientation originOrientation = this.originOrientation;
            if (orientation == ScreenOrientation.LandscapeLeft && (originOrientation == ScreenOrientation.LandscapeLeft || originOrientation == ScreenOrientation.LandscapeRight))
            {
                return;
            }

            Debug.Log("APPERAR SET REQUEST ORIENTATION = " + orientation);

            if (isResume)
            {   
                SetAndroidRequestOrientation(nativeOrientation);
            }

            ScreenOrientation currentOrientation;
            if (orientation == ScreenOrientation.AutoRotation || orientation == ScreenOrientation.LandscapeLeft)
            {
                currentOrientation = GetDeviceOrientation(orientation);
            }
            else
            {
                currentOrientation = orientation;
            }

            Screen.orientation = currentOrientation;
            Debug.Log("current device currentOrientation = " + currentOrientation);

            if (IsAutoRotate())
            {   
                Screen.orientation = ScreenOrientation.AutoRotation;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortrait = (orientation != ScreenOrientation.LandscapeLeft);
                Screen.autorotateToPortraitUpsideDown = false;
                Debug.Log("Set Request Orientation:" + Screen.orientation);
            }

        }

        private void setOriginOrientation()
        {
            if(!Platform.isAndroid())
            {
                return;
            }
            ScreenOrientation orientation = this.originOrientation;
            ScreenOrientation requestOrientation = this.requestOrientation;
            if (requestOrientation == ScreenOrientation.LandscapeLeft && (orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight))
            {
                return;
            }

            Debug.Log("设置成原始方向");
            Screen.orientation = this.originOrientation;

            Screen.autorotateToLandscapeLeft = this.autorotateToLandscapeLeft > 0;
            Screen.autorotateToLandscapeRight = this.autorotateToLandscapeRight > 0;
            Screen.autorotateToPortrait = this.autorotateToPortrait > 0;
            Screen.autorotateToPortraitUpsideDown = this.autorotateToPortraitUpsideDown > 0;

            if(IsAutoRotate())
            {
                Debug.Log("恢复自动旋转");
                Screen.orientation = ScreenOrientation.AutoRotation;
            }
        }

        private bool IsAutoRotate(){
            return this.autorotateToLandscapeLeft > 0 || this.autorotateToLandscapeRight > 0 || this.autorotateToPortrait > 0 || this.autorotateToPortraitUpsideDown > 0;
        }

        private ScreenOrientation GetDeviceOrientation(ScreenOrientation orientation)
        {
            ScreenOrientation currentOrientation;
            DeviceOrientation deviceOrientation = Input.deviceOrientation;
            if (deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                currentOrientation = ScreenOrientation.LandscapeLeft;
            }
            else if (deviceOrientation == DeviceOrientation.LandscapeRight)
            {
                currentOrientation = ScreenOrientation.LandscapeRight;
            }
            else if (deviceOrientation == DeviceOrientation.Portrait && orientation != ScreenOrientation.LandscapeLeft)
            {
                currentOrientation = ScreenOrientation.Portrait;
            }
            else
            {
                currentOrientation = orientation;
            }
            return currentOrientation;
        }

        private Command ConstructorCommand(string method, Dictionary<string, object> dic, bool callbackEnable)
        {
            return new Command(SERVICE_NAME, method, callbackEnable, dic);
        }


    }
}