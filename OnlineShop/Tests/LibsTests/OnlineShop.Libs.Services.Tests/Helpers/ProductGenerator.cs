using OnlineShop.Libs.DtoModels;
using OnlineShop.Libs.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Libs.Services.Tests.Helpers
{
    public static class ProductGenerator
    {
        public static IEnumerable<Product> GetProducts(int count)
        {
            Random rng = new Random();

            var result = new List<Product>(count);

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId=StringGenerator.RandomString(rng.Next(50)),
                    Name = StringGenerator.RandomString(rng.Next(50)),
                    Count=rng.Next(),
                    Price=rng.Next(),
                    Photo1 = StringGenerator.RandomString(rng.Next(50)),
                    Photo2 = StringGenerator.RandomString(rng.Next(50)),
                    Photo3 = StringGenerator.RandomString(rng.Next(50)),
                    Photo4 = StringGenerator.RandomString(rng.Next(50)),
                };

                result.Add(product);
            }

            return result;
        }

        public static IEnumerable<ProductDto> GetProductDtos(int count)
        {
            Random rng = new Random();

            var result = new List<ProductDto>(count);

            for (int i = 0; i < count; i++)
            {
                var product = new ProductDto()
                {
                    ProductId = StringGenerator.RandomString(rng.Next(50)),
                    Name = StringGenerator.RandomString(rng.Next(50)),
                    Count = rng.Next(),
                    Price = rng.Next(),
                    Photo1 = StringGenerator.RandomString(rng.Next(50)),
                    Photo2 = StringGenerator.RandomString(rng.Next(50)),
                    Photo3 = StringGenerator.RandomString(rng.Next(50)),
                    Photo4 = StringGenerator.RandomString(rng.Next(50)),
                };

                result.Add(product);
            }

            return result;
        }
    }
}
