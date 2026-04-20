using System.Reflection;

namespace Krynetic.Database.PluginSystem;

[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Method)]
public class PluginFunctionAttribute(string name, params string[] aliases) : Attribute
{
    public string Name { get => name; }

    public string[] Aliases { get => aliases; }

    public bool Protected { get; set; }

    public string? DisabledReason { get; set; }
}

[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class PluginAttribute(string identifier) : Attribute
{
    public string Identifier { get; set; } = identifier;
    public string? Version { get; set; }
    public PluginLifecycle Stage { get; set; } = PluginLifecycle.Production;
    public LicenseTier Tier { get; set; } = LicenseTier.Community;
    public string Description { get; set; } = "";
    public string[] Tags { get; set; } = [];

    public int Order { get; set; }
}

/// <summary>
/// Improves boot performance, find assembly type directly instead of enumerating all assembly types
/// </summary>
[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Module, AllowMultiple = true)]
public class PluginExport(Type type) : Attribute
{
    public Type Type => type;
}

public enum PluginLifecycle
{
    Experimental = 0,
    Production = 1,
    Obsolete = 2
}

public enum LicenseTier
{
    Community = 0,
    Professional = 1,
    Enterprise = 2
}
