using CodePulse.Api.Data;
using CodePulse.Api.Models.Domain;
using CodePulse.Api.Models.DTO;
using CodePulse.Api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Api.Controllers
{

    // https local host /api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // 

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Map Dto to Domain models
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };


            await categoryRepository.CreateAsync(category);



            // Map Domain To DTO

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };






            return Ok(category);

        }

        // Get all categories/ api/ categories https://localhost:7281/api/Categories

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            // Map domain model to DTO

            var response = new List<CategoryDto>();

            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle

                });
            }

            return Ok(response);
        }




        // get categoties base on id for edit category{id}

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetCategoryById([FromRoute]Guid id)
        {
          var exisitingCategory =  await categoryRepository.GetById(id);


            if(exisitingCategory is null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = exisitingCategory.Id,
                Name = exisitingCategory.Name,
                UrlHandle = exisitingCategory.UrlHandle

            };

            return Ok(response);
        }


    }
}
