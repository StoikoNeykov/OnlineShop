using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OnlineShop.Libs.Data.Tests.Mocks
{
    // for test purpose only

    public class DimmyClass : IDbModel
    {
        public DimmyClass()
        {

        }

        public DimmyClass(bool randomBool)
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = randomBool;
        }

        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public static IEnumerable<DimmyClass> GetDimmyCollection()
        {
            return new List<DimmyClass>()
            {
                new DimmyClass(true) ,
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(true),
                new DimmyClass(true),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(true),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(false),
                new DimmyClass(true),
                new DimmyClass(false)
            };
        }
    }
}
