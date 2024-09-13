using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.Localization;
using Winch.Data.Quest.Grid;
using Winch.Data.Quest.Grid.Condition;
using Winch.Util;

namespace Winch.Serialization.Quest.Grid;

public class QuestGridConfigConverter : DredgeTypeConverter<DeferredQuestGridConfig>
{
    internal const string QuestGridConfigTableDefinition = "Strings";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "questGridExitMode", new(QuestGridExitMode.REVISITABLE, o => DredgeTypeHelpers.GetEnumValue<QuestGridExitMode>(o)) },
        { "titleString", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "helpStringOverride", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "exitPromptOverride", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "backgroundImage", new(null, o=> TextureUtil.GetSprite(o.ToString())) },
        { "gridHeightOverride", new(0f, o=> float.Parse(o.ToString())) },
        { "overrideGridCellColor", new(false, o=> bool.Parse(o.ToString())) },
        { "gridCellColor", new(DredgeColorTypeEnum.NEUTRAL, o => DredgeTypeHelpers.GetEnumValue<DredgeColorTypeEnum>(o)) },
        { "allowStorageAccess", new(false, o=> bool.Parse(o.ToString())) },
        { "isSaved", new(false, o=> bool.Parse(o.ToString())) },
        { "createItemsIfEmpty", new(false, o=> bool.Parse(o.ToString())) },
        { "gridKey", new(GridKey.NONE, o => DredgeTypeHelpers.GetEnumValue<GridKey>(o)) },
        { "allowManualExit", new(false, o=> bool.Parse(o.ToString())) },
        { "allowEquipmentInstallation", new(false, o=> bool.Parse(o.ToString())) },
        { "createWithDurabilityValue", new(false, o=> bool.Parse(o.ToString())) },
        { "startingDurabilityProportion", new(0f, o=> float.Parse(o.ToString())) },
        { "gridConfiguration", new(string.Empty, null) },
        { "presetGrid", new(new SerializableGrid(), o => DredgeTypeHelpers.ParseSerializableGrid(o)) }, //TODO: implement better
        { "presetGridMode", new(PresetGridMode.NONE, o => DredgeTypeHelpers.GetEnumValue<PresetGridMode>(o)) },
        { "completeConditions", new(new List<CompletedGridCondition>{ new FullCondition() }, o=> DredgeTypeHelpers.ParseCompletedGridConditions((JArray)o)) },
    };

    private readonly Dictionary<string, string> _reroutes = new()
    {
        { "gridConfiguration", "id" }
    };

    public QuestGridConfigConverter()
    {
        AddDefinitions(_definitions);
        AddReroutes(_reroutes);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(QuestGridConfigTableDefinition, value);
}
