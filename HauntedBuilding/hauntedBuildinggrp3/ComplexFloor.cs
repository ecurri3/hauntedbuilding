using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ComplexFloor
    {
        private int number;           //floor number
        private Tile[][] complexfloor = new Tile[ComplexFloorConstants.CFLOOR_LENGTH][];
        static public int First_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Second_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Third_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Four_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Five_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Six_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Seven_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Eight_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Nine_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        static public int Ten_CWIDTH = ComplexFloorConstants.rndNumWidth.Next(1, 10);
        private PassCode pc; //passcode for case
        private PassCode doorPC = null; //be default only first floor has a doorPC
        private Coordinate[] elevators;
        private ArrayList coordinates; //has coordinates for all items/elevators
    }
}
