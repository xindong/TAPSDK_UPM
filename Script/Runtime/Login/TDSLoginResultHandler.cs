using TDSCommon;

namespace TapSDK
{
    public class TDSLoginResultHandler
    {
        public static void HandlerLoginResult(LoginCallback callback, Result result)
        {
            if (result.code != Result.RESULT_SUCCESS)
            {
                return;
            }
            if (string.IsNullOrEmpty(result.content))
            {
                return;
            }
            LoginWrapperBean<string> wrapperBean = new LoginWrapperBean<string>(result.content);
            if (wrapperBean.loginCallbackCode == 0)
            {
                TDSAccessToken accessToken = new TDSAccessToken(wrapperBean.wrapper);
                callback.LoginSuccess(accessToken);
                return;
            }
            if (wrapperBean.loginCallbackCode == 1)
            {
                callback.LoginCancel();
                return;
            }
            TDSAccountError error = new TDSAccountError(wrapperBean.wrapper);
            callback.LoginError(error);
        }
    }
}