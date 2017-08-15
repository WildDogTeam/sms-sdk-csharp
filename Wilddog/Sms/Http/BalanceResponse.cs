using System;
using Newtonsoft.Json;

namespace Wilddog.Sms.Http
{
    public class BalanceResponse : Response
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public BalanceData Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.BalanceResponse"/> class.
        /// </summary>
        public BalanceResponse() : base(true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.BalanceResponse"/> class.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        /// <param name="wilddogError">Wilddog error.</param>
        public BalanceResponse(bool success, WilddogError wilddogError) : base(success, wilddogError)
        {
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.BalanceResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.BalanceResponse"/>.</returns>
        public override string ToString()
        {
            return $"[BalanceResponse: Status={Status}, data={Data}]";
        }
    }

    public class BalanceData
    {
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("balance")]
        public long Balance { get; set; }

        /// <summary>
        /// Gets the voucher balance.
        /// </summary>
        /// <value>The voucher balance.</value>
        [JsonProperty("voucherBalance")]
        public long VoucherBalance { get; set; }

        public override string ToString()
        {
            return $"[BalanceData: Balance={Balance}, VoucherBalance={VoucherBalance}]";
        }
    }

}
