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
    public class CategoryRequiredValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public CategoryRequiredValidator(Info info):base(info){}

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (!Entity.Categories.Any())
                    return false;
                return true ;
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
                    yield return new CategoryRequiredError();
            }
        }
    }
}
