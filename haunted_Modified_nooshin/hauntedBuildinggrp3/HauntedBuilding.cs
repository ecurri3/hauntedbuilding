using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game{

    static class Constants
    {
        public const int FLOOR_LENGTH = 10;
        public const int FLOOR_WIDTH = 10;
        static public String[] ITEMS = new String[] { "Note", "Phone", "Audio"};
        static public Random randGen = new Random();
    }

    class Graphic //simulate graphics (for now just text)
    {
        private String text;

        public Graphic(String text)
        {
            this.text = text;
        }

        public String Text
        {
            set { this.text = value; }
            get { return text; }
        }
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

    //TODO need constructor that initializes floor with a 10x10 matrix of tiles
    class Floor{

       // private Random randomGen = new Random();

        //Location of case
        private int xCase;
        private int yCase;

        private Tile[,] floor = new Tile[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

        public Floor()
        {
            for(int i = 0; i < Constants.FLOOR_LENGTH;i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    floor[i, j] = new Tile();
                }
            //int ranAmount = randomGen.Next(0, Constants.FLOOR_WIDTH * Constants.FLOOR_LENGTH);
            int x, y; //random place of case
            int a,b,c; //random passcode for case

            x = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
            y = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

            //Random decimal pass code
            a = Constants.randGen.Next(0, 9);
            b = Constants.randGen.Next(0, 9);
            c = Constants.randGen.Next(0, 9);

            //Place case at random tile
            floor[x,y].Item = new Case("The case", "Go to Elevator X", a,b,c);

            int rand,x1,y1,x2,y2,x3,y3;

            //Randomly place three items, each with one digit of the pass code
            //Making sure they don't overlap
            do
            {
                x1 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y1 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (x1 == x && y1 == y); //can't be same as case

            rand = Constants.randGen.Next(0, 2);
            floor[x1,y1].Item = new Item(Constants.ITEMS[rand],a.ToString());

            do
            {
                x2 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y2 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (x2 == x1 && y2 == y1 && x2 == x && y2 == y);

            rand = Constants.randGen.Next(0, 2);
            floor[x2,y2].Item = new Item(Constants.ITEMS[rand],b.ToString());

            do
            {
                x3 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y3 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);
            } while (x3 == x2 && y3 == y2 && x3 == x1 && y3 == y1 && x3 == x && y3 == y);

            rand = Constants.randGen.Next(0, 2);
            floor[x3,y3].Item = new Item(Constants.ITEMS[rand],c.ToString());
        }

        public Item pickupItem(Coordinate c)
        {
            if (floor[c.x, c.y].Item == null) return null;
            Item i = floor[c.x,c.y].Item;
            floor[c.x, c.y].Item = null;
            return i;
        }
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
        private Item item;
        //Construct a random item for each tile
        /*
         * Case, password, nothing, etc
         */
        public Tile()
        {
            //Not sure how to decide how item is initialized
            //Random random = new Random();
            int rand = Constants.randGen.Next(0, 4); //(0,4]
            if (rand == 3) item = null; //No item
            else
                item = new Item(Constants.ITEMS[rand], "No hint!");
        }

        public Item Item
        {
            set { this.item = value; }
            get { return this.item;}
        }

    }

    //TODO
    class Item
    {
        private String itemName;
        private String itemHint;
        public Item(String name, String hint){
            itemName = name;
            itemHint = hint;//String.Copy(hint);
        }

        public String name() { return itemName; }
        public String getHint() { return itemHint; }
    }

    class Case : Item
    {
        private int a, b, c; //passcode
        private bool unlocked = false;
        public Case(String name, String hint, int a, int b, int c) : base(name,hint) //call base class constructor
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool tryToUnlock(int a, int b, int c){

            if (this.a == a && this.b == b && this.c == c)
            {
                unlocked = true;
                return true;
            }

            return false;
        }

        public new String getHint() //using 'new' keyword to hide base method
        {
            if (unlocked) return base.getHint();
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
        private Floor floor; //what floor are they on
        private Coordinate coord; //may need to init to something
        private Item inventory = null; // should be an ArrayList
        private String name; //their name

        public String stringCoord()
        {
            return "(" + coord.x + "," + coord.y + ")";
        }

        public Floor Floor{
            set { this.floor = value; }
            get { return this.floor; }
        }

        public Coordinate Coord //getter and setter for coordinate
        {
            set { this.coord = value;}
            get { return this.coord; }
        }

        public Item Inventory
        {
            set {this.inventory = value;}
            get { return inventory; }
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

        //TODO
        public String pickup()
        {
            Item i = floor.pickupItem(coord);
            if (i != null)
            {
                inventory = i;
                return i.name();
            }

            return "nothing";
        }



        //TODO
        public String showInventory()
        {
            if(inventory == null) return "nothing";

            String invtList = inventory.name();

            return invtList;
        }


    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private Graphic currentGraphic; //the current image saved.
        //private Item[] items;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";
            floors = new Floor[10]; //Creating 10 foors

            for (int i = 0; i < 10; i++)
            {
                floors[i] = new Floor();
            }
            
            player = new Player();
            //currentGraphic = new Graphic(""); //empty image on screen
            //items = new Item[3];
            /*
            items[0] = new Item("Note", "First number is 9");
            items[1] = new Item("Recording", "This is a recording");
            items[2] = new Item("Flashlight", "This is a flashlight");
            */
        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame()
        {
            player.Floor = floors[9]; //start at the roof
            player.Name = "Johnny"; //for now we call him Johnny
            player.Coord = new Coordinate(9,4); //Floor matrix is zero indexed!! so 10th tile is 9

            Graphic graphic = new Graphic(player.Name + " is on the roof. (10th floor)");

            currentGraphic = graphic;
            return graphic;
        }

        public Player getPlayer()
        {
            return player;
        }

        //TODO error check the command
        public Graphic enterCommand(String command)
        {
            Graphic graphic = new Graphic("Bad command! Click Help for help.");

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
                    graphic.Text = player.Name + " moved to " + player.stringCoord() + System.Environment.NewLine;

            }
            else if (command == "ENTER")
            {
                //TODO
                if (player.enterElevator())
                {
                    /*
                    graphic.setGraphic("Taking Elevator..." + System.Environment.NewLine +
                                        player.Name + " is on floor " + player.Floor.Number + " at " +
                                        player.stringCoord() + System.Environment.NewLine);
                     */
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

    }
}