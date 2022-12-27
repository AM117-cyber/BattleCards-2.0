# BattleCards-2.0
Para abrir el juego el usuario debe seguir los siguientes pasos:

Entrar en la carpeta del juego.

Carpeta con el nombre UserInterface.

Carpeta con el nombre bin.

Carpeta con el nombre Debug.

Carpeta con el nombre net6.0-windows. Verá una ventana como la que se muestra abajo.
 
![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/1.png?raw=true)
 
Haga doble click en UserInterface.exe para que se abra una ventana como esta:

![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/2.png?raw=true)
 
En la ventana se muestran tres botones.Seleccionando el primero se comienza una partida, mientras que el segundo y el tercero te llevan a otra ventana para la creación de cartas.La diferencia es que el segundo botón abre una ventana que ya tiene las propiedades que el diseño del juego permite crear al usuario, junto con un espacio para escribir el valor de cada una.

![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/3.png?raw=true)
 
El tercer botón lleva a una ventana que solo tiene un espacio para escribir, en el cual el usuario debe teclear la descripción de la carta, definiendo los parámetros de esta siguiendo la sintaxis y semántica que se explican a continuación.

![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/4.png?raw=true)
 
Para escribir la definición de una carta se escriben sus propiedades, comenzando por el tipo y colocando las demás en el orden preferido por el usuario, de forma tal que cada propiedad esté separada de su valor por dos puntos y un espacio, como se muestra a continuación: 
Type: Monster
Después de escribir el valor de cada propiedad presione ‘enter’ para escribir otra propiedad con su valor correspondiente. Las únicas propiedades que son indispensables son el nombre de la carta y su tipo; las demás en caso de no ser especificado su valor por el usuario tendrán un valor por defecto:
Valores por defecto de cartas Monster:

Damage: 50

Healing Powers: 0

Armour: 10

ManaCost: 5

HealthPoints: 100

Valores por defecto de cartas Spell:

Damage: 0

Healing Powers: 50

Armour: 0

ManaCost: 5

LifeTime: 1


Propiedades de la carta:

Type: Monster  o   Spell.

Name(Nombre de la carta). 


HealthPoints(solo para cartas de tipo Monster).

LifeTime(solo para cartas de tipo Spell).

HealingPowers(representa la cantidad de puntos de vida que una carta es capaz de incrementar). 


Armour(representa la defensa de la carta).

Damage(representa la cantidad de puntos de vida que una carta es capaz de substraer cuando hace una ataque directo o ataca a otra carta).

ManaCost(representa la cantidad de puntos de mana que un jugador debe tener para invocar la carta).

Attack(representa la cantidad de puntos de vida que una carta es capaz de substraer).

Heal(representa la cantidad de puntos de vida que una carta es capaz de incrementar). 

Defend(representa la defensa de la carta).

Estas tres últimas propiedades pueden expresarse con un valor o a través de expresiones para condicionar su valor al estado del juego.


Expresiones:

Constantes: Puedes escribir números para trabajar con ellos o simplemente asociar un valor al ataque, la defensa o el poder curativo, escribiendo entre paréntesis dichos números.Ejemplo: (30)

OnCard() : Esta expresión se utiliza para referirse a los valores de propiedades de la carta que estás definiendo, entre los paréntesis se coloca la propiedad cuyo valor queremos utilizar, siendo las opciones: Damage, HealingPowers, Armour, HealthPoints, LifeTime y ManaCost.

LifeTime solo es para cartas de tipo Spell y HealthPoints solo es para cartas de tipo Monster.

EnemyCard() : Se utiliza de la misma forma que la expresión anterior, pero se refiere a las propiedades de la carta sobre la cual ejecutarás la acción, ya sea curar o atacar.Tiene las mismas opciones de propiedades con excepción de LifeTime.

OnPlayer(): Esta expresión se utiliza para referirse a los valores de propiedades del jugador que activa el efecto de la carta, es decir, su dueño. Entre los paréntesis se coloca la propiedad cuyo valor queremos utilizar, siendo las opciones: Health, Mana, CardsOnBoard, CardsOnHand. Las dos primeras propiedades corresponden a la vida y el mana actual del jugador respectivamente, mientras que las otras dos corresponden a la cantidad de cartas pertenecientes al jugador en el tablero y en su mano.

EnemyPlayer(): Se utiliza de la misma forma que la expresión anterior, pero se refiere a las propiedades del jugador al cual le pertenece la carta que sobre la cual ejecutarás la acción.


Expresiones binarias(con dos elementos):
Se separan en Expresiones numéricas(que devuelven un número) y Expresiones booleanas(devuelven verdadero o falso):

1-Expresiones numéricas:
Devuelven el resultado de realizar la operación que indica el operador entre los sus dos elementos, por lo cual tanto elemento 1 como elemento 2 deben devolver valores numéricos cuando se evalúen independientemente.
Los distintos operadores son: 

Add(suma los elementos), 

Substract(resta los elementos, tomando el primer elemento como minuendo y el segundo como substraendo), 

Multiply(multiplica los elementos), 

Divide(divide los elementos, tomando el primer elemento como dividendo y el segundo como divisor), 

Pow(eleva el primer elemento al segundo, tomando el primer elemento como base y el segundo como exponente),

Root(obtiene la raíz de orden igual al segundo elemento del primer elemento, tomando el segundo elemento como radical y como radicando el primero).

Ejemplo: Attack: Add( (50), OnCard(HealthPoints))
Esta expresión hace que cuando esta carta vaya a atacar, el valor del ataque sea el resultado se adicionarle 50 a los puntos de vida que tiene dicha carta.


