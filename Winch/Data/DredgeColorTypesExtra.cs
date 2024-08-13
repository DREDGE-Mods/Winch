using Winch.Util;

[EnumHolder]
public static class DredgeColorTypesExtra
{
    public static readonly DredgeColorTypeEnum ATTENTION = DredgeColorTypeEnum.DISABLED + 1;
    public static readonly DredgeColorTypeEnum INFO = DredgeColorTypeEnum.DISABLED + 2;
    public static readonly DredgeColorTypeEnum PRIORITY = DredgeColorTypeEnum.DISABLED + 3;
    public static readonly DredgeColorTypeEnum ALERT = DredgeColorTypeEnum.DISABLED + 4;
}