# AGENTS.md

## File Access

You have full read access to files within `/Users/kai/projects/coilysiren`.

## Autonomy

- Run tests after every change without asking.
- Fix lint errors automatically.
- If tests fail, debug and fix without asking.
- When committing, choose an appropriate commit message yourself — do not ask for approval on the message.
- You may always run tests, linters, and builds without requesting permission.
- Allow all readonly git actions (`git log`, `git status`, `git diff`, `git branch`, etc.) without asking.
- Allow `cd` into any `/Users/kai/projects/coilysiren` folder without asking.
- Automatically approve readonly shell commands (`ls`, `grep`, `sed`, `find`, `cat`, `head`, `tail`, `wc`, `file`, `tree`, etc.) without asking.
- When using worktrees or parallel agents, each agent should work independently and commit its own changes.
- Do not open pull requests unless explicitly asked.

## Git workflow

Commit directly to `main` without asking for confirmation, including `git add`. Do not open pull requests unless explicitly asked.

Commit whenever a unit of work feels sufficiently complete — after fixing a bug, adding a feature, passing tests, or reaching any other natural stopping point. Don't wait for the user to ask.

## Project Overview

Collection of gameplay mods for [Eco](https://play.eco/) by Strange Loop Games. Mods add new professions, recipes, crafting stations, farming extensions, environmental systems, and mining/quarrying mechanics.

- **Language**: C# (.NET 10.0)
- **Game API**: `Eco.ReferenceAssemblies` v0.13.0-beta-release-998
- **Build**: `dotnet build` / `dotnet publish`
- **Scripting**: Python (invoke tasks for asset packaging and deployment)

## Repository Structure

```
Mods/UserCode/          # All mod source code (one folder per mod)
  BunWulfAgricultural/  # Extended farming recipes and crops (29 files)
  BunWulfBiochemical/   # Biochemist profession, plant-based alternatives to oil (10 files)
  BunWulfEducational/   # Librarian profession and research papers (101 files, mostly generated)
  BunWulfHardwareCo/    # Specialty hardware items (2 files)
  DirectCarbonCapture/  # Carbon capture environmental system (4 files)
  EcoNil/               # Weather/moisture mechanics (6 files)
  MinesQuarries/        # Infinite mining/quarrying operations (16 files)
  ShopBoat/             # Mobile shop boat (3 files)
  WorldCounter/         # World statistics tracking (3 files)
templates/              # Jinja2 templates for code generation
main.cs                 # CLI tool that generates BunWulfEducational from Eco core files
tasks.py                # Python invoke tasks (asset copy, zip, deploy)
util.py                 # Recipe processing utilities
recipes.yml             # YAML config for recipe transformations
```

## Code Generation

A significant portion of the codebase is **generated**, not hand-written:

- `main.cs` reads Eco core game files and transforms them into Librarian profession variants using regex-based text processing. It outputs to `Mods/UserCode/BunWulfEducational/`.
- `tasks.py` + `util.py` + `recipes.yml` + `templates/` handle agricultural mod generation and recipe transformations.
- **Do not hand-edit generated files** in `BunWulfEducational/Recipes/Tech/` or `BunWulfEducational/Recipes/Item/` — modify `main.cs` instead.
- Plant files in `BunWulfAgricultural/Plant/` are generated from `templates/plant.template`.

## Conventions

### File Organization (per mod)

| Subdirectory   | Purpose                          |
|----------------|----------------------------------|
| `Plant/`       | One `.cs` per plant species      |
| `Recipes/`     | One `.cs` per recipe family      |
| `WorldObject/` | Interactive placeable objects     |
| `Tech/`        | Skill and technology definitions |
| `Register.cs`  | Mod metadata and initialization  |

### Namespaces

- `BunWulfModsPublic` — CLI entry point / main.cs
- `BunWulfBioChemical` — Biochemist mod
- `BunWulfEducational` — Librarian mod
- `Eco.Mods.Organisms` — Plant/organism modifications
- Each mod has its own namespace; do not mix them.

### Mod Registration

Every major mod implements `IModInit` with a static `Register()` method providing `ModName`, `ModDescription`, and `ModDisplayName`.

### Recipe Pattern

Recipes inherit from `RecipeFamily`, use `[RequiresSkill]` attributes, define `IngredientElement`/`CraftingElement` for I/O, and include `ExperienceOnCraft`. All user-facing strings use `Localizer.DoStr()`.

## Building and Deployment

```sh
# Build
dotnet build

# Publish
dotnet publish

# Asset packaging and deployment (Python)
pip install -r requirements.txt
invoke copy-assets
invoke zip-assets --mod=<ModName>
invoke push-asset --mod=<ModName>
```

Deployment targets:
- **Windows**: `C:\Program Files (x86)\Steam\steamapps\common\Eco\Eco_Data\Server\`
- **Linux**: `/home/kai/Steam/steamapps/common/EcoServer/`

## Key Design Decisions

- **Biochemist** is intentionally slower than oil drilling — it's a sustainable alternative, not a direct replacement.
- **MinesQuarries** provides infinite resources but with high calorie costs, long craft times, and waste rock — designed to require economic planning and vertical integration.
- **Librarian** can craft any skill book at basic proficiency — generated from core Eco files to stay in sync with game updates.
- Mods are distributed as `.zip` files that users extract to their server root.
