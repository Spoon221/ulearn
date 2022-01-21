using System;
using NUnit.Framework;

namespace Manipulation
{
    public class TriangleTask
    {
        /// <summary>
        /// Возвращает угол (в радианах) между сторонами a и b в треугольнике со сторонами a, b, c 
        /// </summary>
        public static double GetABAngle(double a, double b, double c)
        {
            return (SidesMakesTriangle(a, b, c))
                ? Math.Acos((a * a + b * b - c * c) / (2 * a * b))
                : double.NaN;
        }

        private static bool SidesMakesTriangle(double a, double b, double c)
        {
            return (Math.Min(Math.Min(a, b), c) >= 0)
                && (a + b + c - 2 * Math.Max(Math.Max(a, b), c) > -1e-9);
        }
    }

    [TestFixture]
    public class TriangleTask_Tests
    {
        [TestCase(3, 4, 5, Math.PI / 2)]
        [TestCase(1, 1, 1, Math.PI / 3)]
        [TestCase(-1, 1, 1, double.NaN)]
        [TestCase(1, -1, 1, double.NaN)]
        [TestCase(1, 1, -1, double.NaN)]
        [TestCase(0, 1, 1, double.NaN)]
        [TestCase(1, 0, 1, double.NaN)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(0, 0, 0, double.NaN)]
        [TestCase(1, 1, 3, double.NaN)]
        [TestCase(1, 1, 2, Math.PI)]
        [TestCase(2, 1, 1, 0)]
        [TestCase(3, 2, 1, 0)]
        [TestCase(1, 3, 2, 0)]
        [TestCase(2, 8, 18, double.NaN)]
        [TestCase(2, 5, 10, double.NaN)]
        public void TestGetABAngle(double a, double b, double c, double expectedAngle)
        {
            var angle = TriangleTask.GetABAngle(a, b, c);
            Assert.AreEqual(expectedAngle, angle, 1e-4);
        }
    }
}