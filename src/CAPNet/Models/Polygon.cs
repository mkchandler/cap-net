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
        private IEnumerable<Coordinate> coordinates;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Coordinate> Coordinates
        {
            get { return coordinates; }
            private set { coordinates = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation">The geographic polygon is represented by a whitespace-delimited list of [WGS 84] coordinate pairs</param>
        public Polygon(string stringRepresentation)
        {
            var stringCoordinates = stringRepresentation.Split(' ');

            coordinates = from coordinate in stringCoordinates
                          select new Coordinate(coordinate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(" ", coordinates);
        }

        
    }
}
