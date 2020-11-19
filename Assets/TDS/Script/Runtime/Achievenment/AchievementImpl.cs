using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSAchievement
{

    public class AchievementImpl : IAchievement
    {

        private static string CLZ_NAME = "com.tds.achievement.wrapper.TDSAchievementService";

        private static string IMP_NAME = "com.tds.achievement.wrapper.TDSAchievementServiceImpl";

        private static string SERVICE_NAME = "TDSAchievementService";

        private AchievementImpl()
        {
            TDSCommon.EngineBridge.GetInstance().Register(CLZ_NAME, IMP_NAME);
        }

        private volatile static AchievementImpl sInstance;

        private static readonly object locker = new object();

        public static AchievementImpl GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new AchievementImpl();
                }
            }
            return sInstance;
        }

        public void registerCallback(AchievementCallback callback)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "registerBridgeCallback";
            command.callback = true;
            command.callbackId = System.Guid.NewGuid().ToString();

            TDSCommon.EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                Debug.Log("AchievementSDKCallback:" + result.toJSON());

                if (result.code != Result.RESULT_SUCCESS)
                {
                    return;
                }

                if (string.IsNullOrEmpty(result.content))
                {
                    return;
                }

                AchievementWrapperBean<AchievementBean> bean = new AchievementWrapperBean<AchievementBean>(result.content);

                if (bean.initCallback)
                {
                    if (bean.achievementCode == 0)
                    {
                        callback.onAchievementSDKInitSuccess();
                    }
                    else
                    {
                        callback.onAchievementInitFail(bean.achievementCode);
                    }
                    return;
                }

                callback.onAchievementStatusUpdate((bean.wrapper != null && bean.wrapper.Count > 0) ? bean.wrapper[0] : null, bean.achievementCode);
            });
        }

        public void initWithTap(string appId, string token)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "initWithTap";
            command.args = "{\"appId\":\"" + appId + "\",\"tapToken\":\"" + token + "\"}";
            command.callback = true;
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        public void initWithXD(string appId, string token)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "initWithXD";
            command.callback = true;
            command.args = "{\"appId\":\"" + appId + "\",\"xdToken\":\"" + token + "\"}";
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        public void fetchAllAchievementList(GetAchievementCallback callback)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "fetchAllAchievementList";
            command.callback = true;
            command.callbackId = System.Guid.NewGuid().ToString();
            TDSCommon.EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerResult(callback, result);
            });
        }

        public void getLocalAllAchievementList(GetAchievementCallback callback)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "getLocalAllAchievementList";
            command.callback = true;
            command.callbackId = System.Guid.NewGuid().ToString();
            TDSCommon.EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerResult(callback, result);
            });
        }

        public void getLocalUserAchievementList(GetAchievementCallback callback)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "getLocalUserAchievementList";
            command.callback = true;
            command.callbackId = System.Guid.NewGuid().ToString();
            TDSCommon.EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerResult(callback, result);
            });
        }

        public void fetchUserAchievementList(GetAchievementCallback callback)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "fetchUserAchievementList";
            command.callback = true;
            command.callbackId = System.Guid.NewGuid().ToString();
            TDSCommon.EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                handlerResult(callback, result);
            });
        }

        public void reach(string id)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "reach";
            command.args = "{\"displayId\":\"" + id + "\"}";
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        public void growSteps(string id, int step)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "growSteps";
            command.args = "{\"displayId\":\"" + id + "\",\"growStep\":" + step + "}";
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        public void makeSteps(string id, int step)
        {
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "makeSteps";
            command.args = "{\"displayId\":\"" + id + "\",\"numStep\":" + step + "}";
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        public void showAchievementPage(){
            Command command = new Command();
            command.service = SERVICE_NAME;
            command.method = "showAchievementPage";
            TDSCommon.EngineBridge.GetInstance().CallHandler(command);
        }

        private void handlerResult(GetAchievementCallback callback, Result result)
        {

            Debug.Log("resultCallback:" + result.toJSON());

            if (result.code == Result.RESULT_ERROR)
            {
                return;
            }

            if (string.IsNullOrEmpty(result.content))
            {
                return;
            }

            Dictionary<string, string> dic = JsonUtility.FromJson<Dictionary<string, string>>(result.content);

            AchievementWrapperBean<AchievementBean> wrapperBean = JsonUtility.FromJson<AchievementWrapperBean<AchievementBean>>(result.content);

            callback.GetAchievementCallback(wrapperBean.wrapper, wrapperBean.achievementCode);

        }

    }


}