using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// 
        /// </summary>
        private ICollection<Coordinate> coordonates;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Coordinate> Coordonates
        {
            get { return coordonates; }
            private set { coordonates = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation">The geographic polygon is represented by a whitespace-delimited list of [WGS 84] coordinate pairs</param>
        public Polygon(string stringRepresentation)
        {
            coordonates = new List<Coordinate>();
            string[] splittedString = stringRepresentation.Split(' ');

            foreach (string coordonate in splittedString)
                coordonates.Add(new Coordinate(coordonate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(" ", coordonates);
        }

        
    }
}
