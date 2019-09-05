using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizerTest.API.Data.DTOs;
using WizerTest.Data.Entities;
using WizerTest.Services.Repository.Interfaces;

namespace WizerTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet (Name = "GetCategories")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = _categoryRepository.GetCategories().ToList();

            var categoriesDTO = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name

                });
            }

            return Ok(categoriesDTO);
        }

        [HttpGet("{categoryId}", Name = "GetCategory")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int categoryId)
        {
            

            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryDTO = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Category))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateCategory(CategoryDto categoryDto)
        {
           

            var categoryToCreate = new Category
            {
                Name = categoryDto.Name
            };

            var createdCategory = _categoryRepository.CreateCategory(categoryToCreate);
            return StatusCode(201);


        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCategory(int categoryId, Category UpdatedcategoryInfo)
        {
           

            var categoryToUpdate = new Category
            {
                Name = UpdatedcategoryInfo.Name
            };

            var updatedCategory = _categoryRepository.UpdateCategory(categoryToUpdate);
            return StatusCode(201);

           
        }

        //api/categories/categoryId
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest();

            

            var deletedcategory = _categoryRepository.DeleteCategory(categoryToDelete); 

            return NoContent();


        }
    }
}
