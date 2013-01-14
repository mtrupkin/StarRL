using ConsoleLib;


namespace StarRL
{

    public class SystemScreen : HorizontalComposite
    {

        public SystemMasterComposite SystemMasterComposite { get; set; }
        public SystemDetailComposite SystemDetailComposite { get; set; }

        public SystemScreen(Composite parent)
            : base(parent)
        {
            SystemMasterComposite = new SystemMasterComposite(this);
            SystemDetailComposite = new SystemDetailComposite(this) { GrabHorizontal = true, };

            var masterBoxWidget = new BoxWidget(SystemMasterComposite) { GrabHorizontal = true, GrabVertical = true };
            var detailBoxWidget = new BoxWidget(SystemDetailComposite) { GrabHorizontal = true, GrabVertical = true };
            AddControl(masterBoxWidget);
            AddControl(detailBoxWidget);
        }
    }
}
