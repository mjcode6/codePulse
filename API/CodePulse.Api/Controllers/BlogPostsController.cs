using CodePulse.Api.Models.Domain;
using CodePulse.Api.Models.DTO;
using CodePulse.Api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CodePulse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository,
            ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }

        // post api base url for post methode blog post

        [HttpPost]
        public async Task<IActionResult> createBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            // Convert dto to domain model

            var blogPost = new BlogPost
            {
                Author = request.Author,
                UrlHandle = request.UrlHandle,
                Title = request.Title,
                FeaturedImageUrl = request.FeaturedImageUrl,
                PublichedDate = request.PublichedDate,
                IsVisible = request.IsVisible,
                Content = request.Content,
                ShortDescription = request.ShortDescription,
                Categories = new List<Category>()


            };

            foreach (var categoryGuid in request.Categories)
            {
                var exisitingCategory = await categoryRepository.GetById(categoryGuid);

                if(exisitingCategory is not null)
                {
                    blogPost.Categories.Add(exisitingCategory);
                }
                
            }





            blogPost =  await blogPostRepository.CreateAsync(blogPost);

            // Convert domain model to dto

            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                Content = blogPost.Content,
                PublichedDate = blogPost.PublichedDate,
                ShortDescription = blogPost.ShortDescription,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()

            };

            return Ok();
        }

        // get blog  post api url 
        [HttpGet]
        public async Task<IActionResult> getAllBlogPosts()
        {
          var blogPosts =   await blogPostRepository.getAllAsync();

            // Convert domain model to dto

            var response = new List<BlogPostDto>();

            foreach (var blogPost in blogPosts)
            {
                response.Add(new BlogPostDto
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Title = blogPost.Title,
                    UrlHandle = blogPost.UrlHandle,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    Content = blogPost.Content,
                    PublichedDate = blogPost.PublichedDate,
                    ShortDescription = blogPost.ShortDescription,
                    IsVisible = blogPost.IsVisible,
                    Categories = blogPost.Categories.Select(x => new CategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle
                    }).ToList()
                });
            }

            return Ok(response);
        }
    }
}
