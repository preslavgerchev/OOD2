﻿using System.Drawing;
using System;

namespace OOD2WPF
{
    public abstract class Component
    {
        public int LocationX { get; private set; }
        public int LocationY { get; private set; }
        private int drawingTextLocX;
        private int drawingTextLocY;
        private int currentFlow;
        private int maxFlow;
        private Rectangle componentBox;

        public Component(int locx, int locy, int maxFlow)
        {
            this.MaxFlow = maxFlow;
            this.CurrentFlow = 0;
            drawingTextLocX = locx;
            drawingTextLocY = locy;
            this.LocationX = locx - GetImage().Height / 2;//sets the X to the upper-left corner
            this.LocationY = locy - GetImage().Width / 2;//sets the Y to the upper-left corner
            componentBox = new Rectangle(new Point(LocationX, LocationY), new Size(GetImage().Height, GetImage().Width));
        }

        public int MaxFlow
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for the max flow is not valid!");
                }
                maxFlow = value;
            }
            get { return this.maxFlow; }
        }

        public virtual int CurrentFlow
        {
            set
            {
                if (value < 0 || value > maxFlow)
                {
                    throw new ArgumentException("The value for the current flow is not valid!");
                }
                this.currentFlow = value;
            }
            get { return this.currentFlow; }
        }

        public Rectangle GetComponentBox()
        {
            return this.componentBox;
        }

        public bool IsInFigure(Component compB)
        {
            return this.componentBox.IntersectsWith(compB.componentBox);
        }

        public abstract Image GetImage();

        public void SetCurrentFlow(int currFlow)
        {
            this.CurrentFlow = currFlow;
        }

        public Point GetLocation()
        {
            return new Point(LocationX, LocationY);
        }

        public Point GetTextLocation()
        {
            return new Point(drawingTextLocX, drawingTextLocY);
        }
    }
}
