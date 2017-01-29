using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OnlineShop.Libs.Data.Tests.Mocks
{
    // for test purpose only

    public class DimmyClass : IDbModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public static IEnumerable<DimmyClass> GetDimmyCollection()
        {
            return new List<DimmyClass>()
            {
                new DimmyClass {Id = 11, IsDeleted = true },
                new DimmyClass {Id = 1, IsDeleted = false },
                new DimmyClass {Id = 6, IsDeleted = true },
                new DimmyClass {Id = 5, IsDeleted = true },
                new DimmyClass {Id = 0, IsDeleted = false },
                new DimmyClass {Id = 12, IsDeleted = false },
                new DimmyClass {Id = 14, IsDeleted = false },
                new DimmyClass {Id = 21, IsDeleted = true },
                new DimmyClass {Id = 20, IsDeleted = true },
                new DimmyClass {Id = 19, IsDeleted = false },
                new DimmyClass {Id = 17, IsDeleted = false },
                new DimmyClass {Id = 18, IsDeleted = false },
                new DimmyClass {Id = 8, IsDeleted = true },
                new DimmyClass {Id = 22, IsDeleted = false },
                new DimmyClass {Id = 9, IsDeleted = false },
                new DimmyClass {Id = 16, IsDeleted = false },
                new DimmyClass {Id = 3, IsDeleted = false },
                new DimmyClass {Id = 15, IsDeleted = true },
                new DimmyClass {Id = 7, IsDeleted = false },
                new DimmyClass {Id = 23, IsDeleted = true },
                new DimmyClass {Id = 10, IsDeleted = false },
                new DimmyClass {Id = 13, IsDeleted = true },
                new DimmyClass {Id = 2, IsDeleted = false }
            };
        }
    }
}
