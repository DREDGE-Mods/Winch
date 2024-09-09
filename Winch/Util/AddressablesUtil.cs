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

    public static string GetAssetGUID(string assetPath)
    {
        if (GuidByAssetPath.TryGetValue(assetPath, out string guid))
            return guid;
        return string.Empty;
    }

    public static string GetAssetPath(string guid)
    {
        if (AssetPathByGuid.TryGetValue(guid, out string assetPath))
            return assetPath;
        return string.Empty;
    }

    public static AssetReference EmptyAssetReference => new AssetReference(string.Empty);

    private static string GetPossibleAssetGUID(string assetPath)
    {
        var possibleGUID = GetAssetGUID(assetPath);
        return !string.IsNullOrWhiteSpace(possibleGUID) && Guid.TryParse(possibleGUID, out _) ? possibleGUID : assetPath;
    }

    /// <summary>
    /// Creates an asset reference from an asset path if it exists in the resource location map
    /// </summary>
    public static AssetReference CreateAssetReference(string assetPath)
        => new AssetReference(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceT<TObject> CreateAssetReferenceT<TObject>(string assetPath) where TObject : UnityEngine.Object
        => new AssetReferenceT<TObject>(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceGameObject CreateAssetReferenceGameObject(string assetPath)
        => new AssetReferenceGameObject(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture3D CreateAssetReferenceTexture3D(string assetPath)
        => new AssetReferenceTexture3D(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture2D CreateAssetReferenceTexture2D(string assetPath)
        => new AssetReferenceTexture2D(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceTexture CreateAssetReferenceTexture(string assetPath)
        => new AssetReferenceTexture(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceSprite CreateAssetReferenceSprite(string assetPath)
        => new AssetReferenceSprite(GetPossibleAssetGUID(assetPath));

    /// <inheritdoc cref="CreateAssetReference(string)"/>
    public static AssetReferenceAtlasedSprite CreateAssetReferenceAtlasedSprite(string assetPath)
        => new AssetReferenceAtlasedSprite(GetPossibleAssetGUID(assetPath));

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
