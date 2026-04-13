namespace BunWulfAgricultural
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(ButcherySkill), 1)]
    public partial class FattyGreaseRecipe : RecipeFamily
    {
        public FattyGreaseRecipe()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "FattyGrease",
                displayName: Localizer.DoStr("Grease from Fat"),
                ingredients: new List<IngredientElement>
                {
                    new("Fat", 2, typeof(ButcherySkill)),
                },
                items: new List<CraftingElement> { new CraftingElement<LubricantItem>(4) }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = this.CreateLaborInCaloriesValue(180, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(FattyGreaseRecipe),
                start: 1.5f,
                skillType: typeof(ButcherySkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Grease from Fat"),
                recipeType: typeof(FattyGreaseRecipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(ButcherySkill), 1)]
    public partial class OilyGreaseRecipe : RecipeFamily
    {
        public OilyGreaseRecipe()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "OilyGrease",
                displayName: Localizer.DoStr("Grease from Oil"),
                ingredients: new List<IngredientElement>
                {
                    new("Oil", 2, typeof(ButcherySkill)),
                },
                items: new List<CraftingElement> { new CraftingElement<LubricantItem>(4) }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = this.CreateLaborInCaloriesValue(180, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(OilyGreaseRecipe),
                start: 1.5f,
                skillType: typeof(ButcherySkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Grease from Oil"),
                recipeType: typeof(OilyGreaseRecipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipeFamily: this);
        }
    }
}
