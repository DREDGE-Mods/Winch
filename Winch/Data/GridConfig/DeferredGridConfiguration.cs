using UnityEngine;

namespace Winch.Data.GridConfig;

public class DeferredGridConfiguration : GridConfiguration
{
    [SerializeField]
    public new string mainItemData = string.Empty;

    [SerializeField]
    public GridKey gridKey = GridKey.NONE;
}
