namespace BunWulfHardwareCo
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(MechanicsSkill), 5)]
    public partial class LowTechStreetlampRecipe : RecipeFamily
    {
        public LowTechStreetlampRecipe()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "Low Tech Streetlamp",
                displayName: Localizer.DoStr("Low Tech Streetlamp"),
                ingredients: new List<IngredientElement>
                {
                    new(
                        typeof(IronBarItem),
                        12,
                        typeof(MechanicsSkill)
                    ),
                    new(
                        typeof(GlassItem),
                        5,
                        typeof(MechanicsSkill)
                    ),
                    new(
                        typeof(CopperWiringItem),
                        5,
                        typeof(MechanicsSkill)
                    ),
                    new(typeof(LightBulbItem), 1, true),
                },
                items: new List<CraftingElement> { new CraftingElement<StreetlampItem>() }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(LowTechStreetlampRecipe),
                start: 6,
                skillType: typeof(MechanicsSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Low Tech Streetlamp"),
                recipeType: typeof(LowTechStreetlampRecipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(AssemblyLineObject), recipeFamily: this);
        }
    }
}
