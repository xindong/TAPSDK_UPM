using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace TDSAchievement
{
    public interface IAchievement{

        void registerCallback(AchievementCallback callback);

        void initWithTap(string appid,string token);

        void initWithXD(string appid,string token);

        void fetchAllAchievementList(GetAchievementCallback callback);

        void getLocalAllAchievementList(GetAchievementCallback callback);

        void getLocalUserAchievementList(GetAchievementCallback callback);

        void fetchUserAchievementList(GetAchievementCallback callback);

        void reach(string id);

        void growSteps(string id,int step);

        void makeSteps(string id,int step);

        void showAchievementPage();

    }

    public interface AchievementCallback
    {

        void onAchievementSDKInitSuccess();

        void onAchievementInitFail(int errrorCode);

        void onAchievementStatusUpdate(AchievementBean achievement,int errorCode);
        
    }

    public interface GetAchievementCallback{
        
        void GetAchievementCallback(List<AchievementBean> list ,int errorCode);

    }


}