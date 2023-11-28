using System;
using System.IO;

internal class Program
{
    private string textoCifrado;
    private string textoDecifrado;

    private Program()
    {
        textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        textoDecifrado = "";

        for (int i = 0; i < textoCifrado.Length; i++)
        {
            int numerosInt;

            if (i % 5 == 0)
            {
                numerosInt = (int)textoCifrado[i] - 8;
            }
            else
            {
                numerosInt = (int)textoCifrado[i] - 16;
            }

            char caracterDecifrado = (char)numerosInt;
            textoDecifrado += caracterDecifrado;
        }

        textoDecifrado = textoDecifrado.Replace('@', '\n');
    }

    private void MostrarConteudoTextoCifrado()
    {
        Console.WriteLine("Conteúdo do texto cifrado:");
        Console.WriteLine(textoCifrado);
    }

    private void EncontrarPalindromos()
    {
        string[] palindromos = { "gloriosa", "bondade", "passam" };
        string[] palavras = textoDecifrado.Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("\nPalíndromos encontrados:");
        int palindromoIndex = 0;
        for (int i = 0; i < palavras.Length; i++)
        {
            if (IsPalindrome(palavras[i]))
            {
                if (palindromoIndex < palindromos.Length)
                {
                    Console.WriteLine($"{palavras[i]} -> {palindromos[palindromoIndex]}");
                    palindromoIndex++;
                }
            }
        }
    }

    private void MostrarNumeroCaracteresTextoDecifrado()
    {
        int numCaracteres = textoDecifrado.Length;
        Console.WriteLine($"\nNúmero de caracteres do texto decifrado: {numCaracteres}");
    }

    private void MostrarQuantidadePalavrasTextoDecifrado()
    {
        string[] palavras = textoDecifrado.Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        int numPalavras = palavras.Length;
        Console.WriteLine($"Quantidade de palavras no texto decifrado: {numPalavras}");
    }

    private void MostrarTextoDecifradoEmMaiusculo()
    {
        string textoEmMaiusculo = textoDecifrado.ToUpper();
        Console.WriteLine($"\nTexto decifrado em maiúsculo:\n{textoEmMaiusculo}");
    }

    private static bool IsPalindrome(string word)
    {
        int length = word.Length;
        if (length < 3)
        {
            return false; // Ignorar palavras com menos de 3 caracteres
        }

        for (int i = 0; i < length / 2; i++)
        {
            if (word[i] != word[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    private static void Main(string[] args)
    {
        Program programa = new Program();

        programa.MostrarConteudoTextoCifrado();
        programa.EncontrarPalindromos();
        programa.MostrarNumeroCaracteresTextoDecifrado();
        programa.MostrarQuantidadePalavrasTextoDecifrado();
        programa.MostrarTextoDecifradoEmMaiusculo();
    }
}
//      SANDRO DE LIMA