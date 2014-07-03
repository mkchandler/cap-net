using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Validator<T> : IValidator<T>
    {
        private readonly T entity;

        /// <summary>
        /// 
        /// </summary>
        public T Entity
        {
            get { return entity; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public Validator(T entity)
        {
            this.entity = entity;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract bool IsValid
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract IEnumerable<Error> Errors
        {
            get;
        }
    }
}