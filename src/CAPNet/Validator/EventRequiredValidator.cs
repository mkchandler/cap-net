using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    class EventRequiredValidator : Validator<Info>
    {
        public EventRequiredValidator(Info info) : base(info) { }

        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Entity.Event);
            }
        }

        public override IEnumerable<Error> ValidationError
        {
            get
            {
                yield return (new EventRequiredError());
            }
        }
    }
}
