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
        private ICollection<Coordonate> coordonates;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Coordonate> Coordonates
        {
            get { return coordonates; }
            private set { coordonates = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeValue"></param>
        public Polygon(string codeValue)
        {
            coordonates = new List<Coordonate>();
            string[] splittedString = codeValue.Split(' ');

            foreach (string coordonate in splittedString)
                coordonates.Add(new Coordonate(coordonate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCodeValue()
        {
            StringBuilder codeValueBuilder = new StringBuilder("");

            foreach (Coordonate coordonate in coordonates)
                codeValueBuilder.Append(coordonate.GetCodeValue()+" ");

            return codeValueBuilder.ToString().Trim();
        }

        
    }
}
