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
    public class ResponseTypeValidator : Validator<ResponseType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseType"></param>
        public ResponseTypeValidator(ResponseType responseType) : base(responseType) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(ResponseType), Entity); 
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
                    yield return new ResponseTypeError();
            }
        }
    }
}
