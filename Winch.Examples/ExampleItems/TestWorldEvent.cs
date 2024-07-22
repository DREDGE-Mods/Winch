using Winch.Components;

namespace ExampleItems
{
    public class TestWorldEvent : ModdedWorldEvent
    {
		public override void Activate()
		{
			base.gameObject.SetActive(true);
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
