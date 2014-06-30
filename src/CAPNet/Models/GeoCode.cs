namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GeoCode
    {
        private readonly string value;

        private readonly string valueName;

        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ValueName
        {
            get
            {
                return this.valueName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        public GeoCode(string valueName, string value)
        {
            this.valueName = valueName;
            this.value = value;
        }
    }
}
