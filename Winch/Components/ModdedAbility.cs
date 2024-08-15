using UnityEngine;
using Winch.Data.Abilities;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// A wrapper for <see cref="Ability"/> that allows for modded abilities
/// </summary>
public abstract class ModdedAbility : Ability
{
    [SerializeField]
    /// <inheritdoc cref="ID"/>
    internal string id;

    /// <summary>
    /// ID of the ability data
    /// </summary>
    public string ID => id;

    public ModdedAbilityData ModdedAbilityData
    {
        get
        {
            var moddedWorldEventData = AbilityUtil.GetModdedAbilityData(id);
            abilityData = moddedWorldEventData;
            return moddedWorldEventData;
        }
    }

    public virtual new void Awake()
    {
    }

    public virtual new void Start()
    {
        base.Start();
    }

    public virtual new void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void Init()
    {
        base.Init();
        AutoUnlock();
    }

    /// <summary>
    /// Registers this ability
    /// </summary>
    public void Register()
    {
        if (GameManager.Instance != null && GameManager.Instance.PlayerAbilities != null)
        {
            GameManager.Instance.PlayerAbilities.abilityDatas.SafeAdd(ModdedAbilityData);
            GameManager.Instance.PlayerAbilities.RegisterAbility(ModdedAbilityData, this);
        }
    }

    internal void AutoUnlock()
    {
        if (ModdedAbilityData.autoUnlock) Unlock();
    }

    /// <summary>
    /// Unlocks this ability
    /// </summary>
    public void Unlock()
    {
        if (GameManager.Instance != null && GameManager.Instance.PlayerAbilities != null)
        {
            GameManager.Instance.PlayerAbilities.UnlockAbility(ID);
        }
    }
}