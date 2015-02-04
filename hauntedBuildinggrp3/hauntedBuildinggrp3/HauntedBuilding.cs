using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hauntedBuildinggrp3
{
    class Floor{

    }

    class Player{
        private Floor floor;
        private String name;

        public void setFloor(Floor floor){
            this.floor = floor;
        }

        public void setName(String name)
        {
            this.name = name;
        }

    }

    class HauntedBuilding
    {
        private String title;
        private Floor[] floors;
        private Player player;

        public HauntedBuilding(){
            title = "Welcome to Haunted Building\n";
            floors = new Floor[10];
            player = new Player();
        }

        public String getTitle(){
            return title;
        }

        public void startGame()
        {
            player.setFloor(floors[9]);
            player.setName("Johnny");


        }

        public Player getPlayer()
        {
            return player;
        }

    }
}
