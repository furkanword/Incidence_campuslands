# Gestor de Incidencias CampusLands

El Gestor de Incidencias en CampusLands es una solución completa que facilita la gestión eficiente de los problemas y contratiempos que puedan surgir en el entorno empresarial. Con su registro centralizado, priorización, asignación de responsabilidades, comunicación efectiva, seguimiento y análisis de métricas, así como su capacidad para mantener un historial detallado, este sistema ayuda al personal de CampusLands a optimizar sus procesos y garantizar una resolución efectiva de las incidencias. Estamos seguros de que este proyecto será una herramienta fundamental para impulsar la eficiencia y mejorar la calidad de los servicios en nuestro entorno de trabajo. Este repositorio no se encuentra actulizado a la nueva estructura de proyecto vista.

## Desarrolladores
1. Javier David Campo Suarez 
2. Karen Sofía Velásquez Meneses
3. Julian Esteban Sanabria Sarmiento 
4. Rolando Rodriguez Garcia 
5. Camilo Andres Hernandez Diaz
6. Angel Gabriel Ortega Corzo
7. Kevin Elias Arce Garza
   

## Contenidos del Proyecto

1. [Creación del proyecto Incidencias](#creación-del-proyecto-incidencias)
2. [Creando clase de contexto](#creando-clase-de-contexto)
3. [Instalaciones Necesarias](#instalaciones-necesarias)
4. [Configuracion de la conexion a Mysql](#configuracion-de-la-conexion-a-mysql)
5. [Creando Entidades y Configurations](#creando-entidades-y-configurations)

## Creación del proyecto Incidencias

   Cree una Carpeta principal en la cual se crearan los proyectos internos para la generación del WebApi

------

- ​       Ejecute comando **dotnet new sln** : Genera la solucion principal.

- ​       Ejecute el comando **dotnet new webapi –-output API** : Para crear el proyecto WebApi
- ​       dotnet sln add (Solucion Agregar) ex. dotnet sln add .\API\

- ​       Ejecute el comando : **dotnet new classlib –o Core**
- ​       Ejecute el comando : **dotnet new classlib –o Infrastructure**

- ​       Agregue los proyectos Core e Infrastructure:
    ​    ​    **dotnet sln add** .\Core\
    ​    ​    **dotnet sln add** .\Infrastructure\
    
- ​      Ejecute el comando : **dotnet sln list** -> Para visualizar los proyectos agregados a la solucion

  ```bash
  Proyectos    
  API\API.csproj
  Core\Core.csproj
  Infrastructure\Infrastructure.csproj
  PS D:\projectsNetCore\bodegas>
  ```

------

- Establezca referencia entre los proyectos Infraestructure y Core.

  ```tex
  PS D:\projectsNetCore\bodegas> cd .\Infrastructure\
  PS D:\projectsNetCore\bodegas\Infrastructure> dotnet add reference ..\Core\
  Se ha agregado la referencia "..\Core\Core.csproj" al proyecto.
  PS D:\projectsNetCore\bodegas\Infrastructure>
  ```

  Establezca referencia entre Api e Infrastructure

  ```tex
  PS D:\projectsNetCore\bodegas> cd .\API\
  PS D:\projectsNetCore\bodegas\API> dotnet add reference ..\Infrastructure\
  ```
  
  # Instalaciones Necesarias

1. Instale el paquete de EntityCore ingrese a la url https://www.nuget.org/packages/Microsoft.EntityFrameworkCore En la terminal. El comando se debe ejecutar dentro de la carpeta **Infrastructure y API**.


   ```tex
   dotnet add package Microsoft.EntityFrameworkCore --version 7.0.8
   ```

3. Instale el paquete de Mysql dentro de **Infrastructure** para configurar la conexion a la base de datos. https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql Ejecute el siguiente comando desde la terminal.

   ```tex
   dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
   ```
 
4. Instale el paquete design dentro de **API** para poder hacer las migraciones. https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design . Ejecute el siguiente comando desde la terminal.
   ```tex
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.9
   ```
# Configuracion de la conexion a Mysql

1. En el archivo appsettings.Development.json agregar el parametro ConnectionStrings:

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
       "DefaultConnection":"server=localhost;user=root;password=;database=incidence"
     }
   }
   ```

   

------

# Creando clase de contexto

La clase de contexto se crea en el proyecto Infrastructure/Data. Se recomienda que el nombre de la clase de contexto inicie con el nombre del proyecto. Para el ejemplo **BodegasContext**

```c#
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class incidenceContext : DbContext
{
     public incidenceContext(DbContextOptions<incidenceContext> options) : base(options)
    {
    }       
}
```

En el archivo Program.cs que se encuentra en el proyecto API pegar el siguiente codigo:

```c#
builder.Services.AddDbContext<incidenceContext>(options =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```

Nota : Se recomienda insertar despues de la linea de codigo:

```c#
builder.Services.AddControllers();
```

Nota: Recuerde realizar la importaciones de librerias using

```c#
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
```

# Creando Entidades y Configurations

Crea la carpeta ``Entities`` dentro de Core y haz las entidades requeridas.

**Entidad:** 

```c#
namespace Core.Entities;
public class Incidence
{
    [Key]
    public int Id_Incidence { get; set; }
    public int Id_User { get; set; }
    public int Id_State { get; set; }
    public int Id_Area { get; set; }
    public int Id_Place { get; set; }
    public DateTime Date { get; set; }
}
```

 ​Crea la carpeta ``Data`` dentro de infrastructure.
 
 Crea la carpeta ``Configuration`` dentro de Data y haz la configuracion de cada una de las entidades.

```c#
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");
        builder.Property(p => p.Id_Contact).IsRequired();
        builder.Property(p => p.Id_User).IsRequired();
        builder.Property(p => p.Id_ContactType).IsRequired();
        builder.Property(p => p.Id_CategoryContact).IsRequired();
        builder.Property(p => p.Description_Contact).IsRequired().HasMaxLength(100);
    }
}
```
  
Crea el archivo ``NameDbContext`` que permite la conexion a la base de datos. ///ANGEL

```c#
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InsidenciasContext : DbContext
{
    public InsidenciasContext(DbContextOptions<InsidenciasContext> options) : base(options)
    {
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<AreaUsuario> AreaUsuarios { get; set; }
    public DbSet<CategoriaContacto> CategoriaContactos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
```

Para la creación de las migraciones:

```bash
dotnet ef migrations add InitialCreate --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations
```
Aplicar la migracion a la base de datos:

```bash
dotnet ef database update --project ./Infrastructure/ --startup-project ./API/  
```
