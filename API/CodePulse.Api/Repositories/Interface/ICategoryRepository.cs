using CodePulse.Api.Models.Domain;
using System.Collections.Generic;

namespace CodePulse.Api.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);


        Task<IEnumerable<Category>>GetAllAsync();
    }
}
