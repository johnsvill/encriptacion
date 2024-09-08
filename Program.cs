
Dictionary<char, int> abecedario = new Dictionary<char, int>()
{
    { '_', 0 },
    { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 },
    { 'F', 6 }, { 'G', 7 }, { 'H', 8 }, { 'I', 9 }, { 'J', 10 },
    { 'K', 11 }, { 'L', 12 }, { 'M', 13 }, { 'N', 14 }, { 'O', 15 },
    { 'P', 16 }, { 'Q', 17 }, { 'R', 18 }, { 'S', 19 }, { 'T', 20 },
    { 'U', 21 }, { 'V', 22 }, { 'W', 23 }, { 'X', 24 }, { 'Y', 25 },
    { 'Z', 26 }, { ',', 27 }, { '.', 28 }
};

//Solicitar al usuario que ingrese un texto
Console.WriteLine("Ingresa un texto de longitud par:");

Console.WriteLine();

string texto = Console.ReadLine().ToUpper();

Console.WriteLine();

if (texto.Length % 2 != 0)
{
    Console.WriteLine("El texto debe tener una longitud par.");
    return;
}

//Matriz normal y su inversa
int[] matriz = { 1, 2, 2, 5 };
int[] matrizInversa = { 5, 27, 27, 1 };

//Lista para almacenar los resultados de los pares
List<(int, int)> resultados = new List<(int, int)>();
string mensajeOriginal = "";

//Procesar el texto en pares de letras
for (int i = 0; i < texto.Length; i += 2)
{
    char letra1 = texto[i];
    char letra2 = texto[i + 1];

    if (abecedario.ContainsKey(letra1) && abecedario.ContainsKey(letra2))
    {
        int valor1 = abecedario[letra1];
        int valor2 = abecedario[letra2];

        //Crear el vector con los valores de las letras
        int[] vector = { valor1, valor2 };

        //Operar el vector con la matriz y aplicar módulo 29
        int resultado1 = (vector[0] * matriz[0] + vector[1] * matriz[1]) % 29;
        int resultado2 = (vector[0] * matriz[2] + vector[1] * matriz[3]) % 29;
       
        //Asignar valores del diccionario según corresponda la posición
        char letraResultado1 = abecedario.FirstOrDefault(x => x.Value == resultado1).Key;
        char letraResultado2 = abecedario.FirstOrDefault(x => x.Value == resultado2).Key;

        resultados.Add((resultado1, resultado2));

        Console.WriteLine(@$"
                    Par ordenado: {letra1}{letra2} 
                    Vector resultante: [{valor1}, {valor2}] 
                    Resultado encriptado: [{letraResultado1}, {letraResultado2}]");
    }
    else
    {
        Console.WriteLine($"Par: {letra1}{letra2}, contiene letras no asignadas.");
    }       
}

//Aplicar matriz inversa
foreach (var resultado in resultados)
{
    //Operar el vector con la matriz inversa y aplicar módulo 29
    int resultado3 = (resultado.Item1 * matrizInversa[0] + resultado.Item2 * matrizInversa[1]) % 29;
    int resultado4 = (resultado.Item1 * matrizInversa[2] + resultado.Item2 * matrizInversa[3]) % 29;

    //Asignar valores del diccionario según corresponda la posición
    char letraResultado3 = abecedario.FirstOrDefault(x => x.Value == resultado3).Key;
    char letraResultado4 = abecedario.FirstOrDefault(x => x.Value == resultado4).Key;
    
    mensajeOriginal += letraResultado3.ToString() + letraResultado4.ToString();
}

Console.WriteLine();

//Mostrar el mensaje original
Console.WriteLine($"Mensaje original: {mensajeOriginal}");

Console.ReadKey();
