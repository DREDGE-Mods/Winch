using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components;
using Winch.Util;

namespace Winch.Data.Character;

public class AdvancedSpeakerData : SpeakerData
{
    /// <summary>
    /// The id of this speaker data
    /// </summary>
    [SerializeField]
    public string id = string.Empty;

    /// <summary>
    /// The character you'd like to copy the paralinguistics from.
    /// </summary>
    [SerializeField]
    public ParalinguisticsNameKey paralinguisticsNameKey = ParalinguisticsNameKey.NONE;

    /// <summary>
    /// The image of the character. This will show up when you are talking to them.
    /// </summary>
    [SerializeField]
    public Sprite portraitSprite;

    /// <summary>
    /// Image overrides
    /// </summary>
    [SerializeField]
    public new List<AdvancedPortraitOverride> portraitOverrideConditions = new List<AdvancedPortraitOverride>();

    [SerializeField]
    public new string loopSFX = string.Empty;

    public AudioClip LoopSFX => base.loopSFX;

    public static GameObject MakePortraitPrefab(string name, Sprite portraitSprite)
    {
        var portraitPrefab = new GameObject($"{name} PortraitPrefab", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster), typeof(SpeakerPortraitAnimator)).Prefabitize();
        portraitPrefab.layer = Layer.UI;
        var imageObj = new GameObject(name, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
        var rt = (RectTransform)imageObj.transform;
        rt.SetParent(portraitPrefab.transform, false);
        rt.localScale = Vector3.one * 100f;
        rt.sizeDelta = Vector2.one * 7f;
        var image = imageObj.GetComponent<Image>();
        image.sprite = portraitSprite;
        image.preserveAspect = true;
        image.raycastTarget = false;
        return portraitPrefab;
    }

    public static List<PortraitOverride> MakePortraitOverrides(string name, List<AdvancedPortraitOverride> portraitOverrideConditions)
    {
        var portraitOverrides = new List<PortraitOverride>();
        var num = 2;
        foreach (var portraitOverride in portraitOverrideConditions)
        {
            portraitOverrides.Add(new PortraitOverride
            {
                portraitPrefab = MakePortraitPrefab($"{name} {num++}", portraitOverride.portraitSprite),
                smallPortraitSprite = portraitOverride.smallPortraitSprite,
                useManualState = portraitOverride.useManualState,
                stateName = portraitOverride.stateName,
                stateValue = portraitOverride.stateValue,
                nodesVisited = portraitOverride.nodesVisited
            });
        }
        return portraitOverrides;
    }

    public void MakePortraitPrefabs()
    {
        portraitPrefab = MakePortraitPrefab(id, portraitSprite);
        base.portraitOverrideConditions = MakePortraitOverrides(id, portraitOverrideConditions);
    }

    internal void Populate()
    {
        MakePortraitPrefabs();
        base.loopSFX = AudioClipUtil.GetAudioClip(loopSFX); // TODO: maybe move to this to when game is loaded
    }
}
