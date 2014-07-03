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
    public class MimeTypeRequiredValidator : Validator<Resource>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public MimeTypeRequiredValidator(Resource resource) : base(resource) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Entity.MimeType);
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
                    yield return new MimeTypeRequiredError();
            }
        }
    }
}
