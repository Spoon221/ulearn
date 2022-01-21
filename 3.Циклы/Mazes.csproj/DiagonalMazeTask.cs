namespace Mazes
{
    public static class DiagonalMazeTask
    {
        static int moveLeft = 1;
        static int moveDown = 1;
        static int countMoveLeft = 0;
        static int countMoveDown = 0;
        public static void MoveOut(Robot robot, int width, int height)
        {
            if (width >= height)
                MoveIfWidthLargerHeight(robot, width, height, moveLeft,
               moveDown, countMoveLeft, countMoveDown);
            if (width <= height)
                MoveIfHeightlargerWidth(robot, width, height, moveLeft,
                moveDown, countMoveLeft, countMoveDown);
        }

        private static void MoveRobot(Robot robot, int width,Direction direction)
        {
            for (int i = 0; i < width; i++)
                robot.MoveTo(direction);
        }

        private static void MoveIfHeightlargerWidth(Robot robot, int width, int height,
        int moveLeft, int moveDown, int countMovesLeft, int countMovesDown)
        {
            moveDown = (height - 2) / (width - 2);
            countMovesDown = width - 2;
            countMovesLeft = width - 3;
            for (int i = 0; i < countMovesLeft; i++)
            {
                MoveRobot(robot, moveDown, Direction.Down);
                MoveRobot(robot, moveLeft, Direction.Right);
            }
            MoveRobot(robot, moveDown, Direction.Down);
        }

        private static void MoveIfWidthLargerHeight(Robot robot, int width, int height,
        int moveLeft, int moveDown, int countMovesLeft, int countMovesDown)
        {
            moveLeft = (width - 2) / (height - 2);
            countMovesDown = height - 3;
            countMovesLeft = height - 2;
            for (int i = 0; i < countMovesDown; i++)
            {
                MoveRobot(robot, moveLeft, Direction.Right);
                MoveRobot(robot, moveDown, Direction.Down);
            }
            MoveRobot(robot, moveLeft, Direction.Right);
        }
    }
}