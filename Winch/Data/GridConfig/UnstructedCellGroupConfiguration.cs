using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Data.GridConfig;

/// <summary>
/// Need this or else SetValue won't work
/// </summary>
public class UnstructedCellGroupConfiguration
{
    public List<Vector2Int> cells;
    public ItemType itemType;
    public ItemSubtype itemSubtype;
    public bool isHidden;
    public bool damageImmune;

    public static implicit operator CellGroupConfiguration(UnstructedCellGroupConfiguration u)
    {
        return new CellGroupConfiguration
        {
            cells = u.cells,
            itemType = u.itemType,
            itemSubtype = u.itemSubtype,
            isHidden = u.isHidden,
            damageImmune = u.damageImmune
        };
    }
}