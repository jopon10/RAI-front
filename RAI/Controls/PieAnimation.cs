﻿using System;

namespace RAI.Controls
{
    [Flags]
    public enum PieAnimation
    {
        None = 0,
        StartAngle = 1,
        SweepAngle = 2,
        RadiusFactor = 4,
        Slice = 8,
    }
}