using UnityEngine;

namespace Winch.Util;

public static class Layer
{
    public static int Default = LayerMask.NameToLayer(nameof(Default));
    public static int TransparentFX = LayerMask.NameToLayer(nameof(TransparentFX));
    public static int IgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
    public static int Water = LayerMask.NameToLayer(nameof(Water));
    public static int UI = LayerMask.NameToLayer(nameof(UI));
    public static int Player = LayerMask.NameToLayer(nameof(Player));
    public static int CollidesWithPlayer = LayerMask.NameToLayer(nameof(CollidesWithPlayer));
    public static int POI = LayerMask.NameToLayer(nameof(POI));
    public static int CollidesWithPOI = LayerMask.NameToLayer(nameof(CollidesWithPOI));
    public static int GridObject = LayerMask.NameToLayer(nameof(GridObject));
    public static int GridCell = LayerMask.NameToLayer(nameof(GridCell));
    public static int FoamEffects = LayerMask.NameToLayer(nameof(FoamEffects));
    public static int HarvestZone = LayerMask.NameToLayer(nameof(HarvestZone));
    public static int CollidesWithHarvestZone = LayerMask.NameToLayer(nameof(CollidesWithHarvestZone));
    public static int CollidesWithPlayerAndCamera = LayerMask.NameToLayer(nameof(CollidesWithPlayerAndCamera));
    public static int Monster = LayerMask.NameToLayer(nameof(Monster));
    public static int CollidesWithMonster = LayerMask.NameToLayer(nameof(CollidesWithMonster));
    public static int SanityModifierDetector = LayerMask.NameToLayer(nameof(SanityModifierDetector));
    public static int SanityModifier = LayerMask.NameToLayer(nameof(SanityModifier));
    public static int PlayerDetectionCollider = LayerMask.NameToLayer(nameof(PlayerDetectionCollider));
    public static int ZoneCollider = LayerMask.NameToLayer(nameof(ZoneCollider));
    public static int CameraHidden = LayerMask.NameToLayer(nameof(CameraHidden));
    public static int CollidesWithPlayerAndMonster = LayerMask.NameToLayer(nameof(CollidesWithPlayerAndMonster));
    public static int CollidesWithCamera = LayerMask.NameToLayer(nameof(CollidesWithCamera));
    public static int DSMonster = LayerMask.NameToLayer(nameof(DSMonster));
    public static int SafeZone = LayerMask.NameToLayer(nameof(SafeZone));
    public static int InteractPointUI = LayerMask.NameToLayer(nameof(InteractPointUI));
    public static int Ice = LayerMask.NameToLayer(nameof(Ice));
    public static int Icebreaker = LayerMask.NameToLayer(nameof(Icebreaker));
    public static int Ooze = LayerMask.NameToLayer(nameof(Ooze));
}
