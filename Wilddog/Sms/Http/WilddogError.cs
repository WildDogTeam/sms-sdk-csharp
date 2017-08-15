using System;
using Newtonsoft.Json;
namespace Wilddog.Sms.Http
{
    public class WilddogError
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [JsonProperty("errcode")]
        public string ErrCode { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.WilddogError"/> class.
        /// </summary>
        /// <param name="errCode">Error code.</param>
        /// <param name="message">Message.</param>
        public WilddogError(string errCode, string message)
        {
            this.ErrCode = errCode;
            this.Message = message;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.WilddogError"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.WilddogError"/>.</returns>
        public override string ToString()
        {
            return $"[WilddogError: ErrCode={ErrCode}, Message={Message}]";
        }

    }
}
