using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization;
using Winch.Data.Quest;
using Winch.Util;

namespace Winch.Serialization.Quest;

public class QuestDataConverter : DredgeTypeConverter<DeferredQuestData>
{
    internal const string QuestDataTableDefinition = "Strings";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "titleKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "summaryKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "resolutionKeys", new(new LocalizedString[0], o=> DredgeTypeHelpers.ParseStringList((JArray)o).Select(CreateLocalizedString).ToArray()) },
        { "mapMarkersToRemoveOnCompletion", new(new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "showUnseenIndicators", new(false, o=> bool.Parse(o.ToString())) },
        { "steps", new(new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "subquests", new(new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "onOfferedQuestStep", new(string.Empty, null) },
        { "offerConditions", new(new List<QuestStepCondition>(), o=>DredgeTypeHelpers.ParseQuestStepConditions((JArray)o)) },
        { "canBeOfferedAutomatically", new(false, o=> bool.Parse(o.ToString())) },
    };

    public QuestDataConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(QuestDataTableDefinition, value);
}
