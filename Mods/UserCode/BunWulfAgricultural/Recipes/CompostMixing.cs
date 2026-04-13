namespace BunWulfAgricultural
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class BerryExtractFertilizerMixing : RecipeFamily
    {
        public BerryExtractFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "BerryExtractFertilizerMixing",
                displayName: Localizer.DoStr("Berry Extract Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(BerryExtractFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BerryExtractFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Berry Extract Fertilizer Mixing"),
                recipeType: typeof(BerryExtractFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class BloodMealFertilizerMixing : RecipeFamily
    {
        public BloodMealFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "BloodMealFertilizerMixing",
                displayName: Localizer.DoStr("Blood Meal Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(BloodMealFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(BloodMealFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Blood Meal Fertilizer Mixing"),
                recipeType: typeof(BloodMealFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class CamasAshFertilizerMixing : RecipeFamily
    {
        public CamasAshFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "CamasAshFertilizerMixing",
                displayName: Localizer.DoStr("Camas Ash Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(CamasAshFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(CamasAshFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Camas Ash Fertilizer Mixing"),
                recipeType: typeof(CamasAshFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class HideAshFertilizerMixing : RecipeFamily
    {
        public HideAshFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "HideAshFertilizerMixing",
                displayName: Localizer.DoStr("Hide Ash Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(HideAshFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(HideAshFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Hide Ash Fertilizer Mixing"),
                recipeType: typeof(HideAshFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class PeltFertilizerMixing : RecipeFamily
    {
        public PeltFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "PeltFertilizerMixing",
                displayName: Localizer.DoStr("Pelt Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(PeltFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(PeltFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Pelt Fertilizer Mixing"),
                recipeType: typeof(PeltFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(FertilizersSkill), 6)]
    public partial class PhosphateFertilizerMixing : RecipeFamily
    {
        public PhosphateFertilizerMixing()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "PhosphateFertilizerMixing",
                displayName: Localizer.DoStr("Phosphate Fertilizer Mixing"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(PhosphateFertilizerItem), 1, staticIngredient: true),
                    new(typeof(CompostFertilizerItem), 1, staticIngredient: true),
                },
                items: new List<CraftingElement> { new CraftingElement<CompostFertilizerItem>(2) }
            );
            Recipes = new List<Recipe> { recipe };
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill));
            CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(PhosphateFertilizerMixing),
                start: 0.25f,
                skillType: typeof(FertilizersSkill)
            );
            Initialize(
                displayText: Localizer.DoStr("Phosphate Fertilizer Mixing"),
                recipeType: typeof(PhosphateFertilizerMixing)
            );
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipeFamily: this);
        }
    }
}
