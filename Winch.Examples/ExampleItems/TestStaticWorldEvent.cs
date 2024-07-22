using Winch.Components;

namespace ExampleItems
{
    public class TestStaticWorldEvent : StaticWorldEvent
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
