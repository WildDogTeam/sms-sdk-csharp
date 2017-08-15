using System;
using Newtonsoft.Json;
namespace Wilddog.Sms.Http
{
    public class SubmitResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public SubmitData Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.SubmitResponse"/> class.
        /// </summary>
        public SubmitResponse() : base(true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.SubmitResponse"/> class.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        /// <param name="wilddogError">Wilddog error.</param>
        public SubmitResponse(bool success, WilddogError wilddogError) : base(success, wilddogError)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.SubmitResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.SubmitResponse"/>.</returns>
        public override string ToString()
        {
            return $"[SubmitResponse: data={Data}]";
        }
    }

    public class SubmitData
    {
        /// <summary>
        /// Gets or sets the rrid.
        /// </summary>
        /// <value>The rrid.</value>
        [JsonProperty("rrid")]
        public string Rrid { get; set; }

        public override string ToString()
        {
            return $"[SubmitData: rrid={Rrid}]";
        }
    }
}
