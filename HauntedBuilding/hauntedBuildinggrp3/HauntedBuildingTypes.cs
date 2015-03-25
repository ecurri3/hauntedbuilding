using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    enum Move { STALL, FORWARD, BACKWARD, LEFT, RIGHT };
    enum iName { NOTE, PHONE, AUDIO, SECRETCASE, MONSTER}; //Used to index into ITEMS
    enum CaseState { STALL, UNLOCKED, LOCKED, NOTHAVE };//For use in tryCase methods
    enum DoorState { STALL, UNLOCKED, LOCKED, NOTNEAR};

    static class Constants
    {

        static public int FLOOR_LENGTH = 10; //X
        static public int FLOOR_WIDTH = 10; //Y
        public const int NUM_ELEVATORS = 2; //Per Floor
        public const int NUM_FLOORS = 10; 
        public const int NUM_ITEMS = 5;
        public const int CODE_LENGTH = 3;
        static public String[] ITEMS = new String[] { "Note", "Phone", "Audio", "Secret Case", "Monster" };
        static public Random randGen = new Random();
        static public int nextObjID = 1; //Used by floor to give each tile object a unique ID, helpful for reference
        static public int[,] hourglassTypes = new int[,] { { 5, 10 , 20}, {5, 3, 1} }; //hourglass timer bonus times and upper limit amount per floor
    }

    static class ComplexFloorConstants
    {
        static public int CFLOOR_LENGTH = 10; //X
        static public Random rndNumWidth = new Random();
        public const int NUM_ELEVATORS = 2; //Per Floor
        public const int NUM_FLOORS = 10;
        public const int NUM_ITEMS = 5;
        public const int CODE_LENGTH = 3;
        static public String[] ITEMS = new String[] { "Note", "Phone", "Audio", "Secret Case", "Monster" };
        static public Random randGen = new Random();
        static public int nextObjID = 1; //Used by floor to give each tile object a unique ID, helpful for reference
        static public int[,] hourglassTypes = new int[,] { { 5, 10, 20 }, { 5, 3, 1 } }; //hourglass timer bonus times and upper limit amount per floor

    }

    class Graphic //simulate graphics (for now just text)
    {

        private char[,] image;
        private Coordinate pCoord; //player Coordinate
        private ArrayList marks; //array list of NamedCoord's
        private String text;
        private int extraFlag = 0; //right now used for updating time
        private bool imageSet;
        private bool textSet;

        public int ExtraFlag
        {
            set { this.extraFlag = value; }
            get { return this.extraFlag; }
        }

        //Helper for Graphic() and setImage()
        private void labelMarks(ArrayList marks)
        {
            if (marks != null)
                foreach (NamedCoord mark in marks)
                {
                    if (mark.name == "CorrectElevator" || mark.name == "WrongElevator")
                        image[mark.coord.x, mark.coord.y] = 'e';
                    else if (mark.name == "Door")
                        image[mark.coord.x, mark.coord.y] = 'd';
                    else if (mark.name == "Monster")
                        image[mark.coord.x, mark.coord.y] = 'm';
                    else if (mark.name == "Hourglass")
                        image[mark.coord.x, mark.coord.y] = 'h';
                    else if (mark.name == "Wall")
                        image[mark.coord.x, mark.coord.y] = '*';
                    else
                        image[mark.coord.x, mark.coord.y] = 'o';
                }
        }

        public Graphic(Coordinate pCoord, ArrayList marks, String text)
        {
            this.pCoord = new Coordinate(pCoord.x, pCoord.y);
            this.marks = marks != null ? new ArrayList(marks) : null;

            this.image = new char[Constants.FLOOR_LENGTH,Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                    image[i, j] = '-';

            labelMarks(marks);

            this.image[pCoord.x, pCoord.y] = 'X'; //may overwrite a mark if on the same coordinate

            this.imageSet = true;
            
            this.text = text;
            this.textSet = true;
        }

        //Graphic with only text set
        public Graphic(String text)
        {
            this.pCoord = null;
            this.marks = null;

            this.image = new char[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                    image[i, j] = '-';

            this.imageSet = false;
            this.text = text;
            this.textSet = true;
        }

        //Empty Graphic
        public Graphic()
        {
            this.pCoord = null;
            this.marks = null;

            this.image = new char[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                    image[i, j] = '-';

            this.imageSet = false;
            this.text = "";
            this.textSet = false;
        }

        public String Text
        {
            set { this.text = value; }
            get { return text; }
        }

        public void setImage(Coordinate pCoord, ArrayList marks)
        {
            //Reset
            if(this.marks != null)
                foreach (NamedCoord mark in this.marks)
                    this.image[mark.coord.x, mark.coord.y] = '-'; //reset old marks

            this.image[this.pCoord.x, this.pCoord.y] = '-';

            this.pCoord = new Coordinate(pCoord.x, pCoord.y);
            this.marks = marks != null ? new ArrayList(marks) : null;

            //Fill
            labelMarks(marks);

            this.imageSet = true;
            this.image[pCoord.x, pCoord.y] = 'X'; //may overwrite an 'O' if on the same coordinate
        }

        public String getImage()
        { 
            String image_t = "";
            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
            {
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    image_t += this.image[i, j] + "     ";
                }

                image_t += System.Environment.NewLine;
            }

            return image_t;
        }

        public bool isImageSet() { return this.imageSet; }
        public bool isTextSet() { return this.textSet; }
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

    class NamedCoord
    {
        public String name;
        public Coordinate coord;
        public int id; //some coordinates have the same name, distinguish with id
        public NamedCoord(String name, Coordinate coord, int id)
        {
            this.name = name;
            this.coord = new Coordinate(coord.x, coord.y);
            this.id = id;
        }

        //Useful when removing from ArrayLists
        public override bool Equals(Object obj)
        {
            //Only compare NamedCoord, int, or String
            if (obj == null || (!(obj is NamedCoord) && !(obj is int) && !(obj is String))) 
                return false;
            
            //If comparing to a NameCoord
            if(obj is NamedCoord)
                return (this.name == ((NamedCoord)obj).name) && (this.id == ((NamedCoord)obj).id);

            //If comparing to an int
            if (obj is int)
                return this.id == (int)obj;

            //If comparing to a String
            return this.name == ((String)obj);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }

    class PassCode
    {
        public int[] code;
        public PassCode(int a, int b, int c)
        {
            code = new int[Constants.CODE_LENGTH];
            code[0] = a;
            code[1] = b;
            code[2] = c;
         }
    }

    class GameState
    {
        public String playerName;
        public int floorNumber;
        public PassCode pc;
        public Coordinate coord;
        public bool caseLocked; //is the case locked? IF they don't have it, its a yes
        public bool[] have;
        public int difficulty;

        public GameState(int difficulty, String playerName, int floorNumber,
                         PassCode pc, Coordinate coord, bool caseLocked,
                         bool[] have)
        {
            this.playerName = playerName;
            this.difficulty = difficulty;
            this.floorNumber = floorNumber;
            this.pc = pc;
            this.coord = coord;
            this.caseLocked = caseLocked;

            this.have = new bool[Constants.NUM_ITEMS];
            
            for(int i = 0; i < Constants.NUM_ITEMS; i++)
                this.have[i] = have[i];
        }

        public GameState(int difficulty, String playerName) //default constructor with an inital state
        {
            this.playerName = playerName;
            this.difficulty = difficulty;
            floorNumber = Constants.NUM_FLOORS;
            pc = null;
            coord = new Coordinate(0, 0);
            caseLocked = true;

            this.have = new bool[Constants.NUM_ITEMS];

            //set all too false, player doesn't have anything
            for (int i = 0; i < Constants.NUM_ITEMS; i++)
                this.have[i] = false;
        }
    }

    class Tile
    {
        private tileObj obj = null;

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

        public tileObj Obj
        {
            set { this.obj = value; }
            get { return this.obj; }
        }

    }

    //can't be instantiated!
    abstract class tileObj
    {
        private String objName;
        private bool canPickup;
        private bool barrier; //can the player share the same coordinate?
        private int id;
        public tileObj(String objName, bool canPickup, bool barrier)
        {
            this.objName = objName;
            this.canPickup = canPickup;
            this.barrier = barrier;
            this.id = Constants.nextObjID++;
        }

        public String name() { return objName; }
        public bool iCanPickup() { return canPickup; }
        public bool iBarrier() { return barrier; }
        public int getID() { return id; }
    }

    //can't be instantiated!
    abstract class Item : tileObj
    {
        protected String description;
        public Item(String itemName, String description)
            : base(itemName, true, false) //Can pickup, not a barrier
        {
            this.description = description;
        }

        abstract public String getDescription(); 
    }

    class Wall : tileObj
    {
        public Wall() : base("Wall", false, true) { }//can't pickup, is a barrier
    }

    //Regular Items
    class Record : Item
    {
        public Record(String name, String hint) : base(name, hint) { }
        override public String getDescription() { return description; }
    }

    //Special Item, a case
    class Case : Item
    {
        private PassCode pc; //passcode
        private bool locked;
        public Case(String name, String hint, PassCode pc, bool locked)
            : base(name, hint) //call base class constructor
        {
            this.pc = pc;
            this.locked = locked;
        }

        public bool matchCode(PassCode pc)
        {
            for (int i = 0; i < Constants.CODE_LENGTH; i++)
                if (this.pc.code[i] != pc.code[i]) return false;

            this.locked = false;
            return true;
        }

        public bool isLocked() { return locked; }

        override public String getDescription()
        {
            if (locked) return "Case Locked!";
            return description;
        }
    }

    class Hourglass : Item
    {
        int sec; //number of seconds to increase
        public Hourglass(int sec)
            : base("Hourglass", "More time added!")
        {
            this.sec = sec;
        }

        public override string getDescription()
        {
            return description;
        }

        public int getMoreTime() { return sec; }
    }

    //can't be instantiated!
    abstract class Monster : tileObj
    {
        protected bool alive;
        protected int health;
        public Monster(String name, int health) 
            : base(name, false, true) //Can't pickup, is a barrier
        {
            this.alive = true;
            this.health = health;
        }

        public bool isAlive() { return alive; }

        //return true if after attacked monster was killed
        public bool attacked()
        {
            if (--health == 0) return true;
            return false;
        }
    }

    class Zombie : Monster
    {
        public Zombie() : base("Zombie", 3) { }
    }

    class Door : tileObj
    {
        private PassCode pc; //passcode
        private bool locked;
        public Door(PassCode pc, bool locked)
            : base("Door", false, false) //can't pickup, is not a barrier
        {
            this.pc = new PassCode(pc.code[0], pc.code[1], pc.code[2]);
            this.locked = locked;
        }

        public bool matchCode(PassCode pc)
        {
            for (int i = 0; i < Constants.CODE_LENGTH; i++)
                if (this.pc.code[i] != pc.code[i]) return false;

            this.locked = false;
            return true;
        }

        public bool isLocked() { return locked; }
    }

    //initialize an array of elevators that will change floors for the player
    abstract class Elevator
    {
        protected int x, y, floor;

        public Elevator(int i, int j, int floor)
        {
            this.x = i;
            this.y = j;
            this.floor = floor;
        }

        public Boolean isThereElevator(int i, int j){ return x==i && y==j; }

        //Will make sure an elevator doesnt pass its boundary limits
        public Boolean canGoUp() { return this.floor != Constants.NUM_FLOORS; }

        public Boolean canGoDown() { return this.floor != 1; }

        public Coordinate getCoord() { return new Coordinate(this.x, this.y); }

        public abstract int go_up();
        public abstract int go_down();
    }

    class WrongElevator : Elevator
    {
        protected int randAbove;    //randomly takes user to any floor above current floor
        protected int randBelow;    //will not take user to first floor

        public WrongElevator(int i, int j, int floor) : base (i, j, floor) { }

        public override int go_up()
        {
            //randAbove = Constants.randGen.Next(this.floor, Constants.NUM_FLOORS);
            randAbove = this.floor + 1;
            return randAbove;
        }

        public override int go_down()
        {
            //randBelow = Constants.randGen.Next(2, this.floor);     //avoids a random ride to first floor
            randBelow = this.floor - 1;
            return randBelow;
        }
    }

    class CorrectElevator : Elevator
    {
        protected int lastFloor, nextFloor;

        public CorrectElevator(int i, int j, int floor) : base (i, j, floor) { }

        public void setPattern(int last, int next)
        {
            this.lastFloor = last;
            this.nextFloor = next;
        }

        public override int go_up() { return lastFloor; }

        public override int go_down() { return nextFloor; }
    }
}