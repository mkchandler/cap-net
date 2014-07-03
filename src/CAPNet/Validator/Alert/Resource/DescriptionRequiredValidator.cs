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
    public class DescriptionRequiredValidator:Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public DescriptionRequiredValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                        yield return new DescriptionRequiredError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get 
            {
                var invalidDescription = from info in Entity.Info
                                         from resource in info.Resources
                                         where string.IsNullOrEmpty(resource.Description)
                                         select resource.Description;
                return !invalidDescription.Any();
            }
        }
    }
}
