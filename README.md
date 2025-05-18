# Examen-Practico-3
Examen Práctico Terce Parcial: Sistema de Gestión de Registros Académicos en C#, realizado por Fernando Orozco

# Sistema de Gestión de Estudiantes

## Descripción
Realizar una aplicación de consola en C# para ayudar a registrar, ordenar y buscar las matriculas e informaciones de estudiantes de una institución educativa, conociendo los datos que contienen cada uno y el promedio que contiene

## Estructuras de Datos
- `List<Estudiante>`: Ayuda a almacenar estudiantes en orden de su ingreso.
- `Árbol Binario de Búsqueda (BST)`: Ayuda a búscar eficientemente la información de un estudiante con su matrícula.

## Algoritmos
- **MergeSort**: Ayuda con el ordenamiento de los estudiantes por nombre.
- **Búsqueda en BST**: Permite encontrar a los estudiantes por su matrícula en O(log n) en su promedio total.

## Resultados de Pruebas
Despues de 3 distintas pruebas, cada uno resulto con cargas de:
- 10 estudiantes: búsqueda de 10 estudiantes en BST promedio resulto una carga de 1 ms.
- 1000 estudiantes: búsqueda de 1000 estudiantes en BST promedio resulto una carga de 4 ms.
- 5000 estudiantes: búsqueda de 5000 estudiantes en BST promedio resulto una carga de 12 ms.

## Conclusiones
El uso de las estructuras adecuadas como BST y algoritmos eficientes como MergeSort ayudan a mejorar notablemente el rendimiento de comparación con soluciones más simples como listas sin orden y sin índices.
