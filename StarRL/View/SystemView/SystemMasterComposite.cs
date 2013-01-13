
using ConsoleLib;
namespace StarRL
{
    public class SystemMasterComposite : VerticalComposite
    {
        public EntityDisplayControl SystemControl { get; set; }

        public SystemMasterComposite(Composite parent)
            : base(parent)
        {

            SystemControl = new EntityDisplayControl(parent);

            var boxControl = new BoxWidget(SystemControl);

            AddControl(boxControl);
        }        

    }
}
