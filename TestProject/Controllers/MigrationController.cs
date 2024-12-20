using Microsoft.AspNetCore.Mvc;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly DataTransferService _dataTransferService;

        public RecipesController(DataTransferService dataTransferService)
        {
            _dataTransferService = dataTransferService;
        }

        [HttpPost("migrate")]
        public async Task<IActionResult> MigrateRecipes()
        {
            try
            {
                await _dataTransferService.MigrateRecipesAsync();
                return Ok("Recipes migrated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
