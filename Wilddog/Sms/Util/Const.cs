using System;
namespace Wilddog.Sms.Util
{
    public class Const
    {
        /// <summary>
        /// The send notify URL.
        /// </summary>
        public static string SEND_NOTIFY_URL = "https://api.wilddog.com/sms/v1/{0}/notify/send";

        /// <summary>
        /// The send notify sign template.
        /// </summary>
        public static string SEND_NOTIFY_SIGN_TEMPLATE = "mobiles={0}&params={1}&templateId={2}&timestamp={3}&{4}";

        /// <summary>
        /// The send code URL.
        /// </summary>
        public static string SEND_CODE_URL = "https://api.wilddog.com/sms/v1/{0}/code/send";

        /// <summary>
        /// The send code sign no parameter template.
        /// </summary>
        public static string SEND_CODE_SIGN_NO_PARAM_TEMPLATE = "mobile={0}&templateId={1}&timestamp={2}&{3}";

        /// <summary>
        /// The send code sign with parameter template.
        /// </summary>
        public static string SEND_CODE_SIGN_WITH_PARAM_TEMPLATE = "mobile={0}&params={1}&templateId={2}&timestamp={3}&{4}";

        /// <summary>
        /// The check code URL.
        /// </summary>
        public static string CHECK_CODE_URL = "https://api.wilddog.com/sms/v1/{0}/code/check";

        /// <summary>
        /// The check code sign template.
        /// </summary>
        public static string CHECK_CODE_SIGN_TEMPLATE = "code={0}&mobile={1}&timestamp={2}&{3}";

        /// <summary>
        /// The query status URL.
        /// </summary>
        public static string QUERY_STATUS_URL = "https://api.wilddog.com/sms/v1/{0}/status?rrid={1}&signature={2}";

        /// <summary>
        /// The query status sign template.
        /// </summary>
        public static string QUERY_STATUS_SIGN_TEMPLATE = "rrid={0}&{1}";

        /// <summary>
        /// The query balance URL.
        /// </summary>
        public static string QUERY_BALANCE_URL = "https://api.wilddog.com/sms/v1/{0}/getBalance?timestamp={1}&signature={2}";

        /// <summary>
        /// The query balance sign template.
        /// </summary>
        public static string QUERY_BALANCE_SIGN_TEMPLATE = "timestamp={0}&{1}";

        /// <summary>
        /// The wilddog sms user agent.
        /// </summary>
        public static string WILDDOG_SMS_USER_AGENT = "wilddog-sms-csharp/1.0.0";
    }
}
