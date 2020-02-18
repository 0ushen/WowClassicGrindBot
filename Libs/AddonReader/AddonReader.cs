﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Libs
{
    public class AddonReader : IAddonReader
    {
        private Color[] FrameColor { get; set; } = new Color[100];

        private readonly int width;
        private readonly int height;
        private readonly List<DataFrame> frames;
        private readonly IColorReader colorReader;

        public AddonReader(IColorReader colorReader, List<DataFrame> frames, int width, int height)
        {
            this.colorReader = colorReader;
            this.frames = frames;
            this.width = width;
            this.height = height;
        }

        public void Refresh()
        {
            var bitMap = WowScreen.GetAddonBitmap(this.width, this.height);
            frames.ForEach(frame => FrameColor[frame.index] = colorReader.GetColorAt(frame.point, bitMap));
        }

        public Color GetColorAt(DataFrame frame)
        {
            return FrameColor[frame.index];
        }
    }
}