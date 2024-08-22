using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Components
{
    [UsedInUnityProject]
    public class BoatCustomization : MonoBehaviour
    {
        [SerializeField]
        public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

        [SerializeField]
        public List<GameObject> buntingObjects = new List<GameObject>();

        [SerializeField]
        public List<SkinnedMeshRenderer> buntingMeshRenderers = new List<SkinnedMeshRenderer>();

        [SerializeField]
        public List<GameObject> flagObjects = new List<GameObject>();

        [SerializeField]
        public List<SkinnedMeshRenderer> flagMeshRenderers = new List<SkinnedMeshRenderer>();

        public void Awake()
        {
            var customizer = this.GetComponentInParent<PlayerColorCustomizer>(true);
            customizer.meshRenderers.AddRange(meshRenderers);
            customizer.buntingObjects.AddRange(buntingObjects);
            customizer.buntingMeshRenderers.AddRange(buntingMeshRenderers);
            customizer.flagObjects.AddRange(flagObjects);
            customizer.flagMeshRenderers.AddRange(flagMeshRenderers);
        }
    }
}
