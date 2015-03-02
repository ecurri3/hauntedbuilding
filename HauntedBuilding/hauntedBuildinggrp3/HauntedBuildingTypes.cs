using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    enum Move { STALL, FORWARD, BACKWARD, LEFT, RIGHT };

    static class Constants
    {
        public const int FLOOR_LENGTH = 4;
        public const int FLOOR_WIDTH = 4;
        public const int NUM_FLOORS = 10;
        static public String[] ITEMS = new String[] { "Note", "Phone", "Audio", "Secret Case" };
        static public Random randGen = new Random();
    }

    class Graphic //simulate graphics (for now just text)
    {

        private String image;
        private String text;

        public Graphic(Coordinate coord, Coordinate icase, Coordinate note, Coordinate phone, Coordinate audio, String text)
        {
            this.image = "";
            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
            {
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    if (coord.x == i && coord.y == j)
                        this.image += "X";
                    else if (icase.x == i && icase.y == j)
                        this.image += "O";
                    else if (note.x == i && note.y == j)
                        this.image += "O";
                    else if (audio.x == i && audio.y == j)
                        this.image += "O";
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

        public void setImage(Coordinate coord, Coordinate icase, Coordinate note, Coordinate phone, Coordinate audio)
        {
            this.image = "";
            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
            {
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                {
                    if (coord.x == i && coord.y == j)
                        this.image += "X";
                    else if (icase.x == i && icase.y == j)
                        this.image += "O";
                    else if (note.x == i && note.y == j)
                        this.image += "O";
                    else if (audio.x == i && audio.y == j)
                        this.image += "O";
                    else
                        this.image += "--";
                }

                this.image += System.Environment.NewLine;
            }
        }

        public String getImage() { return image; }
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

        public GameState(String playerName, int floorNumber,
                         PassCode pc, Coordinate coord, bool caseLocked,
                         bool haveCase, bool haveNote, bool havePhone, bool haveAudio)
        {
            this.playerName = playerName;
            this.floorNumber = floorNumber;
            this.pc = pc;
            this.coord = coord;
            this.caseLocked = caseLocked;
            this.haveCase = haveCase;
            this.haveNote = haveNote;
            this.havePhone = havePhone;
            this.haveAudio = haveAudio;
        }

        public GameState(String playerName) //default constructor with an inital state
        {
            this.playerName = playerName;
            floorNumber = Constants.NUM_FLOORS;
            pc = null;
            coord = new Coordinate(0, 0);
            caseLocked = true;
            haveCase = false;
            haveNote = false;
            havePhone = false;
            haveAudio = false;
        }
    }

    class Tile
    {
        private Item item = null;

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
            get { return this.item; }
        }

    }

    //can't be instantiated!
    abstract class Item
    {
        private String itemName;
        protected String itemHint;
        public Item(String name, String hint)
        {
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
        private PassCode pc; //passcode
        private bool locked;
        public Case(String name, String hint, PassCode pc, bool locked)
            : base(name, hint) //call base class constructor
        {
            this.pc = pc;
            this.locked = locked;
        }

        public bool tryToUnlock(PassCode pc)
        {
            if (this.pc.a == pc.a && this.pc.b == pc.b && this.pc.c == pc.c)
            {
                this.locked = false;
                return true;
            }

            return false;
        }

        public bool isLocked() { return locked; }

        override public String getHint()
        {
            if (!locked) return itemHint;
            return "Case Locked!";
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

        abstract public Boolean isCorrectElevator();
        abstract public Boolean isWrongElevator();


        public Coordinate getCoord()
        {
            Coordinate coord = new Coordinate(this.x, this.y);
            return coord;
        }

        public abstract int go_up();
        public abstract int go_down();

    }

    class WrongElevator : Elevator
    {
        protected int randAbove;    //randomly takes user to any floor above current floor
        protected int randBelow;    //will not take user to first floor
        protected int floor;

        public WrongElevator(int i, int j, int floor)
        {
            this.x = i;
            this.y = j;
            this.floor = floor;
        }

        public override int go_up()
        {
            //randAbove = Constants.randGen.Next(this.floor, Constants.NUM_FLOORS);
            randAbove = this.floor + 1;
            return randAbove;
        }

        public override Boolean isWrongElevator()
        {
            return true;
        }

        public override Boolean isCorrectElevator()
        {
            return false;
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

        public CorrectElevator(int i, int j, int last, int next)
        {
            this.x = i;
            this.y = j;
            this.lastFloor = last;       //lest and next elevator keep track of where player is coming from 
            this.nextFloor = next;       //WrongElevator doesn't need to keep track thus inheritance
        }

        public override Boolean isWrongElevator()
        {
            return false;
        }

        public override Boolean isCorrectElevator()
        {
            return true;
        }

        public override int go_up() { return lastFloor; }

        public override int go_down() { return nextFloor; }
    }
}