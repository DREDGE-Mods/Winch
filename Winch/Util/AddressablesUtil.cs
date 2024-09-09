using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using Winch.Core;

namespace Winch.Util;

public static class AddressablesUtil
{
    internal static IList<IResourceLocator> Locators => Addressables.ResourceLocators.ToList();
    internal static ResourceLocationMap ResourceLocationMap => Addressables.ResourceLocators.OfType<ResourceLocationMap>().FirstOrDefault();
    internal static IReadOnlyDictionary<string, string> AssetPathByGuid => AllLocations.Where(kvp => Guid.TryParse(kvp.Key.ToString(), out _)).ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.FirstOrDefault().ToString());
    internal static IReadOnlyDictionary<string, string> GuidByAssetPath => AssetPathByGuid.DistinctBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
    internal static IReadOnlyList<string> Guids => AssetPathByGuid.Keys.ToList();
    internal static IReadOnlyList<string> AssetPaths => GuidByAssetPath.Keys.ToList();
    internal static Dictionary<string, IList<IResourceLocation>> AllLocations
    {
        get
        {
            var locations = new Dictionary<string, IList<IResourceLocation>>();
            foreach (var kvp in Locations)
                locations.Add(kvp.Key, kvp.Value);
            foreach (var kvp in MapLocations)
            {
                if (locations.ContainsKey(kvp.Key))
                {
                    locations[kvp.Key] = locations[kvp.Key].Concat(kvp.Value).ToList();
                }
                else
                    locations.Add(kvp.Key, kvp.Value);
            }
            return locations;
        }
    }
    internal static Dictionary<string, IList<IResourceLocation>> MapLocations => (Locators[1] as ResourceLocationMap).Locations.Select(kvp => new KeyValuePair<string, IList<IResourceLocation>>(kvp.Key.ToString(), kvp.Value)).ToDictionary(x => x.Key, x => x.Value);
    internal static Dictionary<string, IList<IResourceLocation>> Locations = new Dictionary<string, IList<IResourceLocation>>();
    internal static Dictionary<IResourceLocation, UnityEngine.Object> Resources = new Dictionary<IResourceLocation, UnityEngine.Object>();

    public static void Initialize()
    {
        var provider = new ModdedResourceProvider();
        var locator = new ModdedResourceLocator();
        Addressables.ResourceManager.ResourceProviders.Add(provider);
        Addressables.AddResourceLocator(locator);
    }

    public static ResourceLocationBase AddResourceAtLocation<T>(string key, string location, T resource) where T : UnityEngine.Object
        => AddResourceAtLocation(key, location, (UnityEngine.Object)resource);

    public static ResourceLocationBase AddResourceAtLocation(string key, string location, UnityEngine.Object resource)
    {
        if (string.IsNullOrWhiteSpace(location)) return null;

        var resourceLocation = new ModdedResourceLocation(location, resource.GetType());

        Resources.Add(resourceLocation, resource);
        AddLocation(key, resourceLocation);

        return resourceLocation;
    }

    public static ResourceLocationBase AddResourceAtLocation<T>(string primaryKey, string secondaryKey, string location, T resource) where T : UnityEngine.Object
        => AddResourceAtLocation(primaryKey, secondaryKey, location, (UnityEngine.Object)resource);

    public static ResourceLocationBase AddResourceAtLocation(string primaryKey, string secondaryKey, string location, UnityEngine.Object resource)
    {
        if (string.IsNullOrWhiteSpace(location)) return null;

        var resourceLocation = new ModdedResourceLocation(location, resource.GetType());

        Resources.Add(resourceLocation, resource);
        AddLocation(primaryKey, resourceLocation);
        AddLocation(secondaryKey, resourceLocation);

        return resourceLocation;
    }

    public static ResourceLocationBase AddResourceAtLocation<T>(IEnumerable<string> keys, string location, T resource) where T : UnityEngine.Object
        => AddResourceAtLocation(keys, location, (UnityEngine.Object)resource);

    public static ResourceLocationBase AddResourceAtLocation(IEnumerable<string> keys, string location, UnityEngine.Object resource)
    {
        if (string.IsNullOrWhiteSpace(location)) return null;

        var resourceLocation = new ModdedResourceLocation(location, resource.GetType());

        Resources.Add(resourceLocation, resource);
        AddLocation(keys, resourceLocation);

        return resourceLocation;
    }

    public static void AddLocation(string key, IResourceLocation location)
    {
        if (string.IsNullOrWhiteSpace(key) || location == null) return;

        if (!Locations.ContainsKey(key))
            Locations.Add(key, new List<IResourceLocation>());
        Locations[key].Add(location);
    }

    public static void AddLocations(string key, IList<IResourceLocation> locations)
    {
        if (string.IsNullOrWhiteSpace(key) || locations == null || locations.Count == 0) return;

        if (!Locations.ContainsKey(key))
            Locations.Add(key, locations);
        else
            Locations[key].AddRange(locations);
    }

    public static void AddLocation(IEnumerable<string> keys, IResourceLocation location)
    {
        if (keys == null || location == null) return;

        foreach (var key in keys)
            AddLocation(key, location);
    }

    public static void AddLocations(IEnumerable<string> keys, IList<IResourceLocation> locations)
    {
        if (keys == null || locations == null || locations.Count == 0) return;

        foreach (var key in keys)
            AddLocations(key, locations);
    }

    internal static IList<IResourceLocation> GetLocations<T>(IResourceLocator locator, string key) => GetLocations(locator, key, typeof(T));

    internal static IList<IResourceLocation> GetLocations(IResourceLocator locator, string key) => GetLocations(locator, key, null);

    internal static IList<IResourceLocation> GetLocations(IResourceLocator locator, string key, Type type)
    {
        locator.Locate(key, type, out IList<IResourceLocation> locations);
        return locations;
    }

    public static IList<IResourceLocation> GetLocations<T>(string key) => GetLocations(key, typeof(T));

    public static IList<IResourceLocation> GetLocations(string key) => GetLocations(key, null);

    public static IList<IResourceLocation> GetLocations(string key, Type type)
    {
        List<IResourceLocation> locations = new List<IResourceLocation>();
        foreach (var locator in Locators)
        {
            var locatorLocations = GetLocations(locator, key, type);
            if (locatorLocations != null)
            {
                locations.AddRange(locatorLocations);
            }
        }
        return locations;
    }

    /// <inheritdoc cref="GetIdenticalLocationKey(string, Type)"/>
    public static string GetIdenticalLocationKey<T>(string key) => GetIdenticalLocationKey(key, typeof(T));

    /// <inheritdoc cref="GetIdenticalLocationKey(string, Type)"/>
    public static string GetIdenticalLocationKey(string key) => GetIdenticalLocationKey(key, null);

    /// <summary>
    /// Searches the resource location map for a key with an identical location as the given <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key to grab the location from and search for another with an identical location</param>
    /// <returns>A different key with an identical location as the given <paramref name="key"/></returns>
    public static string GetIdenticalLocationKey(string key, Type type)
    {
        if (string.IsNullOrWhiteSpace(key)) return null;

        var keyLocations = GetLocations(key, type);
        if (keyLocations == null || keyLocations.Count == 0) return null;

        if (keyLocations.Count > 1)
        {
            WinchCore.Log.Error($"Key \"{key}\" has more than one location attached to it.");
            return null;
        }

        var keyLocation = keyLocations.First();
        var locations = AllLocations.Where(kvp => kvp.Value.Count > 0 && (type != null ? kvp.Value.Any(v => v.ResourceType.IsAssignableFrom(type)) : true) && kvp.Key.ToString() != key);
        foreach (var kvp in locations)
        {
            var oKey = kvp.Key.ToString();
            var location = type != null ? kvp.Value.First(v => v.ResourceType.IsAssignableFrom(type)) : kvp.Value.First();
            if (location.ToString() == keyLocation.ToString())
                return oKey;
        }
        return null;
    }

    /// <inheritdoc cref="TryGetIdenticalLocationKey(string, Type, out string)"/>
    public static bool TryGetIdenticalLocationKey<T>(string key, out string identical) => TryGetIdenticalLocationKey(key, typeof(T), out identical);

    /// <inheritdoc cref="TryGetIdenticalLocationKey(string, Type, out string)"/>
    public static bool TryGetIdenticalLocationKey(string key, out string identical) => TryGetIdenticalLocationKey(key, null, out identical);

    /// <summary>
    /// Searches the resource location map for a key with an identical location as the given <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key to grab the location from and search for another with an identical location</param>
    /// <param name="identical">If found, this will be a different key with an identical location as the given <paramref name="key"/></param>
    /// <returns><see langword="true"/> if found, <see langword="false"/> if not.</returns>
    public static bool TryGetIdenticalLocationKey(string key, Type type, out string identical)
    {
        identical = string.Empty;

        if (string.IsNullOrWhiteSpace(key)) return false;

        var keyLocations = GetLocations(key, type);
        if (keyLocations == null || keyLocations.Count == 0) return false;

        if (keyLocations.Count > 1)
        {
            WinchCore.Log.Error($"Key \"{key}\" has more than one location attached to it.");
            return false;
        }

        var keyLocation = keyLocations.First();
        var locations = AllLocations.Where(kvp => kvp.Value.Count > 0 && (type != null ? kvp.Value.Any(v => v.ResourceType.IsAssignableFrom(type)) : true) && kvp.Key.ToString() != key);
        foreach (var kvp in locations)
        {
            var oKey = kvp.Key.ToString();
            var location = type != null ? kvp.Value.First(v => v.ResourceType.IsAssignableFrom(type)) : kvp.Value.First();
            if (location.ToString() == keyLocation.ToString())
            {
                identical = oKey;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Searches for an asset path's GUID
    /// </summary>
    public static string GetAssetGUID(string assetPath)
    {
        if (GuidByAssetPath.TryGetValue(assetPath, out string guid))
            return guid;
        return string.Empty;
    }

    /// <summary>
    /// Searches for an asset path's GUID
    /// </summary>
    public static bool TryGetAssetGUID(string assetPath, out string guid)
        => GuidByAssetPath.TryGetValue(assetPath, out guid);

    /// <summary>
    /// Searches for an asset GUID's path
    /// </summary>
    public static string GetAssetPath(string guid)
    {
        if (AssetPathByGuid.TryGetValue(guid, out string assetPath))
            return assetPath;
        return string.Empty;
    }

    /// <summary>
    /// Searches for an asset GUID's path
    /// </summary>
    public static bool TryGetAssetPath(string guid, out string assetPath)
        => AssetPathByGuid.TryGetValue(guid, out assetPath);

    public static AssetReference EmptyAssetReference => new AssetReference(string.Empty);

    private static string GetPossibleAssetGUID(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return string.Empty;

        if (Guid.TryParse(s, out _)) return s;

        if (AddressablesUtil.TryGetAssetGUID(s, out string guid))
            return guid;

        if (AddressablesUtil.TryGetIdenticalLocationKey(s, out string identical))
            return identical;

        return s;
    }

    private static string GetPossibleAssetGUID<TObject>(string namePathOrGuid) where TObject : UnityEngine.Object
    {
        if (string.IsNullOrWhiteSpace(namePathOrGuid)) return string.Empty;

        if (Guid.TryParse(namePathOrGuid, out _)) return namePathOrGuid;

        if (AddressablesUtil.TryGetAssetGUID(namePathOrGuid, out string guid))
            return guid;

        if (AddressablesUtil.TryGetIdenticalLocationKey<TObject>(namePathOrGuid, out string identical))
            return identical;

        return namePathOrGuid;
    }

    /// <summary>
    /// Creates an asset reference from an asset path if it exists in the resource location map
    /// </summary>
    public static AssetReference CreateAssetReference(string namePathOrGuid)
        => new AssetReference(GetPossibleAssetGUID(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceT<TObject> CreateAssetReference<TObject>(string namePathOrGuid) where TObject : UnityEngine.Object
        => new AssetReferenceT<TObject>(GetPossibleAssetGUID<TObject>(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceGameObject CreateAssetReferenceGameObject(string namePathOrGuid)
        => new AssetReferenceGameObject(GetPossibleAssetGUID<GameObject>(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture3D CreateAssetReferenceTexture3D(string namePathOrGuid)
        => new AssetReferenceTexture3D(GetPossibleAssetGUID<Texture3D>(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture2D CreateAssetReferenceTexture2D(string namePathOrGuid)
        => new AssetReferenceTexture2D(GetPossibleAssetGUID<Texture2D>(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture CreateAssetReferenceTexture(string namePathOrGuid)
        => new AssetReferenceTexture(GetPossibleAssetGUID<Texture>(namePathOrGuid));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceSprite CreateAssetReferenceSprite(string namePathOrGuid)
        => new AssetReferenceSprite(GetPossibleAssetGUID<Sprite>(namePathOrGuid));

    /// <summary>
    /// Generates a new GUID in Unity's format
    /// </summary>
    /// <returns>The generated GUID</returns>
    public static string GenerateGUID()
    {
        var guids = Guids;
        var guid = Guid.NewGuid().ToString("N");
        while (guids.Contains(guid))
            guid = Guid.NewGuid().ToString("N");
        return guid;
    }

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceGameObject GenerateAssetReference(string location, GameObject resource)
        => new AssetReferenceGameObject(AddResourceAtLocationWithGUID(location, resource));

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceTexture GenerateAssetReference(string location, Texture resource)
        => new AssetReferenceTexture(AddResourceAtLocationWithGUID(location, resource));

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceTexture2D GenerateAssetReference(string location, Texture2D resource)
        => new AssetReferenceTexture2D(AddResourceAtLocationWithGUID(location, resource));

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceTexture3D GenerateAssetReference(string location, Texture3D resource)
        => new AssetReferenceTexture3D(AddResourceAtLocationWithGUID(location, resource));

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceSprite GenerateAssetReference(string location, Sprite resource)
        => new AssetReferenceSprite(AddResourceAtLocationWithGUID(location, resource));

    /// <inheritdoc cref="GenerateAssetReference(string, UnityEngine.Object)"/>
    public static AssetReferenceT<T> GenerateAssetReference<T>(string location, T resource) where T : UnityEngine.Object
        => new AssetReferenceT<T>(AddResourceAtLocationWithGUID(location, resource));

    internal static AssetReference GenerateAssetReference(string location, UnityEngine.Object resource)
        => new AssetReference(AddResourceAtLocationWithGUID(location, resource));

    /// <summary>
    /// Generates a new GUID and adds the resource to it.
    /// </summary>
    /// <returns>The generated GUID</returns>
    internal static string AddResourceAtLocationWithGUID(string location, UnityEngine.Object resource)
    {
        var guid = GenerateGUID();
        AddResourceAtLocation(guid, resource.name, location, resource);
        return guid;
    }
}

public class AssetPathReference : AssetReference
{
    [SerializeField]
    protected internal string m_AssetPath;

    public AssetPathReference(string assetPath) : base(AddressablesUtil.GetAssetGUID(assetPath))
    {
        m_AssetPath = assetPath;
    }
}
