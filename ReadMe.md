
### Code In game spring challenge 2022 

## Sommaire:

I- Intro  
II- Plan de jeu  
III - Bibliothèque de classes et méthodes   
IV- Stratégie   
V- Conclusion   
 



### I - Intro 

Le but de ce défi Spring Challenge 2022 est de repousser des spiders qui tentent d'attaquer notre base où celle de notre adversaire.   
Nous allons programmer nos 3 héros dans le but de défendre notre base et pousser les spiders à attaquer la base ennemie. 




### II- Plan de jeu 

Dans la première ligue, notre but est tout simplement de défendre notre base. Au fil des ligues des sorts s'ajouteront à la capacité de diriger nos héros afin de coordonner attaque et défense. 

Notre stratégie est la suivante: nous utiliserons deux héros afin de défendre notre base et un héro afin d'empêcher l'adversaire de défendre leur base. 

A chaque tour nous ferons un point sur la situation de la partie pour définir la meilleure action à effectuer. 

Notre priorité est la défense, si nous avons par exemple pas assez de mana pour défendre notre base et pour attaquer en même temps, nous utiliserons notre mana pour défendre 


### III- Bibliothèque de classe et méthodes 

Class Person: Représente nos héros  
  Attributs: (INT) id, (INT) position X, (INT) position y, (INT) vx, (INT) vy, (DOUBLE) distance


Class Spider: Représente les monstres visibles par nos héros  
  Attributs: (INT) id, (INT) position X, (INT) position y, (INT) threatFor, (INT) nearBase,(INT health), (INT) vx, (INT) vy, (Double) distance

Class Sitution: Représente l'état du jeu à chaque tour  
  Attributs: (INT) baseX, (INT) baseY, (INT) mana 


Afin d'attribuer une valeur à nos propriétés, nous allons récupérer les données fournies par CodeInGame à chaque tour et les stocker dans nos objets. 
L'attribut distance résulte d'une fonction mathématique calculant la longueur du vecteur entre la position de l'entité et le point de coordonnées (0,0). 
Il est calculé ainsi: 

Distance =   Racine carré [(posX * posX ) + (posY * posY)] 

Il nous permet de comparer la distance de chaque entité entre elles où par rapport à une base.



### IV -  Évolution du code 

Afin de donner une instruction à chacun de nos héros, il suffit d'écrire une ligne dans la console avec la commande à effectuer. 
La première commande sera attribuée à notre héro 1 la seconde au deuxième héro et la troisième au dernier hero. 

Ainsi à chaque tour nous allons appeler deux fonctions, la première checkIfDanger() va renvoyer deux instructions pour nos deux défenseurs. 
La seconde attackEnemyBase() va renvoyer une instruction d'attaque à notre troisième hero.  


La suite du code n'est qu'une série de condition if - else nous permettant de déterminer la meilleure attaque et la meilleure défense possible. 
Nous allons détailler en français le but de chaque instruction.

Nous définissons d'abord l'emplacement de notre base, si baseX > 4000 alors notre base est au point (17630, 9000) sinon (0,0)       



#### Défense: 


Nous définissons deux listes, les monstres attaquant notre base et les monstres rôdant autour de notre base 

-Si un monstre attaque notre base, nous envoyons nos deux défenseurs le tuer 

-Si deux monstres sont dans notre base nous utiliserons WIND pour les repousser, nous enverrons nos héros les tuer si nous n'avons pas assez de mana. 

-Si trois monstres ou plus attaquent notre base, nous utiliserons WIND, nous enverrons nos héros tuer le monstre le plus proche de notre base si nous n'avons pas assez de mana.



#### Attaque:  

Nous définissons trois listes selon l'ordre de danger que le monstre visible représente pour l'adversaire:
 
-Si le monstre est proche de la base adversaire et l'attaque 

-Si le monstre est éloigné mais sa trajectoire va vers l'adversaire 

-Si le monstre est dans une zone neutre et ne cible pas l'adversaire


Si le monstre attaque la base nous irons en priorité vers lui et lui enverrons un spell WIND afin qu'il se rapproche de la base ennemie. 

Si nous ne voyons pas de monstre dans la base ennemie, mais un monstre en zone neutre se dirigeant vers cette base nous le pousserons avec WIND

Si nous rencontrant uniquement un monstre en zone neutre, nous dévierons sa trajectoire vers la base ennemie avec le spell CONTROL


En cas de mana insuffisant nous irons en priorité vers, le monstre attaquant la base ennemie puis le monstre près de la base ennemie et enfin le monstre en zone neutre.  
Le but est d'attendre que nos défenseurs aient généré assez de mana pour pousser un monstre prés de la base ennemie dés que l'occasion se présente. 


Dans le cas où notre héro en attaque ne rencontre aucun monstre il se mettra en position SPY aux abords de la base ennemie (Sur un des deux côtés car les monstres rentrent généralement dans la base sur le côté).



### V- Conclusion 

# Objectif réussi ! La ligue argent est atteinte ! 

Je tiens à vous remercier pour ce challenge de code car j'ai pris énormément de plaisir à coder pour trouver les solution sur ce jeu. 



Le code se trouve dans le fichier challengeJ2.cs
Vous pouvez voir l'évolution de mon code sur GitHub (github.com/ibbraba/CodeInGameSpringChallenge).
Mon pseudo CodeInGame est ibbraba



A bientôt ! 
