# Recipe_Migration

# Описание проекта

Этот проект представляет собой ASP.NET Core Web API для миграции данных рецептов из одной базы данных (шаблонной) в другую (таргетную). Приложение предоставляет возможность автоматического переноса данных с учетом связанных таблиц и особенностей модели данных.

## Функциональность
- Миграция рецептов из шаблонной базы данных в таргетные базы (TargetRecipe и TargetRecipe2).
- Учет связанных данных, таких как RecipeMixerSet, RecipeTimeSet, и RecipeStructure.
- Обработка ошибок и логирование.

## Требования
- .NET 8
- PostgreSQL
- Среда разработки (Visual Studio, Rider, VS Code и т.д.)

## Установка

1. Склонируйте репозиторий:
   ```bash
   git clone <URL репозитория>
   ```

2. Перейдите в папку проекта:
   ```bash
   cd TestProject
   ```

3. Убедитесь, что PostgreSQL запущен и созданы базы данных для шаблона и таргета.

4. Настройте файл `appsettings.json`, добавив строки подключения к базам данных:
   ```json
   "ConnectionStrings": {
       "SourceDb": "Host=<HOST>;Database=<TEMPLATE_DB>;Username=<USER>;Password=<PASSWORD>",
       "TargetDb": "Host=<HOST>;Database=<TARGET_DB>;Username=<USER>;Password=<PASSWORD>"
   }
   ```

## Запуск

1. Выполните миграции для базы данных:
   ```bash
   dotnet ef database update --context DatabaseContext
   dotnet ef database update --context Target1DatabaseContext
   ```

2. Запустите приложение:
   ```bash
   dotnet run
   ```

3. API будет доступно по адресу: `https://localhost:5001` (или другому порту, указанному в настройках).

## Использование

### Миграция данных
Для запуска миграции данных используйте эндпоинт:
- `POST /api/migrate`

Пример запроса с помощью `curl`:
```bash
curl -X POST https://localhost:5001/api/migrate
```

### Примеры моделей
- **Recipe** (шаблон): содержит данные о рецептах и ссылки на MixerSet и TimeSet.
- **TargetRecipe** и **TargetRecipe2** (таргет): рецепты с различными форматами и полями.

## Структура проекта
- `Models/`: Содержит модели данных (Recipe, TargetRecipe, RecipeStructure и др.).
- `Services/`: Реализует логику миграции данных.
- `Controllers/`: Содержит API контроллеры.
- `Data/`: Конфигурация базы данных (DbContext).

