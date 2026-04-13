namespace ShopBoat
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(ShipwrightSkill), 3)]
    [Ecopedia("Crafted Objects", "Vehicles", subPageName: "Shop Boat Item")]
    public partial class ShopBoatRecipe : RecipeFamily
    {
        public ShopBoatRecipe()
        {
            Recipe recipe = new();
            recipe.Init(
                name: "Shop Boat",
                displayName: Localizer.DoStr("Shop Boat"),
                ingredients: new List<IngredientElement>
                {
                    new(typeof(WoodenTransportShipItem), 1, true),
                    new(typeof(WoodShopCartItem), 1, true),
                    new(
                        typeof(NailItem),
                        40,
                        typeof(ShipwrightSkill)
                    ),
                },
                items: new List<CraftingElement> { new CraftingElement<ShopBoatItem>() }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(ShipwrightSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ShopBoatRecipe),
                start: 1,
                skillType: typeof(ShipwrightSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Shop Boat"),
                recipeType: typeof(ShopBoatRecipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(MediumShipyardObject),
                recipeFamily: this
            );
        }
    }
}
