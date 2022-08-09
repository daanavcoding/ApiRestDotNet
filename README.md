# ApiRestDotNet
Api Rest .Net Daniel Del Viso

Para la Api Rest he generado un script de la base de datos que creé, que se llama Base de datos Api rest.sql

Dentro de la api Rest para la conexion con el servidor de la bbdd está en la carpeta "Models", en la clase "TerminalContext.cs", 
en el método OnConfiguring, dentro de optionsBuilder.UseSqlServer("INSERTE CADENA DE CONEXIÓN AQUí");

Adicionalmente en el archivo dentro de la carpeta "wwwroot", request.js, se encuentra la cadena de petición, si el puerto al que se conecta
es diferente debe insertar su número de puerto en: var url = "https://localhost:INSERTE PUERTO AQUÍ/Terminales";
