using Winch.Components;
using Winch.Core;

namespace ExampleItems
{
    public class TestWorldEvent : ModdedWorldEvent
    {
		public override void Activate()
		{
			WinchCore.Log.Debug("[TestWorldEvent] Activate()");
			base.Activate();
		}

		public override void RequestEventFinish()
		{
			WinchCore.Log.Debug("[TestWorldEvent] RequestEventFinish()");
			base.RequestEventFinish();
			this.EventFinished();
			gameObject.Destroy();
		}
	}
}
