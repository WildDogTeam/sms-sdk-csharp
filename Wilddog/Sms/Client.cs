using System;
using Wilddog.Sms.Http;
using Wilddog.Sms.Util;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Cryptography;
namespace Wilddog.Sms
{
    public class Client
    {
        /// <summary>
        /// The app identifier.
        /// </summary>
        private string AppId;

        /// <summary>
        /// The sms key.
        /// </summary>
        private string SmsKey;

        /// <summary>
        /// The wilddog http client.
        /// </summary>
        private readonly WilddogHttpClient WilddogHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.sms.Client"/> class.
        /// </summary>
        /// <param name="appId">App identifier.</param>
        /// <param name="smsKey">Sms key.</param>
        public Client(string appId, string smsKey)
        {
            ValidationUtils.NotEmptyString(appId, "AppId");
            ValidationUtils.NotEmptyString(smsKey, "SmsKey");

            this.AppId = appId;
            this.SmsKey = smsKey;
            WilddogHttpClient = new WilddogHttpClient();
        }

        /// <summary>
        /// Queries the balance.
        /// </summary>
        /// <returns>The balance.</returns>
        public BalanceResponse QueryBalance()
        {
            long TimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string Signature = CryptoUtils.Sha256(string.Format(Const.QUERY_BALANCE_SIGN_TEMPLATE, TimeStamp, SmsKey));
            var QueryBalanceUrl = string.Format(Const.QUERY_BALANCE_URL, AppId, TimeStamp, Signature);
            BalanceResponse Response = WilddogHttpClient.DoGet<BalanceResponse>(QueryBalanceUrl);
            return Response;
        }

        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="mobile">Mobile.</param>
        /// <param name="templateId">Template identifier.</param>
        public SubmitResponse SendCode(string mobile, string templateId)
        {
            ValidationUtils.NotEmptyString(mobile, "Mobile");
            ValidationUtils.NotEmptyString(templateId, "TemplateId");

            return SendCode(mobile, templateId, null);
        }

        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="mobile">Mobile.</param>
        /// <param name="templateId">Template identifier.</param>
        /// <param name="Params">Parameters.</param>
        public SubmitResponse SendCode(string mobile, string templateId, IList Params)
        {
            ValidationUtils.NotEmptyString(mobile, "Mobile");
            ValidationUtils.NotEmptyString(templateId, "TemplateId");

            IDictionary<string, string> postParams = new Dictionary<string, string>();
            postParams.Add("mobile", mobile);
            postParams.Add("templateId", templateId);

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            postParams.Add("timestamp", timestamp.ToString());

            if (Params is null || Params.Count == 0)
            {
                postParams.Add("signature", CryptoUtils.Sha256(string.Format(Const.SEND_CODE_SIGN_NO_PARAM_TEMPLATE, mobile, templateId, timestamp, SmsKey)));
            }
            else
            {
                string paramsJsonStr = JsonConvert.SerializeObject(Params);
                postParams.Add("signature", CryptoUtils.Sha256(string.Format(Const.SEND_CODE_SIGN_WITH_PARAM_TEMPLATE, mobile, paramsJsonStr, templateId, timestamp, SmsKey)));
                postParams.Add("params", paramsJsonStr);
            }

            FormUrlEncodedContent content = new FormUrlEncodedContent(postParams);
            string sendCodeUrl = string.Format(Const.SEND_CODE_URL, AppId);
            SubmitResponse response = WilddogHttpClient.DoPost<SubmitResponse>(sendCodeUrl, content);
            return response;
        }

        /// <summary>
        /// Checks the code.
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="mobile">Mobile.</param>
        /// <param name="code">Code.</param>
        public CheckCodeResponse CheckCode(string mobile, string code)
        {
            ValidationUtils.NotEmptyString(mobile, "Mobile");
            ValidationUtils.NotEmptyString(code, "Code");

            IDictionary<string, string> postParams = new Dictionary<string, string>();
            postParams.Add("mobile", mobile);
            postParams.Add("code", code);

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            postParams.Add("timestamp", timestamp.ToString());

            string signature = CryptoUtils.Sha256(string.Format(Const.CHECK_CODE_SIGN_TEMPLATE, code, mobile, timestamp, SmsKey));
            postParams.Add("signature", signature);

            string checkCodeUrl = string.Format(Const.CHECK_CODE_URL, AppId);

            FormUrlEncodedContent content = new FormUrlEncodedContent(postParams);

            CheckCodeResponse response = WilddogHttpClient.DoPost<CheckCodeResponse>(checkCodeUrl, content);
            return response;
        }

        /// <summary>
        /// Queries the status.
        /// </summary>
        /// <returns>The status.</returns>
        /// <param name="rrid">Rrid.</param>
        public StatusResponse QueryStatus(string rrid)
        {
            ValidationUtils.NotEmptyString(rrid, "Rrid");

            string signature = CryptoUtils.Sha256(string.Format(Const.QUERY_STATUS_SIGN_TEMPLATE, rrid, SmsKey));
            string queryStatusUrl = string.Format(Const.QUERY_STATUS_URL, AppId, rrid, signature);
            StatusResponse response = WilddogHttpClient.DoGet<StatusResponse>(queryStatusUrl);
            return response;
        }

        /// <summary>
        /// Sends the notify.
        /// </summary>
        /// <returns>The notify.</returns>
        /// <param name="mobiles">Mobiles.</param>
        /// <param name="templateId">Template identifier.</param>
        /// <param name="Params">Parameters.</param>
        public SubmitResponse SendNotify(IList mobiles, string templateId, IList Params)
        {
            ValidationUtils.NotEmptyCollection(mobiles, "Mobiles");
            ValidationUtils.NotEmptyString(templateId, "TemplateId");
            ValidationUtils.NotEmptyCollection(Params, "Params");

            IDictionary<string, string> postParams = new Dictionary<string, string>();

            string mobilesJsonStr = JsonConvert.SerializeObject(mobiles);
            postParams.Add("mobiles", mobilesJsonStr);

            postParams.Add("templateId", templateId);

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            postParams.Add("timestamp", timestamp.ToString());

            string paramsJsonStr = JsonConvert.SerializeObject(Params);
            postParams.Add("params", paramsJsonStr);

            postParams.Add("signature", CryptoUtils.Sha256(string.Format(Const.SEND_NOTIFY_SIGN_TEMPLATE, mobilesJsonStr, paramsJsonStr, templateId, timestamp, SmsKey)));

            FormUrlEncodedContent content = new FormUrlEncodedContent(postParams);

            string sendCodeUrl = string.Format(Const.SEND_NOTIFY_URL, AppId);
            SubmitResponse response = WilddogHttpClient.DoPost<SubmitResponse>(sendCodeUrl, content);
            return response;
        }
    }
}