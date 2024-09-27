using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Util;

namespace Winch.Components;

[UsedInUnityProject]
[RequireComponent(typeof(Renderer))]
public class SpecificShaderReplacer : MonoBehaviour
{
    [SerializeField]
    public Renderer renderer;

    [SerializeField]
    public List<string> shaders = new List<string>();

    public string shader
    {
        get => shaders?.FirstOrDefault() ?? string.Empty;
        set
        {
            if (shaders != null && shaders.Count > 0)
                shaders[0] = value;
            else
                shaders = new List<string> { value };
        }
    }

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

    public bool ReplaceShaders()
    {
        if (renderer != null && shaders != null && shaders.Count >= 0)
        {
            return renderer.sharedMaterials.AllForEach((material, i) =>
            {
                if (shaders.Count > i && shaders.TryGetValue(i, out string shader) && !string.IsNullOrWhiteSpace(shader))
                    return material.ReplaceShader(shader);
                return true;
            });
        }
        return true;
    }

    public void OnValidate()
    {
        if (renderer == null) renderer = GetComponent<Renderer>();
        if (renderer != null && (shaders == null || shaders.Count == 0)) shaders = renderer.sharedMaterials.Select(material => material.shader.name).ToList();
    }
}
