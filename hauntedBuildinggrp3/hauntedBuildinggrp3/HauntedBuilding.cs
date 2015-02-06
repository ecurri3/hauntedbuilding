using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Graphic //simulate graphics (for now just text)
    {
        private String graphic;

        public Graphic(String graphic)
        {
            this.graphic = graphic;
        }

        public String getGraphic()
        {
            return graphic;
        }

        public void setGraphic(String graphic)
        {
            this.graphic = graphic;
        }
    }
    
    
    // FORWARD decrements X
    // BACKWARD increments x
    // LEFT decrements Y
    // RIGHT increments Y

    // Coordinate (9,4) is marked as [x]. We use (x,y) format.
    //Johnny starts on the 10th floor at coordinate (9,4)

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
        private const int FLOOR_LENGTH = 10;
        private const int FLOOR_WIDTH = 10;

        //might have an x,y position for the floor
        private int xPos;
        private int yPos;

        private Tile[,] floor = new Tile[FLOOR_LENGTH, FLOOR_WIDTH];

        public Floor()
        {
            ;
        }
    }

    //TODO
    class Tile
    {

    }

    //TODO
    class Item
    {

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

    class Player{
        private Floor floor; //what floor are they on
        private int xPos; //Coordinates
        private int yPos;
        private Item inventory; // should be an ArrayList
        private String name; //their name

        public void setFloor(Floor floor){
            this.floor = floor;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setCoord(Coordinate coord)
        {
            this.xPos = coord.x;
            this.yPos = coord.y;
        }

        public bool move(int where)
        {
            switch (where)
            {
                    //TODO write an enum
                //FORWARD
                case 0: if(xPos - 1 < 0) return false; //they hit boundary 
                        xPos--; break;
                //RIGHT
                case 1: if (yPos + 1 > 9 ) return false;
                        yPos++; break;
                //BACKWARD
                case 2: if (xPos + 1 > 9) return false;
                        xPos++; break;
                //LEFT
                case 3: if (yPos - 1 < 0) return false;
                        yPos--; break;
                default:
                    return false; //bad direction
                
            }

            return true; //success!
        }

        public Coordinate getCoordinates() { return new Coordinate(xPos, yPos); }

    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;
        private Graphic currentGraphic; //the current image saved.

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";
            floors = new Floor[10]; //Creating 10 foors
            player = new Player();
            currentGraphic = new Graphic(""); //empty image on screen
        }

        public String getTitle(){
            return title;
        }

        public Graphic startGame()
        {
            player.setFloor(floors[9]); //start at the roof
            player.setName("Johnny"); //for now we call him Johnny
            player.setCoord(new Coordinate(9,4)); //Floor matrix is zero indexed!! so 10th tile is 9

            Graphic graphic = new Graphic(player.getName() + " is on the roof. (10th floor)");

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

            int where = -1;
            switch (command) //see if movement command
            {
                case "FORWARD": where = 0; break;
                case "RIGHT": where = 1; break;
                case "BACKWARD": where = 2; break;
                case "LEFT": where = 3; break;
                default: where = -1; break;// other command
            }

            if (where != -1) //It is a move command
            {
                if (!player.move(where))
                    graphic.setGraphic("There is wall in front of you!" + System.Environment.NewLine);
                else
                {
                    Coordinate coord = player.getCoordinates();
                    graphic.setGraphic(player.getName() + " moved to (" + coord.x + "," + coord.y + ")" + System.Environment.NewLine);
                }

                return graphic;
            }

            if (command == "ENTER")
            {
                
            }
            else if (command == "PICKUP")
            {

            }
            else if (command == "INVT")
            {

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
