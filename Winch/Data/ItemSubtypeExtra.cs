using System.ComponentModel;
using Winch.Util;

[EnumHolder]
public static class ItemSubtypeExtra
{
    /// <summary>
    /// Every subtype except <see cref="ItemSubtype.ENGINE"/>, <see cref="ItemSubtype.ROD"/>, <see cref="ItemSubtype.LIGHT"/>, <see cref="ItemSubtype.NET"/>, and <see cref="ItemSubtype.DREDGE"/>.
    /// Used for inventory/hull grid configs.
    /// </summary>
    public const ItemSubtype DEFAULT = (ItemSubtype)(-1671);
}