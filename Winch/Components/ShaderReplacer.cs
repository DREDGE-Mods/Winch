using System.Collections;
using UnityEngine;
using Winch.Util;

namespace Winch.Components;

[UsedInUnityProject]
public class ShaderReplacer : MonoBehaviour
{
    private void Awake() => StartCoroutine(KeepReplacingShaders());

    private IEnumerator KeepReplacingShaders()
    {
        bool result = false;
        while (!result)
        {
            result = ReplaceShaders();
            yield return new WaitForEndOfFrame();
        }
    }

    public bool ReplaceShaders() => gameObject.ReplaceShaders();
}
