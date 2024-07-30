using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return base.Activate();
            }
        }

        public override void Deactivate()
        {
            if (Locked) return;

            if (isActive)
            {
                WinchCore.Log.Warn("Deactivating");
            }

            base.Deactivate();
        }

        public override void Init()
        {
            WinchCore.Log.Warn("Initializing");
            base.Init();
        }
    }
}
