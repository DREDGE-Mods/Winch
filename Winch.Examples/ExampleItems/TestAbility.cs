using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Components;
using Winch.Core;

namespace ExampleItems
{
    public class TestAbility : ModdedAbility
    {
        public override bool Activate()
        {
            if (Locked) return false;

            if (this.isActive)
            {
                this.Deactivate();
                return false;
            }
            else
            {
                this.isActive = true;
                WinchCore.Log.Warn("Activating");
                StabilizeOcean();
                return base.Activate();
            }
        }

        public override void Deactivate()
        {
            if (Locked) return;

            if (isActive)
            {
                WinchCore.Log.Warn("Deactivating");
                UnstabilizeOcean();
            }

            base.Deactivate();
        }

        public static void StabilizeOcean()
        {
            GameManager.Instance.WaveController.steepness = 0;
            Shader.SetGlobalFloat("_WaveSteepness", 0);
            GameManager.Instance.WaveController.wavelength = 1;
            Shader.SetGlobalFloat("_WaveLength", 1);
            GameManager.Instance.WaveController.speed = 0;
            Shader.SetGlobalFloat("_WaveSpeed", 0);
            GameManager.Instance.WaveController.waveDirections = new float[4] { 0, 0, 0, 0 };
            Shader.SetGlobalVector("_WaveDirections", Vector4.zero);
        }

        public static void UnstabilizeOcean()
        {
            GameManager.Instance.WaveController.steepness = 0.1158f;
            Shader.SetGlobalFloat("_WaveSteepness", 0.1158f);
            GameManager.Instance.WaveController.wavelength = 6;
            Shader.SetGlobalFloat("_WaveLength", 6);
            GameManager.Instance.WaveController.speed = 0.1f;
            Shader.SetGlobalFloat("_WaveSpeed", 0.1f);
            GameManager.Instance.WaveController.waveDirections = new float[4] { 0.1f, 0.4f, 0.2f, 0.3f };
            Shader.SetGlobalVector("_WaveDirections", new Vector4(0.1f, 0.4f, 0.2f, 0.3f));
        }

        public override void Init()
        {
            WinchCore.Log.Warn("Initializing");
            base.Init();
        }
    }
}
