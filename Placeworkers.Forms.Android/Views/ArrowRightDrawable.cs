using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Views.Animations;

namespace Placeworkers.Forms
{
	public class ArrowRightDrawable : Drawable
	{
		private Paint arrowPaint;
		private Path arrowPath;
		private float density;
		private int diameter = 25, diameter_calc, radius_calc;

		public ArrowRightDrawable(Context context)
		{
			//Getting density "dp"
			density = context.Resources.DisplayMetrics.ScaledDensity;
			//Calculating actual diameter
			diameter_calc = (int)density * diameter;
			radius_calc = diameter / 2;

			//Creating paint
			arrowPaint = new Paint();
			arrowPaint.AntiAlias = true;
			arrowPaint.Color = Color.Red;

			//Initialize path
			arrowPath = new Path();
			//this.SetWillNotDraw(false);
		}

		private int startX, startY, currentX, currentY;

		public override int Opacity
		{
			get
			{
				return 1;
			}
		}

		public override void Draw(Canvas canvas)
		{
			startX = canvas.Width;
			startY = canvas.Height / 2;

			canvas.Rotate(-45, startX, startY);

			arrowPath.Reset();
			currentX = startX;
			currentY = startY;
			//Move to right end side center of the canvas
			arrowPath.MoveTo(currentX, currentY);
			//Lets move up
			currentY = radius_calc;
			arrowPath.LineTo(currentX, currentY);
			//Now draw circle
			currentX -= radius_calc;
			arrowPath.AddCircle(currentX, radius_calc, radius_calc, Android.Graphics.Path.Direction.Ccw);
			currentX -= radius_calc;

			arrowPath.LineTo(currentX, currentY);
			// Go to inner side center point
			currentX = startX - diameter_calc;
			currentY = startY - diameter_calc;
			arrowPath.LineTo(currentX, currentY);
			// Go left
			currentX = startX - startY + radius_calc;
			arrowPath.LineTo(currentX, currentY);
			//Draw circle
			currentY += radius_calc;
			canvas.DrawCircle(currentX, currentY, radius_calc, arrowPaint);
			currentY += radius_calc;
			arrowPath.LineTo(currentX, currentY);
			//Go to start
			arrowPath.LineTo(startX, startY);

			canvas.DrawPath(arrowPath, arrowPaint);
		}

		public override void SetAlpha(int alpha)
		{
			
		}

		public override void SetColorFilter(ColorFilter colorFilter)
		{
			
		}
	}
}
