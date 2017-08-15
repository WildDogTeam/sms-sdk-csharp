using System;

namespace Wilddog.Sms.Http
{
    public class Response
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Wilddog.Sms.Http.Response"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets the wilddog error.
        /// </summary>
        /// <value>The wilddog error.</value>
        public WilddogError WilddogError { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.Response"/> class.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        /// <param name="wilddogError">Wilddog error.</param>
        public Response(bool success, WilddogError wilddogError)
        {
            this.Success = success;
            this.WilddogError = wilddogError;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.Response"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Wilddog.Sms.Http.Response"/>.</returns>
        public override string ToString()
        {
            return $"[Response: Success={Success}, WilddogError={WilddogError}]";
        }
    }
}
