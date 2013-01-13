using ConsoleLib;

namespace StarRL
{

    public class GalaxyScreen : HorizontalComposite
    {
        public GalaxyMasterComposite GalaxyMasterComposite { get; set; }
        public GalaxyDetailComposite GalaxyDetailComposite { get; set; }

        public GalaxyScreen(Composite parent)
            : base(parent)
        {
            GalaxyMasterComposite = new GalaxyMasterComposite(this);
            GalaxyDetailComposite = new GalaxyDetailComposite(this) { GrabHorizontal = true, };

            var masterBoxWidget = new BoxWidget(GalaxyMasterComposite) { GrabHorizontal = true, GrabVertical = true };
            var detailBoxWidget = new BoxWidget(GalaxyDetailComposite) { GrabHorizontal = true, GrabVertical = true };

            AddControl(masterBoxWidget);
            AddControl(detailBoxWidget);
        }
    }
}
