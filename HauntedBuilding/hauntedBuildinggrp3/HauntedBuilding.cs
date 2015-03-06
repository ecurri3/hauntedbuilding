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
        private PassCode pc; //passcode
        public ArrayList coordinates; //has all items and correct elevator

        /*
         * Gives each place in the Floor a Tile class
         * 
         * See Tile for more information
         */

        public Floor(int number, PassCode pc, bool haveNote, bool havePhone, bool haveAudio, bool haveCase, Coordinate correctElevator)
        {
            this.number = number;
            this.coordinates = new ArrayList();

            //Prevent certain items from overlapping on the same tile
            bool[,] taken = new bool[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for(int i = 0; i < Constants.FLOOR_LENGTH;i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    floor[i, j] = new Tile();
                    taken[i, j] = false;
                }

            coordinates.Add(new NamedCoord("CorrectElevator", correctElevator));

            //Random decimal pass code
            if (pc == null)
            {
                this.pc = new PassCode(Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10),
                                       Constants.randGen.Next(0, 10));
            }
            else this.pc = pc;

            int x, y; //random coordinates

            x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
            y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

            //Place case at random tile
            if (!haveCase)
            {
                floor[x, y].Item = new Case(Constants.ITEMS[(int)iName.SECRETCASE], 
                                            "Check at position (" + correctElevator.x + "," + correctElevator.y + ")", 
                                            this.pc, true);
                this.coordinates.Add(new NamedCoord(Constants.ITEMS[(int)iName.SECRETCASE], new Coordinate(x, y)));
                taken[x, y] = true;
            }

            //Randomly place three items, each with one digit of the pass code
            //Making sure they don't overlap
            do
            {
                x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (taken[x,y]); //can't be same as case


            if (!haveNote)
            {
                floor[x, y].Item = new Tool(Constants.ITEMS[(int)iName.NOTE], "First digit: " + this.pc.a.ToString());
                this.coordinates.Add(new NamedCoord(Constants.ITEMS[(int)iName.NOTE], new Coordinate(x, y)));
                taken[x, y] = true;
            }

            do
            {
                x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (taken[x,y]);


            if (!havePhone)
            {
                floor[x, y].Item = new Tool(Constants.ITEMS[(int)iName.PHONE], "Second digit: " + this.pc.b.ToString());
                this.coordinates.Add(new NamedCoord(Constants.ITEMS[(int)iName.PHONE], new Coordinate(x, y)));
                taken[x, y] = true;            
            }

            do
            {
                x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (taken[x,y]);


            if (!haveAudio)
            {
                floor[x, y].Item = new Tool(Constants.ITEMS[(int)iName.AUDIO], "Third digit: " + this.pc.c.ToString());
                this.coordinates.Add(new NamedCoord(Constants.ITEMS[(int)iName.AUDIO], new Coordinate(x, y)));
                taken[x, y] = true;
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

        public int Number{
            set {this.number = value;}
            get{return this.number;}
        }

        //returns passcode
        public PassCode getPassCode() { return pc; }
    }

    /*
     * Handles player information such as name, current floor, coordinates, and their inventory
     */
    class Player{
        private String name;
        private Floor floor;
        private Coordinate coord; //may need to init to something
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
                if(item.name() == Constants.ITEMS[3]){
                    Case iCase = (Case)item;
                    return iCase.isLocked();
                }
            }

            return true;
        }

        public int tryUnlock(PassCode pc)
        {
            foreach (Item item in inventory)
            {
                if (item.name() == Constants.ITEMS[3])
                {
                    Case iCase = (Case)item;
                    if (!iCase.isLocked()) return 1; //case already unlocked

                    if (iCase.tryToUnlock(pc) == true) return 2; //case unlocked!
                    
                    return 3; //bad pass code attempt
                }
            }

            return 0;//player does not have case
        }

        public void dropItems()
        {
            inventory.Clear();
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

            floors = new Floor[Constants.NUM_FLOORS]; //Creating 10 foors
        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame(GameState gs)
        {
            correct_elevator = new CorrectElevator[Constants.NUM_FLOORS];
            wrong_elevator = new WrongElevator[Constants.NUM_FLOORS];

            // Generate Elevator sequence
            //generate a random sequence of correct elevators
            int[] correct_seq = new int[10] {1,3,5,7,9,2,4,6,8,10};
            int numFloors =Constants.NUM_FLOORS;

            //initializes the elevators on each floor with an indication of its path
            for (int i = numFloors-1; i >= 0; i--)
            {
                if(i == 7)
                    correct_elevator[i] = new CorrectElevator(0, 0, i + 1);
                else
                    correct_elevator[i] = new CorrectElevator(3, 1, i+1);

                wrong_elevator[i] = new WrongElevator(3, 2, i + 1);
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

            for (int i = 0; i < Constants.NUM_FLOORS; i++)
            {
                if (gs.floorNumber == i + 1)
                    floors[i] = new Floor(i+1, gs.pc, gs.haveNote, gs.havePhone, gs.haveAudio, gs.haveCase, correct_elevator[i].getCoord());
                else
                    floors[i] = new Floor(i + 1,null,false,false,false,false, correct_elevator[i].getCoord());
            }

            ArrayList items = new ArrayList();

            if (gs.haveNote) items.Add(new Tool(Constants.ITEMS[0], "First digit: " + gs.pc.a.ToString()));
            if (gs.havePhone) items.Add(new Tool(Constants.ITEMS[1], "Second digit: " + gs.pc.b.ToString()));
            if (gs.haveAudio) items.Add(new Tool(Constants.ITEMS[2], "Digit digit: " + gs.pc.c.ToString()));
            if (gs.haveCase) items.Add(new Case(Constants.ITEMS[3], "Got to elevator X", gs.pc, gs.caseLocked));

            player = new Player(gs.playerName, floors[gs.floorNumber-1], gs.coord, items);

            Graphic graphic = new Graphic(player.Coord, player.Floor.coordinates,player.Name + " is on floor " +  player.Floor.Number + System.Environment.NewLine);

            return graphic;
        }

        public Player getPlayer()
        {
            return player;
        }

        public Graphic enterCommand(String command)
        {
            Graphic graphic = new Graphic(player.Coord,player.Floor.coordinates,"Bad command! Click Help for help.");

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
                    graphic.setImage(player.Coord, player.Floor.coordinates);
                    graphic.Text = player.Name + " moved to " + player.stringCoord() + System.Environment.NewLine;
                }
            }
            else if (command == "ENTER DOWN")
            {
                int currX       = player.Coord.x;
                int currY       = player.Coord.y;
                int currfloor   = player.Floor.Number - 1;
                int newFloor    = player.Floor.Number - 1;
                bool took       = false;

                if (correct_elevator[currfloor].isThereElevator(currX,currY))  //for now, the elevator only goes down
                {
                    if (correct_elevator[currfloor].canGoDown())
                    {
                        newFloor = correct_elevator[currfloor].go_down(); //why not just -1 here?
                        newFloor--;//?

                        player.dropItems();
                        player.Floor = floors[newFloor];                   //set the new floor
                        player.Coord = correct_elevator[newFloor].getCoord();

                        took = true;
                    }
                }

                if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
                {
                    if (wrong_elevator[currfloor].canGoDown())
                    {
                        newFloor = wrong_elevator[currfloor].go_down();//why not just -1 here?
                        newFloor--; //?

                        player.dropItems();
                        player.Floor = floors[newFloor];                   //set the new floor
                        player.Coord = wrong_elevator[newFloor].getCoord();

                        took = true;
                    }
                }

                if (took)
                {
                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                   player.Name + " is on floor " + player.Floor.Number + " at " +
                                   player.stringCoord() + System.Environment.NewLine;

                    graphic.setImage(player.Coord, floors[newFloor].coordinates);
                }
                else
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
                
            }

            else if (command == "ENTER UP")
            {
                int currX       = player.Coord.x;
                int currY       = player.Coord.y;
                int currfloor   = player.Floor.Number - 1;
                int newFloor    = player.Floor.Number - 1;
                bool took       = false;

                if (correct_elevator[currfloor].isThereElevator(currX, currY))  //for now, the elevator only goes down
                {
                    if (correct_elevator[currfloor].canGoUp())
                    {
                        
                        newFloor = correct_elevator[currfloor].go_up();
                        newFloor--;

                        //buggy newFloor - 1 or +1?
                        player.dropItems();
                        player.Floor = floors[newFloor];                   //set the new floor
                        player.Coord = correct_elevator[newFloor].getCoord();

                        took = true;
                    }

                }

                if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
                {
                    if (wrong_elevator[currfloor].canGoUp())
                    {
                        
                        newFloor = wrong_elevator[currfloor].go_up();
                        newFloor--;

                        //buggy newFloor - 1 or +1?
                        player.dropItems();
                        player.Floor = floors[newFloor];                   //set the new floor
                        player.Coord = wrong_elevator[newFloor].getCoord();

                        took = true;
                    }

                }

                if (took)
                {
                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                   player.Name + " is on floor " + player.Floor.Number + " at " +
                                   player.stringCoord() + System.Environment.NewLine;

                    graphic.setImage(player.Coord, floors[newFloor].coordinates);
                }
                else
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
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
                graphic.Text = player.inspectItems() +  System.Environment.NewLine;
            }

            return graphic;
        }

        //attempt at cracking the case
        public Graphic tryCase(int digit1, int digit2, int digit3)
        {
            int result = player.tryUnlock(new PassCode(digit1, digit2, digit3));

            switch (result)
            {
                case 0: return new Graphic(player.Coord, player.Floor.coordinates, "You do not have a case.");
                case 1: return new Graphic(player.Coord, player.Floor.coordinates, "Case already unlocked.");
                case 2: return new Graphic(player.Coord, player.Floor.coordinates, "Case Unlocked!");
                default: return new Graphic(player.Coord, player.Floor.coordinates, "Wrong pass code, try again.");
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
            return new GameState(player.Name, player.Floor.Number, 
                                 player.Floor.getPassCode(), player.Coord,
                                 player.lockedCase(),
                                 player.showInventory().Contains(Constants.ITEMS[3]),
                                 player.showInventory().Contains(Constants.ITEMS[0]),
                                 player.showInventory().Contains(Constants.ITEMS[1]),
                                 player.showInventory().Contains(Constants.ITEMS[2]));
        }

    }
}