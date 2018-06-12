Debemos de hacer completar el fichero app.ts.
En el que deberemos de vincular el click del botón Start Game y mostorar en el identificador messages un texto como el siguiente: Bienvenido a MultiMath!! Empieza un nuevo juego!!" Además deberemos mostrar en la consola del navegador un mensaje de log informandonos que va a comenzar el nuevo juego.

Una vez tenemos implementado tenemos que configurar un fichero tsconfig.json con las siguientes opciones:
- Que quite los comentarios
- Que se incluyan todos los ficheros ts que hayan dentro de esta carpeta
-que extienda de un tsconfig.base ubicado en la raíz del proyecto

El tsconfig.base.json debera tener la siguiente configuración:
-target: es5
-noimplicitany: false
-salida de los js en una carpeta llamada js