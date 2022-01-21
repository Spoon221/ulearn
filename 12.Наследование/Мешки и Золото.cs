using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            CreatureCommand diggerCommand = new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = 0
            };
            if (Game.KeyPressed == Keys.Up &&
                y - 1 >= 0 &&
                !(Game.Map[x, y - 1] is Sack))
                diggerCommand.DeltaY--;
            if (Game.KeyPressed == Keys.Down &&
                y + 1 < Game.MapHeight &&
                !(Game.Map[x, y + 1] is Sack))
                diggerCommand.DeltaY++;
            if (Game.KeyPressed == Keys.Right &&
                x + 1 < Game.MapWidth &&
                !(Game.Map[x + 1, y] is Sack))
                diggerCommand.DeltaX++;
            if (Game.KeyPressed == Keys.Left &&
                x - 1 >= 0 &&
                !(Game.Map[x - 1, y] is Sack))
                diggerCommand.DeltaX--;
            return diggerCommand;
        }

        public bool DeadInConflict(ICreature conflictedObject)
            => conflictedObject is Sack;

        public int GetDrawingPriority()
            => 0;

        public string GetImageFileName()
            => "Digger.png";
    }

    class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
            => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
            =>  true;

        public int GetDrawingPriority()
            => 5;

        public string GetImageFileName()
            => "Terrain.png";
    }

    class Sack : ICreature
    {
        public int CountFall = 0;
        public bool SackFalling = false;
        public CreatureCommand Act(int x, int y)
        {
            if (y + 1 < Game.MapHeight &&
                (Game.Map[x, y + 1] == null ||
                (Game.Map[x, y + 1] is Player &&
                SackFalling)))
            {
                CountFall++;
                SackFalling = true;
                return new CreatureCommand() 
                { 
                    DeltaX = 0,
                    DeltaY = 1
                };
            }
            if (CountFall > 1)
                return new CreatureCommand() 
                {
                    DeltaX = 0,
                    DeltaY = 0,
                    TransformTo = new Gold() 
                };
            CountFall = 0;
            SackFalling = false;
            return new CreatureCommand() 
            { 
                DeltaX = 0,
                DeltaY = 0
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
            => false;

        public int GetDrawingPriority()
            => 3;

        public string GetImageFileName()
            => "Sack.png";
    }

    class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
            => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.Scores += 10;
            return true;
        }

        public int GetDrawingPriority()
            => 3;

        public string GetImageFileName()
            => "Gold.png";
    }
}