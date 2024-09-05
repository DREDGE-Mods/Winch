using UnityEngine;
using Winch.Util;

namespace Winch.Components
{
    [UsedInUnityProject]
    public class SpecificShaderReplacer : MonoBehaviour
    {
        [SerializeField]
        public Material material;

        [SerializeField]
        public string shader;

        private void Awake() => ReplaceShader();

        private void Start() => ReplaceShader();

        private void OnEnable() => ReplaceShader();

        public void ReplaceShader()
        {
            if (material != null && !string.IsNullOrWhiteSpace(shader)) material.ReplaceShader(shader);
        }

        public void OnValidate()
        {
            if (material != null && string.IsNullOrWhiteSpace(shader)) shader = material.shader.name;
        }
    }
}
