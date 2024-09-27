using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Boat;

public class BoatPaintData : SerializedScriptableObject
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public Color color = Color.white;

    [SerializeField]
    public string localizedNameKey = null;

    [SerializeField]
    public string questGridConfig = null;
    public virtual QuestGridConfig QuestGridConfig => QuestUtil.GetQuestGridConfig(questGridConfig);
}
