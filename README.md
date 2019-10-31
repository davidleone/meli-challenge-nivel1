# meli-challenge-nivel1
Repositorio exclusivo para la solución del Desafio Nivel 1

## Descripción
Consiste en una aplicación sencilla de consola, en donde le pasamos la cadena de ADN como argumentos y este nos devuelve el resultado.

## Organización
Dentro del repositorio nos encontramos con 2 carpetas.
* __SourceCode:__ código fuente. Solución desarrollada en C# en VisualStudio 2017. Contiene 2 proyectos:
    - Nivel1: proyecto principal donde se encuentra la lógica del algoritmo requerido.
    - Nivel1Tests: proyecto de test donde se encuentran los casos de test unitario.
* __Builds:__ carpeta que contiene el programa compilado y listo para usar. Para probar su funcionamiento hay un .bat en esta carpeta con un ejemplo de uso.

## Compilar solución
En caso de querer compilar la solución de forma manual:
1. Abrir __SourceCode/Nivel1.sln__ con VS.
2. Click derecho en la solución => restore nugets packages.
3. Compilar solución en modo release.
4. Obtener binario desde __SourceCode/Nivel1/bin/Release/Nivel1.exe__