using System;

namespace TDSCommon
{
    public class TDSUUID
    {
        public static string UUID(){
            return System.Guid.NewGuid().ToString();
        }
    }
}