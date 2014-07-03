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
                bool ok = false;
                int countCategories = 0;
                int countOKs = 0;

                foreach (var category in Entity.Categories)
                {
                    if (Enum.IsDefined(typeof(Category), category))
                        countOKs = countOKs + 1;
                    countCategories = countCategories + 1;
                }

                if (Entity.Categories.Count() > 0) //entity is not empty
                    if (countOKs == countCategories)
                        ok = true;

                return ok;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                yield return new CategoryRequiredError();
            }
        }
    }
}
