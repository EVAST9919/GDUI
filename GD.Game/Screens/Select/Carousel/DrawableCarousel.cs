using System;
using System.Linq;
using GD.Game.Graphics;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Select.Carousel
{
    public class DrawableCarousel : CompositeDrawable
    {
        public Action<Color4> ColourChanged;

        public DefaultLevel[] Items { get; set; }

        private int selectedIndex = 0;

        private Container<DrawableCarouselItem> itemsContainer;
        private FillFlowContainer circlesFlow;

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            AddRangeInternal(new Drawable[]
            {
                itemsContainer = new Container<DrawableCarouselItem>
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                },
                new TexturedGDButton("carousel-button", FlipOrientation.Horizontal)
                {
                    Anchor = Anchor.CentreLeft,
                    X = 85,
                    Y = 10,
                    ClickAction = () => selectPrev()
                },
                new TexturedGDButton("carousel-button")
                {
                    Anchor = Anchor.CentreRight,
                    X = -85,
                    Y = 10,
                    ClickAction = () => selectNext()
                },
                circlesFlow = new FillFlowContainer
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Direction = FillDirection.Horizontal,
                    AutoSizeAxes = Axes.Both,
                    Spacing = new Vector2(30),
                    Y = -40,
                    Children = Items.Select(_ => new Circle
                    {
                        Colour = Color4.Gray,
                        Size = new Vector2(25)
                    }).ToList()
                }
            });

            itemsContainer.AddRange(new[]
            {
                new DrawableCarouselItem
                {
                    X = -1f,
                    State = CarouselItemState.Prev,
                    Item = { Value = Items[getPrevIndex()] }
                },
                new DrawableCarouselItem
                {
                    State = CarouselItemState.Current,
                    Item = { Value = Items[selectedIndex] }
                },
                new DrawableCarouselItem
                {
                    X = 1f,
                    State = CarouselItemState.Next,
                    Item = { Value = Items[getNextIndex()] }
                },
            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            ColourChanged?.Invoke(Items[0].Colour);
            circlesFlow[0].Colour = Color4.White;
        }

        private float dragStartX;

        protected override bool OnDragStart(DragStartEvent e)
        {
            base.OnDragStart(e);

            dragStartX = e.MousePosition.X;
            clearTransforms();

            return true;
        }

        protected override void OnDrag(DragEvent e)
        {
            base.OnDrag(e);

            foreach (var i in itemsContainer)
                i.X += e.Delta.X / DrawWidth;
        }

        protected override void OnDragEnd(DragEndEvent e)
        {
            base.OnDragEnd(e);

            if (e.MousePosition.X > dragStartX)
                selectPrev(400);
            else
                selectNext(400);
        }

        private void selectNext(double time = 800)
        {
            finishTransforms();

            var prev = getDrawableItem(CarouselItemState.Prev);
            var next = getDrawableItem(CarouselItemState.Next);
            var current = getDrawableItem(CarouselItemState.Current);

            prev.MoveToX(1f);
            prev.State = CarouselItemState.Next;

            current.MoveToX(-1f, time, Easing.OutElasticHalf);
            current.State = CarouselItemState.Prev;

            next.MoveToX(0, time, Easing.OutElasticHalf);
            next.State = CarouselItemState.Current;

            updateIndex(true);
            prev.Item.Value = Items[getNextIndex()];
        }

        private void selectPrev(double time = 800)
        {
            finishTransforms();

            var prev = getDrawableItem(CarouselItemState.Prev);
            var next = getDrawableItem(CarouselItemState.Next);
            var current = getDrawableItem(CarouselItemState.Current);

            next.MoveToX(-1f);
            next.State = CarouselItemState.Prev;

            current.MoveToX(1f, time, Easing.OutElasticHalf);
            current.State = CarouselItemState.Next;

            prev.MoveToX(0, time, Easing.OutElasticHalf);
            prev.State = CarouselItemState.Current;

            updateIndex(false);
            next.Item.Value = Items[getPrevIndex()];
        }

        private void updateIndex(bool next)
        {
            circlesFlow[selectedIndex].Colour = Color4.Gray;
            selectedIndex = next ? getNextIndex() : getPrevIndex();
            circlesFlow[selectedIndex].Colour = Color4.White;

            ColourChanged?.Invoke(Items[selectedIndex].Colour);
        }

        private void clearTransforms()
        {
            foreach (var i in itemsContainer)
                i.ClearTransforms();
        }

        private void finishTransforms()
        {
            foreach (var i in itemsContainer)
                i.FinishTransforms();
        }

        private int getNextIndex()
        {
            var i = selectedIndex + 1;
            if (i > Items.Length - 1)
                i = 0;

            return i;
        }

        private int getPrevIndex()
        {
            var i = selectedIndex - 1;
            if (i < 0)
                i = Items.Length - 1;

            return i;
        }

        private DrawableCarouselItem getDrawableItem(CarouselItemState state)
        {
            foreach (var i in itemsContainer)
            {
                if (i.State == state)
                    return i;
            }

            return null;
        }
    }
}
