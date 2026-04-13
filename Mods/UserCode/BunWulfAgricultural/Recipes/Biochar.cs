namespace BunWulfAgricultural
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(FarmingSkill), 6)]
    public partial class BiocharRecipe : RecipeFamily
    {
        public BiocharRecipe()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "Biochar",
                displayName: Localizer.DoStr("Biochar Charcoal Burning"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(CharcoalItem), 4, staticIngredient: true),
                    new(
                        "Vegetable",
                        20,
                        typeof(FarmingSkill)
                    ),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<CharcoalItem>(5),
                    new CraftingElement<OilItem>(5),
                }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BiocharRecipe),
                start: 1,
                skillType: typeof(FarmingSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Biochar Charcoal Burning"),
                recipeType: typeof(BiocharRecipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(KilnObject), recipeFamily: this);
        }
    }
}
