Instrucciones para ejecutar el proyecto

1. Configuración de la base de datos

Antes de ejecutar el proyecto, es necesario abrir SQL Server Management Studio y ejecutar el archivo "BaseDeDatos.sql" del repositorio. Este script permite crear la base de datos, la tabla de usuarios y el procedimiento almacenado necesario para las operaciones CRUD.

2. Configuración de los proyectos de inicio

Una vez configurada la base de datos, abrir el archivo de solución (.sln).
Para ejecutar correctamente la aplicación, es necesario configurar el inicio simultáneo de los dos proyectos:

En el Explorador de soluciones, hacer clic derecho sobre la solución.

Seleccionar la opción Configurar proyectos de inicio.

Marcar la opción proyectos de inicio multiples.

En la columna Acción, seleccionar Iniciar para ambos proyectos:

/servicioWCF
/capaPresentacion

Hacer clic en Aplicar y posteriormente en Aceptar.

3. Ejecución de la aplicación

Finalmente, presionar F5 o seleccionar Iniciar. Esto permitirá ejecutar simultáneamente el servicio WCF y la capa de presentación.

La aplicación web permitirá realizar las operaciones de registro, consulta, modificación y eliminación de usuarios, utilizando el servicio WCF para comunicarse con la base de datos.
