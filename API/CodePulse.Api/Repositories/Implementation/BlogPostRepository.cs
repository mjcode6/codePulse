﻿using CodePulse.Api.Data;
using CodePulse.Api.Models.Domain;
using CodePulse.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Api.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BlogPostRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
           await applicationDbContext.BlogPosts.AddAsync(blogPost);
            await applicationDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> getAllAsync()
        {
           return  await applicationDbContext.BlogPosts.Include(x => x.Categories).ToListAsync();
        }
    }
}
