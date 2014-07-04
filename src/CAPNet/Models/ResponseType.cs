using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// 
        /// </summary>
        Shelter = 1,
        /// <summary>
        /// 
        /// </summary>
        Evacuate,
        /// <summary>
        /// 
        /// </summary>
        Prepare,
        /// <summary>
        /// 
        /// </summary>
        Execute,
        /// <summary>
        /// 
        /// </summary>
        Avoid,
        /// <summary>
        /// 
        /// </summary>
        Monitor,
        /// <summary>
        /// 
        /// </summary>
        Assess,
        /// <summary>
        /// 
        /// </summary>
        AllClear,
        /// <summary>
        /// 
        /// </summary>
        None
    }
}
