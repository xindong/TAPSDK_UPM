using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TapSDK
{
    public class TDSPropertiesChecker
    {
        public static void MergeProperties(Dictionary<string, object> source, Dictionary<string, object> dest)
        {
            if (null == source) return;
            foreach (KeyValuePair<string, object> kv in source)
            {
                if (dest.ContainsKey(kv.Key))
                {
                    dest[kv.Key] = kv.Value;
                } else
                {
                    dest.Add(kv.Key, kv.Value);
                }
            }
        }

    }
}

