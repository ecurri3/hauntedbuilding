using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game{
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

    //TODO 
    /* Find a way to setup the three elevators for each floor and
     * have them references the appropriate floors.
     * */

    /*
     * Handles the creation and initialization of Floor
     * 
     * Randomly generates positions of key items and assigns the passcode a position
     */
    
    class Floor{
        private int number;           //floor number
        private Tile[,] floor = new Tile[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];
        private PassCode pc; //passcode for case
        private PassCode doorPC;
        private Coordinate[] elevators;
        private ArrayList coordinates; //has coordinates for all items/elevators

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

            for (int i = 0; i < Constants.NUM_ELEVATORS; i++)
            {
                this.elevators[i] = new Coordinate(elevators[i].x, elevators[i].y);
                taken[elevators[i].x, elevators[i].y] = true;

                if (i != 0)
                    this.coordinates.Add(new NamedCoord("WrongElevator", this.elevators[i]));
                else //The correct elevator is at index 0
                    this.coordinates.Add(new NamedCoord("CorrectElevator", this.elevators[0]));
            }

            //Random decimal pass code
            if (pc == null)
            {
                this.pc = new PassCode(Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10));
            }
            else this.pc = pc;

            //May need to pass a doorPC from database
            this.doorPC = new PassCode(Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10));

            int x, y;
            if (number == 1) //Generate a door on first floor
            {
                do
                {
                    x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                    y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
                } while (taken[x, y]);

                floor[x, y].Item = new Door(this.doorPC, true);

                taken[x, y] = true;

                this.coordinates.Add(new NamedCoord("Door", new Coordinate(x, y)));
            }

            
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
                        if(number != 1)
                        floor[x, y].Item = new Case(Constants.ITEMS[i],
                                                    "Check at position (" + this.elevators[0].x + "," + this.elevators[0].y + ")",
                                                    this.pc, true);
                        else //The case has a hint on how to unlock the door on the first floor
                        floor[x, y].Item = new Case(Constants.ITEMS[i],
                                                    "Your way out is " + this.doorPC.code[0] + ", " + this.doorPC.code[1] + ", " + this.doorPC.code[2] ,
                                                    this.pc, true);
                    }
                    else if (i == (int)iName.MONSTER)
                    {
                        floor[x, y].Item = new Monster(Constants.ITEMS[i], "Doesn't matter");
                    }
                    else
                    {
                        floor[x, y].Item = new Tool(Constants.ITEMS[i],
                                                    "Digit " + (i+1) + ": " + this.pc.code[i]);
                    }

                    this.coordinates.Add(new NamedCoord(Constants.ITEMS[i], new Coordinate(x, y)));
                    taken[x, y] = true;
                }
            }



        }

        //Picks up item at a given tile and removes the item from that tile
        public Item pickupItem(Coordinate c)
        {
            if (floor[c.x, c.y].Item == null) return null;
            Item i = floor[c.x,c.y].Item;
            floor[c.x, c.y].Item = null; //remove item from that tile
            coordinates.Remove(i.name());
            return i;
        }

        public Door refDoor(Coordinate c)
        {
            //no door at that coordinate
            if (floor[c.x, c.y].Item == null || floor[c.x, c.y].Item.name() != "Door") return null;

            return (Door)floor[c.x, c.y].Item;
        }

        public int Number{
            set {this.number = value;}
            get{return this.number;}
        }

        public ArrayList Coordinates
        {
            set { this.coordinates = value; }
            get { return this.coordinates; }
        }

        //returns passcode
        public PassCode getPassCode() { return pc; }

        //Helper to get random elevator coord
        public Coordinate someElevatorCoord()
        {
            Coordinate e = elevators[Constants.randGen.Next(0, Constants.NUM_ELEVATORS)];
            return new Coordinate(e.x, e.y);
        }
    }

    /*
     * Handles player information such as name, current floor, coordinates, and their inventory
     */
    class Player{
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
            set { this.coord = value;}
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

        //Move player given direction based on command
        //Checks for boundaries
        public bool move(Move where)
        {
            switch (where)
            {
                case Move.FORWARD: if(coord.x - 1 < 0) return false; //they hit boundary 
                        coord.x--; break;

                case Move.RIGHT: if (coord.y + 1 > Constants.FLOOR_WIDTH-1) return false;
                        coord.y++; break;

                case Move.BACKWARD: if (coord.x + 1 > Constants.FLOOR_LENGTH-1) return false;
                        coord.x++; break;

                case Move.LEFT: if (coord.y - 1 < 0) return false;
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

        public String pickup()
        {
            Item i = floor.pickupItem(coord);
            if (i == null) return "nothing";

            inventory.Add(i); //add to inventory
            return i.name();
        }

        public String showInventory()
        {
            if(inventory.Count == 0) return "nothing";

            String invtList = "";
            foreach (Item item in inventory)
                invtList = invtList + item.name() + ", ";

            return invtList;
        }

        //inspect all items
        public String inspectItems()
        {
            if (inventory.Count == 0)
                return "Empty Inventory!";


            String hints = "";
            foreach (Item item in inventory)
                hints = hints + item.name() + ": "+ item.getHint() + System.Environment.NewLine;

            return hints;
        }

        //insepct a specific item, give the name
        public String inspectItem(String name)
        {
            foreach (Item item in inventory)
            {
                if (item.name() == name)
                    return item.getHint();
            }

            return "You don't have that Item!";
        }

        //Check if the case is locked
        public bool lockedCase()
        {
            foreach(Item item in inventory)
            {
                if(item.name() == Constants.ITEMS[(int)iName.SECRETCASE])
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
                        graphic.Text = "Monster!";
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

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private CorrectElevator[] correct_elevator; 
        private WrongElevator[] wrong_elevator;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";

        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame(GameState gs)
        {
            floors = new Floor[Constants.NUM_FLOORS]; //Creating 10 foors
            correct_elevator = new CorrectElevator[Constants.NUM_FLOORS];
            wrong_elevator = new WrongElevator[Constants.NUM_FLOORS];

            // Generate Elevator sequence
            //generate a random sequence of correct elevators
            int[] correct_seq = new int[10] {1,3,5,7,9,2,4,6,8,10};
            int numFloors = Constants.NUM_FLOORS;
            int x1, y1, x2,y2;

            /* may be needed later
            bool[,] taken = new bool[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                    taken[i, j] = false;
             */

            //initializes the elevators on each floor with an indication of its path
            for (int i = numFloors-1; i >= 0; i--)
            {
                x1 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y1 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

                correct_elevator[i] = new CorrectElevator(x1, y1, i+1);

                do
                {
                    x2 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                    y2 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
                } while ((x2 == x1) && (y2 == y1));

                wrong_elevator[i] = new WrongElevator(x2, y2, i + 1);
            }

            for (int i = 0; i < numFloors; i++)
            {
                int currloc = correct_seq[i];
                int prevLoc;
                int nextLoc;

                if (i == 0)
                {
                    prevLoc = correct_seq[i + 1];
                    correct_elevator[currloc - 1].setPattern(prevLoc, -1);
                }
                else if (i == (numFloors - 1))
                {
                    nextLoc = correct_seq[i - 1];
                    correct_elevator[currloc - 1].setPattern(-1, nextLoc);
                }
                else
                {
                    prevLoc = correct_seq[i + 1];
                    nextLoc = correct_seq[i - 1];
                    correct_elevator[currloc - 1].setPattern(prevLoc, nextLoc);
                }

            }

           //TODO error check gs floor number, coord, and pass code digits
           //error check coord
            if (gs.coord.x < 0 || gs.coord.x > Constants.FLOOR_LENGTH - 1 ||
                gs.coord.y < 0 || gs.coord.y > Constants.FLOOR_WIDTH - 1)
                gs.coord = new Coordinate(0, 0); //change bad coord to default


            Coordinate[] elevators = new Coordinate[Constants.NUM_ELEVATORS];
            for (int i = 0; i < Constants.NUM_FLOORS; i++)
            {
                elevators[0] = correct_elevator[i].getCoord();
                elevators[1] = wrong_elevator[i].getCoord();

                if (gs.floorNumber == i + 1) //Only restore settings of one floor
                    floors[i] = new Floor(i + 1, gs.pc, gs.have, elevators);
                else
                    floors[i] = new Floor(i + 1, null, null, elevators);
            }

            ArrayList items = new ArrayList();
            for (int i = 0; i < Constants.NUM_ITEMS; i++)
                if (gs.have[i])
                {
                    if(i == (int)iName.SECRETCASE)
                        items.Add(new Case(Constants.ITEMS[i], "Got to elevator X", gs.pc, gs.caseLocked)); //get real hint form DB
                    else
                        items.Add(new Tool(Constants.ITEMS[i], "Digit " + (i + 1) + ": " + gs.pc.code[i]));
                }

            player = new Player(gs.playerName, floors[gs.floorNumber-1], gs.coord, items);

            return new Graphic(player.Coord, null,player.Name + " is on floor " +  player.Floor.Number + System.Environment.NewLine);
        }

        public Player getPlayer()
        {
            return player;
        }

        //Command ENTER UP & ENTER Down helper
        private void enterElevator(bool up, Graphic graphic)
        {
            int currX = player.Coord.x;
            int currY = player.Coord.y;
            int currfloor = player.Floor.Number - 1;
            int newFloor = player.Floor.Number - 1;
            int flag = 0;

            if (correct_elevator[currfloor].isThereElevator(currX, currY))  //for now, the elevator only goes down
            {
                if (up ? correct_elevator[currfloor].canGoUp() : correct_elevator[currfloor].canGoDown())
                {
                    newFloor = up ? correct_elevator[currfloor].go_up() : correct_elevator[currfloor].go_down();
                    newFloor--;

                    flag = 2;
                }
                else
                    flag = 1;
            }

            if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
            {
                if (up ? wrong_elevator[currfloor].canGoUp() : wrong_elevator[currfloor].canGoDown())
                {
                    newFloor = up ? wrong_elevator[currfloor].go_up() : correct_elevator[currfloor].go_down();
                    newFloor--;

                    flag = 2;
                }
                else
                    flag = 1;
            }

            switch (flag)
            {
                case 2: //Elevator taken
                    player.dropItems();
                    player.Floor = floors[newFloor];                   //set the new floor
                    player.Coord = player.Floor.someElevatorCoord();

                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                   player.Name + " is on floor " + player.Floor.Number + " at " +
                                   player.stringCoord() + System.Environment.NewLine;

                    graphic.setImage(player.Coord, null);
                    break;
                case 1: //Elevator limit reached
                    graphic.Text = "You can't go further " + (up ? "up." : "down.");
                    break;
                default:
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
                    break;
            }
        }

        private void endGame(){
            floors = null;
            player = null;
            correct_elevator = null; 
            wrong_elevator = null;
        }

        public Graphic enterCommand(String command)
        {
            Graphic graphic = new Graphic(player.Coord,null,"Bad command! Click Help for help.");

            Move where = Move.STALL;
            switch (command) //see if movement command
            {
                case "FORWARD": where = Move.FORWARD; break;
                case "RIGHT": where = Move.RIGHT; break;
                case "BACKWARD": where = Move.BACKWARD; break;
                case "LEFT": where = Move.LEFT; break;
            }

            if (where != Move.STALL) //It is a move command
            {
                //TODO not just a wall but maybe an elevator.
                if (!player.move(where))
                    graphic.Text = "Your trying to move into a wall!" + System.Environment.NewLine +
                                        player.Name + " is at " + player.stringCoord() + System.Environment.NewLine;
                else
                {
                    graphic.setImage(player.Coord, null);
                    graphic.Text = player.Name + " moved to " + player.stringCoord() + System.Environment.NewLine;
                }
            }
            else if (command == "ENTER DOWN")
            {
                enterElevator(false, graphic); //false for Down
            }

            else if (command == "ENTER UP")
            {
                enterElevator(true, graphic); //true for Up
            }

            else if (command == "ENTER DOOR")
            {
                DoorState result = player.enterDoor();

                switch (result)
                {
                    case DoorState.UNLOCKED: endGame();
                                             return new Graphic();
                    case DoorState.LOCKED: graphic.Text = "The door is locked.";
                        break;
                    case DoorState.NOTNEAR: graphic.Text = "You are not near a door.";
                        break;
                    default:
                        graphic.Text = "This should not happen.";
                        break;
                }
            }

            else if (command == "PICKUP")
            {
                graphic.Text = "You picked up " + player.pickup() +
                               " at " + player.stringCoord() + System.Environment.NewLine;
            }
            else if (command == "INVT")
            {
                graphic.Text = "You are carrying: " + player.showInventory() + System.Environment.NewLine;
            }
            else if (command == "INSPECT")
            {
                graphic.Text = player.inspectItems() + System.Environment.NewLine;
            }
            else if (command == "FLASHLIGHT")
            {
                //reveal surrounding areas
                graphic.Text = "Used Flashlight" + System.Environment.NewLine;
                graphic.setImage(player.Coord, player.useFlashLight(graphic));
            }

            return graphic;
        }

        //attempt at cracking the case
        public Graphic tryUnlock(int what, int digit1, int digit2, int digit3)
        {
            if (what == 0)
            {
                CaseState result1 = player.tryUnlock(new PassCode(digit1, digit2, digit3));

                switch (result1)
                {
                    case CaseState.NOTHAVE: return new Graphic("You do not have a case.");
                    case CaseState.STALL: return new Graphic("Case already unlocked.");
                    case CaseState.UNLOCKED: return new Graphic("Case Unlocked!");
                    case CaseState.LOCKED:
                    default: return new Graphic("Wrong pass code, try again.");
                }
            }

            DoorState result = player.tryUnlockDoor(new PassCode(digit1, digit2, digit3));

            switch (result)
            {
                case DoorState.NOTNEAR: return new Graphic("You are not near a door.");
                case DoorState.STALL: return new Graphic("Door already unlocked.");
                case DoorState.UNLOCKED: return new Graphic("Door Unlocked!");
                case DoorState.LOCKED:
                default: return new Graphic("Wrong pass code, try again.");
            }
        }

        public Graphic getHelp()
        {
            String howto = "Enter commands in the textbox and click 'Enter'" + System.Environment.NewLine +
                            "The following are supported commands" + System.Environment.NewLine;
            String move = "LEFT: Move left" + System.Environment.NewLine +
                            "RIGHT: Move right" + System.Environment.NewLine +
                            "FORWARD: Move forward" + System.Environment.NewLine +
                            "BACKWARD: Move backward" + System.Environment.NewLine;
            String enter = "ENTER: Enter the elevator" + System.Environment.NewLine;
            String pickup = "PICKUP: Pickup an item" + System.Environment.NewLine;
            String invt = "INVT: Display items currently held by the player" + System.Environment.NewLine;
            String backTogame = "Click 'Help' to go back to game screen" + System.Environment.NewLine;
            
            return new Graphic(howto + move + enter + pickup + invt + backTogame);
        } 

        //returns the current State
        public GameState currentState()
        {
            bool[] have = new bool[Constants.NUM_ITEMS];

            String inventory = player.showInventory();
            for (int i = 0; i < Constants.NUM_ITEMS;  i++)
                have[i] = inventory.Contains(Constants.ITEMS[i]);

            return new GameState(player.Name, player.Floor.Number, 
                                 player.Floor.getPassCode(), player.Coord,
                                 player.lockedCase(),
                                 have);
        }

    }
}