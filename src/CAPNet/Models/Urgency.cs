namespace CAPNet.Models
{
    /// <summary>
    /// The urgency of the subject event of the alert message
    /// </summary>
    public enum Urgency
    {
        /// <summary>
        /// Responsive action SHOULD be taken immediately
        /// </summary>
        Immediate,
        /// <summary>
        /// Responsive action SHOULD be taken soon (within next hour)
        /// </summary>
        Expected,
        /// <summary>
        /// Responsive action SHOULD be taken in the near future
        /// </summary>
        Future,
        /// <summary>
        /// Responsive action is no longer required
        /// </summary>
        Past,
        /// <summary>
        /// Urgency not known
        /// </summary>
        Unknown
    }
}