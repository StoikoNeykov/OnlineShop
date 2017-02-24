using System;
using System.Data.Entity;
using OnlineShop.Libs.Data.Contracts;
using System.Data.Entity.Infrastructure;
using Bytes2you.Validation;

namespace OnlineShop.Libs.Data
{
    public class Stateful<T> : IStateful<T>
        where T : class
    {
        private DbEntityEntry<T> entry;

        public Stateful(DbEntityEntry<T> entry)
        {
            Guard.WhenArgument(entry, "entry").IsNull().Throw();

            this.entry = entry;
        }

        public EntityState State
        {
            get
            {
                return this.entry.State;
            }

            set
            {
                this.entry.State = value;
            }
        }
    }
}
