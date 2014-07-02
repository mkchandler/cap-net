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
                bool ok = true;

                foreach (var category in Enum.GetValues(typeof(Category)))
                {
                    if (!Enum.IsDefined(typeof(Category), Entity.Categories))
                        ok = false;
                }

                return ok;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> ValidationError
        {
            get
            {
                yield return new CategoryRequiredError();
            }
        }
    }
}
