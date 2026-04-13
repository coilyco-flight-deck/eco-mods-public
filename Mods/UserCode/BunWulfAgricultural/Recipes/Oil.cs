namespace BunWulfAgricultural
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    // 2 Tallow                   => 2 Oil item
    // 1 Oil tag + 1 Flaxseed Oil => 2 Flaxseed Oil
    // 1 Flaxseed Oil + 1 Oil     => 2 Oil

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class MashTallowRecipe : RecipeFamily
    {
        public MashTallowRecipe()
        {
            string name = "Mash Tallow";
            Recipe recipe = new();
            recipe.Init(
                name: name.Replace(" ", string.Empty),
                displayName: Localizer.DoStr(name),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(TallowItem), 2, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<OilItem>(2) }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = this.CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(MashTallowRecipe),
                start: 0.1f,
                skillType: typeof(CookingSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr(name),
                recipeType: typeof(MashTallowRecipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(CastIronStoveObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class FlaxyOilRecipe : RecipeFamily
    {
        public FlaxyOilRecipe()
        {
            string name = "Flaxy Oil";
            Recipe recipe = new();
            recipe.Init(
                name: name.Replace(" ", string.Empty),
                displayName: Localizer.DoStr(name),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(FlaxseedOilItem), 1, staticIngredient: true),
                    new("Oil", 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<FlaxseedOilItem>(2) }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = this.CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(FlaxyOilRecipe),
                start: 0.1f,
                skillType: typeof(CookingSkill)
            );
            this.Initialize(displayText: Localizer.DoStr(name), recipeType: typeof(FlaxyOilRecipe));
            CraftingComponent.AddRecipe(tableType: typeof(CastIronStoveObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class OilyOilRecipe : RecipeFamily
    {
        public OilyOilRecipe()
        {
            string name = "Oily Oil";
            Recipe recipe = new();
            recipe.Init(
                name: name.Replace(" ", string.Empty),
                displayName: Localizer.DoStr(name),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(OilItem), 1, staticIngredient: true),
                    new("Oil", 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<OilItem>(2) }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = this.CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(OilyOilRecipe),
                start: 0.1f,
                skillType: typeof(CookingSkill)
            );
            this.Initialize(displayText: Localizer.DoStr(name), recipeType: typeof(OilyOilRecipe));
            CraftingComponent.AddRecipe(tableType: typeof(CastIronStoveObject), recipeFamily: this);
        }
    }
}
