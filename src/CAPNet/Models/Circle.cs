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
            this.Center = new Coordinate(splittedString[0]);
            this.Radius = double.Parse(splittedString[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="radius"></param>
        public Circle(Coordinate coordinate, double radius)
        {
            this.Center = coordinate;
            this.Radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Radius 
        {
            get; 
            private set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public Coordinate Center 
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
            return Center + " " + Radius.ToString();
        }

    }
}
