using OnlineShop.Libs.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OnlineShop.Libs.Data.Tests.Mocks
{
    // for test purpose only

    public class DimmyClass : IDbModel
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public static IEnumerable<DimmyClass> GetDimmyCollection()
        {
            return new List<DimmyClass>()
            {
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = true },
                new DimmyClass {Id = Guid.NewGuid(), IsDeleted = false }
            };
        }
    }
}
