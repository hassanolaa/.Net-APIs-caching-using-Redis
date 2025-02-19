using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testRedis.data.models;
using testRedis.Services.contarcts;

namespace testRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatgeoriesController : ControllerBase
    {
        readonly ICategoryServices _categoryServices;
        private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(10);
        readonly IRedisCache _redisCache;
        public CatgeoriesController(ICategoryServices categoryServices,IRedisCache redisCache)
        {
            this._categoryServices = categoryServices;
            this._redisCache = redisCache;
        }



        [HttpGet]
        public IActionResult Get() {
            var categories = _categoryServices.GetAllCategories();
            if (categories == null)
            {
                return NotFound("No Categories Found");
            }


            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id) {

            var cacheKey = $"Category:{id}";

            var cachedCategory = await _redisCache.GetCacheValueAsync<Category>(cacheKey);
            if (cachedCategory != null)
            {
                return Ok(cachedCategory);
            }

            var category = _categoryServices.GetCategoryById(id);
            if (category == null) {
                return NotFound("No Category with this id");
            }

            await _redisCache.SetCacheValueAsync(cacheKey, category, CacheExpiration);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post( String categoryname) {
            Category category = new Category();
            category.Name = categoryname;
            return Ok(_categoryServices.CreateCategory(category));
        }

    }
}
