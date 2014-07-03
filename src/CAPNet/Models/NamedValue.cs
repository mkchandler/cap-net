namespace CAPNet.Models
{
    /// <summary>
    /// Base class for values with names (e.g. EventCode, GeoCode)
    /// </summary>
    public abstract class NamedValue
    {
        private readonly string value;

        private readonly string valueName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        protected NamedValue(string valueName, string value)
        {
            this.valueName = valueName;
            this.value = value;
        }

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
    }
}