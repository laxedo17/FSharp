module Tutorial3

//TYPE SYSTEM de F#

//PRODUCT TYPES
//Inclue
//Record Types
//Tuple
//Anonymous record


//Record Type. O mais comunmente usado
//o : int ou : string son type annotations
//que son obligatorias cando defines un type
//basicamente implementase como unha class
//read-only, os tipicos getters de C#
//sen setters. Asi funciona internamente
type Dia = {DiaDoMes: int; Mes: int}
type Persona = {Nome: string; Idade: int}

// type Persona2 = 
//     {
//     Nome: string 
//     Idade: int
//     }
//Son Product Types porque o numero de valores
//E o numero maximo de valores que pode ter. Neste caso imaxinemos que temos 30 dias no mes e 12 meses, o producto diso son 360 valores como maximo
//Podemos separalos por punto e coma 
//type Dia = {DiaDoMes: int; Mes: int}
//type Persona = {Nome: string; Idade: int}
//ou por nova linha

let laurie = {Nome = "Laurie"; Idade = 25}
//anque e algo raro definin Persona2
//cos mismos campos que Persona
//e o type inference do compilador
//considera como valido sempre o ultimo
//type definido que coincida cos campos

//Para que non tome os campos como Persona2, teriamos que escribir
//let laurie : Persona = {Nome = "Laurie"; Idade = 25}

//O ToString() de outras linguaxes
//en F# simplemente mostra o contido
//do constructor do obxeto
//coas propiedades e os seus valores
let laurie2 = {Nome = "Laurie"; Idade = 25}

//laurie e laurie2 se os comparamos
//cunha misma expresion 
//laurie = laurie2
//en F# da true, porque
//en programacion funcional comparanse
//valores, non obxetos completos
//e ambos teñen os mesmos valores
//se facemos laurie > laurie2 e
//por exemplo laurie ten 26 anos e laurie2
//ten 25, laurie seria bigger que laurie2
//compara recursivamente todos os campos
//e por iso di que e bigger

//Metodo Copy dos Record Types
let incrementarIdade persona = 
    { persona with Idade = persona.Idade + 1}
//a chave con un with dentro significa Copy
//asi que toma o obxeto orixinal que se
//compara e fai unha novia copia do obxeto
type Duo = {Persona1: Persona; Persona2: Persona}

let alex = {Nome = "Alex"; Idade = 28}
let irmans = {Persona1 = laurie; Persona2 = alex} 

//Pero isto de arriba faixe moito millor con
//TUPLES
type Duo' = Persona * Persona
//este e un Product Type
//é Persona por varias veces Persona
// (laurie,alex)
//o de arriba e un tuple
//Os Tuples en F# son anonymous types
//que realmente pegan moitos metodos
//e algo moi comun en F#

//Os tuples non tenhen porque ser do
//mesmo datatype
//poderiamos ponher laurie,2700
//e seria un tuple valido de Persona e int
// (laurie,2700)

//Tamen podemos facer un tuple moi amplio
// (lauire,2700,"akgak",2,3,4,5,6,7,7,8,34,1,1,21,1)
//non son boas practicas, pero sirve como exemplo
//En F# faremos moitos tuples

//ANONYMOUS RECORDS
let duoPersona = {|Persona1 = laurie; Persona2 = alex|}

//E un punto medio entre un tuple e un record type
//Non temos que definir o type de anteman
//Pero temos o naming, o cal esta ben
let trio = {|duoPersona with Persona3 = laurie2|}
//asi podemos engadir campos -fields-
//ao type ou instance que temos definido

//A desventaxa dos anonymous records
//e que inda non soportan pattern matching
//que e unha das caracteristicas 
//mais potentes de F#
//o cal e unha desventaxa importante

//SUM TYPES ou DISCRIMINATED UNIONS
//tamen chamados Choice Types
//son parte de algo chamado active patterns
//que son un tipo de pattern matching

