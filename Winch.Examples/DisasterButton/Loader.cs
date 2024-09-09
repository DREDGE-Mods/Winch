using UnityEngine;

namespace DisasterButton;

public class Loader
{
    public static void Initialize()
    {
        UnityEngine.Object.DontDestroyOnLoad(new GameObject("DisasterButton", typeof(DisasterButton)));
    }
}