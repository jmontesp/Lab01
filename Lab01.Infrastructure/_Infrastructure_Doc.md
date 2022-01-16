# Documentación Proyecto Lab01.Infrastructure

## Utilidad

Servir como soporte al resto de los proyectos de la solución, definiendo clases, interfaces y recursos comunes, en principio no debe tener código ejecutable salvo Helpers definidos como clases estáticas.

## Dependencias

+ System

## Espacio de Nombres DataStructures

Contiene estructuras de datos comunes a toda la solución.

+ **Fail**: clase derivada de Response diseñada para devolver un fallo.
+ **Response**: clase que define una respuesta propagable por toda la solución.
+ **Success**: clase derivad de Response diseñada para devolver un éxito.

## Espacio de Nombres Delegados

Contiene firmas usadas en los eventos

+ **DelegateSignatures**: delegados

## Espacio de Nombres Interfaces

Contiene todos los interfaces comunes a la solución.

+ **IDataContext**: reunión de todos los interfaces de tratamiento de datos.
+ **ITodoItem**: interfaz de tratamiento de tareas.

## Espacio de Nombres Models

Contiene los modelos de datos utilizados por la aplicación.

+ **TodoItem**: descripción de una tarea.

## Espacio de Nombres Resources

Contiene recursos del sistema

+ **Configuration**: recursos de configuración.
+ **ErrorMsg**: mensajes de error.


