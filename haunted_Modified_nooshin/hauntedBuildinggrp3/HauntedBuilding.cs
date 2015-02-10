using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Constants
    {
        public const int FLOOR_LENGTH = 10;
        public const int FLOOR_WIDTH = 10;
        public const String[] items { "Note", "Phone", "Audio" };
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

        private Random randomGen = new Random();

        //might have an x,y position for the floor
        private int xPos;
        private int yPos;

        private Tile[,] floor = new Tile[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

        public Floor()
        {
            int ranAmount = randomGen.Next(0, Constants.FLOOR_WIDTH * Constants.FLOOR_LENGTH);
            int x, y; //random place of case
            int a,b,c; //random passcode for case

            x = randomGen.Next(0, Constants.FLOOR_LENGTH);
            y = randomGen.Next(0, Constants.FLOOR_WIDTH);

            a = randomGen.Next(0,9);
            b = randomGen.Next(0,9);
            c = randomGen.Next(0,9);

            floor[x,y].Item = new Case("The case", a,b,c);


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
            Random random = new Random();
            int rand = random.Next(0, 3);
            if (rand == 3) item = null;
            else
                item = new Item(Constants.items[rand]);
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
        String itemName;
        String itemHint;
        public Item(String name){
            itemName = String.Copy(name);
            itemHint = "blank";//String.Copy(hint);
        }

        public String Hint
        {
            set { this.itemHint = value; }
            get { return this.itemHint;}
        }
    }

    class Case : Item
    {
        private int a, b, c; //passcode
        public Case(String name, int a, int b, int c) : base(name) //call base class constructor
        {
            this.a = a;
            this.b = b;
            this.c = c;
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
            /*
            if (floor.itemAt(Coord))
            {
                Item item = floor.pickupItem(Coord);
             *  inventory.add(item);
                return item.Name;
            }
             * */

            return "nothing";
        }



        //TODO
        public String showInventory()
        {
            if(inventory == null) return "nothing";

            String invtList = "";
            /* for each item in inventory
             * append to invtList
             * */

            return invtList;
        }


    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private Graphic currentGraphic; //the current image saved.
        private Item[] items;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";
            floors = new Floor[10]; //Creating 10 foors
            player = new Player();
            currentGraphic = new Graphic(""); //empty image on screen
            items = new Item[3];
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
                graphic.Text = "You picked up " + player.pickup() + " at " + player.stringCoord() + System.Environment.NewLine;
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
