using Winch.Components;

namespace ExampleItems
{
    public class TestWorldEvent : ModdedWorldEvent
    {
		public override void Activate()
		{
			base.Activate();
			this.RequestEventFinish();
		}

		public override void RequestEventFinish()
		{
			base.RequestEventFinish();
			this.EventFinished();
		}
	}
}
