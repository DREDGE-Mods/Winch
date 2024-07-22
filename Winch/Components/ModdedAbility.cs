using System.Runtime.CompilerServices;
using Winch.Data.Abilities;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// A wrapper for <see cref="Ability"/> that allows for modded abilities
/// </summary>
public abstract class ModdedAbility : Ability
{
    /// <summary>
    /// ID of the ability data
    /// </summary>
    internal string id;

    /// <inheritdoc cref="id"/>
    public string ID => id;

    public ModdedAbilityData ModAbilityData => AbilityUtil.GetModdedAbilityData(ID);

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
        abilityData = ModAbilityData;
        GameManager.Instance.PlayerAbilities.RegisterAbility(ModAbilityData, this);
    }

    internal void AutoUnlock()
    {
        if (ModAbilityData.autoUnlock) Unlock();
    }

    /// <summary>
    /// Unlocks this ability
    /// </summary>
    public void Unlock()
    {
        GameManager.Instance.PlayerAbilities.UnlockAbility(ModAbilityData.name);
    }
}