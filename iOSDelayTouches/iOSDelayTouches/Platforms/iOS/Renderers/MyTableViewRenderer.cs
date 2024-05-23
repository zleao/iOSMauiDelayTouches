using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;

namespace iOSDelayTouches.Platforms.iOS.Renderers
{
    public class MyTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Apply the fix for the TableViewRenderer on iOS
                Control.DelaysContentTouches = false;
            }
        }
    }
}
