Debemos de hacer completar los ficheros que hay en App.ts
Bien implementando la clase o la interfaz.
1.- Fichero person.ts => Tendra las propiedades Nombre y Edad y un método FullName() 
2.- Fichero player.ts => Se debera de implementar esta clase que hereda del fichero Person. El Nombre se debe de devolver en mayusculas.
3.- Fichero result.ts => Tendrá las propiedades 
    playerName: string;
    score: number;
    problemCount: number;
    factor: number;
4.- Fichero Scoreboard.ts => Se deberean implementar dos métodos:
    -addResult(newresult): se añadira un nuevo resultado al vector de resultados
    -updateScoreboard():=> Se actualizará los resultados que han habido en la partida para ello hay que ponerlo dentro del id llamado "scores"
5.- Fichero game.ts => tiene dos métodos :
    -displayGame() = Cuando se aprete esta botón se debera de añadir una linea por cada "number of problems" y esta se deberá multiplicar por los el número de linea que toca, todo esto se pondrá dentro del id "game"
    -calculateScore()=> Se comprobarán cada una de las preguntas que hay y se vericicará cuantas se han acertado, para ello hay que utilizar los métodos implementados en el fichero scoreboard.ts
6.- Fichero app.ts. se debe de capturar el evento click del identificador "startGame", para ello cada vez que se arranque un nuevo juego hay que obtener el nombre del jugador, el número de problemas y el factor y despues arrancar un nuevo juego y llamar al método display game. En el mismo fichero se debe de capturar el evento click del identificador "calculate" y su funcionalidad sera calcular cuantas respuestas correctas han realizado.
7.- (Opcional) Fichero utility.ts -> Refactor 



