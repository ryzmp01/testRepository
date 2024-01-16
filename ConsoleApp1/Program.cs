public class ScytaleCipher
{
    public string Encrypt(string text, int diameter)
    {
        int textLength = text.Length;
        int rows = (int)Math.Ceiling((double)textLength / diameter);
        char[,] matrix = new char[rows, diameter];
        string cipherText = string.Empty;

        for (int i = 0, k = 0; i < rows; i++)
        {
            for (int j = 0; j < diameter; j++)
            {
                if (k < textLength)
                    matrix[i, j] = text[k++];
                else
                    matrix[i, j] = ' ';
            }
        }

        for (int j = 0; j < diameter; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                cipherText += matrix[i, j];
            }
        }

        return cipherText;
        // Шифрование
    }

    public string Decrypt(string cipherText, int diameter)
    {
        int cipherLength = cipherText.Length;
        int rows = (int)Math.Ceiling((double)cipherLength / diameter);
        char[,] matrix = new char[rows, diameter];
        string text = string.Empty;

        for (int j = 0, k = 0; j < diameter; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (k < cipherLength)
                    matrix[i, j] = cipherText[k++];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < diameter; j++)
            {
                if (matrix[i, j] != '\0')
                    text += matrix[i, j];
            }
        }

        return text.Trim();
        // Дешифрование
    }

    static void Main(string[] args)
    {
        ScytaleCipher scytaleCipher = new ScytaleCipher();

        Console.Write("Введите слова для зашифровки: ");
        string originalText = Console.ReadLine();
        int diameter = 5;

        string cipherText = scytaleCipher.Encrypt(originalText, diameter);
        Console.WriteLine("Зашифрованный текст: " + cipherText);

        string decryptedText = scytaleCipher.Decrypt(cipherText, diameter);
        Console.WriteLine("Расшифрованный текст: " + decryptedText);
    }

}

