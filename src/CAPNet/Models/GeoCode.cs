namespace CAPNet.Models
{
    /// <summary>
    /// Codification of a geographical area (e.g. zip code)
    /// </summary>
    public class GeoCode : NamedValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        public GeoCode(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
