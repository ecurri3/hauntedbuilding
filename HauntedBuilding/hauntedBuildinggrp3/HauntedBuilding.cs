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
            int flag = -1;

            if (correct_elevator[currfloor].isThereElevator(currX, currY))  
            {
                //An attempt to go up or down a correct elevator is made and an elevator exists
                if (up ? correct_elevator[currfloor].canGoUp() : correct_elevator[currfloor].canGoDown())
                {
                    int lastFloor = correct_elevator[currfloor].getLast();
                    int nextFloor = correct_elevator[currfloor].getNext();

                    //determined that you are out of sequence
                    if ( (player.getLastFloor() == lastFloor) || (player.getLastFloor() == nextFloor)) 
                    {
                        //obtain the nextfloor in sequence 
                        newFloor = up ? correct_elevator[currfloor].go_up() : correct_elevator[currfloor].go_down();
                        newFloor--;

                        //save the last floor of where the player was
                        player.UpdateLastFloor(currfloor+1);
                        flag = 2;
                    }
                    else
                    {
                        flag = 0;
                    }
                    
                }
                else
                    flag = 1;
            }

            if (wrong_elevator[currfloor].isThereElevator(currX, currY))    //ive yet to work on it
            {
                //the last and next elevator that is correct in 
                int lastCorrect = correct_elevator[currfloor].getLast();
                int nextCorrect = correct_elevator[currfloor].getNext();

                if (up ? wrong_elevator[currfloor].canGoUp() : wrong_elevator[currfloor].canGoDown())
                {
                    //We want to avoid sending a player to a correct floor and thus allowing entrance to a correct elevator 
                    do
                    {
                        //obtain a random floor to go to. 
                        newFloor = up ? wrong_elevator[currfloor].go_up() : wrong_elevator[currfloor].go_down();
                    } while ((newFloor == lastCorrect) || (newFloor == nextCorrect));
                  
                    newFloor--;

                    //save the last floor of where the player was
                    if (newFloor == 9) { player.UpdateLastFloor(-1); } //allows for another chance to reach the first floor in sequence
                    else { player.UpdateLastFloor(currfloor + 1); }

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

                    graphic.Text = "Taking Elevator..." + System.Environment.NewLine;
                    graphic.Text = "Came from elevator " + (player.getLastFloor()) + System.Environment.NewLine;

                    graphic.setImage(player.Coord, null);
                    break;
                case 1: //Elevator limit reached
                    graphic.Text = "You can't go further " + (up ? "up." : "down.");
                    break;
                case 0: //Attempting to take correct elevator out of sequence
                    graphic.Text = "Unfortunately you can't take this elevator! (out of sequence)" + System.Environment.NewLine;
                    break;
                default:
                    graphic.Text = "You are not near an elevator! You are at " + player.stringCoord() + System.Environment.NewLine;
                    break;
            }
        }


        override public Graphic enterCommand(String command)
        {
            Player player = hb.getPlayer();
            Graphic graphic = new Graphic(player.Coord, null, "");

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
                    graphic.Text = "You can't move there." + System.Environment.NewLine;
                else
                {
                    graphic.setImage(player.Coord, null);
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
                    Constants.NUM_FLOORS = 2;
                    Constants.FLOOR_LENGTH = 10;
                    Constants.FLOOR_WIDTH = 10;
                    break;
                case 1: //medium
                    Constants.NUM_FLOORS = 15;
                    Constants.FLOOR_LENGTH = 15;
                    Constants.FLOOR_WIDTH = 15;
                    break;
                case 2: //hard
                    Constants.NUM_FLOORS = 20;
                    Constants.FLOOR_LENGTH = 20;
                    Constants.FLOOR_WIDTH = 20;
                    break;
            }
        }

        //Code to generate a random sequence

        /**
                 * Generates a string representation of the sequence of
                 * elevators needed to be taken in order to get to the 
                 * first floor
                 * 
                 * the general format of this int[] array is
                 * 
                 * {1, #, #, #, .... , NUM_FLOORS}
                 * 
                 * @returns 
                 * int[] correct_seq;
                 * 
                 * */
        int[] generateRandomSequence(int numFloors)
        {
            int[] seq = new int[numFloors];

            bool[] checks = new bool[numFloors];
            for (int i = 0; i < numFloors; i++)
            {
                checks[i] = false;
            }

            //the first and last have to be 1 and numFloors respectively
            seq[0] = 1;
            checks[0] = true;

            seq[numFloors-1] = numFloors;
            checks[numFloors-1] = true;

            for (int i = 1; i < (numFloors-1); i++)
            {
                int randNum;
                do
                {
                    //second number in Next() is exclusive so we want [1,NUM_FLOORS+1)
                    randNum = Constants.randGen.Next(2, Constants.NUM_FLOORS+1);

                }while(checks[randNum-1]);

                checks[randNum-1] = true;
                seq[i] = randNum;
            }

            //seq =  new int[]{ 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            return seq;
        }

        private void setupElevators()
        {
            correct_elevator = new CorrectElevator[Constants.NUM_FLOORS];
            wrong_elevator = new WrongElevator[Constants.NUM_FLOORS];

            //Generate a random sequence of correct elevators needed to reach the first floor
            //int[] correct_seq = new int[10] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            int[] correct_seq = generateRandomSequence(Constants.NUM_FLOORS);

            int numFloors = Constants.NUM_FLOORS;
            int x1, y1, x2, y2;

            //Initialize the elevators on each floor on a particular point on a floor
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


            /*
             * Maps the random generated sequence to the correct elevators
             * Floors are mapped to indices. Thus correct elevator in the first floor
             * is in correct_elevator[0].
             * Ex.
             *   correct_seq[5] = {1, 3, 4, 2 , 5}
             *   
             *   correct_elevator [first_floor]
             *   cameFrom =  3
             *   goingTo  = -1 (since you cant advance any further)
             *   
             *   correct_elevator [second_floor]
             *   cameFrom =  2
             *   goingTo  =  3
             *   
             *   correct_elevator [third_floor]
             *   camefrom =  4
             *   goingTo  =  1
             *   
             *   correct_elevator [fourth_floor]
             *   cameFrom =  2
             *   goingTo  =  3
             *   
             *   correct_elevator [fifth_floor]
             *   cameFrom =  -1 (Since you can't go up any higher than 5 floors)
             *   goingTo  =   2
             * */
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

            Constants.taken = new bool[Constants.FLOOR_LENGTH, Constants.FLOOR_WIDTH];

            Coordinate[] elevCoord = new Coordinate[Constants.NUM_ELEVATORS];
            for (int i = 0; i < Constants.NUM_FLOORS; i++)
            {
                //Get the elevator coordinates, pass them to Floor constructor
                for (int j = 0; j < Constants.NUM_ELEVATORS; j++)
                {
                    if(j == 0) //Stored at index 0, the correct elevator
                        elevCoord[j] = correct_elevator[i].getCoord();
                    else
                        elevCoord[j] = wrong_elevator[i].getCoord();
                }
                    

                if (gs.floorNumber == i + 1) //Only restore settings of one floor
                    floors[i] = new Floor(i + 1, gs.pc, gs.have, elevCoord, gs);
                else
                    floors[i] = new Floor(i + 1, null, null, elevCoord, gs);
            }
        }

        private void setupPlayer(GameState gs)
        {
            ArrayList items = new ArrayList();
            for (int i = 0; i < Constants.NUM_ITEMS; i++)
                if (gs.have[i])
                {
                    if (i == (int)iName.SECRETCASE)
                        items.Add(new Case(Constants.ITEMS[i], gs.caseHint, gs.pc, gs.caseLocked)); //get real hint form DB
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
                                 have, player.Floor.getCaseHint());
        }

    }
}