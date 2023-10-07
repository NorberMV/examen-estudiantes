internal class Program
{
    // from class

    static void Main(string[] args)
    {
        // Declaring some variables
        int cont = 0;
        int idEstudiante=0;
        bool flag = true;
        int numEstudiantes = 4;
        double[] calificaciones = new double[4];
        string[] nombres = new string[4];
        double[] promedios = new double[4];
        string name = " ";
        int n = 0;

        // Matriz de notas
        // Crear una matriz n*4 [nota1,nota1,nota1,nota4]
        int columnas = 4;
        double[,] matrizNotas = new double[numEstudiantes, 4];
        // pre-cargar la matriz de notas con ceros
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matrizNotas[i, j] = 0.0;
            }
        }

        //display menu
        Console.WriteLine("\n\n1.- Capturar datos\r\nde 4 estudiantes y Calcular promedio calificaciones\r\npromedio de calificaciones\r\n0.- Salir");
        Console.Write("Seleccione una opcion: ");
    

        // desicion stage
        string opcion = Console.ReadLine();
        Console.WriteLine();
        // Fail first
        if (opcion == "0")
        {
            // quit the app.
            flag = false;
        }
        // Attempt to convert the desicion input to an int
        else if (int.TryParse(opcion, out int optionNum))
        {
            switch (optionNum)
            {
                case 1:
                    Console.Write($"Se calificaran {numEstudiantes} estudiantes. ");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
            }

        }
        else
        {
            Console.Write("Wrong type argument!");
            flag = false;
        }


        // loop principal
        while (cont <numEstudiantes)
        {
            if (!flag)
            {
                break;
            }
            Console.WriteLine($"Capturando datos del estudiante #{idEstudiante+1} "); 
            Console.Write($"Ingrese el nombre del estudiante #{idEstudiante + 1}: ");
            name = Console.ReadLine();
            calificaciones = ingresoCalificaciones();
            double promedio = promedioCal(calificaciones);
            // guardar nombre de estudiante en array
            nombres[cont] = name;
            //guardar promedio de estudiante en array
            promedios[cont] = promedio;
            // actualizar la matriz para guardar los datos
            matrizNotas = cargarNotas(calificaciones, matrizNotas, idEstudiante);
            idEstudiante++;
            cont++;
        }
        if (flag == true)
        {
            cont = 0;
            Console.WriteLine();
            // Imprimiendo la matriz de Notas
            //matrixPrint(matrizNotas);
            // Let's first check the shape of the matrix
            int numRows = matrizNotas.GetLength(0);
            int numCols = matrizNotas.GetLength(1);
            Console.WriteLine("****PRESENTACION DE NOTAS POR ESTUDIANTE.****") ;

            //loop presentacion resultados
            while (cont < nombres.Length)
            {
                Console.WriteLine($"Las notas del estudiante {nombres[cont]} son las siguientes: ");
                // iterar sobre la matriz en la primer fila
                for (int i = 0; i < numCols; i++)
                {
                    Console.WriteLine(matrizNotas[cont,i] + " ");
                }
                Console.WriteLine("Y su promedio fue:");
                // iterar sobre la matriz en la primer fila
 
                Console.WriteLine(promedios[cont] + "\n");


                Console.WriteLine();
                cont++;
            }
        }

        Console.WriteLine("Programa finalizado, Sayonara!");
        Console.ReadKey();
    }


    // ingresar calificciones
    static double[] ingresoCalificaciones()
    {
        // Ingresar 4 notas por estudiante
        double[] notas = new double[4];

        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Ingrese nota {i + 1}: ");
            string nota = Console.ReadLine();
            if (double.TryParse(nota, out double notaDouble))
            {
                notas[i] = notaDouble;
                Console.WriteLine();
            }


        }
        return notas;

    }

    // Calculo promedio calificaciones
    static double promedioCal(double[] calificaciones)
    {
        double sumatoria = 0;
        foreach (double calificacion in calificaciones)
        {
            // Ir agregando la calificación a la sumatoria
            sumatoria += calificacion;
        }
        // El promedio resulta de dividir la sumatoria entre la cantidad de elementos
        double promedio = sumatoria / calificaciones.Length;
        return promedio;

    }


    static void imprimirCalificaciones(double[] calificaciones)
    {
        for (int i = 0; i < calificaciones.Length; i++)
        {
            Console.WriteLine($"Calificacion {i + 1}: {calificaciones[i]}");
        }

    }

    static double[,] cargarNotas(double[] calificaciones, double[,] matrizNotas, int row)
    {
        for (int i=0; i<calificaciones.Length;i++)
        {
            //Actualizar la matriz de calificaciones
            matrizNotas[row, i] = calificaciones[i];
        }
        return matrizNotas;
            
    }

    // Print matrix func
    static void matrixPrint(double[,] matrixInput)
    {
        // Let's first check the shape of the matrix
        int numRows = matrixInput.GetLength(0);
        int numCols = matrixInput.GetLength(1);
        // Print matrix
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Console.Write(matrixInput[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }


}

