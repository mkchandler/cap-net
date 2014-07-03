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
    public class SeverityRequiredValidator : Validator<Info>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public SeverityRequiredValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.Severity.HasValue)
                    return Enum.IsDefined(typeof(Severity),Entity.Severity.Value);
                return false;
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
                     yield return new SeverityRequiredError();
            }
        }
    }
}
