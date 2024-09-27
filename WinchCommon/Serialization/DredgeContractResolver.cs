using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Winch.Serialization;

public class DredgeContractResolver : DefaultContractResolver
{
    public bool IsReadOnlyProperty(MemberInfo member)
    {
        return member is PropertyInfo property && property.GetCustomAttribute<JsonPropertyAttribute>() == null;
    }

    public bool IsDelegate(MemberInfo member)
    {
        return (member is FieldInfo field && typeof(Delegate).IsAssignableFrom(field.FieldType)) || (member is PropertyInfo property && typeof(Delegate).IsAssignableFrom(property.PropertyType));
    }

    public bool FilterMember(MemberInfo member)
    {
        if (IsReadOnlyProperty(member)) return false;
        if (IsDelegate(member)) return false;
        return true;
    }

    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        var members = base.GetSerializableMembers(objectType);
        return members.Where(FilterMember).ToList();
    }

    public static List<MemberInfo> GetSerializableMembersForType(Type objectType) => new DredgeContractResolver().GetSerializableMembers(objectType);

}