using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Required Component of Resource
    /// </summary>
    public class ResourceDescriptionRequiredValidator : Validator<Resource>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public ResourceDescriptionRequiredValidator(Resource resource) : base(resource) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new ResourceDescriptionRequiredError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Entity.Description);
            }
        }
    }
}
