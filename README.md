# Documentación de la Template

## Descripción
Esta template se utilizará para hacer proyectos de API robustas en .NET
Se incluirá un manual de cómo proceder en cada punto. Incluye instancia en Docker con base de datos postgre.


## Gestiones
### Configuración de los esquemas
Dentro del proyecto Data.Access.EF habrá una carpeta `Extensions` y dentro un archivo `Schemes.cs`. Este archivo indicará todos los esquemas que se vayana utilizar en la base de datos. Se debe manejar de la siguiente manera:

```cs
builder.ToTable("Users", schema: Schemes.SECURITY.ToString("F"));
```

La agregación de las tablas y los esquemas se debe manejar dentro del mismo proyecto en la carpeta `EntityConfig` en cada uno de los archivos de configuración de las entidades de la base de datos.



## Usos
### Generación de la Migración Inicial
Para crear la migración ejecute el siguiente comando:
```bash
dotnet ef migrations add nombre_migracion -p ..\Data.Access.EF\ -c ApplicationDbContext
```
Este comando generará una nueva migración en la base de datos utilizando el contexto de Entity Framework `ApplicationDbContext`. Asegúrese de que la ruta proporcionada (-p) sea la correcta.



### Aplicación de la Migración
Para aplicar la migración a la base de datos utilice el siguiente comando:
```bash
dotnet ef database update -p ..\Data.Access.EF\ -c ApplicationDbContext
```
Este comando aplicará la migración a la base de datos, asegurándose de que la estructura de la base de datos esté actualizada con la última migración.



### Generación de Script SQL
Para generar un script sql de la base de datos utilice el siguiente comando:
```bash
dotnet ef migrations nombre_script -o Scripts/script.sql -p ..\Data.Access.EF\ -c ApplicationDbContext
```
Este comando generará un script sql de la base de datos una vez tenga hecha la migración dentro de una ruta marcada con (-o)

La ruta (-p) debe ser correcta, que si no se toca la template, siempre será la misma y no tendrá que preocuparse.