2-Expresiones booleanas:
Devuelven si lo que plantea la expresión a evaluar es verdadero o falso, comparando el primer elemento con el segundo en dependencia del operador.
Los distintos operadores son:

<(verdadero si elemento 1 es menor que elemento 2),

>(verdadero si elemento 1 es mayor que elemento 2),

=(verdadero si elemento 1 es igual que elemento 2),

!=(verdadero si elemento 1 es diferente al elemento 2).


Ejemplo:

<( OnCard(HealthPoints), EnemyCard(HealthPoints))  si la vida de la carta que evalúa la expresión es menor que la vida de la carta con la que va a interactuar entonces esta expresión devuelve verdadero.
Estas expresiones booleanas deben tener como elementos expresiones numéricas, pero existen otras dos expresiones booleanas que se muestran a continuación, cuyos elementos son otras expresiones boolenas:

AND(verdadero si el elemento 1 es verdadero y el elemento 2 es verdadero),

OR(verdadero si al menos uno de sus elementos es verdadero).


Ejemplo:


AND( <( OnCard(HealthPoints), EnemyCard(HealthPoints)), >( OnCard(HealthPoints), EnemyCard(HealthPoints)))
Esta expresión siempre devuelve falso porque no es posible que al comparar un número con otro este sea mayor y menor que el otro, luego ambos elementos no pueden devolver verdadero, por lo cual la expresión es falsa.


Expresiones ternarias(con tres elementos):


IfElse(): Expresión que evalúa su primer elemento(expresión booleana) y devuelve el valor de su segundo elemento si el elemento 1 es verdadero y el valor del tercer elemento si el primero es falso. Por lo tanto esta es una expresión numérica, cuyo primer elemento es una expresión booleana, pero el segundo y el tercero son expresiones numéricas, pudiendo ser estos también expresiones ternarias.

![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/5.1.png?raw=true)
 
Ejemplo de definición de carta:

 ![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/5.png?raw=true)
 
Cuando termine de escribir la definición de la nueva carta presione Next para completar el proceso y guardar la carta. En caso de que la definición presente algún error se verá una ventana de error y en caso contrario se vuelve a la ventana anterior. Si se crea una carta con el mismo nombre de una carta ya existente la nueva sobrescribe a la anterior.

Iniciando una partida:

![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/6.png?raw=true)
 
Lo primero es seleccionar el tipo de jugador y escribir su nombre, luego se presiona Next y se escribe el nombre del siguiente jugador y se selecciona el tipo.
 
 ![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/7.png?raw=true)
 
En caso de seleccionar un jugador virtual se muestran aparecen dos opciones que permitirán elegir su nivel de dificultad, por ahora el único funcional es el nivel Medium.Una vez seleccionado el nivel de dificultad solo debe presionar Next. Cuando ya se han creado los dos jugadores y presionado Next se muestra una ventana que representa el juego:

 ![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/8.png?raw=true)


1-	Botón que indica al jugador virtual que haga una jugada, la cual puede consistir en invocar una carta y/o sacar una del deck, atacar o curar con la carta invocada en el turno, atacar o curar con las cartas restantes en su lado del tablero.
2-	Punto en que se debe hacer click en una carta para seleccionarla, es el mismo para todas, ya sea que estén en el tablero o en la mano.
Reglas del juego:
Cuando inicia un juego cada jugador tiene 5 cartas en su mano y un deck con otras cartas.El jugador que juega en el primer turno inicia el juego con 15 puntos de Mana, mientras que el otro tiene desde el principio 20 puntos.Ambos jugadores inician con 1000 puntos de vida.Los valores de estas propiedades aparecen a los lados del nombre del jugador al cual pertenecen.
Fases:
Hay dos fases: Main Phase y Battle Phase.
Cuando un turno comienza el jugador está en la Main Phase, en la cual las acciones disponibles son invocar cartas desde tu mano al tablero o sacar cartas del deck. Sacar una carta del deck tiene un costo de 1 punto de Mana e invocar una carta consume la cantidad de puntos que indica la propiedad Cost de dicha carta. Para sacar una carta del deck un jugador debe hacer click en su deck, mientras que para invocar se hace click en la carta que se desea invocar y luego se presiona el botón Invoke.
Solo se pueden incorporar cartas a la mano y al tablero mientras haya espacio, por lo que no es posible tener más de 5 cartas en la mano ni en el tablero.
Para salir de Main Phase se hace click en el botón End Turn del panel de botones, lo que da comienzo a la Battle Phase. En esta fase el jugador puede atacar o curar a otra carta que se encuentre en el tablero, para lo cual selecciona la carta con la que quiere realizar la operación, luego hace click en el botón Heal o Attack del panel de botones y finalmente en la carta que debe recibir la acción. En caso de que el otro jugador no tenga cartas de tipo Monster en el tablero, se puede hacer un ataque directo, para lo cual se selecciona la carta con la cual se desea atacar y luego el botón Direct Attack.Esta operación descontará la cantidad de puntos de la propiedad Damage de esa carta a la vida del jugador enemigo. Para salir de la Battle Phase se presiona nuevamente el botón End Turn, iniciando entonces la Main Phase del otro jugador. Al final de cada turno el Mana del jugador sube 5 puntos, pero no alcanza valores superiores a 20.
 



![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/9.png?raw=true)





El juego termina cuando la vida de un jugador llega a 0, mostrando una ventana que indica el ganador.
 



![alt text](https://github.com/AM117-cyber/BattleCards-2.0/blob/main/Images/9.1.png?raw=true)










