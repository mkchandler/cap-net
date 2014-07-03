namespace CAPNet
{
    /// <summary>
    /// The certainty of the subject event of the alert message
    /// </summary>
    public enum Certainty
    {
        /// <summary>
        /// Determined to have occurred or to be ongoing
        /// </summary>
        Observed = 1,
        /// <summary>
        /// Likely (p > ~50%)
        /// </summary>
        Likely,
        /// <summary>
        /// Possible but not likely (p &lt;= ~50%)
        /// </summary>
        Possible,
        /// <summary>
        /// Not expected to occur (p ~ 0)
        /// </summary>
        Unlikely,
        /// <summary>
        /// Certainty unknown
        /// </summary>
        Unknown
    }
}