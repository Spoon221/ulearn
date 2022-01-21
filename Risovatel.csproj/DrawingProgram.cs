using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RefactorMe
{
	class Painter
	{
		static float x, y;
		static Graphics graphics;

		public static void ToInitialize(Graphics newGraphics)
		{
			graphics = newGraphics;
			graphics.SmoothingMode = SmoothingMode.None;
			graphics.Clear(Color.Black);
		}

		public static void SetPosition(float x0, float y0)
		{
			x = x0; y = y0;
		}

		public static void DrawAPath(Pen pencil, double length, double corner)
		{
			var x1 = (float)(x + length * Math.Cos(corner));
			var y1 = (float)(y + length * Math.Sin(corner));
			graphics.DrawLine(pencil, x, y, x1, y1);
			x = x1;
			y = y1;
		}

		public static void Change(double length, double corner)
		{
			x = (float)(x + length * Math.Cos(corner));
			y = (float)(y + length * Math.Sin(corner));
		}
	}

	public class ImpossibleSquare
	{
		static double straight = 0.375;
		static double diagonal = 0.04;

		public static void DrawDirection(double direction, int minHeightWidth)
		{
			Painter.DrawAPath(Pens.Yellow, minHeightWidth * straight, direction);
			Painter.DrawAPath(Pens.Yellow, minHeightWidth * diagonal * Math.Sqrt(2), direction + Math.PI / 4);
			Painter.DrawAPath(Pens.Yellow, minHeightWidth * straight, direction + Math.PI);
			Painter.DrawAPath(Pens.Yellow, minHeightWidth * straight - minHeightWidth * diagonal, direction + Math.PI / 2);
			Painter.Change(minHeightWidth * diagonal, direction - Math.PI);
			Painter.Change(minHeightWidth * diagonal * Math.Sqrt(2), direction + 3 * Math.PI / 4);
		}

		public static void Draw(int width, int height, double angleRotation, Graphics graphic)
		{
			Painter.ToInitialize(graphic);
			var minHeightAndWidth = Math.Min(width, height);
			var diagonalLength = Math.Sqrt(2) * (minHeightAndWidth * straight + minHeightAndWidth * diagonal) / 2;
			var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
			var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

			Painter.SetPosition(x0, y0);

			DrawSquare(minHeightAndWidth);
		}

		public static void DrawSquare(int minHeightAndWidth)
		{
			DrawDirection(0, minHeightAndWidth);
			DrawDirection(-Math.PI / 2, minHeightAndWidth);
			DrawDirection(Math.PI, minHeightAndWidth);
			DrawDirection(Math.PI / 2, minHeightAndWidth);
		}
	}
}