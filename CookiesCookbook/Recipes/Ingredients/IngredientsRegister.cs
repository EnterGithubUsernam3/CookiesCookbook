namespace CookiesCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{


    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
{
    new WheatFlour(),
    new SpeltFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamom(),
    new Cinamon(),
    new CocoaPowder()
};

    public Ingredient GetById(int id)
    {
        var allOfIngredientsWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(allOfIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"More than one ingredients have ID equal to {id}.");
        }
        return allOfIngredientsWithGivenId.FirstOrDefault();
    }
   
}


