using Azure.Core;
using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repository.Implementation;
using CodePulseAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                urlHandle = request.UrlHandle,
            };

            await _categoryRepository.CreateAsync(category);
            //Domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                urlHandle = category.urlHandle
            };
            return Ok(response);
        }

        //GET: https://localhost:7256/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var cartegory = await _categoryRepository.GetAllAsync();

            //Map Domain model to DTO

            var response = new List<Category>();
            foreach (var category in cartegory)
            {
                response.Add(new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    urlHandle = category.urlHandle
                });
            }
            return Ok(response);
        }


        //GET: https://localhost:7256/api/Categories/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                urlHandle = category.urlHandle
            };

            return Ok(response);
        }

        //GET: https://localhost:7256/api/Categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditeCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
        {
            //convert DTO to Domain Model
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                urlHandle = request.urlHandle
            };

            await _categoryRepository.UpdateAsync(category);
            return Ok(category);
        }

            
        [HttpDelete]
        [Route("{id=Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await _categoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }


            // Convert Domain model to DTO

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                urlHandle = category.urlHandle
            };

            return Ok(response);
        }

    }
}
