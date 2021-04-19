using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace GD.Game.Graphics.Containers
{
    public class InputBlockContainer : Container
    {
        protected override bool OnClick(ClickEvent e) => true;

        protected override bool OnDragStart(DragStartEvent e) => true;

        protected override bool OnHover(HoverEvent e) => true;

        protected override bool OnScroll(ScrollEvent e) => true;

        protected override bool OnMouseDown(MouseDownEvent e) => true;
    }
}
