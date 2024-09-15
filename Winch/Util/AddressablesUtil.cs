using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Winch.Core;

namespace Winch.Util;

public static class AddressablesUtil
{
    internal static IList<IResourceLocator> Locators => Addressables.ResourceLocators.ToList();
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
}