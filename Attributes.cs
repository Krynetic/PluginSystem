using System.Reflection;

namespace Krynetic.Database.PluginSystem;

/// <summary>
/// Marks a method as a plugin function and defines its public name and aliases
/// </summary>
[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Method)]
public class PluginFunctionAttribute(string name, params string[] aliases) : Attribute
{
    /// <summary>
    /// Gets the public name of the plugin function.
    /// </summary>
    public string Name { get => name; }

    /// <summary>
    /// Gets the alternate names that can be used to reference the plugin function.
    /// </summary>
    public string[] Aliases { get => aliases; }

    /// <summary>
    /// Gets or sets a value indicating whether the plugin function is protected and may require elevated access.
    /// </summary>
    public bool Protected { get; set; }

    /// <summary>
    /// Gets or sets the reason why the plugin function is disabled
    /// </summary>
    public string? DisabledReason { get; set; }
}

/// <summary>
/// Declares a class as a plugin
/// </summary>
[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class PluginAttribute(string identifier) : Attribute
{
    /// <summary>
    /// Gets or sets the unique identifier of the plugin.
    /// </summary>
    public string Identifier { get; set; } = identifier;

    /// <summary>
    /// Gets or sets the version of the plugin.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Gets or sets the lifecycle stage of the plugin.
    /// </summary>
    public PluginLifecycle Stage { get; set; } = PluginLifecycle.Production;

    /// <summary>
    /// Gets or sets the license tier required for the plugin.
    /// </summary>
    public LicenseTier Tier { get; set; } = LicenseTier.Community;

    /// <summary>
    /// Gets or sets a human-readable description of the plugin.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Gets or sets the tags associated with the plugin.
    /// </summary>
    public string[] Tags { get; set; } = [];

    /// <summary>
    /// Gets or sets the ordering value used when multiple plugins are processed.
    /// </summary>
    public int Order { get; set; }
}

/// <summary>
/// Exports a plugin type at the module level to improve boot performance by 
/// allowing direct type discovery instead of enumerating all assembly types.
/// </summary>
[Obfuscation(Exclude = true)]
[AttributeUsage(AttributeTargets.Module, AllowMultiple = true)]
public class PluginExport(Type type) : Attribute
{
    /// <summary>
    /// Gets the exported plugin type.
    /// </summary>
    public Type Type => type;
}

/// <summary>
/// Represents the lifecycle stage of a plugin.
/// </summary>
public enum PluginLifecycle
{
    /// <summary>
    /// The plugin is experimental and may change or be unstable.
    /// </summary>
    Experimental = 0,

    /// <summary>
    /// The plugin is production-ready and intended for normal use.
    /// </summary>
    Production = 1,

    /// <summary>
    /// The plugin is obsolete and should no longer be used.
    /// </summary>
    Obsolete = 2
}

/// <summary>
/// Represents the license tier associated with a plugin.
/// </summary>
public enum LicenseTier
{
    /// <summary>
    /// The plugin is available in the community tier.
    /// </summary>
    Community = 0,

    /// <summary>
    /// The plugin is available in the professional tier.
    /// </summary>
    Professional = 1,

    /// <summary>
    /// The plugin is available in the enterprise tier.
    /// </summary>
    Enterprise = 2
}
