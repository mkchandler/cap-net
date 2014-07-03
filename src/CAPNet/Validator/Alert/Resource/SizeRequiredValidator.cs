using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Resource with uri SHOULD have Size ! 
    /// </summary>
    public class SizeRequiredWhenUriValidator : Validator<Resource>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public SizeRequiredWhenUriValidator(Resource resource) : base(resource) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                // if uri is not null , size should Exist . So if uri is not null and size exists , everything is ok
                return Entity.Uri == null || Entity.Size.HasValue;
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
                    yield return new SizeRequiredError();
            }
        }
    }
}
