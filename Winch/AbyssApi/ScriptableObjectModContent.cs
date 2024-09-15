using JetBrains.Annotations;
using UnityEngine;

namespace Winch.AbyssApi;

/// <summary>
/// A localized mod content that is based on a ScriptableObject
/// </summary>
[PublicAPI]
public abstract class ScriptableObjectModContent<T> : LocalizedModContent where T : ScriptableObject
{
    /// <summary>
    /// The instance of T that this class is associated with
    /// </summary>
    public T Item { get; set; } = null!;

    /// <summary>
    /// Allows you to edit the item before it is registered
    /// </summary>
    /// <param name="item"></param>
    public virtual void Edit(T item)
    {
    }

    /// <inheritdoc />
    public override void Register()
    {
        Item = ScriptableObject.CreateInstance<T>();
        Item.name = Id;
    }
}