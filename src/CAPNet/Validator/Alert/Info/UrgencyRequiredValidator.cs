using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class UrgencyRequiredValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public UrgencyRequiredValidator(Info info) : base(info) { }
       
        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(Urgency), Entity.Urgency);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                     yield return new UrgencyRequiredError();
            }
        }
    }
}
