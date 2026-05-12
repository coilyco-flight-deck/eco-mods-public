# Agent instructions

See `../AGENTS.md` for workspace-level conventions (git workflow, test/lint autonomy, readonly ops, writing voice, deploy knowledge). This file covers only what's specific to this repo.

---

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
- **Do not hand-edit generated files** in `BunWulfEducational/Recipes/Tech/` or `BunWulfEducational/Recipes/Item/` - modify `main.cs` instead.
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

- `BunWulfModsPublic` - CLI entry point / main.cs
- `BunWulfBioChemical` - Biochemist mod
- `BunWulfEducational` - Librarian mod
- `Eco.Mods.Organisms` - Plant/organism modifications
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

- **Biochemist** is intentionally slower than oil drilling - it's a sustainable alternative, not a direct replacement.
- **MinesQuarries** provides infinite resources but with high calorie costs, long craft times, and waste rock - designed to require economic planning and vertical integration.
- **Librarian** can craft any skill book at basic proficiency - generated from core Eco files to stay in sync with game updates.
- Mods are distributed as `.zip` files that users extract to their server root.

## Third-party source code reference

The `../Eco/` sibling directory contains vendor-provided game source. Use it as read-only background for type signatures, API shapes, and reproducing vanilla formulas, but do not paste, quote, or link snippets of it in anything that leaves this repo: commit messages, PR descriptions, public READMEs, issues, Discord posts, or other published docs. Describe game behavior in your own words and use fresh examples rather than lifting source prose.

## Server communications

When a change from this repo reaches the live Sirens Eco server, post to the Sirens Discord. The tooling lives in `../eco-cycle-prep/` (never reimplement locally):

- Patch note to `#general-public`: `cd ../eco-cycle-prep && inv discord-post --channel=general-public --from-file=<path-to-body.md>`
- Pre-restart heads-up to `#eco-status`: `cd ../eco-cycle-prep && inv restart-notice [--reason="<short reason>"]`

For the voice / tone rules, the when-to-post rules, and the private voice guide pointer, consult [`../eco-cycle-prep/AGENTS.md`](../eco-cycle-prep/AGENTS.md). Do not inline curl snippets or channel IDs here.

### Deploy triggers for eco-mods-public

- `invoke push-asset --mod=<Name>` from this repo (scp + unzip into `/home/kai/Steam/steamapps/common/EcoServer/Mods/UserCode/`).
- `inv mods-sync` in eco-cycle-prep, when it picks up a change from here.
- A mod.io release that Sirens then pulls.
- Any direct ssh edit to `/home/kai/Steam/steamapps/common/EcoServer/Mods/UserCode/<Mod>/` on kai-server.

A plain commit to `main` is not a deploy trigger by itself. Post when the bits actually reach the Sirens server, in the same turn as the deploy. Do not describe the post as a backfill, delayed notice, or after-the-fact summary.

### Link back to the commit

This repo is **public** (`github.com/coilysiren/eco-mods-public`). When a patch note describes a change whose source landed here, include a link to the relevant commit (or the compare view for multi-commit changes) in the message body. Players and outside contributors can then trace exactly what changed without reverse-engineering it from the patch-note prose.

Format: `https://github.com/coilysiren/eco-mods-public/commit/<short-sha>` (or `.../compare/<a>...<b>` for ranges). Paste above the sign-off line. Use the full URL so Discord renders a preview. If the change came from another public sibling repo, link its commit(s) instead (or in addition).

## Commands

Route every dev command through coily, which reads [`.coily/coily.yaml`](.coily/coily.yaml). The lockdown denies bare invocations of the underlying tools (`make`, `uv`, `python3`, etc.). Add new verbs to that file before invoking them.

## See also

- [README.md](README.md) - human-facing intro.
- [docs/FEATURES.md](docs/FEATURES.md) - inventory of what ships today.
- [.coily/coily.yaml](.coily/coily.yaml) - allowlisted commands. Agents route through coily, not bare `make` / `uv` / `python` / `npm` / `cargo` / `dotnet`.

Cross-reference convention from [coilysiren/coilyco-ai#313](https://github.com/coilysiren/coilyco-ai/issues/313).
