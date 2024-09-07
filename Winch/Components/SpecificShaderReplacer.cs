using Sirenix.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Util;

namespace Winch.Components
{
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

        private void Awake() => ReplaceShader();

        private void Start() => ReplaceShader();

        private void OnEnable() => ReplaceShader();

        public void ReplaceShader()
        {
            if (renderer != null && shaders != null && shaders.Count >= 0) renderer.sharedMaterials.ForEach((material, i) =>
            {
                if (shaders.Count > i && shaders.TryGetValue(i, out string shader) && !string.IsNullOrWhiteSpace(shader))
                    material.ReplaceShader(shader);
            });
        }

        public void OnValidate()
        {
            if (renderer == null) renderer = GetComponent<Renderer>();
            if (renderer != null && (shaders == null || shaders.Count == 0)) shaders = renderer.sharedMaterials.Select(material => material.shader.name).ToList();
        }
    }
}
