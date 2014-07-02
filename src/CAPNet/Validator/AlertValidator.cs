using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class AlertValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public AlertValidator(Alert alert)
            : base(alert)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> ValidationError
        {
            get
            {
                yield return new AlertError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                IEnumerable<IEnumerable<Error>> errorLists = this.Errors(Entity);
                if (errorLists.Count() == 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public IEnumerable<IEnumerable<Error>> Errors(Alert alert)
        {

            var errors = from info in alert.Info
                         from error in GetErrors(info)
                         select error;

            return errors;
        }

        private IEnumerable<IEnumerable<Error>> GetErrors(Info info)
        {
            var infoValidators = new List<Validator<Info>>();

            infoValidators.Add(new UrgencyRequiredValidator(info));
            infoValidators.Add(new SeverityRequiredValidator(info));
            infoValidators.Add(new EventRequiredValidator(info));
            infoValidators.Add(new CertaintyRequiredValidator(info));
            infoValidators.Add(new CategoryRequiredValidator(info));

            return from validator in infoValidators
                   where !validator.IsValid
                   select validator.ValidationError;
        }
    }
}
