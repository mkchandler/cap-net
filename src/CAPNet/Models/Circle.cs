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
        /// <param name="codeValue"></param>
        public Circle(string codeValue)
        {
            string[] splittedString = codeValue.Split(' ');
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
        public string GetCodeValue()
        {
            return CentralPoint.GetCodeValue() + " " + RadiusValue.ToString();
        }

    }
}
