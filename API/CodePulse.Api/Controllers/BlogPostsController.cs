using CodePulse.Api.Models.Domain;
using CodePulse.Api.Models.DTO;
using CodePulse.Api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CodePulse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
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
                ShortDescription = request.ShortDescription
            };

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
                IsVisible = blogPost.IsVisible

            };

            return Ok();
        }
      

    }
}
