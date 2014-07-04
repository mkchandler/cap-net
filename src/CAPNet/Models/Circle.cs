using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Circle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation">The circular area is represented by a central point given as a [WGS 84] coordinate pair followed by a space character and a radius value in kilometers.</param>
        public Circle(string stringRepresentation)
        {
            string[] splittedString = stringRepresentation.Split(' ');
            this.CentralPoint = new Coordonate(splittedString[0]);
            this.RadiusValue = double.Parse(splittedString[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordonate"></param>
        /// <param name="radius"></param>
        public Circle(Coordonate coordonate, double radius)
        {
            this.CentralPoint = coordonate;
            this.RadiusValue = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        public double RadiusValue 
        {
            get; 
            private set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public Coordonate CentralPoint 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CentralPoint + " " + RadiusValue.ToString();
        }

    }
}
