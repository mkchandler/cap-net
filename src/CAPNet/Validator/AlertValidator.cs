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
        public AlertValidator() : base(new Alert()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public AlertValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from info in Entity.Info
                       from error in GetErrors(info)
                       select error;
            }
        }

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
        /// <param name="info"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(Info info)
        {
            var infoValidators = new List<Validator<Info>>();

            infoValidators.Add(new UrgencyRequiredValidator(info));
            infoValidators.Add(new SeverityRequiredValidator(info));
            infoValidators.Add(new EventRequiredValidator(info));
            infoValidators.Add(new CertaintyRequiredValidator(info));
            infoValidators.Add(new CategoryRequiredValidator(info));

            return from validator in infoValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
