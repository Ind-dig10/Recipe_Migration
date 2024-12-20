using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Models;

namespace TestProject.Services
{
    /// <summary>
    /// Сервис для миграции из шаблонной БД в целевую
    /// </summary>
    public class DataTransferService
    {
        private readonly DatabaseContext _templateDbContext;
        private readonly Target1DatabaseContext _targetDbContext;
        private readonly Target2DatabaseContext _target2DbContext;

        public DataTransferService(DatabaseContext templateDbContext, Target1DatabaseContext targetDbContext, Target2DatabaseContext target2DbContext)
        {
            _templateDbContext = templateDbContext;
            _targetDbContext = targetDbContext;
            _target2DbContext = target2DbContext;
        }

        /// <summary>
        /// Миграция данных
        /// </summary>
        /// <returns></returns>
        public async Task MigrateRecipesAsync()
        {
            try
            {
                // Получаем рецепты из шаблонной базы данных
                var templateRecipes = await _templateDbContext.Recipes
                    .Include(r => r.RecipeMixerSet)
                    .Include(r => r.RecipeTimeSet)
                    .ToListAsync();

                foreach (var templateRecipe in templateRecipes)
                {
                    var existingRecipe = await _targetDbContext.Recipes
                        .FirstOrDefaultAsync(r => r.Id == templateRecipe.Id);

                    // Создаем новый рецепт для таргетной базы данных
                    var targetRecipe = new TargetRecipe
                    {
                        Id = templateRecipe.Id,  // Убедитесь, что Id уникален
                        Name = templateRecipe.Name,
                        DateModified = templateRecipe.DateModified,
                        MixTime = templateRecipe.RecipeTimeSet?.MixTime ?? 0,
                        WaterCorrect = 0 // По умолчанию
                    };

                    if (existingRecipe == null)
                    {                
                        await _targetDbContext.Recipes.AddAsync(targetRecipe);
                    }
                    else
                    {
                        _targetDbContext.Entry(existingRecipe).CurrentValues.SetValues(targetRecipe);
                    }

                    //var targetRecipe2 = new TargetRecipe2
                    //{
                    //    Id = templateRecipe.Id,
                    //    Name = templateRecipe.Name,
                    //    DateModified = templateRecipe.DateModified,
                    //    MixerHumidity = 0, // по умолчанию 0
                    //    MixerSetId = templateRecipe.RecipeMixerSet?.Id ?? 0, // MixerSetId берем из RecipeMixerSet
                    //    TimeSetId = templateRecipe.RecipeTimeSet?.Id ?? 0, // TimeSetId берем из RecipeTimeSet
                    //    ConsistencyId = 0 // Если необходимо, добавить логику для ConsistencyId
                    //};

                    //await _target2DbContext.Recipes.AddAsync(targetRecipe2);
                }

                await _targetDbContext.SaveChangesAsync();
               // await _target2DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Логируем ошибку (подключить Nlog)
                Console.WriteLine($"Error migrating recipes: {ex.Message}");
                Console.WriteLine($"Inner ex: {ex.InnerException}");

                throw;
            }
        }
    }
}