//Discriminated unions
type BarallaCartas = 
    | Corazons
    | Treboles
    | Picas 
    | Diamantes

//parece un Enum tipico en Java ou C#
//pero e moito mais potente que un enum
//Chamase Sum Type porque e a suma
//das suas posibilidades
//Temos 4 casos e cada un dos casos
//Ten un valor posible

//Agora imos con outra gran posibilidade
//para as discriminated unions
//falamos de formas
//Un Rectangulo para medilo necesito
//ancho por alto
//enton medimos o Rectangulo usando un Tuple
//o * entre double * double indica que e un tuple
//A palabra clave of e como un constructor
//un constructor dun obxeto

//_base vai con guion baixo
//para distinguila da palabra reservada base
type Forma =
    | Rectangulo of alto:double * _base:double
    | Triangulo of alto:double * _base:double
    | Circulo of radio:double
    | Punto

//Tamen podemos definir o obxeto Rectangulo
//antes, e quedaria algo asi

type RectanguloNormal = {Base: double; Altura: double}

//Punto e unha area constante
//asi que podemos deixala asi sen datos

//Neste caso o Rectangulo a esquerda
//de Rectangulo of Rectangulo
//non e un tipo, e un union case
//basicamente un constructor

//No exemplo e en terminos de .NET
//Forma e unha clase abstracta
//e os casos posibles son clases concretas
//que implementan a clase abstracta

//cando imos a escribir unha funcion sobre
//un type, son boas practicas englobala
//nun module
// module Forma = 
//     let area forma =

//neste module poderiamos utilizar pattern matching
let siOuNon bool =
    if bool 
        then "Si" 
        else "Non"
//F# e unha linguaxe expression based
//e sempre espera que se devolva un valor
//por iso o if then e else son basicos

//Peeeeero en F# non se usan moito os
//if statements porque temos pattern matching
let siOuNonPM bool =
    match bool with
    | true -> "Si"
    | false -> "Non"

//Outra forma de escribilo
//seria coa palabra clave function
let siOuNonPM2 = function
    | true -> "Si"
    | false -> "Non" 
//Function e un metodo que toma un parametro
//E facemoslle pattern matching
//esta ultima funcion e equivalente a isto
let siOuNonPM3 bool =
    (function 
    | true -> "Si"
    | false -> "Non") bool
//Nunca se debe facer esto pero vese que lle
//pasamos un bool a funcion con claridade

//Abaixo queremos valorar se un numero e par
//ou non, facendo pattern matching
let numeroPar = function 
    | x when x % 2 = 0 -> true
    | _ -> false
//o _ guion baixo significa "en calquera outro caso non listado"
//e dicir, se o numero e par, devolve true
//en calquera outro caso devolve false

//Este exemplo e extremo, fixose
//para explicar
//pero esta funcion seria moi facil
//de escribir asi
let numeroPar' x =
    x % 2 = 0

//Mais pattern matching
let eUn = function 
    | 1 -> true
    | _ -> false

//E unha funcion moi sinxela que non
//necesitaria pattern matching
let eUn' numero = 
    numero = 1

//E podemos levar o anterior algo mais lonxe
let eUn'' =
    (=) 1

//Pattern matching brilla en casos moito
//mais complexos

//PATTERN MATCHING resolvendo algoritmo famoso
//O tipico fizzbuzz
//O algoritmo pide que imprimas todos os
//de 1 a 100 na pantalla
//e se o numero e multiplo de 3
//en vez de escribir o numero
//escribes fizz
//E se e multiplo de 5
//en vez de escribir o numero escribes buzz
//E se o numero e multiplo de ambos
//en vez de escribir o numero, escribes fizzbuzz
//Neste caso imos facer ao reves
//traducir fizzbuzz a numeros
let traducirFizzBuzz = function
    | "Fizz" -> string 3
    | "Buzz" -> string 5
    | "FizzBuzz" -> string 15
    | x -> x

