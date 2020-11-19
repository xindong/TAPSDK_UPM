using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSAchievement
{
    [Serializable]
    public class AchievementWrapperBean<AchievementBean>
    {

        public List<AchievementBean> wrapper;
        
        public int achievementCode;

        public bool initCallback;

        public AchievementWrapperBean(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public AchievementWrapperBean()
        {
            
        }

    }

}