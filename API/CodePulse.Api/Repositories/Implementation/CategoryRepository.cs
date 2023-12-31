﻿using CodePulse.Api.Data;
using CodePulse.Api.Models.Domain;
using CodePulse.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Category?> DeleteAsync(Guid id)
        {
             var exisitingCategory =  await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(exisitingCategory is null)
            {
                return null;
            }

            applicationDbContext.Categories.Remove(exisitingCategory);

            await applicationDbContext.SaveChangesAsync();
            return exisitingCategory;
                


        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
          return await applicationDbContext.Categories.ToListAsync();

            
        }

        public async Task<Category?> GetById(Guid id)
        {
           return await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
           var existingCategory =      await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory != null)
            {
                applicationDbContext.Entry(existingCategory).CurrentValues.SetValues(category);

                await applicationDbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
