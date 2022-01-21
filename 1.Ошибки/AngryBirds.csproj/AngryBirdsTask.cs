using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		const double G = 9.8f;

		/// <param name="speed">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		
		public static double FindSightAngle(double speed, double distance)
		{
			return Math.Asin(G * distance / (speed * speed)) / 2;
		}
	}
}