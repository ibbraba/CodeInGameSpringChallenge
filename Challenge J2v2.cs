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
    public string[] roles = {"top", "middle", "bottom"};

}







public class Situation
{

    public int nearBase;
    public int posEnemyX;
    public int posEnemyY;



}


public class Strategy
{
    public int nearBase; 

    public int positionAttackX=5080;
    public int positionStackX=4700;
    public int positionDefendX=400;
     

    public Dictionary <int,int> positionY = new Dictionary<int, int>(){

            {01, 400},
            {02, 4000},
            {03, 6100},
     };
        
         //   
            
        

    public int topLanerY= 400;
    public int MiddleLanerY=2100;
    public int BottomLanerY= 3000;


    Random rnd = new Random();
   


    Person hero;

    //Define 3 fonction checkStrat


    
    


    
    public void checkStrategy(Person hero){

  


    int randomMove = rnd.Next(-100, 100);
    int moveA= randomMove + positionAttackX;
    int moveD= randomMove + positionDefendX;  
  
  
  
        if(hero.id==0 ){
            if(hero.posX<positionStackX){
               
                Console.WriteLine("MOVE " + moveA + " " + topLanerY );

            }else{
                Console.WriteLine("MOVE " +  moveD + " " + topLanerY );
            }
        }
        
        else if (hero.id==1){
            // CHECK Strat TOP
            if(hero.posX<positionStackX){
                Console.WriteLine("MOVE " + moveA + " " + MiddleLanerY );
            }else{
                Console.WriteLine("MOVE " + moveD + " " + MiddleLanerY );
            }

        }

        else if(hero.id==2){
           
            if(hero.posX<positionStackX){
                Console.WriteLine("MOVE " + moveA + " " + MiddleLanerY );
            }else{
                Console.WriteLine("MOVE " + moveD + " " + MiddleLanerY );
            }
          
        } 

        
    }
    
    
    /*public void retreat(){

        Console.WriteLine("MOVE" + positionDefendX );
    }
    

    public void Defend(){
        Console.WriteLine("MOVE" + positionStackX);
    }

    public void Attack(){
        Console.WriteLine("MOVE"  + positionAttackX);
    }

    public void Stand(){
        Console.WriteLine("WAIT");
    }*/
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
           

        Person[] heroes = new Person[3];


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

                //STORE DATA 
                Strategy roundStrat = new Strategy();
                roundStrat.nearBase= nearBase;


                // Catch the situation 
                Situation situation = new Situation();
                situation.nearBase = nearBase;
                if()
                situation.posEnemyX
            }




            for (int i = 0; i < heroesPerPlayer; i++)
            {
                // Find all Person instances 
                //Check Action todo
                //Write in console the action 
                

                foreach(Person hero in heroes) {

                    hero.role = hero.roles[hero.id];
                    
                    Strategy strat = new Strategy();  
                    strat.checkStrategy(hero);
                    Console.Error.WriteLine(strat.positionY[2]);
                   
                }


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