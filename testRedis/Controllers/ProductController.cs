using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using testRedis.data.models;
using testRedis.Services.contarcts;

namespace testRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IProductServices _productServices;
        private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(10);
        readonly IRedisCache _redisCache;
        public ProductController(IProductServices productServices,IRedisCache redisCache) {
        this._productServices = productServices;
        this._redisCache = redisCache;

        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var cacheKey = "Products";

            // Try to get cached data from Redis
            var cachedProductsJson = await _redisCache.GetCacheValueAsync<string>(cacheKey);

            if (cachedProductsJson != null)
            {
                // Deserialize the cached products with circular reference handling
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                };

                var cachedProducts = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(cachedProductsJson, options);
                return Ok(cachedProducts);
            }

            // If no cached data, fetch the products from the database/service
            var products = _productServices.GetAllProducts();

            if (products == null)
            {
                return NotFound("No Products Found");
            }

            // Serialize the products with circular reference handling before storing them in Redis
            var serializeOptions = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

            // Serialize and cache the products
            await _redisCache.SetCacheValueAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(products, serializeOptions), CacheExpiration);

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productServices.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Post(String productname , decimal price , int categoryid)
        {

            Product product = new Product();
            product.Name = productname;
            product.Price = price;
            product.CategoryId = categoryid;
            var result = _productServices.CreateProduct(product);

            if (result == "Product created successfully")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
