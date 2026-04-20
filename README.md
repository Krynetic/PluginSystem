## Krynetic Plugin System

Reference this package when creating plugins for Krynetic database

Example plugin that should be placed in same directory as Krynetic server executable, named **ExampleNameHere.Plugin.dll**:

```csharp
using Krynetic.Database.PluginSystem;

[module: PluginExport(typeof(HelloPlugin))]

[Plugin(
    "Hello",
    Description = "Example plugin that says hello",
    Tags = ["example"]
)]
public static partial class HelloPlugin
{
    [PluginFunction("Hello")]
    public static string Hello() => "Hello";
}

```