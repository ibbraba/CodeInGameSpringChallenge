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
       public int mana;


    public void checkIfDanger (List<Spider> dangerSpiders, List<Spider> threatSpiders, Person hero0, Person hero1){

            
    
        int spiderNumber = dangerSpiders.Count; 
        int threatNumber = threatSpiders.Count; 

        int enemyBaseX = 17630-baseX;
        int enemyBaseY = 9000-baseY;

        //Find The closest enemy from our base
       

        List <Spider> orderThreat = threatSpiders.OrderBy(o=>o.distance).ToList();
        List <Spider> orderDanger = dangerSpiders.OrderBy(o=>o.distance).ToList();   

      
        if(baseX  > 4000){
        orderThreat = orderThreat.OrderByDescending(o=>o.distance).ToList();
        orderDanger = orderDanger.OrderByDescending(o=>o.distance).ToList();
         }
        
      // WHEN NO Spider in our base
        if(spiderNumber == 0 ){
            //NO Spider threatning 
            if(threatNumber == 0){
                
            for(int i=0; i<2; i++){
                    Console.WriteLine("WAIT no danger");
                }
                

            } 

            //Kill the closest Spider threatning
            if(threatNumber == 1 ){
              
                //if(threatSpiders[0].posX <  && threatSpiders[0].posY < 5000){
                Console.WriteLine("MOVE " + orderThreat[0].posX + " " + orderThreat[0].posY + " kill threat1");
                Console.WriteLine("MOVE " + orderThreat[0].posX + " " + orderThreat[0].posY + " kill threat1");
               
              /*  }else{
                        for(int i=0; i<3; i++){
                        Console.WriteLine("WAIT");
                        }
                */
                
            }

            
            if(threatNumber == 2 || threatNumber > 2){
              
                Console.WriteLine("MOVE " +  orderThreat[0].posX + " " + orderThreat[0].posX  + " kill threat 2+");

                Console.WriteLine("MOVE " + orderThreat[1].posX + " " + orderThreat[1].posX + " kill threat 2+" );

               
            }   
                
            

        }

       //ONE Spider in base       
        if(spiderNumber == 1 ){
             
                Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger1");
                Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger1");
            
        }


        //TWO Spiders in base
        if(spiderNumber == 2 ){
          
            //USE CONTROL IF MANA
            if(mana> 10) {


                double distanceToHero0 = hero0.distance - orderDanger[0].distance;
                double distanceToHero1 = hero1.distance - orderDanger[0].distance;

                bool spiderNearHero0 = false;
                bool spiderNearHero1 = false;

                     if(distanceToHero0 > -1280 && distanceToHero0 < 1280 ){
                        spiderNearHero0=true; 
                        Console.WriteLine("SPELL WIND " + orderDanger[0].id + " " + enemyBaseX +" " + enemyBaseY +   " WIND " +  orderDanger[0].id);
                        Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger2");
                    }else if(distanceToHero1 > -1280 && distanceToHero1 < 1280 ){
                        Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger2");
                         Console.WriteLine("SPELL WIND " + orderDanger[0].id + " " + enemyBaseX +" " + enemyBaseY +   " WIND " +  orderDanger[0].id);
                    }else{
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger2");
                      Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger2");
                    }


                
                

               
        }else{
            Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill danger2");
            Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill danger2");
            }
        
         
           
        }

        //Three or more spiders in base
        if(spiderNumber == 3 || spiderNumber > 3  ){
            
            //defensive Spell
            if(mana > 10 ){
                
                int spiderNearHero0 = 0;
                int spiderNearHero1 = 0;
             
                foreach (Spider spider in orderDanger){
                    double distanceToHero0 = hero0.distance - spider.distance;
                    double distanceToHero1 = hero0.distance - spider.distance;

                    if(distanceToHero0 > -1280 && distanceToHero0 < 1280 ){
                        spiderNearHero0 ++; 
                    }

                    if(distanceToHero1 > -1280 && distanceToHero1 < 1280 ){
                        spiderNearHero1 ++; 
                    }
                }


                //Check if most dangerous spiider is in range 
                //LOOP CHECK HOW MUCH SPIDERS IN RANGE 
                //IF SPIDER 0 IN RANGE => PRIORITY
                // ELSE IF 2+ SPIDER IN RANGE WIND

                int spiderInRange0 = hero0.posX - orderDanger[0].posX;
                int spiderInRange1 = hero1.posX - orderDanger[0].posX;

                //Choose which defender to launch spell with 
                if(spiderNearHero0 < spiderNearHero1 && spiderInRange0 > -640 && spiderInRange0 < 640  ){
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill hero0 " + orderDanger[0].id );
                    Console.WriteLine("SPELL WIND " + enemyBaseX + " " + enemyBaseY + " SPELL DEFENSE" +orderDanger[0].id );
                }else if (spiderNearHero0 >= spiderNearHero1 && spiderInRange1 > -640 && spiderInRange1 < 640 )
                {
                    Console.WriteLine("SPELL WIND " + enemyBaseX + " " + enemyBaseY + " SPELL DEFENSE"+orderDanger[0].id );
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill hero1 " + orderDanger[0].id );
                }else if (spiderNearHero0 == spiderNearHero1 && spiderInRange0 > -640 && spiderInRange0 < 640){
                    Console.WriteLine("SPELL WIND " + enemyBaseX + " " + enemyBaseY + " DEFENSIVE "+orderDanger[0].id );
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill hero1 " + orderDanger[0].id );
                }
                
                
                else{
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " DEFENSE " + orderDanger[0].id );
                    Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " DEFENSE " + orderDanger[0].id ) ;
                }



            }else{
                Console.WriteLine("MOVE " + orderDanger[0].posX + " " + orderDanger[0].posY + " kill ID " + orderDanger[0].id );
                Console.WriteLine("MOVE " + orderDanger[1].posX + " " + orderDanger[1].posY + " kill ID " + orderDanger[1].id ) ;
                }
            
       //     Console.WriteLine("MOVE " + orderDanger[2].posX + " " + orderDanger[2].posY + " kill danger3" + orderDanger[2].id);
        }
    }

        public void attackEnemyBase(List <Person> enemiesHeroes, Person hero2 , List<Spider> enemySpiders, List<Spider> neutralSpiders, List<Spider> potentialEnemySpider){ 


            int enemySpidersCount = enemySpiders.Count();
            int neutralSpidersCount = neutralSpiders.Count();

            int potentialEnemiesCount = potentialEnemySpider.Count();
            int enemiesHeroesCount = enemiesHeroes.Count();


            int windDirection = - 201; 
            int enemyBaseX = 17630-baseX;
            int enemyBaseY = 9000-baseY;

            int spyBottomX; 
            int spyBottomY; 

            int spyTopX;
            int spyTopY;

            bool positionTop; 

            if (enemyBaseX == 17630){
                spyBottomX = 14300; 
                spyBottomY = 8500;

                spyTopX =17250;
                spyTopY = 4250;
            }else{ 
                spyBottomX = 3500; 
                spyBottomY = 630;

                spyTopX =3000;
                spyTopY = 200;

            }

            //bool closeToEnemyID=false;

            bool heroCommanded = false;  

            List <Spider> orderPotential = potentialEnemySpider.OrderByDescending(o=>o.distance).ToList();
            List <Spider> orderEnemy = enemySpiders.OrderByDescending(o=>o.distance).ToList();
            List <Spider> orderNeutral = neutralSpiders.OrderByDescending(o=>o.distance).ToList();
        
            if(baseX > 4000){
            orderEnemy = orderEnemy.OrderBy(o=>o.distance).ToList();
            orderNeutral = orderNeutral.OrderBy(o=>o.distance).ToList();
            orderPotential = orderPotential.OrderBy(o=>o.distance).ToList();
            //Define where to place our hero to spell a mignon in oppenent base trajectory 
            windDirection = 201;
            }
            foreach(Spider enemy in potentialEnemySpider){
            Console.Error.WriteLine("Ennemies : " + enemy.id);

            }

              //FARM IF ENEMY BASE NOT THREATEND

                //CHECK NUMBER OF SPIDERS, ATTACK ONE Not threatning

            //PUSH ENEMY IF NEAR BASE AND MANA AVAILABLE

            //PUSH ENEMY IF IN BASE AND MANA AVAILABLE

            //PIORITY

         /*   if(enemiesHeroesCount > 0 && potentialEnemiesCount > 0){ 

              foreach(Person enemy in enemiesHeroes){

                double distanceHeroToSpider = hero2.distance - enemy.distance;
                Console.Error.WriteLine("distance to" + enemy.id + ": " + distanceHeroToSpider);

                if(distanceHeroToSpider > -1280 && distanceHeroToSpider < 1280 && heroCommanded == false && mana > 10){
                    Console.WriteLine("SPELL CONTROL " + enemy.id + " " + baseX + " " + baseY + " CONTROL HERO" + enemy.id);
                    heroCommanded= true; 
                }
                  
               }
               
               if (heroCommanded ==  false){
                    Console.WriteLine("MOVE " + enemiesHeroes[0].posX + " " + enemiesHeroes[0].posY + " Target Hero");
                    heroCommanded=true; 
                }

            } */ 



            if(potentialEnemiesCount> 0){

                Console.Error.WriteLine("POTENTAL !");

                foreach(Spider enemy in orderPotential){ 

                     //Check if spider can be spelled
                    double distanceHeroToSpider = hero2.distance - enemy.distance;

                    if(distanceHeroToSpider > -1280 && distanceHeroToSpider < 1280 && heroCommanded == false && mana > 10){

                            //IF ENEEMY CONTROL AWAY


                            //IF NEARBASE PROTECT 

                       if( enemy.threatFor==2 && enemy.nearBase == 1  ){
                        Console.WriteLine("SPELL WIND " + enemyBaseX + " " +  enemyBaseY + " WIND " + enemy.id);
                        heroCommanded =true; 
                        } else if(enemy.threatFor==0){
                             Console.WriteLine("SPELL CONTROL " + enemy.id + " " + enemyBaseX + " " + enemyBaseY +  " CONTROL " + enemy.id);
                            heroCommanded =true; 
                            }



                            //IF NO THREAT PUSH

                         }
                    

                }

                

           


            }
        
            if( enemySpidersCount > 0 && heroCommanded == false){ 



                // Define if a spell has already been thrown this round 
               foreach(Spider spider in orderEnemy){
                        //Check if spider can be spelled
                        double distanceHeroToSpider = hero2.distance - spider.distance;
                        //Check if distance is close and mana available
                        if(distanceHeroToSpider > -1280 && distanceHeroToSpider < 1280 && heroCommanded == false && mana > 20){
                               Console.WriteLine("SPELL WIND " + enemyBaseX  + " " + enemyBaseY + " Spell enemy" ); 
                               heroCommanded = true;
                        }


                }
 
                //If no spider close get close to the most enemy threatning spider 

                if(heroCommanded == false){ 
                    int  x = orderEnemy[enemySpidersCount-1].posX+windDirection;
                    int y = orderEnemy[enemySpidersCount-1].posY+windDirection;
                    Console.WriteLine("MOVE " +  x + " " + y +  " get close ID" + orderEnemy[enemySpidersCount-1].id);
                    heroCommanded = true;
                }

            }
             

            if( neutralSpidersCount > 0 && heroCommanded == false){
                
            
                foreach(Spider spider in orderNeutral){
                        //Check if spider can be spelled
                        double distanceHeroToSpider = hero2.distance - spider.distance;
                        //Check if distance is close and mana available
                        if(distanceHeroToSpider > 1280 && distanceHeroToSpider < 1280 && heroCommanded == false && mana > 20){
                               Console.WriteLine("SPELL CONTROL " + spider.id + " "+ enemyBaseX  + " " + enemyBaseY + " Spell neutral" ); 
                               Console.Error.WriteLine("CAN ATTACK ID" + spider.id);
                               heroCommanded = true;
                        }
                }
                int spiderCount = orderNeutral.Count;
                // Kill the closest spider from our base
                 if(heroCommanded == false){ 
                         int x;
                         int y;


                         //Make sure attacking hero is close
                         double isClose = hero2.distance - orderNeutral[0].distance;
                        
                        if( mana >= 10 && isClose> -2200 && isClose < 2200 ){
                            x = orderNeutral[0].posX;
                            y = orderNeutral[0].posY;
                        Console.WriteLine("MOVE " + x + " "+ y + " MOVETO"  + orderNeutral[0].id);
                        heroCommanded = true;
                        }else{ 


                        if(hero2.posY < spyTopX -2000){
                            Console.WriteLine("MOVE " + spyBottomX +" " +  spyBottomY + " SPYBOTTOM");


                        }else{
                            Console.WriteLine("MOVE " + spyTopX +" " +  spyTopY + " SPYTOP");

                        }

                        }
                         //IF too far away from base farm 
                         //If close ignore 
                        
                        /*

                        else{ 
                            x = orderNeutral[0].posX+windDirection;
                            y = orderNeutral[0].posY+windDirection;
                         Console.WriteLine("MOVE " + x  + " " + " " + y + " FARM");
                        }*/
                    }
   

          
            }

            if (neutralSpidersCount == 0 && enemySpidersCount == 0){
                
        
                Console.WriteLine("MOVE " + spyBottomX +" " +  spyBottomY + " HI BRO ");
                  

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

        int enemyBaseX = 17630-baseX;
        int enemyBaseY = 9000-baseY;

        double enemyBaseDistance = findDistance(enemyBaseX, enemyBaseY);

        // game loop
        while (true)
        {
             
           
           
        Situation situation = new Situation(); 
        situation.baseX = baseX; 
        situation.baseY = baseY; 


        List <Person> allies = new List <Person>();
        List <Person> enemy = new List<Person> ();


        List <Spider>  dangerSpiders = new List <Spider>(); 
        List <Spider> threatSpiders = new List<Spider>();

        List <Spider> enemySpiders = new List<Spider>();
       
        List <Spider> neutralSpiders =  new List<Spider>();

        
        List <Spider> potentialEnemySpider =  new List<Spider>();

            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int health = int.Parse(inputs[0]); // Each player's base health
                int mana = int.Parse(inputs[1]); // Ignore in the first league; Spend ten mana to cast a spell
                if(i == 0){
                    situation.mana = mana;
                }
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


                if(type == 2 ){
                    Person person = new Person(); 
                    person.id = id;
                    
                    person.posX=x;
                    person.posY=y;
                    person.health=health;
                    person.vx = vx;
                    person.vy= vy;
                    person.distance=findDistance(x, y);
                    Console.Error.WriteLine("x:" + x + " y: " + y );
                    enemy.Add(person);

                }

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


                    //GET SPIDERS ATTACKIG ENEMY BASE 
                    if(threatFor == 2 ){ 
                        enemySpiders.Add(spider);
                    }

                    //GET spiders in neutral zone
                    if(nearBase == 0 ){
                        neutralSpiders.Add(spider);
                    }

                    if(spider.distance - enemyBaseDistance > -6000 && spider.distance - enemyBaseDistance < 6000 ){
                        potentialEnemySpider.Add(spider);
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



           
            //DEFENSIVE PLAN FOR THE ROUND
            situation.checkIfDanger(dangerSpiders, threatSpiders, allies[0], allies[1]); 
            
            //OFFENSIVE PLAN FOR THE ROUND
       
            situation.attackEnemyBase(enemy, allies[2] ,enemySpiders, neutralSpiders, potentialEnemySpider);

         //   Console.Error.WriteLine("Base : " + dangerSpiders.Count);
            
          //  Console.Error.WriteLine("Threat : " + threatSpiders.Count);


        
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