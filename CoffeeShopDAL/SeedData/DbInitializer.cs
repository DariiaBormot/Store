using CoffeeShopDAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeShopDAL.SeedData
{
    public class DbInitializer
    {
        public static async Task SeedAsync(CoffeeShopContext ctx)
        {

            if (!ctx.Categories.Any())
            {
                var categoriesData = File.ReadAllText("../CofeeShopDAL/SeedData/Assets/categories.json");

                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                foreach (var item in categories)
                {
                    ctx.Categories.Add(item);
                }

                await ctx.SaveChangesAsync();
            }

            if (!ctx.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../CofeeShopDAL/SeedData/Assets/types.json");

                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                foreach (var item in types)
                {
                    ctx.ProductTypes.Add(item);
                }

                await ctx.SaveChangesAsync();
            }

            if (!ctx.Products.Any())
            {
                var productsData = File.ReadAllText("../CofeeShopDAL/SeedData/Assets/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                foreach (var item in products)
                {
                    ctx.Products.Add(item);
                }

                await ctx.SaveChangesAsync();
            }

        }
    }
}

