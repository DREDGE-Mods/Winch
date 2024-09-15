using UnityEngine;
using Winch.Util;

namespace Winch.Components;

[UsedInUnityProject]
public class ShaderReplacer : MonoBehaviour
{
    private void Awake() => ReplaceShaders();

    private void Start() => ReplaceShaders();

    private void OnEnable() => ReplaceShaders();

    public void ReplaceShaders()
    {
        gameObject.ReplaceShaders();
    }
}