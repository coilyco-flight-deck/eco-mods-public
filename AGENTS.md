# Agent instructions

Workspace conventions load globally via `~/.claude/CLAUDE.md` -> `agentic-os-kai/AGENTS.md`. This file covers only what is specific to this repo.

## Scope

Public collection of gameplay mods for [Eco](https://play.eco/). C# (.NET 10.0) against `Eco.ReferenceAssemblies` v0.13.0-beta-release-998. Mods add professions, recipes, crafting stations, farming, environmental systems, mining/quarrying.

## Project shape

```
Mods/UserCode/<ModName>/   # one folder per mod
templates/                  # Jinja2 templates for codegen
main.cs                     # CLI that generates BunWulfEducational from Eco core
tasks.py, util.py           # Python invoke tasks + recipe utilities
recipes.yml                 # YAML config for recipe transformations
```

Mods: BunWulfAgricultural (farming), BunWulfBiochemical (biochemist, plant-based oil alternative), BunWulfEducational (librarian + research papers, mostly generated), BunWulfHardwareCo, DirectCarbonCapture, EcoNil (weather/moisture), MinesQuarries (infinite mining with high calorie + waste), ShopBoat, WorldCounter.

Codegen, conventions, and design rationale live in [docs/codegen.md](docs/codegen.md). A significant portion of code is generated, not hand-written.

## Repo boundaries

The `../Eco/` sibling has vendor-provided game source. Background-only. Do not paste, quote, or link snippets in anything that leaves this repo. Describe behavior in your own words.

## Commands

Route dev verbs through `ward`, which reads [.ward/ward.yaml](.ward/ward.yaml) (run verbs with `ward exec <verb>`).

```sh
ward exec build
ward exec copy-assets
ward exec zip-assets mod=<ModName>
ward exec push-asset mod=<ModName>
```

## Validation

`ward exec build` type-checks all mods against `Eco.ReferenceAssemblies`. Run `pre-commit run --all-files` before pushing. Run tests, linters, and builds without asking. Fix failures. Never use `--no-verify`.

## Safety

Do not hand-edit generated files in `BunWulfEducational/Recipes/Tech/` or `BunWulfEducational/Recipes/Item/`. Edit `main.cs`. Plant files in `BunWulfAgricultural/Plant/` come from `templates/plant.template`. Keep vendor source out of public artifacts.

## Cross-repo contracts

Patch notes + restart heads-ups delegate to `../eco-cycle-prep/`:

- `cd ../eco-cycle-prep && coily discord-post --channel=general-public --from-file=<path>`
- `cd ../eco-cycle-prep && coily restart-notice [--reason="..."]`

Voice rules in [`../eco-cycle-prep/AGENTS.md`](../eco-cycle-prep/AGENTS.md). Posting is gated to actual deploys (`push-asset`, `mods-sync`, mod.io release, direct ssh edit), not bare main commits.

## Release

Targets: Windows `C:\Program Files (x86)\Steam\steamapps\common\Eco\Eco_Data\Server\`, Linux `/home/kai/Steam/steamapps/common/EcoServer/`. Mods distribute as `.zip` files users extract to their server root via `ward exec push-asset`.

## Agent rules

Commit to main directly, push after each commit, no PRs unless asked.

Public repo. Link back to the commit (or compare view) in each patch note. Format: `https://github.com/coilyco-flight-deck/eco-mods-public/commit/<short-sha>`. Paste above the sign-off so Discord renders a preview.

## See also

- [README.md](README.md), [docs/FEATURES.md](docs/FEATURES.md), [docs/codegen.md](docs/codegen.md), [.ward/ward.yaml](.ward/ward.yaml) - allowlisted commands (`ward exec`). ([.coily/coily.yaml](.coily/coily.yaml) retained during the .coily -> .ward migration window.)

Cross-reference convention from [coilysiren/agentic-os#59](https://github.com/coilyco-flight-deck/agentic-os/issues/59).
