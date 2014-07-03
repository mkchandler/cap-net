using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Verifies if all elements of category are ok
    /// </summary>
    public class InvalidCategoryValidator : Validator<Info>
    {
        /// <summary>
        /// Constructor with info parameter
        /// </summary>
        /// <param name="info"></param>
        public InvalidCategoryValidator(Info info) : base(info) { }

        /// <summary>
        /// Validation Method
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var queryErrors = from category in Entity.Categories
                                  where !Enum.IsDefined(typeof(Category), category)
                                  select category;

                return !queryErrors.Any();
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
                    yield return new InvalidCategoryError();
            }
        }
    }
}
