using System;
using System.Collections.Generic;

public class Estudiante
{
    public string Nombre { get; set; }
    public string Matricula { get; set; }
    public double Promedio { get; set; }
    public Estudiante(string nombre, string matricula, double promedio)
    {
        Nombre = nombre;
        Matricula = matricula;
        Promedio = promedio;
    }
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Matrícula: {Matricula}, Promedio: {Promedio}";
    }
}

public class NodoBST
{
    public Estudiante Estudiante { get; set; }
    public NodoBST Izquierdo { get; set; }
    public NodoBST Derecho { get; set; }
    public NodoBST(Estudiante estudiante)
    {
        Estudiante = estudiante;
    }
}

public class ArbolBST
{
    public NodoBST Raiz;
    public void Insertar(Estudiante estudiante)
    {
        Raiz = InsertarRec(Raiz, estudiante);
    }
    private NodoBST InsertarRec(NodoBST nodo, Estudiante estudiante)
    {
        if (nodo == null)
            return new NodoBST(estudiante);
        if (string.Compare(estudiante.Matricula, nodo.Estudiante.Matricula) < 0)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, estudiante);
        else
            nodo.Derecho = InsertarRec(nodo.Derecho, estudiante);
        return nodo;
    }
    public Estudiante Buscar(string matricula)
    {
        return BuscarRec(Raiz, matricula);
    }
    private Estudiante BuscarRec(NodoBST nodo, string matricula)
    {
        if (nodo == null)
            return null;
        if (nodo.Estudiante.Matricula == matricula)
            return nodo.Estudiante;
        else if (string.Compare(matricula, nodo.Estudiante.Matricula) < 0)
            return BuscarRec(nodo.Izquierdo, matricula);
        else
            return BuscarRec(nodo.Derecho, matricula);
    }
}

public static class Algoritmos
{
    public static List<Estudiante> MergeSort(List<Estudiante> lista)
    {
        if (lista.Count <= 1)
            return lista;
        int mitad = lista.Count / 2;
        var izquierda = MergeSort(lista.GetRange(0, mitad));
        var derecha = MergeSort(lista.GetRange(mitad, lista.Count - mitad));

        return Merge(izquierda, derecha);
    }
    private static List<Estudiante> Merge(List<Estudiante> izq, List<Estudiante> der)
    {
        var resultado = new List<Estudiante>();
        int i = 0, j = 0;
        while (i < izq.Count && j < der.Count)
        {
            if (string.Compare(izq[i].Nombre, der[j].Nombre) <= 0)
                resultado.Add(izq[i++]);
            else
                resultado.Add(der[j++]);
        }
        resultado.AddRange(izq.GetRange(i, izq.Count - i));
        resultado.AddRange(der.GetRange(j, der.Count - j));
        return resultado;
    }
}

class Program
{
    static List<Estudiante> estudiantes = new List<Estudiante>();
    static ArbolBST bst = new ArbolBST();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- SISTEMA DE ESTUDIANTES ---");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar por matrícula");
            Console.WriteLine("3. Ordenar por nombre");
            Console.WriteLine("4. Mostrar todos");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    AgregarEstudiante();
                    break;
                case "2":
                    BuscarMatricula();
                    break;
                case "3":
                    OrdenarEstudiantes();
                    break;
                case "4":
                    MostrarEstudiantes();
                    break;
                case "5":
                    return;
            }
        }
    }
    static void AgregarEstudiante()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine();
        Console.Write("Promedio: ");
        double promedio = double.Parse(Console.ReadLine());

        var estudiante = new Estudiante(nombre, matricula, promedio);
        estudiantes.Add(estudiante);
        bst.Insertar(estudiante);
    }
    static void BuscarMatricula()
    {
        Console.Write("Ingrese matrícula a buscar: ");
        string matricula = Console.ReadLine();
        var resultado = bst.Buscar(matricula);
        Console.WriteLine(resultado != null ? resultado.ToString() : "No encontrado.");
    }
    static void OrdenarEstudiantes()
    {
        estudiantes = Algoritmos.MergeSort(estudiantes);
        Console.WriteLine("Estudiantes ordenados por nombre.");
    }
    static void MostrarEstudiantes()
    {
        foreach (var e in estudiantes)
        {
            Console.WriteLine(e);
        }
    }
}