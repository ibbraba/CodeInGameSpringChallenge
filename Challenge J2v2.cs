using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


    
public class Person
{
    public int id { get; set; }
    public string Name { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public int health { get; set; }
    public string role { get; set; }
    

}


public class Spider{
    public int id; 
    public int posX; 
    public int posY; 
    public int threatFor; 
    public int nearBase; 
    public int health;

}





public class Situation
{

    public void checkIfDanger (List<Spider> dangerSpiders){

        int spiderNumber = dangerSpiders.Count; 

        if(spiderNumber == 0){

            for(int i=0; i<3; i++){
                Console.WriteLine("WAIT");
            }


        }

        if(spiderNumber == 1 ){
             for(int i=0; i<3; i++){
                Console.WriteLine("MOVE " + dangerSpiders[0].posX + " " + dangerSpiders[0].posY);
            }
        }


        if(spiderNumber == 2 ){
            Console.WriteLine("MOVE " + dangerSpiders[0].posX + " " + dangerSpiders[0].posY);
            Console.WriteLine("MOVE " + dangerSpiders[0].posX + " " + dangerSpiders[0].posY);
            Console.WriteLine("MOVE " + dangerSpiders[1].posX + " " + dangerSpiders[1].posY);



        }

        if(spiderNumber >= 3 ){
            Console.WriteLine("MOVE " + dangerSpiders[0].posX + " " + dangerSpiders[0].posY);
            Console.WriteLine("MOVE " + dangerSpiders[1].posX + " " + dangerSpiders[1].posY);
            Console.WriteLine("MOVE " + dangerSpiders[2].posX + " " + dangerSpiders[2].posY);
        }

      
           
               
        

        }




}






/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {

        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int baseX = int.Parse(inputs[0]); // The corner of the map representing your base
        int baseY = int.Parse(inputs[1]);
        int heroesPerPlayer = int.Parse(Console.ReadLine()); // Always 3


        
        
 

        // game loop
        while (true)
        {
           
           
        Situation situation = new Situation(); 
        Person[] heroes = new Person[3];
        List <Spider>  dangerSpiders = new List <Spider>(); 
   

            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int health = int.Parse(inputs[0]); // Each player's base health
                int mana = int.Parse(inputs[1]); // Ignore in the first league; Spend ten mana to cast a spell
            }



            int entityCount = int.Parse(Console.ReadLine()); // Amount of heros and monsters you can see


            for (int i = 0; i < entityCount; i++)
            {
                             

                inputs = Console.ReadLine().Split(' ');
                int id = int.Parse(inputs[0]); // Unique identifier
                int type = int.Parse(inputs[1]); // 0=monster, 1=your hero, 2=opponent hero
                int x = int.Parse(inputs[2]); // Position of this entity
                int y = int.Parse(inputs[3]);
                int shieldLife = int.Parse(inputs[4]); // Ignore for this league; Count down until shield spell fades
                int isControlled = int.Parse(inputs[5]); // Ignore for this league; Equals 1 when this entity is under a control spell
                int health = int.Parse(inputs[6]); // Remaining health of this monster
                int vx = int.Parse(inputs[7]); // Trajectory of this monster
                int vy = int.Parse(inputs[8]);
                int nearBase = int.Parse(inputs[9]); // 0=monster with no target yet, 1=monster targeting a base
                int threatFor = int.Parse(inputs[10]); // Given this monster's trajectory, is it a threat to 1=your base, 2=your opponent's base, 0=neither


                // STORE HERO
                 if(type == 1){
                    
                    Person person = new Person(); 
                    person.id = id;
                    person.Name="MIGNON" + id;
                    person.posX=x;
                    person.posY=y;
                    person.health=health;
                    
                    heroes[id] = person; 
                } 


                //Store Spiders 
                if (type== 0 && nearBase==1){
                    Spider spider= new Spider(); 
                    spider.id = id; 
                    spider.posX= x;
                    spider.posY = y; 
                    spider.threatFor= threatFor; 
                    spider.nearBase= nearBase;
                    dangerSpiders.Add(spider);
                }

              
                

             
            }


        
           

            situation.checkIfDanger(dangerSpiders); 



            for (int i = 0; i < heroesPerPlayer; i++)
            {
                // Find all Person instances 
                //Check Action todo
                //Write in console the action 
                Console.Error.WriteLine("Hero" +  heroes[i].id + ":" + heroes[i].posX + "," +  heroes[i].posY)

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // In the first league: MOVE <x> <y> | WAIT; In later leagues: | SPELL <spellParams>;
              ;
              //  Console.WriteLine("MOVE 2000 2000");
               // Console.WriteLine("MOVE 6500 3000");


            }
        }
    }
}




//Project: Crate 3 laners (bottom, top, middle)
// Define their zones 
//MOVE INTO ZONE if Limit go backwards 
// if One laner dies redfine two lanes for each laner left 
// If one laner left retrat to base 
//If one of our hero is protecting the safe zone, other hero can slay 
// Else one hero has to retreat 



// Create Scenarios and associate it with Actions