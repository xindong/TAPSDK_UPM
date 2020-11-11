using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSAchievement
{

    public class TDSAchievement
    {

        public static int UNKNOWN = 9000;

        public static int SDK_NOT_INIT = 9001;

        public static int ACHIEVEMENT_NOT_FOUND = 90002;

        public static int UNAUTHORIZED = 401;

        public static void registerCallback(AchievementCallback callback)
        {
            AchievementImpl.GetInstance().registerCallback(callback);
        }

        public static void initWithXD(string appId, string token)
        {
            AchievementImpl.GetInstance().initWithXD(appId, token);
        }

        public static void initWithTap(string appId, string token)
        {
            AchievementImpl.GetInstance().initWithTap(appId, token);
        }

        public static void fetchAllAchievementList(GetAchievementCallback callback)
        {
            AchievementImpl.GetInstance().fetchAllAchievementList(callback);
        }

        public static void getLocalAllAchievementList(GetAchievementCallback callback)
        {
            AchievementImpl.GetInstance().getLocalAllAchievementList(callback);
        }

        public static void getLocalUserAchievementList(GetAchievementCallback callback)
        {
            AchievementImpl.GetInstance().getLocalUserAchievementList(callback);
        }

        public static void fetchUserAchievementList(GetAchievementCallback callback)
        {
            AchievementImpl.GetInstance().fetchUserAchievementList(callback);
        }

        public static void reach(string id)
        {
            AchievementImpl.GetInstance().reach(id);
        }

        public static void growSteps(string id, int step)
        {
            AchievementImpl.GetInstance().growSteps(id, step);
        }

        public static void makeSteps(string id, int step)
        {
            AchievementImpl.GetInstance().makeSteps(id, step);
        }

        public static void showAchievementPage()
        {
            AchievementImpl.GetInstance().showAchievementPage();
        }
    }
}