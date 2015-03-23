using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game{
    //Trying out State Pattern
    abstract class GameCondition
    {
        abstract public Graphic enterCommand(String command);
        abstract public Graphic tryUnlock(int what, int digit1, int digit2, int digit3);
    }

    class ReadyCondition : GameCondition
    {
        override public Graphic enterCommand(String command)
        {
            return new Graphic();
        }

        public override Graphic tryUnlock(int what, int digit1, int digit2, int digit3)
        {
            return new Graphic();
        }
    }

    class PlayingCondition : GameCondition
    {
        private HauntedBuilding hb;
        public PlayingCondition(HauntedBuilding hb)
        {
            this.hb = hb;
        }
        //Command ENTER UP & ENTER Down helper
        private void enterElevator(bool up, Graphic graphic)
        {
            Player player = hb.getPlayer();
            Floor[] floors = hb.getFloors();
            CorrectElevator[] correct_elevator = hb.getCorrectElevators();
            WrongElevator[] wrong_elevator = hb.getWrongElevators();

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
                    player.Coord = player.Floor.randElevatorCoord();

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


        override public Graphic enterCommand(String command)
        {
            Player player = hb.getPlayer();
            Graphic graphic = new Graphic(player.Coord, null, "Bad command! Click Help for help.");

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
                    graphic.Text = "You can't move there." + System.Environment.NewLine +
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
                    case DoorState.UNLOCKED:
                        graphic.Text = "";
                        graphic.ExtraFlag = 1;
                        break;
                    case DoorState.LOCKED: 
                        graphic.Text = "The door is locked.";
                        break;
                    case DoorState.NOTNEAR: 
                        graphic.Text = "You are not near a door.";
                        break;
                    default:
                        graphic.Text = "This should not happen.";
                        break;
                }
            }
            else if (command == "PICKUP")
            {
                Item i = player.pickup();
                graphic.Text = "You picked up " + (i != null ? i.name() : "nothing") + System.Environment.NewLine;
                if (i != null && i.name() == "Hourglass")
                {
                    graphic.ExtraFlag = ((Hourglass)i).getMoreTime();
                    graphic.Text += "+" + graphic.ExtraFlag + " secs" + System.Environment.NewLine;
                }
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
                graphic.Text = "Used Flashlight." + System.Environment.NewLine;
                graphic.setImage(player.Coord, player.useFlashLight(graphic));
            }

            return graphic;
        }

        override public Graphic tryUnlock(int what, int digit1, int digit2, int digit3)
        {
            if (what == 0)
            {
                CaseState result1 = hb.getPlayer().tryUnlock(new PassCode(digit1, digit2, digit3));

                switch (result1)
                {
                    case CaseState.NOTHAVE: return new Graphic("You do not have a case.");
                    case CaseState.STALL: return new Graphic("Case already unlocked.");
                    case CaseState.UNLOCKED: return new Graphic("Case Unlocked!");
                    case CaseState.LOCKED:
                    default: return new Graphic("Wrong pass code, try again.");
                }
            }

            DoorState result = hb.getPlayer().tryUnlockDoor(new PassCode(digit1, digit2, digit3));

            switch (result)
            {
                case DoorState.NOTNEAR: return new Graphic("You are not near a door.");
                case DoorState.STALL: return new Graphic("Door already unlocked.");
                case DoorState.UNLOCKED: return new Graphic("Door Unlocked!");
                case DoorState.LOCKED:
                default: return new Graphic("Wrong pass code, try again.");
            }
        }
    }

    class HauntedBuilding
    {
        private GameCondition condition;
        private int difficulty; //Maybe part of GameCondition?
        private String title;
        private Floor[] floors;
        private Player player;
        private CorrectElevator[] correct_elevator; 
        private WrongElevator[] wrong_elevator;

        public HauntedBuilding()
        {
            condition = new ReadyCondition();
            difficulty = 0; //Maybe part of GameCondition?
            title = "Welcome to Haunted Building\n";
            floors = null;
            player = null;
            correct_elevator = null; 
            wrong_elevator = null;
        }

        public String getDifficulty()
        {
            switch (difficulty)
            {
                case 0: return "Easy";
                case 1: return "Medium";
                case 2:
                default: return "Hard";
            }
        }
        //Return as references
        public String getTitle() { return title; }
        public Player getPlayer() { return player; }
        public Floor[] getFloors() { return floors; }
        public CorrectElevator[] getCorrectElevators() { return correct_elevator; }
        public WrongElevator[] getWrongElevators() { return wrong_elevator; }

        private void errorCheck(GameState gs)
        {
            //TODO error check gs floor number, coord, and pass code digits
            //error check coord
            if (gs.coord.x < 0 || gs.coord.x > Constants.FLOOR_LENGTH - 1 ||
                gs.coord.y < 0 || gs.coord.y > Constants.FLOOR_WIDTH - 1)
                gs.coord = new Coordinate(0, 0); //change bad coord to default
        }

        private void setupDifficulty(GameState gs)
        {
            difficulty = gs.difficulty;
            switch (difficulty)
            {
                case 0: //easy
                    Constants.FLOOR_LENGTH = 10;
                    Constants.FLOOR_WIDTH = 10;
                    break;
                case 1: //medium
                    Constants.FLOOR_LENGTH = 15;
                    Constants.FLOOR_WIDTH = 15;
                    break;
                case 2: //hard
                    Constants.FLOOR_LENGTH = 20;
                    Constants.FLOOR_WIDTH = 20;
                    break;
            }
        }

        private void setupElevators()
        {
            correct_elevator = new CorrectElevator[Constants.NUM_FLOORS];
            wrong_elevator = new WrongElevator[Constants.NUM_FLOORS];

            // Generate Elevator sequence
            //generate a random sequence of correct elevators
            int[] correct_seq = new int[10] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            int numFloors = Constants.NUM_FLOORS;
            int x1, y1, x2, y2;

            //initializes the elevators on each floor with an indication of its path
            for (int i = numFloors - 1; i >= 0; i--)
            {
                x1 = Constants.randGen.Next(0, Constants.FLOOR_LENGTH);
                y1 = Constants.randGen.Next(0, Constants.FLOOR_WIDTH);

                correct_elevator[i] = new CorrectElevator(x1, y1, i + 1);

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
        }

        private void setupFloors(GameState gs)
        {
            floors = new Floor[Constants.NUM_FLOORS]; //Creating 10 foors

            /* may be needed later
            bool[,] taken = new bool[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            for (int i = 0; i < Constants.FLOOR_LENGTH; i++)
                for (int j = 0; j < Constants.FLOOR_WIDTH; j++)
                    taken[i, j] = false;
             */

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
        }

        private void setupPlayer(GameState gs)
        {
            ArrayList items = new ArrayList();
            for (int i = 0; i < Constants.NUM_ITEMS; i++)
                if (gs.have[i])
                {
                    if (i == (int)iName.SECRETCASE)
                        items.Add(new Case(Constants.ITEMS[i], "Got to elevator X", gs.pc, gs.caseLocked)); //get real hint form DB
                    else
                        items.Add(new Record(Constants.ITEMS[i], "Digit " + (i + 1) + ": " + gs.pc.code[i]));
                }

            player = new Player(gs.playerName, floors[gs.floorNumber - 1], gs.coord, items);
        }
        

        public Graphic startGame(GameState gs)
        {
            condition = new PlayingCondition(this);
            errorCheck(gs);
            setupDifficulty(gs);
            setupElevators();
            setupFloors(gs);
            setupPlayer(gs);

            return new Graphic(player.Coord, null,player.Name + " is on floor " +  player.Floor.Number + System.Environment.NewLine);
        }

        public void endGame()
        { 
            //we're letting garabage collector clean up memory
            condition = new ReadyCondition(); //Change state
            correct_elevator = null;
            wrong_elevator = null;
            floors = null;
            player = null;
        }

        public Graphic enterCommand(String command)
        {
            return condition.enterCommand(command);
        }

        //attempt at cracking the case
        public Graphic tryUnlock(int what, int digit1, int digit2, int digit3)
        {
            return condition.tryUnlock(what, digit1, digit2, digit3);
        }
        

        public Graphic getHelp()
        {
            String howto = "Use the following controls to navigate your character:" + System.Environment.NewLine;
            String move = "W, A, S, D to move." + System.Environment.NewLine;
            String enter = "Q to enter a door." + System.Environment.NewLine;
            String elevator = "X to go up in an elevator and C to go down." + System.Environment.NewLine;
            String pickup = "E to pickup an Item." + System.Environment.NewLine;
            String invt = "1 to show inventory and R to inspect inventory." + System.Environment.NewLine;
            String flashlight = "F to shine your flashlight" + System.Environment.NewLine;
            String code = "Enter 3 digits in the textboxes and select which device you plan to break." + System.Environment.NewLine;
            String backTogame = "Click 'Help' to go back to game screen" + System.Environment.NewLine;
            
            return new Graphic(howto + move + enter + elevator + pickup + invt + flashlight + code + backTogame);
        } 

        //returns the current State
        public GameState currentState()
        {
            bool[] have = new bool[Constants.NUM_ITEMS];

            String inventory = player.showInventory();
            for (int i = 0; i < Constants.NUM_ITEMS;  i++)
                have[i] = inventory.Contains(Constants.ITEMS[i]);

            return new GameState(difficulty, player.Name, player.Floor.Number, 
                                 player.Floor.getPassCode(), player.Coord,
                                 player.lockedCase(),
                                 have);
        }

    }
}