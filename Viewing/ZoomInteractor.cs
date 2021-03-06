﻿using System;
using System.Windows;

namespace Viewing
{
    public class ZoomInteractor : IMouseInteractor
    {
        Point _startPosition;
        double _startFactor = 100;
        bool isDragging;

        public void MouseDown(Point position, Viewport viewport)
        {
            _startPosition = position;
            _startFactor = viewport.Camera.Zoom;
            isDragging = true;
        }

        public bool MouseMove(Point position, Viewport viewport)
        {
            if (!isDragging) { return false; }
            double deltaY = (position - _startPosition).Y;
            viewport.Camera.Zoom = _startFactor * Math.Pow(2, 0.01 * (deltaY));
            return true;
        }

        public void MouseUp(Point position, Viewport viewport)
        {
            isDragging = false;
        }
    }
}
