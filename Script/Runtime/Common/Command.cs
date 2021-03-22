using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{

    [Serializable]
    public class Command
    {
        [SerializeField]
        public string service;
        [SerializeField]
        public string method;
        [SerializeField]
        public string args;
        [SerializeField]
        public bool callback;
        [SerializeField]
        public string callbackId;
        [SerializeField]
        public bool onceTime;

        public Command()
        {

        }

        public Command(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }

        public Command(string service, string method, bool callback, Dictionary<string, object> dic)
        {
            this.args = dic == null ? null : Json.Serialize(dic);
            this.service = service;
            this.method = method;
            this.callback = callback;
            this.callbackId = this.callback ? TDSUUID.UUID() : null;
        }

        public Command(string service, string method, bool callback, bool onceTime, Dictionary<string, object> dic)
        {
            this.args = dic == null ? null : Json.Serialize(dic);
            this.service = service;
            this.method = method;
            this.callback = callback;
            this.callbackId = this.callback ? TDSUUID.UUID() : null;
            this.onceTime = onceTime;
        }

        public class Builder
        {
            public string service;

            public string method;

            public bool callback;

            public string callbackId;

            public bool onceTime;

            public Dictionary<string, object> args;

            public Builder()
            {

            }

            public Builder Service(string service)
            {
                this.service = service;
                return this;
            }

            public Builder Method(string method)
            {
                this.method = method;
                return this;
            }

            public Builder OnceTime(bool onceTime)
            {
                this.onceTime = onceTime;
                return this;
            }

            public Builder Args(Dictionary<string, object> dic)
            {
                this.args = dic;
                return this;
            }

            public Builder Args(string key, object value)
            {
                if (this.args == null)
                {
                    this.args = new Dictionary<string, object>();
                }
                this.args.Add(key, value);
                return this;
            }

            public Builder Callback(bool callback)
            {
                this.callback = callback;
                this.callbackId = this.callback ? TDSUUID.UUID() : null;
                return this;
            }

            public Command CommandBuilder()
            {
                return new Command(this.service, this.method, this.callback, this.onceTime, this.args);
            }
        }

    }


}