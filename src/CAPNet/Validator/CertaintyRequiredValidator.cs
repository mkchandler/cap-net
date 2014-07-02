using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    class CertaintyRequiredValidator : Validator<Info>
    {
        public CertaintyRequiredValidator(Info info):base(info){}

        public override bool IsValid
        {
            get
            {
                return (Enum.IsDefined(typeof(Certainty), this.Entity.Certainty));
            }
        }

        public override IEnumerable<Error> ValidationError
        {
            get
            {
                yield return (new CertaintyRequiredError());
            }
        }
    }
}
