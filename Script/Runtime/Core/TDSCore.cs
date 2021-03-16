
namespace TapSDK
{
    public class TDSCore
    {
        public static void Init(string clientId)
        {
            TDSCoreImpl.GetInstance().Init(clientId);
        }

        public static void Init(string clientID,bool isCN)
        {
            TDSCoreImpl.GetInstance().Init(clientID,isCN);
        }

        public static void EnableMoment()
        {
            TDSCoreImpl.GetInstance().EnableMoment();
        }

        public static void EnableTapDB(string gameVersion, string channel)
        {
            TDSCoreImpl.GetInstance().EnableTapDB(gameVersion, channel);
        }

    }
}