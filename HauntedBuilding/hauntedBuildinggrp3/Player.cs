using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /*
    * Handles player information such as name, current floor, coordinates, and their inventory
    */
    class Player
    {
        private String name;
        private Floor floor;
        private Coordinate coord;
        private ArrayList inventory;

        public Player(String name, Floor floor, Coordinate coord, ArrayList items)
        {
            this.name = name;
            this.floor = floor;
            this.coord = coord;
            this.inventory = new ArrayList(items);
        }
        public String stringCoord()
        {
            return "(" + coord.x + "," + coord.y + ")";
        }

        public Floor Floor
        {
            set { this.floor = value; }
            get { return this.floor; }
        }

        public Coordinate Coord //getter and setter for coordinate
        {
            set { this.coord = value; }
            get { return this.coord; }
        }

        public void addItem(Item item)
        {
            this.inventory.Add(item);
        }

        public String Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        //helper for move()
        private bool isBarrier(int x, int y)
        {
            tileObj i = floor.peek(x, y);
            if (i == null) return false;
            if (i.iBarrier()) return true;
            return false;
        }
        //Move player given direction based on command
        //Checks for boundaries
        public bool move(Move where)
        {
            switch (where)
            {
                case Move.FORWARD: if (coord.x - 1 < 0) return false; //they hit boundary
                    //check if tring to walk into blocking object (e.g. walls, monsters)
                    if (isBarrier(coord.x - 1, coord.y)) return false;
                    coord.x--; break;

                case Move.RIGHT: if (coord.y + 1 > Constants.FLOOR_WIDTH - 1) return false;
                    if (isBarrier(coord.x, coord.y + 1)) return false;
                    coord.y++; break;

                case Move.BACKWARD: if (coord.x + 1 > Constants.FLOOR_LENGTH - 1) return false;
                    if (isBarrier(coord.x + 1, coord.y)) return false;
                    coord.x++; break;

                case Move.LEFT: if (coord.y - 1 < 0) return false;
                    if (isBarrier(coord.x, coord.y - 1)) return false;
                    coord.y--; break;
                default:
                    return false; //bad direction
            }

            return true; //success!
        }

        //TODO
        public bool enterElevator()
        {
            /*
            if (floor.elevatorAt(Coord))
            {
                floor.takeElevator(ref this);
                return true;
            }
             * */

            return false;
        }

        public Item pickup()
        {
            Item i = floor.pickupItem(coord);
            if (i == null) return null;

            //Case when pickuped item was hourlgass, don't add to inventory
            if (i.name() != "Hourglass")
                inventory.Add(i); //add to inventory

            return i;
        }

        public String showInventory()
        {
            if (inventory.Count == 0) return "nothing";

            String invtList = "";
            foreach (Item item in inventory)
                invtList = invtList + item.name() + ", ";

            return invtList;
        }

        //inspect all items
        public String inspectItems()
        {
            if (inventory.Count == 0)
                return "Empty Inventory.";

            String hints = "";
            foreach (Item item in inventory)
                hints = hints + item.name() + ": " + item.getDescription() + System.Environment.NewLine;

            return hints;
        }

        //insepct a specific item, give the name
        public String inspectItem(String name)
        {
            foreach (Item item in inventory)
            {
                if (item.name() == name)
                    return item.getDescription();
            }

            return "You don't have that Item.";
        }

        //Check if the case is locked
        public bool lockedCase()
        {
            foreach (Item item in inventory)
            {
                if (item.name() == Constants.ITEMS[(int)iName.SECRETCASE])
                    return ((Case)item).isLocked();
            }

            return true;
        }

        public CaseState tryUnlock(PassCode pc)
        {
            foreach (Item item in inventory)
                if (item.name() == Constants.ITEMS[(int)iName.SECRETCASE])
                {
                    if (!((Case)item).isLocked())
                        return CaseState.STALL; //case already unlocked

                    if (((Case)item).matchCode(pc) == true)
                        return CaseState.UNLOCKED; //case unlocked!

                    return CaseState.LOCKED; //bad pass code attempt
                }

            return CaseState.NOTHAVE;//player does not have case
        }

        //Helper for useFlashLight(). true if player within distance 1.
        private bool nearMe(Coordinate what)
        {
            return Math.Abs(what.x - coord.x) <= 1 && Math.Abs(what.y - coord.y) <= 1;
        }
        //Return a list of NamedCoord that are near the current player's coordinate;
        public ArrayList useFlashLight(Graphic graphic)
        {
            ArrayList marks = new ArrayList();

            foreach (NamedCoord mark in floor.Coordinates)
            {
                if (nearMe(mark.coord))
                {
                    marks.Add(mark);
                    if (mark.name == "Monster")
                    {
                        graphic.Text += "Monster!" + System.Environment.NewLine;
                    }
                }
            }

            return marks;
        }

        public void dropItems()
        {
            inventory.Clear();
        }

        public DoorState tryUnlockDoor(PassCode pc)
        {
            Door door;
            if ((door = floor.refDoor(coord)) == null) return DoorState.NOTNEAR;

            if (!door.isLocked()) return DoorState.STALL;

            if (door.matchCode(pc)) return DoorState.UNLOCKED;

            return DoorState.LOCKED;
        }

        public DoorState enterDoor()
        {
            Door door;
            if ((door = floor.refDoor(coord)) == null) return DoorState.NOTNEAR;

            if (door.isLocked()) return DoorState.LOCKED;

            return DoorState.UNLOCKED;
        }
    }
}