# Copilot Instructions for RimWorld Mod: Harvest When Butchering

## Mod Overview and Purpose

**Mod Name**: Harvest When Butchering  
**Description**: This RimWorld mod enhances the butchering process by automatically triggering the harvesting of resources from animals when they are butchered. It aims to streamline the process of gathering valuable animal resources, ensuring that players do not miss out on potential materials.

**Purpose**: The primary goal of this mod is to optimize resource management when butchering animals, particularly focusing on retrieving every possible harvestable material from dead animals. This is especially useful for animals that may explode on death, often seen when using compatible mods like BoomMod Expanded.

## Key Features and Systems

- **Automatic Resource Harvesting**: The mod adds functionality to the butchering process, ensuring all harvestable resources are collected.
- **Compatibility with Exploding Animals**: Works seamlessly with other mods that alter animal behavior upon death (e.g., BoomMod Expanded).
- **Configurable Yield Settings**: Introduces a setting that allows players to adjust the amount of resources harvested from wild animals, providing flexibility in gameplay.

## Coding Patterns and Conventions

- **Class and Method Organization**: The structure of the mod’s C# code is organized with clear class separation. Each class follows the single responsibility principle, enhancing maintainability and readability.
- **Internal and Public Modifiers**: Use of `internal` modifiers in classes like `HarvestWhenButcheringMod` and `HarvestWhenButcheringSettings` for encapsulation, while `public` is used for externally accessible components in `Main` and `Pawn_ButcherProducts`.

## XML Integration

- The mod does not explicitly use XML in the provided files but maintains integration compatibility with RimWorld’s XML-based definitions for mod settings and configurations. It's crucial to ensure any XML configuration follows RimWorld's schema and structure.

## Harmony Patching

- **Pawn_ButcherProducts**: This class likely uses Harmony patches to modify or extend the existing butchering methods in RimWorld. Harmony is a key tool for injecting code into existing methods without altering the original game files.
- For Copilot, focus should be on understanding the necessary parts to patch, including method signatures and return types relevant to butchering operations within RimWorld's codebase.

## Suggestions for Copilot

1. **Refactor Method Suggestions**: Recommend ensuring extensible method signatures and clear logic separation within methods, especially concerning butchering and resource calculation logic.
2. **Predictive Completion**: Aim for suggesting complete blocks of Harmony patching code tailored to identify and modify butchering processes.
3. **Adaptive Integration**: Suggest compatibility snippets for integrating with external mods, especially those altering animal death behaviors.
4. **Settings and Balance Logic**: Encourage suggestions around config file handling and settings management to adjust harvested resources.
5. **Debugging Assistance**: Provide hints or auto-completions for logging and debugging setups to track mod behavior accurately during runtime.

By following these guidelines, Copilot can become a more effective tool in assisting with the development and enhancement of the "Harvest When Butchering" mod, ensuring seamless integration with RimWorld and other mods.
