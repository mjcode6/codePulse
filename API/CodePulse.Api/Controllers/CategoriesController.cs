﻿using CodePulse.Api.Data;
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


    }
}
