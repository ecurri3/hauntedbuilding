using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game{

    static class Constants
    {
        public const int FLOOR_LENGTH = 4;
        public const int FLOOR_WIDTH  = 4;
        public const int NUM_FLOORS   = 10;
        static public String[] ITEMS  = new String[] { "Note", "Phone", "Audio", "Secret Case"};
        static public Random randGen  = new Random();
    }

    class Graphic //simulate graphics (for now just text)
    {

        private String image;
        private String text;

        public Graphic(Coordinate coord, String text)
        {
            this.image = "";
            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
            {
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    if (coord.x == i && coord.y == j)
                        this.image += "X";
                    else
                        this.image += "--";
                }
                    
                this.image += System.Environment.NewLine;
            }

            this.text = text;
        }

        public Graphic(String text)
        {
            this.image = "";
            this.text = text;
        }

        public String Text
        {
            set { this.text = value; }
            get { return text; }
        }

        public void setImage(Coordinate coord)
        {
            this.image = "";
            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
            {
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    if (coord.x == i && coord.y == j)
                        this.image += "X";
                    else
                        this.image += "--";
                }

                this.image += System.Environment.NewLine;
            }
        }

        public String getImage() { return image; }
    }
    
    
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
    class PassCode
    {
        public int a, b, c;
        public PassCode(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
    class Floor{
        private int number;           //floor number
        private Tile[,] floor = new Tile[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];
        private PassCode pc;          //passcode
        
        public Floor(int number)
        {
            this.number = number;
            for(int i = 0; i < Constants.FLOOR_LENGTH;i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    floor[i, j] = new Tile();
                }
            //int ranAmount = randomGen.Next(0, Constants.FLOOR_WIDTH * Constants.FLOOR_LENGTH);
            int x, y; //random place of case
            //int a,b,c; //random passcode for case

            x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
            y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

            //Random decimal pass code
            pc = new PassCode(Constants.randGen.Next(0, 10),
                              Constants.randGen.Next(0, 10),
                              Constants.randGen.Next(0, 10));

            //Place case at random tile
            floor[x,y].Item = new Case(Constants.ITEMS[3], "Go to Elevator X", pc);

            int x1,y1,x2,y2,x3,y3;

            //Randomly place three items, each with one digit of the pass code
            //Making sure they don't overlap
            do
            {
                x1 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y1 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (x1 == x && y1 == y); //can't be same as case

            //rand = Constants.randGen.Next(0, 2);
            floor[x1,y1].Item = new Tool(Constants.ITEMS[0],"First digit: " + pc.a.ToString());

            do
            {
                x2 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y2 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while ((x2 == x1 && y2 == y1) || (x2 == x && y2 == y));

            //rand = Constants.randGen.Next(0, 2);
            floor[x2,y2].Item = new Tool(Constants.ITEMS[1],"Second digit: " + pc.b.ToString());

            do
            {
                x3 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y3 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while ((x3 == x2 && y3 == y2) || (x3 == x1 && y3 == y1) || (x3 == x && y3 == y));

            //rand = Constants.randGen.Next(0, 2);
            floor[x3,y3].Item = new Tool(Constants.ITEMS[2],"Third digit: " + pc.c.ToString());
        }

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

        public PassCode getPassCode() { return pc; }
    }

    //TODO
    /*
     * When Floor is initialized, the case/password will be randomly assigned to a Tile
     * When each Tile is initalized, it will check if the item is already set to something
     * if not, set the item to some random item
     * else, skip the current Tile because that Tile is already set to the case/password
     */
    class Tile
    {
        private Item item = null;
        //Construct a random item for each tile
        /*
         * Case, password, nothing, etc
         */
        public Tile()
        {
            //Not sure how to decide how item is initialized
            //Random random = new Random();
            /*
            int rand = Constants.randGen.Next(0, 4); //(0,4]
            if (rand == 3) item = null; //No item
            else item = new Tool(Constants.ITEMS[rand], "No hint!"); //Item with no hint
            */
        }

        public Item Item
        {
            set { this.item = value; }
            get { return this.item;}
        }

    }

    //can't be instantiated!
    abstract class Item
    {
        private String itemName;
        protected String itemHint;
        public Item(String name, String hint){
            itemName = name;
            itemHint = hint;//String.Copy(hint);
        }

        public String name() { return itemName; }
        abstract public String getHint();
    }

    //Regular Items
    class Tool : Item
    {
        public Tool(String name, String hint) : base(name, hint) { }
        override public String getHint() { return itemHint; }
    }

    //Special Item, a case
    class Case : Item
    {
        private int a, b, c; //passcode
        private bool locked = true;
        public Case(String name, String hint, PassCode pc) : base(name,hint) //call base class constructor
        {
            this.a = pc.a;
            this.b = pc.b;
            this.c = pc.c;
        }

        public bool tryToUnlock(int a, int b, int c)
        {
            if (this.a == a && this.b == b && this.c == c)
            {
                this.locked = false;
                return true;
            }

            return false;
        }

        public bool isLocked(){
            return locked;
        }

        override public String getHint() //using 'new' keyword to hide base method
        {
            if (!locked) return itemHint;
            return "Case Locked!";
        }
    }

    //just helper class to pass coordinates around easier.
    class Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    enum Move { STALL, FORWARD, BACKWARD, LEFT, RIGHT};

    class Player{
        private Floor floor;
        private Coordinate coord; //may need to init to something
        private ArrayList inventory;
        private String name;

        public Player()
        {
            this.inventory = new ArrayList();
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
    }

    class GameState
    {
        public String playerName;
        public int floorNumber;
        public PassCode pc;
        public Coordinate coord;
        public bool caseLocked; //is the case locked? IF they don't have it, its a yes
        public bool haveCase;
        public bool haveNote;
        public bool havePhone;
        public bool haveAudio;

        public GameState(String playerName, int fn,
                         PassCode pc, Coordinate coord, bool locked,
                         bool hcase, bool hnote, bool hphone, bool haudio)
        {
            this.playerName = playerName;
            floorNumber = fn;
            this.pc = pc;
            this.coord = coord;
            caseLocked = locked;
            haveCase = hcase;
            haveNote = hnote;
            havePhone = hphone;
            haveAudio = haudio;
        }
    }

    //initialize an array of elevators that will change floors for the player
    abstract class Elevator
    {
        protected int x, y;

        public Boolean isThereElevator(int i, int j)
        {
            if (x == i && y == j)
            {
                return true;
            }

            return false;
        }

        public abstract int go_up();
        public abstract int go_down();

    }

    class WrongElevator : Elevator
    {
        protected int randAbove;    //randomly takes user to any floor above current floor
        protected int randBelow;    //will not take user to first floor
        protected int floor;

        public WrongElevator(int i, int j, int floor){
            this.x = i;
            this.y = j;
            this.floor = floor;
        }

       
        public override int go_up(){
            randAbove = Constants.randGen.Next(this.floor, Constants.NUM_FLOORS);
            return randAbove;
        }

        public override int go_down(){
            randBelow = Constants.randGen.Next(2, this.floor);     //avoids a random ride to first floor
            return randBelow;
        }
    }

    class CorrectElevator : Elevator
    {
        protected int lastFloor, nextFloor;

        public CorrectElevator(int i, int j, int last, int next){
            this.x = i;
            this.y = j;
            this.lastFloor = last;       //lest and next elevator keep track of where player is coming from 
            this.nextFloor = next;       //WrongElevator doesn't need to keep track thus inheritance
        }

        public override int go_up() { return lastFloor; }

        public override int go_down() { return nextFloor; }
    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private Elevator[] correct_elevator, wrong_elevator;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";
            floors = new Floor[10]; //Creating 10 foors
            correct_elevator = new CorrectElevator[10];
            wrong_elevator   = new WrongElevator[10];


            //generate a random sequence of correct elevators
            int [] correct_seq = new int[13] {-1,1,2,3,4,5,6,7,8,9,10,-1,-1}; 
            int last = 11;
            int next = 9;

            for (int i = 0; i < 10; i++)
            {
                floors[i] = new Floor(i+1);

            }

            //initializes the elevators on each floor with an indication of its path
            for (int i = 9; i >= 0; i--, last--, next--)
            {
                correct_elevator[i] = new CorrectElevator(3, 1, correct_seq[last], correct_seq[next]);
                wrong_elevator[i]   = new WrongElevator(3, 2, i+1);
            }
                player = new Player();
        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame()
        {
            player.Floor = floors[9]; //start at the roof
            player.Name = "Johnny"; //for now we call him Johnny
            player.Coord = new Coordinate(0,0); //Floor matrix is zero indexed!! so 10th tile is 9

            Graphic graphic = new Graphic(player.Coord, player.Name + " is on floor " +  player.Floor.Number + System.Environment.NewLine);

            return graphic;
        }

        public Player getPlayer()
        {
            return player;
        }

        public Graphic enterCommand(String command)
        {
            Graphic graphic = new Graphic(player.Coord, "Bad command! Click Help for help.");

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
                    graphic.setImage(player.Coord);
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
                        player.Floor = floors[newFloor-1];                   //set the new floor
                    
                        graphic.Text = "Taking Elevator..." + System.Environment.NewLine +
                                        player.Name + " is on floor " + player.Floor.Number + " at " +
                                        player.stringCoord() + System.Environment.NewLine;
             
                }
                else if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
                {
                    newFloor = correct_elevator[currfloor].go_down();
                    player.Floor = floors[newFloor-1];                   //set the new floor

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

        //Used to store into SQL
        

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