using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;

namespace Wilddog.Sms.Http
{
    public class CheckCodeResponse : Response
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.CheckCodeResponse"/> class.
        /// </summary>
        public CheckCodeResponse() : base(true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.CheckCodeResponse"/> class.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        /// <param name="wilddogError">Wilddog error.</param>
        public CheckCodeResponse(bool success, WilddogError wilddogError) : base(success, wilddogError)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.CheckCodeResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.CheckCodeResponse"/>.</returns>
        public override string ToString()
        {
            return $"[CheckCodeResponse: Status={Status}]";
        }

    }
}
