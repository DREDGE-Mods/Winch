using Winch.Util;

[EnumHolder]
public static class DredgeColorTypesExtra
{
    public const DredgeColorTypeEnum ATTENTION = DredgeColorTypeEnum.DISABLED + 1;
    public const DredgeColorTypeEnum INFO = DredgeColorTypeEnum.DISABLED + 2;
    public const DredgeColorTypeEnum PRIORITY = DredgeColorTypeEnum.DISABLED + 3;
    public const DredgeColorTypeEnum ALERT = DredgeColorTypeEnum.DISABLED + 4;
}