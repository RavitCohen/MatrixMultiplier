using System;
using System.Threading;

public class MatrixMultiplier
{
    public static void MultiplyMatricesConcurrently(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int rowsA, int colsA, int colsB, int numThreads)
    {
        Thread[] threads = new Thread[numThreads];
        int jump = rowsA / numThreads;
        for (int i = 0; i < numThreads; i++)
        {
            int startI = i * jump;
            int endI = (i == numThreads - 1) ? rowsA : startI + jump;
            threads[i] = new Thread(() => helperMultiply(matrixA, matrixB, resultMatrix, colsA, colsB, startI, endI));
            threads[i].Start();
        }
        // Wait for all threads to complete
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

    // Helper function for each thread
    public static void helperMultiply(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int colsA, int colsB, int startI, int endI)
    {
        for (int i = startI; i < endI; i++) // from 0 to rowsA
        {
            for (int j = 0; j < colsB; j++)
            {
                //Calculate the resault of each cell in resaultMatrix
                resultMatrix[i, j] = 0;
                for (int k = 0; k < colsA; k++)
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
    }
}

    /*
    // Print matrix to check the results easier
    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Initialize random matrix by range of values
    private static Random random = new Random();

    public static void FillMatrixWithRandomValues(int[,] matrix, int minValue, int maxValue)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }
}


class program
{
    static void main()
    {
        int rowsa = 1000;
        int colsa = 2000;
        int colsb = 5000;
        int numthreads = 20;
        int[,] matrixa = new int[rowsa, colsa];
        int[,] matrixb = new int[colsa, colsb];
        int[,] resultmatrix = new int[rowsa, colsb];

        initialize random values at matrixa and matrixb
        matrixmultiplier.fillmatrixwithrandomvalues(matrixa, 1, 100);
        matrixmultiplier.fillmatrixwithrandomvalues(matrixb, 1, 100);

        call function that calculate by threads
        matrixmultiplier.multiplymatricesconcurrently(matrixa, matrixb, resultmatrix, rowsa, colsa, colsb, numthreads);

        print matrix to check
        matrixmultiplier.printmatrix(matrixa);
        matrixmultiplier.printmatrix(matrixb);
        matrixmultiplier.printmatrix(resultmatrix);
    }
}
*/