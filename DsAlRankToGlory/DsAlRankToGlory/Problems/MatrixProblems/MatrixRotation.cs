namespace DsAlRankToGlory.Problems.MatrixProblems;

public class MatrixRotation
{
    public void Rotate(int[][] matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix), "IsNull");
        if (matrix.Length != matrix[0].Length)
            throw new ArgumentException("Matrix should be NxN", nameof(matrix.Length));

        var n = matrix.Length;

        for (var layer = 0; layer < n / 2; layer++)
        {
            var first = layer;
            var last = n - 1 - layer;

            for (var i = first; i < last; i++)
            {
                var offset = i - first;
                var top = matrix[first][i];

                matrix[first][i] = matrix[last - offset][first];

                matrix[last - offset][first] = matrix[last][last - offset];

                matrix[last][last - offset] = matrix[i][last];

                matrix[i][last] = top;
            }
        }
    }
}