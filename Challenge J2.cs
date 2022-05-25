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
    public int vx; 
    public int vy;
    public double distance;

}


public class Spider{
    public int id; 
    public int posX; 
    public int posY; 
    public int threatFor; 
    public int nearBase; 
    public int health;
    public int vx; 
    public int vy;
    public double distance; 
}





public class Situation
{

       public int baseX; 
       public int baseY; 

       public int limitX;
       public int limitY; 


        public void checkIfDanger (List<Spider> dangerSpiders, List<Spider> threatSpiders){

            
    
        int spiderNumber = dangerSpiders.Count; 
        int threatNumber = threatSpiders.Count; 


        //Find The closest enemy from our base
       

        List <Spider> orderThreat = threatSpiders.OrderBy(o=>o.distance).ToList();
        List <Spider> orderDanger = dangerSpiders.OrderBy(o=>o.distance).ToList();   

      
        if(baseX <4000){
        orderThreat = orderThreat.OrderByDescending(o=>o.distance).ToList();
        orderDanger = orderDanger.OrderByDescending(o=>o.distance).ToList();

        }
        
    

        
    

      

        // WHEN NO Spider in our base
        if(spiderNumber == 0 ){

           
            
            //NO Spider threatning 
            if(threatNumber == 0){
                
                for(int i=0; i<3; i++){
                    Console.WriteLine("WAIT no danger");
                }
                

            }

            //Kill the closest Spider threatning
            if(threatNumber == 1 ){
              
                //if(threatSpiders[0].posX <  && threatSpiders[0].posY < 5000){
                Console.WriteLine("MOVE " + orderThreat[0].posX + " " + orderThreat[0].posY + " kill threat1");
                Console.WriteLine("MOVE " + orderThreat[0].posX + " " + orderThreat[0].posY + " kill threat1");
                Console.WriteLine("WAIT");
              /*  }else{
                        for(int i=0; i<3; i++){
                        Console.WriteLine("WAIT");
                        }
                */
                
            }

            
            if(threatNumber == 2 || threatNumber > 2){
               Console.Error.WriteLine("2 threats");

                Console.WriteLine("MOVE " +  orderThreat[0].posX + " " + orderThreat[0].posX  + " kill threat 2+");

                Console.WriteLine("MOVE " + orderThreat[1].posX + " " + orderThreat[1].posX + " kill threat 2+" );

                Console.WriteLine("MOVE " + " " + baseX + " " + baseY); 
            }   
                /*    foreach(Spider spider in orderThreat){
                   
                    if(spider.posX < 7000  && spider.posY < 5000 ){
                        Console.WriteLine("MOVE " + spider.posX + " " + spider.posY);
                   }else{
                        Console.WriteLine("WAIT");
                    //}
                    }

                Console.WriteLine("WAIT"); */
            
              
            

/*
            if(threatNumber == 3 || threatNumber > 3){

                foreach(Spider spider in orderThreat){
                   
                    if(spider.posX < limitX  && spider.posY < 5000 ){
                        Console.WriteLine("MOVE " + spider.posX + " " + spider.posY );
                    }else{
                        Console.WriteLine("WAIT");
                    }
                }

            }
              */
            

        }

       
        //ONE Spider in base       
        if(spiderNumber == 1 ){
             for(int i=0; i<3; i++){
                Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger1");
            }
        }


        //TWO Spiders in base
        if(spiderNumber == 2 ){
            Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger2");
            Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger2");
            Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger2");



        }

        //Three or more spiders in base
        if(spiderNumber == 3 || spiderNumber > 3  ){
            Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger3" + orderDanger[0].id );
            Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger3" + orderDanger[1].id ) ;
            Console.WriteLine("MOVE " + orderDanger[2].posX + " " + orderDanger[2].posY + " kill danger3" + orderDanger[2].id);
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

       


        
        double findDistance( int posX, int posY){
           
            double squareX = posX * posX;
            double squareY = posY * posY;

            double squareDist = squareX + squareY; 
            double dist = Math.Sqrt(squareDist); 

            return dist;
        }



        Console.Error.WriteLine(baseX + " " + baseY);
        // game loop
        while (true)
        {
             Console.Error.WriteLine("Base :" + baseX);
           
           
        Situation situation = new Situation(); 
        situation.baseX = baseX; 
        situation.baseY = baseY; 
        List <Person> allies = new List <Person>();
        List <Spider>  dangerSpiders = new List <Spider>(); 
        List <Spider> threatSpiders = new List<Spider>();
   

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
                    person.vx = vx;
                    person.vy= vy;
                    person.distance=findDistance(x, y);

                    
                    allies.Add(person); 
                } 


                //Store Spiders NearBase
                if (type== 0){
                    Spider spider= new Spider(); 
                    spider.id = id; 
                    spider.posX= x;
                    spider.posY = y; 
                    spider.threatFor= threatFor; 
                    spider.nearBase= nearBase;
                    spider.vx = vx; 
                    spider.vy = vy;
                    spider.distance=findDistance(x,y);
                    if(nearBase==1 && threatFor ==1){
                        dangerSpiders.Add(spider);
                    }    


                    //Spider threating and not far from our base
                    if (nearBase == 0 && threatFor == 1 ){
                        threatSpiders.Add(spider);
                    }
                    
                }
                 

               

                //STORE DATA 
                  
                 // Catch the situation 
               /* if(threatFor == 1 && type == 0 && id!=0){
                    situation.threatFor=1; 
                    situation.posEnemyX= x;
                    situation.posEnemyY= y; 
                    situation.idEnemy =id; 
                } */
                

             
            }


        
           

            situation.checkIfDanger(dangerSpiders, threatSpiders); 
            Console.Error.WriteLine("Base : " + dangerSpiders.Count);
            
            Console.Error.WriteLine("Threat : " + threatSpiders.Count);


        
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