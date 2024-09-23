public class Program
{
    public static void Main(string[] args)
    {
        // Declaración de variables
        int opcion = 0;
        Console.WriteLine("@======================================================================================@");
        Console.WriteLine("Bienvenido a los ejercicios de los Arreglos Unidimensionales y Arreglos Bidimensionales");
        Console.WriteLine("@======================================================================================@");
        Console.WriteLine();

        Console.WriteLine("1. Simulación de dados");
        Console.WriteLine("2. Sistema de Reservaciones de Aerolínea");
        Console.WriteLine("3. Vendedores de una empresa");
        Console.WriteLine("4. Problema de la empresa");
        Console.Write("Por favor, seleccione una opción: ");
        opcion = int.Parse(Console.ReadLine());

        Console.Clear();

        // Argumentos principales
        switch (opcion)
        {
            case 1:
            {
            // Declaración de variables
            int dado1;
            int dado2;
            int suma;
            int tiradas = 36000;
            int[] regularidad = new int[13];
            Random nRandom = new Random();


            Console.WriteLine("* Simulación de dados");
            Console.WriteLine("Presione una tecla para lanzar los dados");
            Console.ReadKey();
            Console.Clear();

            // basicamente lo que hace es que se generan dos numeros aleatorios entre 1 y 6, se suman y se guarda en un arreglo la regularidad de la suma de los dados
            for (int i = 2; i < tiradas; i++)
            {
                dado1 = nRandom.Next(1, 7);
                dado2 = nRandom.Next(1, 7);
                suma = dado1 + dado2;
                regularidad[suma]++;
            }

            // Se imprime la tabla
            Console.WriteLine("[Suma]\t[Regularidad]");
            for (int i = 2; i < regularidad.Length; i++)
            {
                Console.WriteLine("{0}\t{1}", i, regularidad[i]);
            }
            // Verificar si los totales son razonables
            Console.WriteLine("\nDetalles:");
            Console.WriteLine("Regularidad esperada para la suma 7: {0}", tiradas / 6);
            Console.WriteLine("Regularidad obtenida para la suma 7: {0}", regularidad[7]); // Aqui se agarra el valor de un arreglo (que seria el 6to valor) por ende agarra el numero 7

            // Si la regularidad es igual o mayor a 6000, es la esperada, si no, no lo es
            if (regularidad[7] >= tiradas / 6)
            {
                Console.WriteLine("La regularidad obtenida para la suma N° 7 es la esperada.");

            }
            else
            {
                Console.WriteLine("La regularidad obtenida para la suma N° 7 no es la esperada.");
            }

            Console.ReadKey();
            Console.Clear();
            break;
                    
            }
            case 2:
                {
                    // Declaración de variables
                    bool[] asientos = new bool[10];
                    int opcionAerolinea;
                    bool asignado;

                    Console.WriteLine("Bienvenido al sistema de reservaciones de Aerolínea");

                    while (true)
                    {
                        Console.WriteLine("Por favor, seleccione la sección:");
                        Console.WriteLine("1. Sección de fumar");
                        Console.WriteLine("2. Sección de no fumar");
                        
                        opcionAerolinea = int.Parse(Console.ReadLine());

                        asignado = false;

                        if (opcionAerolinea == 1)
                        {
                            // Intentar asignar asiento en la sección de fumar
                            for (int i = 0; i < 5; i++)
                            {
                                if (!asientos[i])
                                {
                                    asientos[i] = true;
                                    Console.WriteLine("Su asiento es el número {0} en la sección de fumar.", i + 1);
                                    asignado = true;
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                            }

                            // Si la sección de fumar está llena, ofrecer la sección de no fumar
                            if (!asignado)
                            {
                                Console.WriteLine("La sección de fumar está llena. ¿Le parece aceptable ser colocado en la sección de no fumar? (s/n)");
                                if (Console.ReadLine().ToLower() == "s")
                                {
                                    for (int i = 5; i < 10; i++)
                                    {
                                        if (!asientos[i])
                                        {
                                            asientos[i] = true;
                                            Console.WriteLine("Su asiento es el número {0} en la sección de no fumar.", i + 1);
                                            asignado = true;
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (opcionAerolinea == 2)
                        {
                            // Intentar asignar asiento en la sección de no fumar
                            for (int i = 5; i < 10; i++)
                            {
                                if (!asientos[i])
                                {
                                    asientos[i] = true;
                                    Console.WriteLine("Su asiento es el número {0} en la sección de no fumar.", i + 1);
                                    asignado = true;
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                            }

                            // Si la sección de no fumar está llena, ofrecer la sección de fumar
                            if (!asignado)
                            {
                                Console.WriteLine("La sección de no fumar está llena. ¿Le parece aceptable ser colocado en la sección de fumar? (s/n)");
                                if (Console.ReadLine().ToLower() == "s")
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (!asientos[i])
                                        {
                                            asientos[i] = true;
                                            Console.WriteLine("Su asiento es el número {0} en la sección de fumar.", i + 1);
                                            asignado = true;
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        // Si no se pudo asignar ningún asiento
                        if (!asignado)
                        {
                            Console.WriteLine("Lo sentimos, no hay asientos disponibles en ninguna sección.");
                            Console.WriteLine("El siguiente viaje sale en 3 horas.");
                            break;
                        }
                    }
                    break;
                }
            case 3:
                {
                    // Inicializar el arreglo de ventas
                    decimal[,] sales = new decimal[5, 4];

                    // Solicitar la entrada de datos
                    Console.Write("Ingrese el número de ventas que desea registrar: ");
                    int numVentas = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numVentas; i++)
                    {
                        Console.WriteLine("Venta {0}: ", i + 1);

                        Console.Write("Ingrese el número del vendedor (1-4): ");
                        int vendedor = int.Parse(Console.ReadLine()) - 1;

                        Console.Write("Ingrese el número del producto (1-5): ");
                        int producto = int.Parse(Console.ReadLine()) - 1;

                        Console.Write("Ingrese el valor total de la venta: ");
                        decimal valor = decimal.Parse(Console.ReadLine());

                        sales[producto, vendedor] += valor;
                    }

                    // Imprimir resultados en forma tabular
                    Console.WriteLine("\n[Producto|Vendedor]\t[C1]\t[C2]\t[C3]\t[C4]\t[Total del Producto]");
                    for (int i = 0; i < 5; i++)
                    {
                        decimal totalProducto = 0;
                        Console.Write("[Producto] ({0})\t\t", i + 1);
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write("{0}\t", sales[i, j]); // SM = Salesman 
                            totalProducto += sales[i, j];
                        }
                        Console.WriteLine("{0}", totalProducto);
                    }

                    // Imprimir totales por vendedor
                    Console.Write("[Total Vendedor]\t");
                    for (int j = 0; j < 4; j++)
                    {
                        decimal totalVendedor = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            totalVendedor += sales[i, j];
                        }
                        Console.Write("{0}\t", totalVendedor);
                    }
                    Console.WriteLine();
                }
                break;
            case 4:
                {
                    // declaración de variables
                    int[] contadores = new int[9];
                    int ventas;
                    int salario;
                    int indice;

                    Console.WriteLine("Bienvenido al sistema de la empresa");
                    Console.WriteLine("* Ingresar ventas");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();

                    while (true)
                    {
                        Console.Write("Ingrese las ventas para calcular la comisión (Ingrese 0 para terminar): ");
                        ventas = int.Parse(Console.ReadLine());
                        if (ventas == 0)
                        {
                            break;
                        }

                        salario = 200 + (int)(0.09 * ventas); // calcular cuanta comision ganarian
                        indice = (salario - 200) / 100;

                        if (indice > 8) indice = 8; // descarte para comision arriba de 1000
                        contadores[indice]++; // es como el ejercicio 1, se guarda en un arreglo la cantidad de comisiones que se ganaron
                    }

                    // imprimir los resultados
                    Console.WriteLine("Resultados:");
                    Console.WriteLine();                   
                    Console.WriteLine("$200-$299: {0} ", contadores[0]);
                    Console.WriteLine("$300-$399: {0}", contadores[1]);
                    Console.WriteLine("$400-$499: {0}", contadores[2]);
                    Console.WriteLine("$500-$599: {0}", contadores[3]);
                    Console.WriteLine("$600-$699: {0}", contadores[4]);
                    Console.WriteLine("$700-$799: {0}", contadores[5]);
                    Console.WriteLine("$800-$899: {0}", contadores[6]);
                    Console.WriteLine("$900-$999: {0}", contadores[7]);
                    Console.WriteLine("$1000 o superior: {0}", contadores[8]);

                    break;
                }
            default:
            {
                    Console.WriteLine("Opción no válida");
                    break;
            }

        }
    }
}
