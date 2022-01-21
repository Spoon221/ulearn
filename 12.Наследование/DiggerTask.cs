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
            if (Game.KeyPressed == Keys.Right &&
                x + 1 < Game.MapWidth)
                diggerCommand.DeltaX++;
            if (Game.KeyPressed == Keys.Left &&
                x - 1 >= 0)
                diggerCommand.DeltaX--;
            if (Game.KeyPressed == Keys.Down &&
                y + 1 < Game.MapHeight)
                diggerCommand.DeltaY++;
            if (Game.KeyPressed == Keys.Up &&
                y - 1 >= 0)
                diggerCommand.DeltaY--;
            return diggerCommand;
        }

        public bool DeadInConflict(ICreature conflictedObject)
            => false;

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
            => true;

        public int GetDrawingPriority()
            => 1;

        public string GetImageFileName() 
            => "Terrain.png";
    }
}