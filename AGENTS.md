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

## Patch notes on server deploys

Whenever a change from this repo reaches the live Sirens Eco server, post a patch note to the `#general-public` Discord channel in the Sirens server. Players there play multiple cycles and read patch notes carefully.

### When to post

Triggers specific to eco-mods-public:

- `invoke push-asset --mod=<Name>` from this repo (scp + unzip into `/home/kai/Steam/steamapps/common/EcoServer/Mods/UserCode/`).
- `inv mods-sync` in eco-cycle-prep, when it picks up a change from here.
- A mod.io release that Sirens then pulls.
- Any direct ssh edit to `/home/kai/Steam/steamapps/common/EcoServer/Mods/UserCode/<Mod>/` on kai-server.

A plain commit to `main` is not a deploy trigger by itself. Post when the bits actually reach the Sirens server. Post in real time, in the same turn as the deploy. Do not describe the post as a backfill, delayed notice, or after-the-fact summary. Write as if the change just landed.

### Audience and tone

Adult gamers on a small private Eco server. Highly engaged. They play multiple cycles and read patch notes carefully.

- Assume they know the game. Use skill names, tier numbers, recipe names, and mechanics directly. Do not re-explain what a "specialty" is.
- Patch-notes voice: mechanical and specific. Numbers over adjectives. "Carpentry now costs 2 stars (tier 2) + 1 per prior specialty" beats "specialty costs are more realistic now."
- No marketing hype ("we're excited to", "enjoy!", "huge update!"). No condescension ("don't worry if this sounds complicated.").
- Describe the before / after when it's a fix. Describe the new capability when it's a feature.
- No em-dashes. Use periods, commas, parens, or " - " for mid-sentence sidebars. Same rule Kai applies elsewhere.
- Under ~1500 characters so it fits in a single Discord message. Sign off with the repo + mod touched in brackets, e.g. `[eco-mods-public / BunWulfEducational]`.

### Sending the message

Channel ID is at SSM `/discord/channel/general-public`. Bot token is at `/sirens-echo/discord-bot-token` (distinct from `/eco/discord-bot-token`, which is DiscordLink's in-game bridge). Pull both from SSM each time. Do not hardcode.

```sh
# On Windows / Git Bash, prefix each aws call with MSYS_NO_PATHCONV=1. On Mac, drop it.
BOT_TOKEN=$(MSYS_NO_PATHCONV=1 aws ssm get-parameter --name /sirens-echo/discord-bot-token --with-decryption --query Parameter.Value --output text)
CHANNEL=$(MSYS_NO_PATHCONV=1 aws ssm get-parameter --name /discord/channel/general-public --with-decryption --query Parameter.Value --output text)
BODY=$(python -c 'import json,sys; print(json.dumps({"content": sys.stdin.read()}))' <<< 'YOUR MESSAGE BODY HERE')
curl -sS -H "Authorization: Bot $BOT_TOKEN" -H "Content-Type: application/json" -d "$BODY" "https://discord.com/api/v10/channels/$CHANNEL/messages"
```
