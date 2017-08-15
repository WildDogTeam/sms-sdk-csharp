using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wilddog.Sms.Http
{
    public class StatusResponse : Response
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public List<SmsStatus> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.StatusResponse"/> class.
        /// </summary>
        public StatusResponse() : base(true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.StatusResponse"/> class.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        /// <param name="wilddogError">Wilddog error.</param>
        public StatusResponse(bool success, WilddogError wilddogError) : base(success, wilddogError)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.StatusResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.StatusResponse"/>.</returns>
        public override string ToString()
        {
            return $"[StatusResponse: Status={Status}, Data={String.Join(", ", Data)}]";
        }
    }

    public class SmsStatus
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        [JsonProperty("mobile")]
        public String Mobile { get; set; }

        /// <summary>
        /// Gets or sets the receive time.
        /// </summary>
        /// <value>The receive time.</value>
        [JsonProperty("receiveTime")]
        public DateTime ReceiveTime { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.SmsStatus"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.SmsStatus"/>.</returns>
        public override string ToString()
        {
            return $"[SmsStatus: Status={Status}, Mobile={Mobile}, ReceiveTime={ReceiveTime}]";
        }
    }
}
