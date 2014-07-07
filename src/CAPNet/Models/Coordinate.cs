﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringRepresentation"></param>
        public Coordinate(string stringRepresentation)
        {
            var splitCoordinate = stringRepresentation.Split(',');
            this.X = double.Parse(splitCoordinate[0]);
            this.Y = double.Parse(splitCoordinate[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        public double X
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Y
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
            return X.ToString() + "," + Y.ToString();
        }

    }
}
