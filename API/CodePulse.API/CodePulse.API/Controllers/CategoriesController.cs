using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace CodePulse.API.Controllers
{

    // https_://localhost:5000/api/categories
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
           // Map DTO to Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

          await categoryRepository.CreateAsync(category);

            //Model to DTo
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);

        }
     

    }
}
