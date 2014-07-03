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
    public class MimeTypeRequiredValidator:Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public MimeTypeRequiredValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get 
            {
                var invalidMimeType = from info in Entity.Info
                                      from resource in info.Resources
                                      where string.IsNullOrEmpty(resource.MimeType)
                                      select resource.MimeType;
                return !invalidMimeType.Any();
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
