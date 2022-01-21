namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// Этот метод расчитывает угла отскока шарика от стены.
        /// </summary>
        /// <param name="directionRadians">Угол направления движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
        /// <returns>Угол траектории шара оси в OX в; радианах</returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            return 2 * wallInclinationRadians - directionRadians;
        }
    }
}