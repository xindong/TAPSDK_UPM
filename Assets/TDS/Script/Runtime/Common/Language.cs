using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    
    public class TDSLanguage
    {

        private static TDSLanguage sInstance = new TDSLanguage();

        public static TDSLanguage GetInstance(){
            return sInstance;
        }

        private TDSLanguage(){
            EngineBridge.GetInstance().Register("com.tds.common.wrapper.TDSCommonService","com.tds.common.wrapper.TDSCommonServiceImpl");
        }

        public void SetLanguage(string language)
        {
            Command command = new Command(); 
            command.service = "TDSCommonService";
            command.method = "setLanguage";
            command.args = "{\"language\":\""+language+"\"}";
            command.callback = false;
            command.callbackId = null;
            EngineBridge.GetInstance().CallHandler(command);
        }

    }

}