// traducirFizzBuzz "Fizz"
// traducirFizzBuzz "Buzz"
// traducirFizzBuzz "FizzBuzz"
// traducirFizzBuzz "Tomate"

type Forma2 =
    | Rectangulo of RectanguloNormal
    | Triangulo of alto:double * _base:double
    | Circulo of radio:double
    | Punto

let circulo = Circulo 1.
let triangulo = Triangulo(2.,4.)

module Forma = 
    let area forma =
        match forma with
        | Rectangulo rect -> rect.Base * rect.Altura
        | Triangulo (a,b) -> a * b / 2.
        | Circulo(r) -> r ** 2. * System.Math.PI
        | Punto -> 1.

module Forma2 = 
    let area forma =
        match forma with
        | Rectangulo {Base = b; Altura = h} -> b * h
        | Triangulo (a,b) -> a * b / 2.
        | Circulo(r) -> r ** 2. * System.Math.PI
        | Punto -> 1.


//Destructor pattern = Constructor
//O que nos sirve como constructor
//Tb nos vale como destructor

//Equivalente ao de arriba
    let area' forma = function
        | Rectangulo {Base = b; Altura = h} -> b * h
        | Triangulo (a,b) -> a * b / 2.
        | Circulo(r) -> r ** 2. * System.Math.PI
        | Punto -> 1.


type Rectangulo =
    | Normal of RectanguloNormal
    | Cadrado of lado:double

module Rectangulo =
    let area = function
        | Normal {Base = b; Altura = h} -> b * h
        | Cadrado l -> l ** 2.

//Esto funciona con Single Case Pattern Matches
//O cal inclue
//Record Types
//Tuples
//Single Case Discriminated Unions
let area {Base = b; Altura = h} =
    b * h

let area' (b,h) = b * h

type IdEncargo = IdEncargo of int

let incrementarIdEncargo (IdEncargo id) =
    id + 1 
    |>IdEncargo

//Tamen se pode expresar asi
//anque hai a quen non lle gustan os parentesis
let incrementarIdEncargo' (IdEncargo id) =
    IdEncargo (id + 1) 

//Ou asi, o cal aplica unha expresion na esquerda
//Usar o <| reverse pipe con precaucion
let incrementarIdEncargo'' (IdEncargo id) =
    IdEncargo <| id + 1 

