# GitHub Copilot Instructions for Harvest When Butchering Mod

## Mod Overview and Purpose
The "Harvest When Butchering" mod is designed to enhance the butchering process in RimWorld by automatically triggering the harvesting of resources from animals when they are butchered. This adds an additional layer of efficiency and resource management, allowing players to maximize their yields from animals without extra labor.

The mod also integrates with other mods like BoomMod Expanded to handle animals that explode on death, ensuring that resources are still harvested properly. Additionally, a setting is provided to adjust the amount of resources gained from butchered wild animals.

**Idea by:** DisKorruptd  
**Author:** Mlie  
**PackageId:** Mlie.HarvestWhenButchering

## Key Features and Systems
- **Automatic Harvesting:** Resources are harvested automatically when butchering animals, eliminating the need for separate harvest tasks.
- **Mod Compatibility:** Works in conjunction with mods that affect animal behavior on death, such as explosive animals via BoomMod Expanded.
- **Configurable Settings:** Allows players to adjust the amount of resources gained from butchering wild animals, providing gameplay customization.

## Coding Patterns and Conventions
- **File Structure:** 
  - The source code is organized into four main C# files: `HarvestWhenButcheringMod.cs`, `HarvestWhenButcheringSettings.cs`, `Main.cs`, and `Pawn_ButcherProducts.cs`.
- **Namespaces and Classes:** 
  - Classes are organized under a clear and consistent namespace, `HarvestWhenButchering`.
  - Each class has a specific responsibility, adhering to the Single Responsibility Principle.
- **Coding Conventions:** 
  - The project follows C# conventions, including PascalCase for class names and methods.
  - Methods are clearly named to indicate their purpose, e.g., `DoSettingsWindowContents` for UI operations.
  
## XML Integration
While this mod project does not currently utilize XML files for definitions or other purposes, future expansions could involve XML integration for additional settings or moddability.

## Harmony Patching
- **Dependency:** The mod relies on the Harmony library for runtime method patching to alter or extend the behavior of base game methods.
- **Harmony Usage Example:** 
  - The `Pawn_ButcherProducts` class uses a postfix patch to append resource gathering functionality to the butchering process.
  - Example Patch:
    csharp
    [HarmonyPatch(typeof(Pawn_ButcherProducts), nameof(Pawn_ButcherProducts.Postfix))]
    public static void gather(Pawn pawn, ThingWithComps thing)
    {
        // Custom logic for resource harvesting
    }
      

## Suggestions for Copilot
1. **Auto-complete Help:** Use Copilot to suggest boilerplate code for Harmony patches, reducing setup time.
2. **Settings Management:** Assist with generating code for settings serialization and deserialization using the `ExposeData` method.
3. **Debugging Assistance:** Provide suggestions for logging within Harmony patches to help with debugging and performance analysis.
4. **UI Code Suggestions:** Offer layout and UI element handling when implementing settings interfaces, such as the `DoSettingsWindowContents` method.
5. **Error Prevention:** Proactively suggest best practices to prevent common pitfalls in Harmony patching, such as correctly handling pawn references.

By following these guidelines and leveraging GitHub Copilot effectively, developers can ensure efficient development and maintenance of the "Harvest When Butchering" mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

