namespace Helpers.ObjectsUtils.ResponseObjects
{
    /// <summary>
    /// ResponseContent
    /// </summary>
    public class ResponseContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseContent"/> class.
        /// </summary>
        public ResponseContent()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseContent"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="code">The code.</param>
        public ResponseContent(string msg, string code)
        {
            Message = msg;
            Code = code;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
    }
}