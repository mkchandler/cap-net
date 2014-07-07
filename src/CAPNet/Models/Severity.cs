namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the severity of the subject event of the alert message.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Extraordinary threat to life or property.
        /// </summary>
        Extreme = 1,
        /// <summary>
        /// Signifcant threat to life or property.
        /// </summary>
        Severe,
        /// <summary>
        /// Possible threat to life or property.
        /// </summary>
        Moderate,
        /// <summary>
        /// Minimal threat to life or property.
        /// </summary>
        Minor,
        /// <summary>
        /// Severity unknown.
        /// </summary>
        Unknown
    }
}