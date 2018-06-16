## Configurar la web para que consuma un AzureSQL

>Modificar el `appappsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:conferenceserver.database.windows.net,1433;Initial Catalog=ConferenceDataBase;Persist Security Info=False;User ID=shernandez;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  }
}

```

## Desplegar la web en un app service
1. Desde el Visual studio, en el proyecto web seleccionar publicar.
2. Seleccionamos crear un nuevo perfil de publicaci�n en 'Microsoft Azure App service', y 'Publicar'.
3. En la ventana nueva, en la parte superior derecha seleccionamos a�adir cuenta.
4. A�adimos una cuenta de usuario, por ejemplo una cuenta de prueba de Azure https://azure.microsoft.com/es-es/free/
5. Seleccionamos los siguientes datos:
	> 1. Nombre de la app (Recordemos que la url ser� del tipo "NombreApp".azurewebsites.net)
	> 2. Elegimos nuestra suscripci�n creada como Trial
	> 3. Creamos un nuevo grupo de recursos
	> 4 Creamos un nuevo plan (un S1 esta bien)
	> 5 Seleccionamos en crear