# Agent instructions

See `../AGENTS.md` for workspace-level conventions. This file covers only what's specific to this repo.

---

## Project

Public collection of gameplay mods for [Eco](https://play.eco/). C# (.NET 10.0) against `Eco.ReferenceAssemblies` v0.13.0-beta-release-998. Mods add professions, recipes, crafting stations, farming, environmental systems, mining/quarrying.

Build: `coily build` (or `dotnet build` / `dotnet publish`). Scripting: Python via `coily` for asset packaging and recipe codegen.

## Layout

```
Mods/UserCode/<ModName>/   # one folder per mod
templates/                  # Jinja2 templates for codegen
main.cs                     # CLI that generates BunWulfEducational from Eco core
tasks.py, util.py           # Python invoke tasks + recipe utilities
recipes.yml                 # YAML config for recipe transformations
```

Mods: BunWulfAgricultural (farming), BunWulfBiochemical (biochemist profession, plant-based oil alternative), BunWulfEducational (librarian profession + research papers, mostly generated), BunWulfHardwareCo, DirectCarbonCapture, EcoNil (weather/moisture), MinesQuarries (infinite mining with high calorie + waste), ShopBoat, WorldCounter.

## Codegen

A significant portion of code is generated, not hand-written:

- `main.cs` reads Eco core files, transforms via regex into Librarian profession variants, outputs to `Mods/UserCode/BunWulfEducational/`.
- `scripts/mods.py` + `util.py` + `recipes.yml` + `templates/` handle agricultural codegen and recipe transformations.
- **Do not hand-edit generated files** in `BunWulfEducational/Recipes/Tech/` or `BunWulfEducational/Recipes/Item/`. Edit `main.cs`.
- Plant files in `BunWulfAgricultural/Plant/` come from `templates/plant.template`.

## Conventions

Per-mod subdirs: `Plant/` (one .cs per species), `Recipes/` (one .cs per family), `WorldObject/`, `Tech/`, `Register.cs`.

Each mod has its own namespace; don't mix. Major mods implement `IModInit` with `Register()` providing `ModName`, `ModDescription`, `ModDisplayName`. Recipes inherit `RecipeFamily`, use `[RequiresSkill]`, define `IngredientElement`/`CraftingElement`, include `ExperienceOnCraft`. User-facing strings via `Localizer.DoStr()`.

## Build + deploy

```sh
coily build
coily copy-assets
coily zip-assets mod=<ModName>
coily push-asset mod=<ModName>
```

Targets: Windows `C:\Program Files (x86)\Steam\steamapps\common\Eco\Eco_Data\Server\`, Linux `/home/kai/Steam/steamapps/common/EcoServer/`. Mods distribute as `.zip` files users extract to their server root.

## Key design decisions

- Biochemist is intentionally slower than oil drilling: sustainable alternative, not direct replacement.
- MinesQuarries provides infinite resources but with high calorie costs, long craft times, waste rock.
- Librarian crafts any skill book at basic proficiency, generated from core files to stay in sync.

## Vendor source reference

The `../Eco/` sibling has vendor-provided game source. Background-only. Do not paste, quote, or link snippets in anything that leaves this repo. Describe behavior in your own words.

## Server communications

Patch notes + restart heads-ups delegate to `../eco-cycle-prep/`:

- `cd ../eco-cycle-prep && coily discord-post --channel=general-public --from-file=<path>`
- `cd ../eco-cycle-prep && coily restart-notice [--reason="..."]`

Voice rules in [`../eco-cycle-prep/AGENTS.md`](../eco-cycle-prep/AGENTS.md). Posting is gated to actual deploys (`push-asset`, `mods-sync`, mod.io release, direct ssh edit), not bare main commits.

**Public repo** - link back to the commit (or compare view) in each patch note. Format: `https://github.com/coilysiren/eco-mods-public/commit/<short-sha>`. Paste above the sign-off so Discord renders a preview.

## See also

- [README.md](README.md), [docs/FEATURES.md](docs/FEATURES.md), [.coily/coily.yaml](.coily/coily.yaml).

Cross-reference convention from [coilysiren/agentic-os#59](https://github.com/coilysiren/agentic-os/issues/59).
