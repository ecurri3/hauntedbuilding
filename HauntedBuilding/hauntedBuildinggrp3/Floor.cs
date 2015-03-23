using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    // FORWARD decrements X
    // BACKWARD increments x
    // LEFT decrements Y
    // RIGHT increments Y

    // Coordinate (9,4) is marked as [x]. We use (x,y) format.
    //Johnny starts on the 10th floor at coordinate (9,4)
    // Y is width, X is length

    /*   0        Y         9
     * 0 [][][][][][][][][][]
     *   [][][][][][][][][][]
     *   [][][][][][][][][][]
     *   [][][][][][][][][][] 
     * X [][][][][][][][][][]
     *   [][][][][][][][][][] 
     *   [][][][][][][][][][] 
     *   [][][][][][][][][][]
     *   [][][][][][][][][][]
     * 9 [][][][][x][][][][][]
     * */


    /*
     * Handles the creation and initialization of Floor
     * 
     * Randomly generates positions of key items and assigns the passcode a position
     */

    class Floor
    {
        private int number;           //floor number
        private Tile[,] floor = new Tile[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];
        private PassCode pc; //passcode for case
        private PassCode doorPC = null; //be default only first floor has a doorPC
        private Coordinate[] elevators;
        private ArrayList coordinates; //has coordinates for all items/elevators

        private delegate void Arch(Floor f, bool[,] taken);
        //array of "pointers" to functions. Used to build walls
        static private Arch[] architect = new Arch[] {architect1, architect2};


        //prototype for making floors complex with rooms
        //NOTE: Buggy, for some reason some items are still placed on taken spots after architect runs
        //TODO find a better way to create this
        private static void architect1(Floor f, bool[,] taken)
        {
            Tile[,] floor = f.floor;
            ArrayList coordinates = f.coordinates;

            //too small to design on that floor
            if (Constants.FLOOR_LENGTH < 10 || Constants.FLOOR_WIDTH < 10) return;

            //int fl = Constants.FLOOR_LENGTH;
            //int fw = Constants.FLOOR_WIDTH;

            taken[0, 3] = true;

            //Avoids entrance being blocked
            taken[1, 3] = true;
            taken[1, 2] = true;
            taken[1, 4] = true;

            taken[2, 3] = true;
            taken[3, 3] = true;
            taken[3, 2] = true;
            taken[3, 1] = true;
            taken[3, 0] = true;

            //Add wall objects
            floor[0, 3].Obj = new Wall();

            floor[2, 3].Obj = new Wall();
            floor[3, 3].Obj = new Wall();
            floor[3, 2].Obj = new Wall();
            floor[3, 1].Obj = new Wall();
            floor[3, 0].Obj = new Wall();


            //add to floor coordinates list, useful for displaying to graphic
            coordinates.Add(new NamedCoord("Wall", new Coordinate(0,3), 0));
            
            coordinates.Add(new NamedCoord("Wall", new Coordinate(2, 3), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, 3), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, 2), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, 1), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, 0), 0));
        }

        private static void architect2(Floor f, bool[,] taken)
        {
            Tile[,] floor = f.floor;
            ArrayList coordinates = f.coordinates;

            //too small to design on that floor
            if (Constants.FLOOR_LENGTH < 10 || Constants.FLOOR_WIDTH < 10) return;

            //int fl = Constants.FLOOR_LENGTH - 1; //floor length index based
            int fw = Constants.FLOOR_WIDTH - 1; //floor width index based

            taken[0, fw - 3] = true;

            //Avoids entrance being blocked
            taken[1, fw - 3] = true;
            taken[1, fw - 2] = true;
            taken[1, fw - 4] = true;

            taken[2, fw - 3] = true;
            taken[3, fw - 3] = true;
            taken[3, fw - 2] = true;
            taken[3, fw - 1] = true;
            taken[3, fw - 0] = true;

            //Add wall objects
            floor[0, fw - 3].Obj = new Wall();

            floor[2, fw - 3].Obj = new Wall();
            floor[3, fw - 3].Obj = new Wall();
            floor[3, fw - 2].Obj = new Wall();
            floor[3, fw - 1].Obj = new Wall();
            floor[3, fw - 0].Obj = new Wall();


            //add to floor coordinates list, useful for displaying to graphic
            coordinates.Add(new NamedCoord("Wall", new Coordinate(0, fw-3), 0));

            coordinates.Add(new NamedCoord("Wall", new Coordinate(2, fw-3), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, fw-3), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, fw-2), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, fw-1), 0));
            coordinates.Add(new NamedCoord("Wall", new Coordinate(3, fw-0), 0));
        }

        private void firstFloorSetup(bool[,] taken)
        {
            //Only needed on floor 1
            //May need to pass a doorPC from database
            this.doorPC = new PassCode(Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10));

            int x, y;

            do
            {
                x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (taken[x, y]);

            floor[x, y].Obj = new Door(this.doorPC, true);

            taken[x, y] = true;

            this.coordinates.Add(new NamedCoord("Door", new Coordinate(x, y), floor[x, y].Obj.getID()));
        }

        private void storeElevatorCoords(bool[,] taken, Coordinate[] elevators)
        {
            int x, y;
            for (int i = 0; i < Constants.NUM_ELEVATORS; i++)
            {
                x = elevators[i].x;
                y = elevators[i].y;

                //store the coordinates of all elevators
                this.elevators[i] = new Coordinate(x, y);
                taken[x, y] = true;

                if (i != 0)
                    this.coordinates.Add(new NamedCoord("WrongElevator", this.elevators[i], 0));
                else //The correct elevator is at index 0
                    this.coordinates.Add(new NamedCoord("CorrectElevator", this.elevators[0], 0));
            }
        }

        private void setUpPassCode(PassCode pc)
        {
            //Random decimal pass code
            if (pc == null)
            {
                this.pc = new PassCode(Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10));
            }
            else this.pc = pc;
        }

        private void putItems(bool[,] taken, bool[] have)
        {
            int x, y;
            for (int i = 0; i < Constants.NUM_ITEMS; i++)
            {
                do
                {
                    x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                    y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
                } while (taken[x, y]);

                //Place item at random tile
                if (have == null || !have[i])
                {
                    if (i == (int)iName.SECRETCASE)
                    {
                        if (number != 1)
                            floor[x, y].Obj = new Case(Constants.ITEMS[i],
                                                        "Check at position (" + this.elevators[0].x + "," + this.elevators[0].y + ")",
                                                        this.pc, true);
                        else //The case has a hint on how to unlock the door on the first floor
                            floor[x, y].Obj = new Case(Constants.ITEMS[i],
                                                        "Your way out is " + this.doorPC.code[0] + ", " + this.doorPC.code[1] + ", " + this.doorPC.code[2],
                                                        this.pc, true);
                    }
                    else if (i == (int)iName.MONSTER)
                    {
                        floor[x, y].Obj = new Zombie();
                    }
                    else
                    {
                        floor[x, y].Obj = new Record(Constants.ITEMS[i], "Digit " + (i + 1) + ": " + this.pc.code[i]);
                    }

                    this.coordinates.Add(new NamedCoord(Constants.ITEMS[i], new Coordinate(x, y), floor[x, y].Obj.getID()));
                    taken[x, y] = true;
                }
            }
        }

        private void putHourglasses(bool[,] taken)
        {
            int x, y;

            int limit;
            int arrCols = Constants.hourglassTypes.GetUpperBound(1) + 1; //Get number of columns in hourglassTypes array
            //Max amount of hourglasses placed per time amount
            for (int j = 0; j < arrCols; j++)
            {
                limit = Constants.randGen.Next(0, Constants.hourglassTypes[1, j] + 1); //limit density for this type of hourglass
                for (int i = 0; i < limit; i++)
                {
                    do
                    {
                        x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                        y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
                    } while (taken[x, y]);

                    floor[x, y].Obj = new Hourglass(Constants.hourglassTypes[0, j]); //time bonus given by this hourglass
                    this.coordinates.Add(new NamedCoord("Hourglass", new Coordinate(x, y), floor[x,y].Obj.getID()));
                    taken[x, y] = true;
                }

            }

        }
        /*
         * Gives each place in the Floor a Tile class
         * 
         * See Tile for more information
         */
        public Floor(int number, PassCode pc, bool[] have, Coordinate[] elevators)
        {
            this.number = number;
            this.elevators = new Coordinate[Constants.NUM_ELEVATORS];
            this.coordinates = new ArrayList();

            //Prevent certain items from overlapping on the same tile
            bool[,] taken = new bool[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    floor[i, j] = new Tile();
                    taken[i, j] = false;
                }

            //Call a random architect function
            int x = Constants.randGen.Next(0,architect.GetUpperBound(0) + 1);
            architect[x](this, taken);
            if (number == 1) firstFloorSetup(taken);
            storeElevatorCoords(taken, elevators);
            setUpPassCode(pc);
            putItems(taken, have);
            putHourglasses(taken);
        }

        //Picks up item at a given tile and removes the item from that tile
        public Item pickupItem(Coordinate c)
        {
            if (floor[c.x, c.y].Obj == null || !floor[c.x, c.y].Obj.iCanPickup()) return null;
            Item i = (Item)floor[c.x, c.y].Obj;
            floor[c.x, c.y].Obj = null; //remove item from that tile

            //Remove from coordinates list, either by a unique ID or name
            coordinates.Remove(i.getID());

            return i;
        }

        //return a reference to a tileObj given coordinates
        public tileObj peek(int x, int y)
        {
            return floor[x, y].Obj;
        }

        //return a reference to the Door object
        public Door refDoor(Coordinate c)
        {
            //no door at that coordinate
            if (floor[c.x, c.y].Obj == null || floor[c.x, c.y].Obj.name() != "Door") return null;

            return (Door)floor[c.x, c.y].Obj;
        }

        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }

        public ArrayList Coordinates
        {
            set { this.coordinates = value; }
            get { return this.coordinates; }
        }

        //returns passcode
        public PassCode getPassCode() { return pc; }

        //Helper to get random elevator coord
        public Coordinate randElevatorCoord()
        {
            Coordinate e = elevators[Constants.randGen.Next(0, Constants.NUM_ELEVATORS)];
            return new Coordinate(e.x, e.y);
        }
    }
}