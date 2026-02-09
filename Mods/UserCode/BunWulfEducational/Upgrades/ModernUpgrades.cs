namespace BunWulfEducational
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Scholars Modern Upgrade 1")]
    [LocDescription(
        "SMU1, A thinking Econian's Modern Upgrade that increases crafting efficiency, 5% better than a MU1."
    )]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true)]
    [Tag("Upgrade")]
    [Tag("ModernUpgrade")]
    [Tag("ScholarsUpgrade")]
    [Tag("SMU1")]
    public partial class ScholarsModernUpgradeLvl1Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Scholars Modern Upgrade 1");

        public ScholarsModernUpgradeLvl1Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.85f) { }
    }

    [Serialized]
    [LocDisplayName("Scholars Modern Upgrade 2")]
    [LocDescription(
        "SMU2, A thinking Econian's Modern Upgrade that increases crafting efficiency, 5% better than a MU2."
    )]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true)]
    [Tag("Upgrade")]
    [Tag("ModernUpgrade")]
    [Tag("ScholarsUpgrade")]
    [Tag("SMU2")]
    public partial class ScholarsModernUpgradeLvl2Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Scholars Modern Upgrade 2");

        public ScholarsModernUpgradeLvl2Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.70f) { }
    }

    [Serialized]
    [LocDisplayName("Scholars Modern Upgrade 3")]
    [LocDescription(
        "SMU3, A thinking Econian's Modern Upgrade that increases crafting efficiency, 5% better than a MU3."
    )]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true)]
    [Tag("Upgrade")]
    [Tag("ModernUpgrade")]
    [Tag("ScholarsUpgrade")]
    [Tag("SMU3")]
    public partial class ScholarsModernUpgradeLvl3Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Scholars Modern Upgrade 3");

        public ScholarsModernUpgradeLvl3Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.55f) { }
    }

    [Serialized]
    [LocDisplayName("Scholars Modern Upgrade 4")]
    [LocDescription(
        "SMU4, A thinking Econian's Modern Upgrade that increases crafting efficiency, as good as a MU5 (specialized), but more flexible."
    )]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true)]
    [Tag("Upgrade")]
    [Tag("ModernUpgrade")]
    [Tag("ScholarsUpgrade")]
    [Tag("SMU4")]
    public partial class ScholarsModernUpgradeLvl4Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Scholars Modern Upgrade 4");

        public ScholarsModernUpgradeLvl4Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.50f) { }
    }

    [RequiresSkill(typeof(LibrarianSkill), 6)]
    public partial class ScholarsModernUpgradeLvl1Recipe : RecipeFamily
    {
        public ScholarsModernUpgradeLvl1Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ScholarsModernUpgradeLvl1",
                displayName: Localizer.DoStr("Scholars Modern Upgrade 1"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ModernUpgradeLvl1Item), 1, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ScholarsModernUpgradeLvl1Item>(),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 30;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(LibrarianSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ScholarsModernUpgradeLvl1Recipe),
                start: 2,
                skillType: typeof(LibrarianSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Scholars Modern Upgrade 1"),
                recipeType: typeof(ScholarsModernUpgradeLvl1Recipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(LibrarianSkill), 6)]
    public partial class ScholarsModernUpgradeLvl2Recipe : RecipeFamily
    {
        public ScholarsModernUpgradeLvl2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ScholarsModernUpgradeLvl2",
                displayName: Localizer.DoStr("Scholars Modern Upgrade 2"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ModernUpgradeLvl1Item), 1, true),
                    new IngredientElement(typeof(ScholarsModernUpgradeLvl1Item), 1, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ScholarsModernUpgradeLvl2Item>(),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 30;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(LibrarianSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ScholarsModernUpgradeLvl2Recipe),
                start: 2,
                skillType: typeof(LibrarianSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Scholars Modern Upgrade 2"),
                recipeType: typeof(ScholarsModernUpgradeLvl2Recipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(LibrarianSkill), 6)]
    public partial class ScholarsModernUpgradeLvl3Recipe : RecipeFamily
    {
        public ScholarsModernUpgradeLvl3Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ScholarsModernUpgradeLvl3",
                displayName: Localizer.DoStr("Scholars Modern Upgrade 3"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ModernUpgradeLvl2Item), 1, true),
                    new IngredientElement(typeof(ScholarsModernUpgradeLvl2Item), 1, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ScholarsModernUpgradeLvl3Item>(),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 30;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(LibrarianSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ScholarsModernUpgradeLvl3Recipe),
                start: 2,
                skillType: typeof(LibrarianSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Scholars Modern Upgrade 3"),
                recipeType: typeof(ScholarsModernUpgradeLvl3Recipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipeFamily: this);
        }
    }

    [RequiresSkill(typeof(LibrarianSkill), 6)]
    public partial class ScholarsModernUpgradeLvl4Recipe : RecipeFamily
    {
        public ScholarsModernUpgradeLvl4Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ScholarsModernUpgradeLvl4",
                displayName: Localizer.DoStr("Scholars Modern Upgrade 4"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ModernUpgradeLvl3Item), 1, true),
                    new IngredientElement(typeof(ScholarsModernUpgradeLvl3Item), 1, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ScholarsModernUpgradeLvl4Item>(),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 30;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(LibrarianSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ScholarsModernUpgradeLvl4Recipe),
                start: 2,
                skillType: typeof(LibrarianSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Scholars Modern Upgrade 4"),
                recipeType: typeof(ScholarsModernUpgradeLvl4Recipe)
            );
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipeFamily: this);
        }
    }
}
