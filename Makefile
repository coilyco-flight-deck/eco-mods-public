DEFAULT_GOAL := help

.PHONY: help build copy-assets zip-assets push-asset bunwulf-agricultural bunwulf-structural

help: ## Print this help.
	@awk 'BEGIN {FS = ":.*?## "} /^[a-zA-Z_-]+:.*?## / {printf "%-25s %s\n", $$1, $$2}' $(MAKEFILE_LIST)

build: ## Type-check all mods against Eco.ReferenceAssemblies via dotnet build.
	dotnet build --nologo

copy-assets: ## Refresh the assets folder from eco-mods-assets. Args - branch=<release-branch>.
	@uv run python scripts/mods.py copy-assets $(if $(branch),--branch=$(branch))

zip-assets: ## Zip Mods/UserCode/<name> into <name>.zip. Args - mod=<Name>.
	@test -n "$(mod)" || { echo "mod=<Name> is required" >&2; exit 2; }
	@rm -f $(mod).zip
	@rm -rf ./Mods/UserCode/$(mod)/bin ./Mods/UserCode/$(mod)/obj
	zip -r $(mod).zip ./Mods/UserCode/$(mod)

push-asset: zip-assets ## Zip a UserCode mod, scp it to kai-server, unzip into the EcoServer tree. Args - mod=<Name>.
	coily gaming eco mod push --src $(mod).zip

bunwulf-agricultural: ## Regenerate BunWulfAgricultural plants from templates.
	@uv run python scripts/mods.py bunwulf-agricultural

bunwulf-structural: ## Regenerate BunWulfStructural recipes from recipes.yml.
	@uv run python scripts/mods.py bunwulf-structural
