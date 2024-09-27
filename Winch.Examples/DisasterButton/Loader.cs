using UnityEngine;

namespace DisasterButton;

public class Loader
{
    public static void Initialize()
    {
        new GameObject("DisasterButton", typeof(DisasterButton)).DontDestroyOnLoad();
    }
}