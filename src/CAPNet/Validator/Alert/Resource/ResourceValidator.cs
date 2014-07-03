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
    public class ResourceValidator:Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public ResourceValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get 
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get 
            {
                return from error in GetErrors(Entity)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(Alert alert)
        {
            var resourceValidators = new List<Validator<Alert>>();

            resourceValidators.Add(new MimeTypeRequiredValidator(alert));
            resourceValidators.Add(new DescriptionRequiredValidator(alert));

            return from validator in resourceValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
