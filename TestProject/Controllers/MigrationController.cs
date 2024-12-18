using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TestProject.Data;
using TestProject.Models;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MigrationController : ControllerBase
    {
        private readonly DatabaseContext _sourceContext;
        private readonly DatabaseContext _targetContext;

        public MigrationController(DatabaseContext sourceContext, DatabaseContext targetContext)
        {
            _sourceContext = sourceContext;
            _targetContext = targetContext;
        }

        [HttpPost("migrate")]
        public async Task<IActionResult> MigrateRecipes()
        {
            try
            {
                // Загрузка данных из исходной БД
                var sourceRecipes = _sourceContext.Recipes.ToList();
                var sourceStructures = _sourceContext.RecipeStructures.ToList();

                // Маппинг данных
                foreach (var recipe in sourceRecipes)
                {
                    var mappedRecipe = MapRecipe(recipe);
                    await _targetContext.Recipes.AddAsync(mappedRecipe);
                }

                await _targetContext.SaveChangesAsync();

                return Ok("Migration completed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error during migration: {ex.Message}");
            }
        }

        private Recipe MapRecipe(Recipe sourceRecipe)
        {
            // Пример преобразования рецепта
            return new Recipe
            {
                Name = sourceRecipe.Name,
                DateModified = sourceRecipe.DateModified,
                MixerSetId = sourceRecipe.MixerSetId,
                TimeSetId = sourceRecipe.TimeSetId,
                WaterCorrect = sourceRecipe.WaterCorrect
            };
        }
    }
}
