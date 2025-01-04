namespace DsAlRankToGlory.Problems.MatrixProblems;

public class MatrixRotation
{
    public void Rotate(int[][] matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException("matrix", "IsNull");
        }
        if(matrix.Length != matrix[0].Length)
        {
            throw new ArgumentException("matrix.Length", "Matrix should be NxN");
        }

        int n = matrix.Length;

        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;

                int top = matrix[first][i];

                matrix[first][i] = matrix[last - offset][first];

                matrix[last - offset][first] = matrix[last][last - offset];

                matrix[last][last - offset] = matrix[i][last];

                matrix[i][last] = top;
            }
        }
    }
}