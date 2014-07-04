using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// A text description of the affected area is required ! 
    /// </summary>
    public class AreaDescriptionRequiredValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public AreaDescriptionRequiredValidator(Area area) : base(area) { }

        /// <summary>
        /// Area description should not be null or empty
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !(string.IsNullOrEmpty(Entity.Description));
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
                    yield return new AreaDescriptionRequiredError();
            }
        }

    }
}
