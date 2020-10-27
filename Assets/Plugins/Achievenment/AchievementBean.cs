using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSAchievement
{

    [Serializable]
    public class AchievementBean
    {

        public static int STATE_UN_REACHED = 0;
        public static int STATE_REACHED = 1;

        public static int VISIBLE_FALSE = 0;
        public static int VISIBLE_TRUE = 1;
        /*base*/
        [SerializeField]
        public string id;
        [SerializeField] public string displayId;

        [SerializeField]
        public int visible = VISIBLE_FALSE;
        [SerializeField]
        public string title;
        [SerializeField]
        public string subTitle;
        [SerializeField]
        public string achieveIcon;
        [SerializeField]
        public int step;
        [SerializeField]
        public long createTime;
        [SerializeField]
        public int showOrder;
        /*user*/
        [SerializeField]
        public int fullReached = STATE_UN_REACHED;
        [SerializeField]
        public int reachedStep;
        [SerializeField]
        public long reachedTime;
        [SerializeField]

        public bool isChanged = false;
        public string toJson()
        {
            return JsonUtility.ToJson(this);
        }

        public AchievementBean(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }

}