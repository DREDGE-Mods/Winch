using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Core;

namespace Winch.Components
{
    public class ModdedAutoMovePOI : AutoMovePOI
    {
        [SerializeField]
        public bool unlockPlayerMovementAfterConversationCompleted = true;

        public override void OnConversationCompleted()
        {
            base.OnConversationCompleted();
            if (unlockPlayerMovementAfterConversationCompleted)
            {
                UnlockPlayerMovement();
            }
        }

        public void UnlockPlayerMovement()
        {
            WinchCore.Log.Debug("[ModdedAutoMovePOI] UnlockPlayerMovement()");
            GameManager.Instance.Player.Controller.ClearAutoMoveTarget();
            GameManager.Instance.Player.Controller.ClearAutoRotateTarget();
        }
    }
}
