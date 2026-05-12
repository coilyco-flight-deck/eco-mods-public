[![Eco by Strange Loop Games](https://cdn.cloudflare.steamstatic.com/steam/apps/382310/header.jpg)](https://store.steampowered.com/app/382310/Eco/)

<sub>Banner: Steam header for Eco by [Strange Loop Games](https://strangeloopgames.com/). Used here for attribution; not my artwork.</sub>

# eco-mods-public

A collection of public C# gameplay mods for [Eco](https://play.eco/), Strange Loop Games' multiplayer survival and simulation game. The mods add new professions, recipes, crafting stations, farming extensions, environmental systems, and mining and quarrying mechanics. Everything targets `Eco.ReferenceAssemblies` (v0.13.0-beta as of Cycle 13) and builds with `dotnet build`; see [AGENTS.md](AGENTS.md) for the full project layout, code-generation notes, and conventions.

The mods fall into a few clusters. The **BunWulf** family (Agricultural, Biochemical, Educational, HardwareCo) adds extended farming and crop variety, a plant-based Biochemist profession as an alternative to petrochemical oil, a Librarian profession that can craft skill books across every discipline, and a handful of specialty hardware items. Standalone mods include **DirectCarbonCapture** (late-game atmospheric CO2 mitigation), **EcoNil** (weather and moisture mechanics), **MinesQuarries** (infinite but expensive mining and quarrying operations, designed around vertical integration), **ShopBoat** (a mobile shop world object), and **WorldCounter** (world statistics tracking). Released builds are distributed as `.zip` files at the repo root; AGENTS.md documents the asset packaging and deploy workflow.

See also [eco-cycle-prep](https://github.com/coilysiren/eco-cycle-prep) for cycle-prep automation (worldgen rolls, Discord announcements, mod sync). The official modkit lives at [StrangeLoopGames/EcoModKit](https://github.com/StrangeLoopGames/EcoModKit), modding docs are at [docs.play.eco](https://docs.play.eco/) and [wiki.play.eco/en/Modding](https://wiki.play.eco/en/Modding), and other community mods are catalogued on [mod.io](https://mod.io/g/eco).

## Commands

Dev commands are declared in [`.coily/coily.yaml`](.coily/coily.yaml). Run them as `coily exec <verb>`.
