namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                MoveRobot(robot, Direction.Right, width - 3);
                MoveRobot(robot, Direction.Down, 2);
                MoveRobot(robot, Direction.Left, width - 3);
                if (!robot.Finished)
                {
                    MoveRobot(robot, Direction.Down, 2);
                }
            }
        }

        public static void MoveRobot(Robot robot, Direction direction, int stepCount)
        {
            for (var step = 0; step < stepCount; step++)
            {
                robot.MoveTo(direction);
            }
        }
    }
}