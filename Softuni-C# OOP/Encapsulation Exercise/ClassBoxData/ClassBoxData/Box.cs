using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBoxData
{
    public class Box
    {
        private const double SIDE_MIN_VALUE = 0;
        private const string INVALID_SIDE_MESSEGE = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Width = width;
            this.Height = height;
        }
        public double Lenght
        {
            get => this.length;
            private set
            {
                this.ValidateSide(value, nameof(this.Lenght));
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateSide(double value, string side)
        {
            if (value <= SIDE_MIN_VALUE)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_MESSEGE, side));
            }
        }

        public double SurfaceArea()
        {
            double area = 2 * (this.Lenght * this.Width) + 2 * (this.Lenght * this.Height) + 2 * (this.Width * this.Height);
            return area;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Width * this.Lenght * this.Height;
            return volume;
        }

    }
}