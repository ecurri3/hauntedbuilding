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
        public Coordinate noteCoord = null;
        public Coordinate phoneCoord = null;
        public Coordinate audioCoord = null;
        public Coordinate caseCoord = null;

        /*
         * Gives each place in the Floor a Tile class
         * 
         * See Tile for more information
         */

        public Floor(int number, PassCode pc, bool haveNote, bool havePhone, bool haveAudio, bool haveCase)
        {
            this.number = number;
            for(int i = 0; i < Constants.FLOOR_LENGTH;i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    floor[i, j] = new Tile();
                }

            int x, y; //random place of case

            x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
            y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

            //Random decimal pass code
            if (pc == null)
            {
                this.pc = new PassCode(Constants.randGen.Next(0, 10),
                                  Constants.randGen.Next(0, 10),
                                  Constants.randGen.Next(0, 10));
            }
            else this.pc = pc;

            //Place case at random tile
            if (!haveCase)
            {
                floor[x, y].Item = new Case(Constants.ITEMS[3], "Go to Elevator X", this.pc, true);
                this.caseCoord = new Coordinate(x, y);
            }

            int x1,y1,x2,y2,x3,y3;

            //Randomly place three items, each with one digit of the pass code
            //Making sure they don't overlap
            do
            {
                x1 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y1 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (x1 == x && y1 == y); //can't be same as case



            //rand = Constants.randGen.Next(0, 2);
            if (!haveNote)
            {
                floor[x1, y1].Item = new Tool(Constants.ITEMS[0], "First digit: " + this.pc.a.ToString());
                this.noteCoord = new Coordinate(x1, y1);
            }
            do
            {
                x2 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y2 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while ((x2 == x1 && y2 == y1) || (x2 == x && y2 == y));

            //rand = Constants.randGen.Next(0, 2);
            if (!havePhone)
            {
                floor[x2, y2].Item = new Tool(Constants.ITEMS[1], "Second digit: " + this.pc.b.ToString());
                this.phoneCoord = new Coordinate(x2, y2);
            }
            do
            {
                x3 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y3 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while ((x3 == x2 && y3 == y2) || (x3 == x1 && y3 == y1) || (x3 == x && y3 == y));

            //rand = Constants.randGen.Next(0, 2);
            if (!haveAudio)
            {
                floor[x3, y3].Item = new Tool(Constants.ITEMS[2], "Third digit: " + this.pc.c.ToString());
                this.audioCoord = new Coordinate(x3, y3);
            }
            }

        //Picks up item at a given tile and removes the item from that tile
        public Item pickupItem(Coordinate c)
        {
            if (floor[c.x, c.y].Item == null) return null;
            Item i = floor[c.x,c.y].Item;
            floor[c.x, c.y].Item = null; //remove item from that tile
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
    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private Elevator[] correct_elevator, wrong_elevator;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";

            floors = new Floor[Constants.NUM_FLOORS]; //Creating 10 foors
            correct_elevator = new CorrectElevator[10];
            wrong_elevator = new WrongElevator[10];
        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame(GameState gs)
        {
            // Generate Elevator sequence
            //generate a random sequence of correct elevators
            int[] correct_seq = new int[13] { -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, -1 };
            int last = 11;
            int next = 9;

            //initializes the elevators on each floor with an indication of its path
            for (int i = 9; i >= 0; i--, last--, next--)
            {
                correct_elevator[i] = new CorrectElevator(3, 1, correct_seq[last], correct_seq[next]);
                wrong_elevator[i] = new WrongElevator(3, 2, i + 1);
            }

            //TODO error check gs floor number, coord, and pass code digits
            //error check coord
            if (gs.coord.x < 0 || gs.coord.x > Constants.FLOOR_LENGTH - 1 ||
                gs.coord.y < 0 || gs.coord.y > Constants.FLOOR_WIDTH - 1)
                gs.coord = new Coordinate(0, 0); //change bad coord to default

            for (int i = 0; i < Constants.NUM_FLOORS; i++)
            {
                if (gs.floorNumber == i + 1)
                    floors[i] = new Floor(i+1, gs.pc, gs.haveNote, gs.havePhone, gs.haveAudio, gs.haveCase);
                else
                    floors[i] = new Floor(i + 1,null,false,false,false,false);
            }

            ArrayList items = new ArrayList();
            if (gs.haveNote) items.Add(new Tool(Constants.ITEMS[0], "First digit: " + gs.pc.a.ToString()));
            if (gs.havePhone) items.Add(new Tool(Constants.ITEMS[1], "Second digit: " + gs.pc.b.ToString()));
            if (gs.haveAudio) items.Add(new Tool(Constants.ITEMS[2], "Digit digit: " + gs.pc.c.ToString()));
            if (gs.haveCase) items.Add(new Case(Constants.ITEMS[3], "Got to elevator X", gs.pc, gs.caseLocked));

            player = new Player(gs.playerName, floors[gs.floorNumber-1], gs.coord, items);

            /*
            player.Floor = floors[9]; //start at the roof
            player.Name = "Johnny"; //for now we call him Johnny
            player.Coord = new Coordinate(0,0); //Floor matrix is zero indexed!! so 10th tile is 9
            */

            Graphic graphic = new Graphic(player.Coord,player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord ,player.Name + " is on floor " +  player.Floor.Number + System.Environment.NewLine);

            return graphic;
        }

        public Player getPlayer()
        {
            return player;
        }

        public Graphic enterCommand(String command)
        {
            Graphic graphic = new Graphic(player.Coord,player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord,"Bad command! Click Help for help.");

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
                    graphic.setImage(player.Coord, player.Floor.caseCoord, player.Floor.noteCoord, player.Floor.phoneCoord, player.Floor.audioCoord);
                    graphic.Text = player.Name + " moved to " + player.stringCoord() + System.Environment.NewLine;
                }
            }
            else if (command == "ENTER DOWN")
            {
                int currX     = player.Coord.x;
                int currY     = player.Coord.y;
                int currfloor = player.Floor.Number-1;
                int newFloor;

                //TODO

                if (currfloor == 1)
                {
                        graphic.Text = "You have reached the first floor. Such Wow... very play again... wow"; 
                }

                else if (correct_elevator[currfloor].isThereElevator(currX,currY))  //for now, the elevator only goes down
                {
                        newFloor = correct_elevator[currfloor].go_down();
                        newFloor--;

                        player.Floor = floors[newFloor];                   //set the new floor
                        player.Coord = correct_elevator[newFloor].getCoord();

                        graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                        player.Name + " is on floor " + player.Floor.Number + " at " +
                                        player.stringCoord() + System.Environment.NewLine;
             
                }
                else if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
                {
                    newFloor = correct_elevator[currfloor].go_down();
                    newFloor--;

                    player.Floor = floors[newFloor];                   //set the new floor
                    player.Coord = wrong_elevator[newFloor].getCoord();
                    

                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                        player.Name + " is on floor " + player.Floor.Number + " at " +
                                        player.stringCoord() + System.Environment.NewLine;
                }
                else
                {
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
                }
            }

            else if (command == "ENTER UP")
            {
                int currX = player.Coord.x;
                int currY = player.Coord.y;
                int currfloor = player.Floor.Number - 1;
                int newFloor;

                //TODO

                if (currfloor == 1)
                {
                    graphic.Text = "You have reached the first floor. Such Wow... very play again... wow";
                }

                else if (correct_elevator[currfloor].isThereElevator(currX, currY))  //for now, the elevator only goes down
                {
                    newFloor = correct_elevator[currfloor].go_up();
                    player.Floor = floors[newFloor - 1];                   //set the new floor

                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                    player.Name + " is on floor " + player.Floor.Number + " at " +
                                    player.stringCoord() + System.Environment.NewLine;

                }
                else if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
                {
                    newFloor = correct_elevator[currfloor].go_up();
                    player.Floor = floors[newFloor - 1];                   //set the new floor

                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                        player.Name + " is on floor " + player.Floor.Number + " at " +
                                        player.stringCoord() + System.Environment.NewLine;
                }
                else
                {
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
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
                case 0: return new Graphic(player.Coord, player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord, "You do not have a case.");
                case 1: return new Graphic(player.Coord, player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord,"Case already unlocked.");
                case 2: return new Graphic(player.Coord, player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord,"Case Unlocked!");
                default: return new Graphic(player.Coord, player.Floor.caseCoord,player.Floor.noteCoord, player.Floor.phoneCoord,player.Floor.audioCoord, "Wrong pass code, try again.");
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