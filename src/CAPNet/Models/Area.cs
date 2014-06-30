using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the area sub-element of the info sub-element
    /// of the alert message (OPTIONAL)
    /// </summary>
    /// <remarks>
    ///   <list type="number">
    ///     <item>
    ///       <description>
    ///         Multiple occurrences permitted, in which case the target area for the &lt;info>
    ///         block is the union of all the included &lt;area> blocks.
    ///       </description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///         MAY contain one or multiple instances of &lt;polygon>, &lt;circle> or &lt;geocode>.
    ///         If multiple &lt;polygon>, &lt;circle> or &lt;geocode>  elements are included, the
    ///         area described by this &lt;area> block is represented by the union of all the included elements.
    ///       </description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class Area
    {
        /// <summary>
        /// 
        /// </summary>
        public Area()
        {
            _geocodes = new List<Parameter>();
            _polygons = new List<string>();
            _circles = new List<string>();
        }

        /// <summary>
        /// The text describing the affected area of the alert message (REQUIRED)
        /// </summary>
        /// <remarks>A text description of the affected area.</remarks>
        public string Description { get; set; }

        /// <summary>
        /// The paired values of points defining a polygon that delineates the affected area of the alert message (OPTIONAL)
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item><description>
        ///       Code Values: The geographic polygon is represented by a whitespace-delimited list of [WGS 84] coordinate pairs.
        ///     </description></item>
        ///     <item><description>
        ///       A minimum of 4 coordinate pairs MUST be present and the first and last pairs of coordinates MUST be the same.
        ///     </description></item>
        ///     <item><description>
        ///       Multiple instances MAY occur within an &lt;area> block.
        ///     </description></item>
        ///   </list>
        /// </remarks>
        public ICollection<string> Polygons
        {
            get { return _polygons; }
            set { _polygons = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> Circles
        {
            get { return _circles; }
            set { _circles = value; }
        }

        private ICollection<string> _circles
        {
            get;
            set;
        }

        private ICollection<string> _polygons;

        private ICollection<Parameter> _geocodes;

        /// <summary>
        /// The geographic code(s) delineating the affected area of the alert message (OPTIONAL)
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item><description>
        ///       Any geographically-based code to describe a message target area, in the form:
        ///         &lt;geocode>
        ///           &lt;valueName>valueName&lt;/valueName>
        ///           &lt;value>value&lt;/value>
        ///         &lt;/geocode>
        ///       where the content of “valueName” is a user-assigned string designating the domain
        ///       of the code, and the content of “value” is a string (which may represent a number)
        ///       denoting the value itself (e.g., valueName ="SAME" and value="006113").
        ///     </description></item>
        ///     <item><description>
        ///       Values of “valueName” that are acronyms SHOULD be represented in all capital letters without periods (e.g., SAME, FIPS, ZIP).
        ///     </description></item>
        ///     <item><description>
        ///       Multiple instances MAY occur within an &lt;area> block.
        ///     </description></item>
        ///     <item><description>
        ///       This element is primarily for compatibility with other systems. Use of this element presumes knowledge
        ///       of the coding system on the part of recipients; therefore, for interoperability, it SHOULD be used
        ///       in concert with an equivalent description in the more universally understood &lt;polygon> and &lt;circle>
        ///       forms whenever possible.
        ///     </description></item>
        ///   </list>
        /// </remarks>
        public ICollection<Parameter> Geocodes
        {
            get { return _geocodes; }
        }

        /// <summary>
        /// The specific or minimum altitude of the affected area of the alert message (OPTIONAL)
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item><description>
        ///       If used with the &lt;ceiling> element this value is the lower limit of a range. Otherwise, this value specifies a specific altitude.
        ///     </description></item>
        ///     <item><description>
        ///       The altitude measure is in feet above mean sea level per the [WGS 84] datum.
        ///     </description></item>
        ///   </list>
        /// </remarks>
        public string Altitude { get; set; }

        /// <summary>
        /// The maximum altitude of the affected area of the alert message (CONDITIONAL)
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item><description>
        ///       MUST NOT be used except in combination with the &lt;altitude> element.
        ///     </description></item>
        ///     <item><description>
        ///       The ceiling measure is in feet above mean sea level per the [WGS 84] datum.
        ///     </description></item>
        ///   </list>
        /// </remarks>
        public string Ceiling { get; set; }
    }
}
