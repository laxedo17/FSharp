namespace FSharpBasico
open System
open System.Threading
//os namespaces son boas formas de conter
//clases, types e modulos
//como e programacion funcional
//imos usar mais types que clases
//MOI Recomendable usar namespaces SEMPRE
//na cima dos nosos ficheiros
//porque un namespace pode conter un monton
//de modules.

//Poremos a maior parte do codigo en modulos
//os modulos contenhen valore, funcions e alguns
//types

//Podemos ter modulos anidados, nested modules

//let x = 1
//non podemos ter valores en namespaces
//asi que a linha de arriba non funciona

module Aritmetico =
    module Suma =
        let sumar x y = x + y

//ACCESS CONTROL
//a let sumar podemos ponherlle
//let private sumar x y = x + y
//e public por defecto
//os modules tamen poden ter accessors privados
//asi que un modulo tamen pode ser private

module Outro =
    let programa =
        Aritmetico.Suma.sumar 5 3

//Se escribimos sumar 5 3 di que non esta definido

//tamen podemos usar este formato
module Outro2 =
    open Aritmetico
    let programa =
        Suma.sumar 5 3




//IMPORTANTE: F# valuase de arriba a abaixo
//Para evitar dependencias ciclicas tipicas das
//linguaxes orientadas a obxetos
//Se ponhemos Outro e Outro2 por enriba de Aritmetico, as referencias de Outro e Outro2 a Aritmetico
//perdense. Todas as tuas definicions estan ordenadas
//isto pode evitarnos moitos problemas á larga

//IMPORTANTE2: Os arquivos tamen estan ordenados!
//E dicir, se creamos un arquivo chamado Tut03.fs
//intentamos facer un open a Outro e está debaixo do
//arquivo onde está Outro, non imos ter problema
//peeeeero se movemos o arquivo por enriba de onde
//se atopa o modulo Outro, o open da error
//xa que non o atopa
//Isto preven dependencias ciclicas
//e son boas practicas.
//Choca o principio, pero o numero de arquivos en F#
//e moi moi pequeno, moi sucinto
//A larga e beneficioso

//En F# non e mala practica ter un monton de codigo
//no mesmo ficheiro
//vai separado por modulos

//un module actua como unha static class
//e e como un trozo de codigo que pode tomar
//elementos do codigo
//un module e unha agrupacion de elementos de codigo

//APLICACION HELLO WORLD con Unit
// module Program = 
//     [<EntryPoint>]
//     let main args = 
//         Console.WriteLine "Hola mundo con ()"
//         0

//UNIT. Fai que sempre se devolva algo return
//Console.WriteLine toma un string
//e devolve Unit. Unit e basicamente void

//IMPRIMIR ALGO EN PANTALLA CON F#
// module Program =
//     [<EntryPoint>]
//     let main args = 
//         printf "Hola mundo"
//         0

//IMPRIMIR ALGO MAIS EN PANTALLA CON F#
//con un parametro extra
// module Program =
//     [<EntryPoint>]
//     let main args = 
//         let idade = 27
//         printf "Hola mundo a minha idade e %i" idade
//         0

//O %i significa que imos imprimir un int
//%s seria un string, %f un float, etc
//printfn engade unha nova linha
//se ponhemos %s arriba en vez de %i
//vai dar un erro dicindo que espera un int
//e non un string, o cal nos axuda
//de cara a cando imos compilar o codigo

//IMPRIMIR ALGO MAIS EN PANTALLA CON F#
//PIDINDO INPUT DE USUARIO
// module Program =
//     [<EntryPoint>]
//     let main args =
//         //1 -> 3
//         //2 -> 4
//         //3 -> 5
//         let sumar2 x = x + 2
//         printf "Hola, como te chamas?"
//         let nome = Console.ReadLine()
//         printfn "Hola %s" nome
//         0

//normalmente pasar parentesis () en F#
//significa que estas enviando Unit
//darlle Unit a unha funcion
//Unit como parametro = Impuro
//Noutras linguaxes, pasar () significa
//que e un metodo
//Cando damos Unit a unha funcion
//a nosa funcion non e deterministic
//As funcions puras son como un mapping
//Que lles das un certo conxunto de inputs
//para certo conxunto de outputs.
//Cando pedimos input de usuario
//Tratamola como Unit porque non e determinista
//Pode devolver casi calquera cousa
//Xa que depende do que se lle ocurro ao usuario
//Nunca vai devolver o mesmo

//CANDO USAR UNIT
//1a razon) Cando hai un side-effect
//2a razon) Cando non e determinista
//3a razon) Cando queres evaluar algo noutro momento
//debido a que F# e unha linguaxe
//eagerly evaluated, ao contrario que Lazy
//o que quere dicir que se escribes
//let x = 1 + 1
//evaluara este valor cando se defina
module Program =
    [<EntryPoint>]
    let main args =
        //1 -> 3
        //2 -> 4
        //3 -> 5
        let sumar2 x = x + 2
        printf "Hola, como te chamas?"
        let nome = Console.ReadLine()
        printfn "Hola %s" nome
        let horaActual () = 
            DateTime.Now

        horaActual()
        |>printfn "Hora = %O"

        Thread.Sleep 2000

        horaActual()
        |>printfn "Hora = %O"
        0
//A DateTime.Now temos que pasarlle UNIT
//Senon non se reevalua
//Con UNIT, cada vez que queiramos usar 
//o valor de DateTime
//Porque DateTime non e deterministic
//non sempre devolve o mesmo valor

//En programacion funcional Pura
//as cousas ten que especificarse
//se son deterministic ou non


//NUNCA usar Thread.Sleep, ten que ser async
//Isto e so de exemplo. Se non se pon Async, 
//o que fai e que bloquea o proceso

//%O e que imos imprimir un obxeto
//en .NET a clase base para todos os types
//e Object, asi que todo e un Object