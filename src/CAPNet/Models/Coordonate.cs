using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Coordonate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeValue"></param>
        public Coordonate(string codeValue)
        {
            string[] splitted = codeValue.Split(',');
            this.X = double.Parse(splitted[0]);
            this.Y = double.Parse(splitted[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordonate(double x, double y)
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
