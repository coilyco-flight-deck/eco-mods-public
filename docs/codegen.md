# Codegen and design notes

Detail offloaded from [AGENTS.md](../AGENTS.md) to keep that file under its size cap.

## Codegen

A significant portion of code is generated, not hand-written:

- `main.cs` reads Eco core files, transforms via regex into Librarian profession variants, outputs to `Mods/UserCode/BunWulfEducational/`.
- `scripts/mods.py` + `util.py` + `recipes.yml` + `templates/` handle agricultural codegen and recipe transformations.
- Do not hand-edit generated files in `BunWulfEducational/Recipes/Tech/` or `BunWulfEducational/Recipes/Item/`. Edit `main.cs`.
- Plant files in `BunWulfAgricultural/Plant/` come from `templates/plant.template`.

## Conventions

Per-mod subdirs: `Plant/` (one .cs per species), `Recipes/` (one .cs per family), `WorldObject/`, `Tech/`, `Register.cs`.

Each mod has its own namespace. Don't mix. Major mods implement `IModInit` with `Register()` providing `ModName`, `ModDescription`, `ModDisplayName`. Recipes inherit `RecipeFamily`, use `[RequiresSkill]`, define `IngredientElement`/`CraftingElement`, include `ExperienceOnCraft`. User-facing strings via `Localizer.DoStr()`.

## Key design decisions

- Biochemist is intentionally slower than oil drilling: sustainable alternative, not direct replacement.
- MinesQuarries provides infinite resources but with high calorie costs, long craft times, waste rock.
- Librarian crafts any skill book at basic proficiency, generated from core files to stay in sync.
