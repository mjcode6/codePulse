﻿using CodePulse.Api.Data;
using CodePulse.Api.Models.Domain;
using CodePulse.Api.Repositories.Interface;

namespace CodePulse.Api.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {


            await applicationDbContext.Categories.AddAsync(category);

            await applicationDbContext.SaveChangesAsync();

            return category;
        }
    }
}