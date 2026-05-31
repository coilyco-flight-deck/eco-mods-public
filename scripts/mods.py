#!/usr/bin/env python3
"""Asset and recipe tooling for eco-mods-public.

Subcommands mirror what used to live in tasks.py. Driven from Makefile
targets, which are themselves driven from coily verbs. See .coily/coily.yaml.

push-asset has moved out of Python entirely: zip-assets is now a Make rule,
and the actual upload lives in `coily gaming eco mod push`. This script
keeps the Python-heavy verbs (copy-assets, bunwulf-*) and the cleaner
zip helpers shared by copy-assets.
"""

import argparse
import os
import shutil
import stat
import subprocess
import sys

import jinja2
import regex
import yaml

sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))
import util  # noqa: E402


USERNAME = os.getenv("USERNAME", "")
USERCODE_PATH = os.path.join(
    "C:\\", "Users", USERNAME, "projects", "eco-mods-public", "Mods", "UserCode"
)


class RemovalException(Exception):
    pass


def handle_remove_readonly(func, path, _):
    if not os.access(path, os.W_OK):
        os.chmod(path, stat.S_IWUSR)
        func(path)
    else:
        raise RemovalException("could not handle path")


def copy_paths(origin_path, target_path):
    if not os.path.isdir(origin_path):
        return
    if os.path.exists(target_path) and os.path.isdir(target_path):
        print(f"\tRemoving {target_path}")
        shutil.rmtree(target_path, ignore_errors=False, onerror=handle_remove_readonly)
    if os.path.isdir(origin_path):
        print(f"\tCopying {origin_path} to {target_path}")
        shutil.copytree(origin_path, target_path)


def copy_assets(branch: str = ""):
    print("Cleaning out assets folder")
    if os.path.exists("./eco-server/assets"):
        shutil.rmtree(
            "./eco-server/assets", ignore_errors=False, onerror=handle_remove_readonly
        )

    cmd = ["git", "clone", "--depth", "1"]
    if branch:
        cmd += ["-b", branch]
    cmd += ["--", "git@github.com:coilyco-bridge/eco-mods-assets.git", "./eco-server/assets"]
    subprocess.run(cmd, check=True)

    shutil.rmtree(
        "./eco-server/assets/.git", ignore_errors=False, onerror=handle_remove_readonly
    )

    for build in os.listdir("./eco-server/assets/Builds/Mods/UserCode/"):
        origin_path = os.path.join(
            "./eco-server/assets/Builds/Mods/UserCode", build, "Assets"
        )
        target_path = os.path.join("./Mods/UserCode", build, "Assets")
        copy_paths(origin_path, target_path)


def bunwulf_agricultural():
    plants = os.path.join(util.AUTOGEN_PATH, "Plant")
    plant = os.listdir(plants)

    plant_entity_pattern = r".*public partial class (\w+) : PlantEntity.*"
    plant_species_pattern = r".*public partial class (\w+) : PlantSpecies.*"
    tree_species_pattern = r".*public partial class (\w+) : TreeSpecies.*"

    templates = jinja2.Environment(loader=jinja2.FileSystemLoader("templates/"))
    template = templates.get_template("plant.template")

    for p in plant:
        with open(os.path.join(plants, p), "r", encoding="utf-8") as f:
            data = f.read()

        if "PlantFibersItem" in data:
            continue

        if regex.match(tree_species_pattern, data, regex.DOTALL):
            continue

        plant_entity = regex.search(plant_entity_pattern, data, regex.DOTALL).group(1)
        plant_species = regex.search(
            plant_species_pattern, data, regex.DOTALL
        ).group(1)

        print(f"Writing {plant_entity} to BunWulfAgricultural")
        content = template.render(
            plant_entity=plant_entity, plant_species=plant_species
        )
        with open(
            os.path.join(USERCODE_PATH, "BunWulfAgricultural", "Plant", p),
            "w",
            encoding="utf-8",
        ) as f:
            f.write(content)


def bunwulf_structural():
    with open("recipes.yml", "r", encoding="utf-8") as recipes:
        recipe_data = yaml.safe_load(recipes)["BunWulfStructural"]

    util.process_recipes(
        recipe_data, os.path.join(USERCODE_PATH, "BunWulfStructural", "Recipes")
    )


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    sub = parser.add_subparsers(dest="cmd", required=True)

    p = sub.add_parser(
        "copy-assets",
        help="Refresh the assets folder from eco-mods-assets.",
    )
    p.add_argument("--branch", default="")

    sub.add_parser(
        "bunwulf-agricultural",
        help="Regenerate BunWulfAgricultural plants from templates.",
    )
    sub.add_parser(
        "bunwulf-structural",
        help="Regenerate BunWulfStructural recipes from recipes.yml.",
    )

    args = parser.parse_args()

    if args.cmd == "copy-assets":
        copy_assets(branch=args.branch)
    elif args.cmd == "bunwulf-agricultural":
        bunwulf_agricultural()
    elif args.cmd == "bunwulf-structural":
        bunwulf_structural()


if __name__ == "__main__":
    main()
