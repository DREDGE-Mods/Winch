using UnityEngine;
using UnityEngine.AddressableAssets;
using Winch.Util;

namespace Winch.Components;

[RequireComponent(typeof(BaseDestination))]
public class AddressableDestination : MonoBehaviour
{
    [SerializeField]
    public BaseDestination destination;

    [SerializeField]
    public string titleTable = LanguageManager.STRING_TABLE;

    [SerializeField]
    public string titleKey = "title.";

    [SerializeField]
    public string visitSFX = "";

    public void Start()
    {
        SetFields();
    }

    public void SetFields()
    {
        destination.titleKey = LocalizationUtil.CreateReference(titleTable, titleKey);
        destination.visitSFX = new AssetReference(visitSFX);
    }

    public void OnValidate()
    {
        if (destination == null) destination = GetComponent<BaseDestination>();
        SetFields();
    }
}
