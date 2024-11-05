using CookiesCookbook.App;
using CookiesCookbook.DataAccess;
using CookiesCookbook.FileAccess;
using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

var ingredientsRegister = new IngredientsRegister();

const FileFormat Format = FileFormat.Txt;

IStringsRepository stringsRepository = Format == FileFormat.Json ? new StringsJsonRepository() : new StringsTextualRepository();

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(stringsRepository , ingredientsRegister) , new RecipesConsoleUserInteraction( ingredientsRegister));

const string FileName = "recipes";
var fileMetadata = new FileMetadata(FileName,Format);
cookiesRecipesApp.Run(fileMetadata.ToPath());






