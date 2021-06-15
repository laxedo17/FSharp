//en F# os valores asocianse a un nome, non a unha variable como en outras linguaxes. Asi que o 1 é meuUn. Ademais non fai
let meuUn = 1
//se queremos cambiar un tipo int a double, podemos escribir : double despois de meuDous, isto chamase type annotations
let meuDous (meuDous:double) = 2

let letraA = 'a'
let estaActivado = true

//en F# as funcions son valores
//a frecha en F# significa que devolve un valor
//Isto e moi similar as Func de C#
//Basicamente o que ocurre e que o ultimo parametro e o que se devolve
//en C# Func<string, int, int> significa que a funcion toma dous parametros (un string e un int) e devolve un int -ultimo tipo da Func-
//En F# temos int -> int -> int , que significa que toma dous int e devolve un int
let sumar x y = x + y

//esta expresion e a misma que a de arriba, so que e unha lambda expression
let sumar' = fun x y -> x + y

//misma funcion que as anteriores. Isto e unha tecnica que se chama currying ou baking in, e o que fai e que bake in un parametro, neste caso x e faslle bake it in a unha funcion, neste caso x + y. O que facemos e crear un parametro temprano -early-, que crea unha nova funcion que toma outro parametro. Asi que en vez de ter unha funcion que toma dous parametros, tes unha funcion que toma un parametro, que devolve -return- unha funcion que tamen toma un parametro, que devolve o resultado que realmente queres. Esta estratexia e bastante comun en programacion funcional -functional programming-. Creamos dependencias, con baking in, tamen chamado currying, que crea unha funcion que devolve outra funcion, que a sua vez devolve outra funcion.... Se en oop tes unha funcion que devolve 2 parametros, en programacion funcional tes unha funcion que devolve un dos parametros e logo outra que devolve outro dos parametros, etc. De feito TODAS as funcions en F# son curried.

//A funcion sumar orixinal, en realidad no compilador esta escrita como a funcion sumar'' internamente na linguaxe.
let sumar'' x = fun y -> x + y

let sumar5 x = x + 5

//podemos facer nested (anidar) a algunhas funcions.
let sumar7 x =
    let sete = 7
    x + sete

//cada nova linea en F# e unha expresion

//Partial application
let sumar5' x = sumar 5 x
//let sumar5' = sumar 5 (tamen se pode escribir asi)
//na funcion comentada de arriba estamos facendo partial application
//o cal significa que non lle estas pasando a funcion todos os parametros unha vez
//e algo moi sucinto
//Tamen se lle chama Point Free implementation, que significa que non estamos implementando todos os parametros que usamos
sumar5' 6

//Function composition. Combinar funcions xuntas. Moi potente

// (2 * (numero + 3)) ^ 2
let operacion numero = (2. * (numero + 3.)) ** 2.
//Multiplicamos 2 por un numero mais 3 e elevamos todo iso a 2
//os int non soportan o operador de potencia (ao cuadrado), por iso leva un punto porque necesita ser un float

let sumar3 numero = numero + 3
//isto e como dicir 3 + numero
let sumar3' numero = (+) numero 3
//notacion infix, igual que o de arriba pero co infix
//con notacion infix podemos transformalo nisto
let sumar3'' = (+) 3.
let multiplicarPorDous = (*) 2.
//let potenciaDe2 = ( ** ) 2. isto non corresponderia porque o que fas e que elevas a potencia de 2
//no caso da potencia de 2 teriamos que escribir algo asi
let potencia2 numero = numero ** 2.

//enton para xuntar todo o anterior nunha operacion
//e facelo como cando programamos e non como matematicas
//no sentido de ser mais por pasos que nunha expresion matematica, fariamos isto

//Aqui facemos tres operacion
//unha que vai
//float -> float
//float -> float
//float -> float
let operacion' numero =
    let x = sumar3'' numero
    let y = multiplicarPorDous x
    potencia2 y

//Forma perfecta para componher unha funcion
//Hai 2 maneiras de componher as funcions
//O de arriba podemos escribilo asi

//PIPE OPERATOR. Funcion + lexible. 1ª forma
let operacion'' numero =
    numero 
    |> sumar3''
    |> multiplicarPorDous
    |> potencia2
//Quizas a mais lexible das 2, comparada con Composition Operator, e milhor a pipe notation

//COMPOSITION OPERATOR. 2ª forma
let operacion''' =
    sumar3'' 
    >> multiplicarPorDous
    >> potencia2

operacion'' 1.
operacion''' 1.

//Definindo novos operators
let(>>) f g =
    fun x ->
    x
    |> f 
    |> g
    //g(f x) estamos facendo f x e enviando o resultado a g

//FICHEIROS, NAMESPACES, MODULOS