//Con fun
let incrementarIdEncargo''' =
    fun(IdEncargo id) ->
        IdEncargo <| id + 1

//OPTION TYPE - un tipo de Discriminated Union
type Option1<'a> =
    | Some of 'a
    | None
//isto termina para sempre cos malditos NULL

let traducirFizzBuzz' = function
    | "Fizz" -> 3
    | "Buzz" -> 5
    | "FizzBuzz" -> 15
    | _ ->  failwith "Non e un argumento correcto"

//Domain errors vs Exceptions

//Agora o mismo que antes pero sen Exceptions
let traducirFizzBuzz'' = function
    | "Fizz" -> Some 3
    | "Buzz" -> Some 5
    | "FizzBuzz" -> Some 15
    | _ ->  None

//GENERICS
let tenUnValor = function
    | Some _ -> true
    | None -> false
//En F# non temos que indicar que algo e Generic
//Cando vemos o guion 'a significa que
//o resultado se resolve dinamicamente

//e os tipos de parametros statically typed...
let sumar x y = x + y
//non tivemos que indicar que son int e xa mostra que son 3 int
//exemplo clasico de tipos de parametros statically typed.
//este tipo de parametros permiten
//engadir constraints basados nos membros
//dun type
//se o codigo esta cun inline
//o rendemento para o programa e mais rapido
let inline sumar' x y = x + y
//isto significa que nos tipos requiren un membro chamado plus (do signo +)
//podemos especificar os membros nos types
//volvendo ao caso de Persona
// type Persona2 = 
//     {Nome: string; Idade: int}
//     with
//         static member (+) ({Nome = n1; Idade = i1 },{Nome = n2; Idade = i2 }) =
//         {Nome = n1 + n2; Idade = i1 + i2}

//COLLECTIONS
//Hay 3 tipos de collections ordenadas
//Arrays
//Listas
//
//Os arrays son de tamanho fixo (fixed size)
//e son mutables
//podemos definir un Array asi
// [|1,2,3,4,5,6,7,8,9|]
//Tamen se poden expresar asi
// [|
//     1
//     2
//     3
//     4
//     5
//     6
//     7
//     8
//     9
// |]

//Tamen temos un range operator, para facilitar as cousas
//Danos todos os elementos entre 1 e 10
let arr = [|1 .. 10|]
arr.[0] <- 5
//Como son mutables, non son o tipo de coleccion
//preferida en F#
//O valor 1 cambiouse a 5 por iso que fixemos

//Listas
//Esta e a coleccion preferida en F#
//As listas son inmutables
//en C# unha lista e un ArrayList
//pero en F# e unha lista, e non se usa ArrayList nunca en F#, ou casi nunca, e chamanselle resize arrays
//non recomendado usar ArrayList en xeral
//Declaranse como os ArrayList pero sen o |
// [1,2,3,4,5,6,7,8,9]
// [
//     1
//     2
//     3
//     4
//     5
//     6
//     7
//     8
//     9
// ]
// [1 .. 10]
//Este range operator esta muy bien
//Porque podes establecer os incrementos
//Por exemplo, para que se incremente en 2 cada vez
// [1 ..2.. 10]
//Tamen funciona con doubles
// [1. .. 0.1 .. 10.]
// ['a' .. 'z']
//o de arriba representa os caracteres de a a z
//O beneficio maior dos arrays e que dan
//acceso aleatorio aos elementos (random access)
//Por exemplo, ao elemento 50avo dunha coleccion

//lista
//cons --abreviatura de constructing
type LinkedList<'a> =
    | ([])
    | (::) of head:'a * tail:'a LinkedList
//:: significa engadir
let vacia = []

let engadeNaLista x xs =
    x::xs
//pegamos x ao principio da lista

// let listaExemplo = [2,3,4]
// engadeNaLista 1 listaExemplo
//isto poria o 1 ao frente da lista

//List.head
//queremos obter o 1ro elemento dunha lista
let getPrimeiroElemento = function
    | x::_ -> Some x
    | _ -> None 

//Isto devolvera unha Exception se temos unha lista vacia 
let getPrimeiroElemento' lista = 
    List.head
//Con List.tryHead devolvera unha option en vez dunha Exception

let x: int = List.head []
//se e unha lista de ints

//Recursion / List iter
//en programacion imperativa tipo C#
//usamos un loop for para iterar na lista
//en programacion funcional hay outras
//duas opcions para facer iso
//List.iter e basicamente un loop for
//mais exactamente un foreach

//Unha delas e con tail recursion, que e unha forma de recursividade
// let rec mostraCadaObxetoPorPantalla = function
//     | x::xs -> 
//         printf "%O" x
//         mostraCadaObxetoPorPantalla xs
//     | [] -> ()

// let rec facerConCadaObxeto f = function
//     | x::xs -> 
//         f x
//         facerConCadaObxeto f xs
//     | [] -> ()
let imprimirTodosObxetos lista =
    lista
        |> List.iter (printfn "%O")

//O segundo metodo para facer loops en F# e List.map
let lista1A10 = [1 .. 10]
// -> ["1"; "2".. "10"]
//Map e algo moi prevalente en programacion funcional
let stringificaLista lista =
    lista1A10
    |> List.map string

//.map e como o Select das bases de datos

//List.fold
let lista1A10' = [1 .. 10]
let suma lista =
    lista1A10'
    |> List.fold (fun acumulador obxetoActual -> acumulador + obxetoActual) 0
//Isto e como facer aggregate en C#
//[1;2;3;4;5;6;7;8;9;10]
//Acum: 0 obxetoActual; 1
//Acum: 1 obxetoActual; 2
//Acum: 3 obxetoActual; 3

//Tamen a podemos escribir asi
let suma' lista =
    lista1A10'
    |> List.fold (+) 0
//Fold e como se extendes unha alfombra
//vaise ampliando

//List.reduce
let reduce lista =
    lista1A10'
    |> List.reduce (+)
//Toma unha funcion de dous parametros do mesmo tipo
//Logo toma unha lista dese tipo
//e devolve un valor final
//E como fold pero con duas restriccions
//o type ten que ser capz de combinarse a si mismo
//co operador de adicion -suma- 
//neste caso dous integers co +
//crean un novo integer que e combinacion de ambos
//Esa e a 1ra restriccion, ten que combinarse
//A segunda restriccion e que debe ter
//un zero ou un identity value
//o cal cando engades o cero con outro
//valor do seu tipo
//devolve ese valor
//no caso dos integers, coa funcion plus
//cando engades tres e tes tres and sumaslle
//cero, devolve 3.
//Outro exemplo e a multiplicacion
//Asi que se queres o producto de todos os elementos
//dunha lista. O cero para a funcion de multiplicacion e 1
//por que se por exemplo multiplica 1 x 3, devolve 3
//devolve un tipo que debe ter esas duas limitacions
//para que poida usar o reduce e as funcions de suma

//List.sum
let inline suma'' lista =
    List.sum lista
//funciona con inline, para que se cumplan as restriccions mencionadas arriba

//Bind
//Imaxinemos que temos unha funcion que toma un numero e divideo por outro numero
//se non devolve un int, e devolve un double como 1.5
//enton non queremos o resultado, so queremos un int neste caso como resultado

let divideInteger numero denominador =
    match numero % denominador with 
    | 0 -> Some <| numero / denominador
    | _ -> None
//Con pattern matching indicamos que so aceptamos un integer, que dan como resto 0

let dividirPor2 = divideInteger 2

let bind f = function
    | Some  x -> f x
    | None -> None
// 24
// |> dividirPor2
// |> Option.bind dividirPor2

//Bind so executa a funcion se hai some
//Se hai algo
//Bind xunta duas funcions que normalmente
//non funcionan xuntas

//Exceptions
//Normalmente non se usas Excepcions en programacion funcional, pero si o permite
//Para momentos extraordinarios, podemos querer usar excepcions
exception CannotConnectException of System.Uri
//en F# as excepcions son muy lixeiras
//tenhen varias limitacions
//non podes engadir unha inner exception
//a unha exception
//non podes crear unha mensaxe de excepcion por defecto
//son duas limitacions grandes

//A forma na que se usa normalmente e mais como Union cases
//Como error union cases
let manexar f =
    try
        f ()
    with
    | CannotConnectException uri -> ()
    | :? System.ArgumentException as e -> printfn "%s" e.Message

//A segunda linha indica que tratamos de facer catch a Exception e se llo facemos ponhemola en e, asi podemos imprimir unha mensaxe

// raise (CannotConnectException (Uri("Http://google.es")))

//En vez de excepcions
//en F# facemos Results / Error Modeling
type ErrorRetiradaCartos =
    | FondosInsuficientes of double
    | PINErroneo

type Result<'Ok, 'Error> =
    | Ok of 'Ok
    | Error of 'Error
//A unica diferencia coa clausula Error entre Result e Option, e que a Error Case conten datos
//E moito millor poder documentar que posibles erros tes
//Usaremos Result nalgunha aplicacion de exemplo

type Option<'Ok> =
    | Some of 'Ok
    | None

let result = Error (FondosInsuficientes 10.)



