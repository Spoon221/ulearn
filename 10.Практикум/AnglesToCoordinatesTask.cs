using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbowPos = new PointF((float)(Manipulator.UpperArm * Math.Cos(shoulder)),
                (float)(Manipulator.UpperArm * Math.Sin(shoulder)));
            var wristPosAngle = shoulder + Math.PI + elbow;
            var wristPos = new PointF((float)(Manipulator.Forearm * Math.Cos(wristPosAngle) + elbowPos.X),
                (float)(Manipulator.Forearm * Math.Sin(wristPosAngle) + elbowPos.Y));
            var palmEndPosAngle = wristPosAngle + Math.PI + wrist;
            var palmEndPos = new PointF((float)(Manipulator.Palm * Math.Cos(palmEndPosAngle) + wristPos.X),
                (float)(Manipulator.Palm * Math.Sin(palmEndPosAngle) + wristPos.Y));

            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        private const double PI = Math.PI;

        [TestCase(PI / 2, PI / 2, PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        [TestCase(PI / 2, PI / 2, PI / 2, Manipulator.Forearm, Manipulator.UpperArm - Manipulator.Palm)]
        [TestCase(PI / 2, 3 * PI / 2, 3 * PI / 2, -(Manipulator.Forearm), Manipulator.UpperArm - Manipulator.Palm)]
        [TestCase(PI / 2, PI, 3 * PI, 0, Manipulator.Forearm + Manipulator.UpperArm + Manipulator.Palm)]
        [TestCase(0, PI, PI, Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm, 0)]
        [TestCase(PI / 2, PI, PI, 0, Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5);
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5);
            Assert.AreEqual(Manipulator.UpperArm, CountLength(joints[0], new PointF(0, 0)), 1e-5);
            Assert.AreEqual(Manipulator.Forearm, CountLength(joints[0], joints[1]), 1e-5);
            Assert.AreEqual(Manipulator.Palm, CountLength(joints[1], joints[2]), 1e-5);
        }

        public static double CountLength(PointF coordinateBefore, PointF coordinateAfter)
        {
            return Math.Sqrt((coordinateAfter.X - coordinateBefore.X) * (coordinateAfter.X - coordinateBefore.X)
                + (coordinateAfter.Y - coordinateBefore.Y) * (coordinateAfter.Y - coordinateBefore.Y));
        }
    }
}