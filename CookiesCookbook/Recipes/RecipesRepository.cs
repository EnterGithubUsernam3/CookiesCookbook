using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes;

public class RecipesRepository : IRecipesRepository

{
    private readonly IStringsRepository _stringRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string _separator = ",";
    public RecipesRepository(IStringsRepository stringRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringRepository = stringRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    public List<Recipe> Read(string filePath)
    {
        return _stringRepository.Read(filePath)
            .Select(recipe => RecipeFromString(recipe))
            .ToList();

    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        return  new Recipe(recipeFromFile.Split(_separator).
            Select(textualId => int.Parse(textualId)).
            Select(numberId => _ingredientsRegister.GetById(numberId)).ToList());
       
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = allRecipes.Select(recipe =>
        {
            var allIds = recipe.Ingredients.Select(ingredient => ingredient.Id);
            return string.Join(_separator, allIds);
        }); ;
        

        _stringRepository.Write(filePath, recipesAsStrings.ToList());
    }
}

