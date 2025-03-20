namespace Lab4;

public abstract class TMatrix
{
    protected float[,] _matrix;

    protected TMatrix(int order, float[,] matrix)
    {
        _matrix = new float[order, order];
        Fill(matrix);
    }

    public abstract int Order { get; }

    public abstract float Determinant();

    public virtual float Sum()
    {
        float sum = 0;

        for (var i = 0; i < Order; i++)
        for (var j = 0; j < Order; j++)
            sum += GetNumber(i, j);

        return sum;
    }

    public virtual float GetNumber(int i, int j)
    {
        if (i < 0 || i >= Order || j < 0 || j >= Order)
            throw new IndexOutOfRangeException($"Індекси повинні бути в межах [0, {Order - 1}]");

        return _matrix[i, j];
    }

    public virtual void SetNumber(int i, int j, float number)
    {
        if (i < 0 || i >= Order || j < 0 || j >= Order)
            throw new IndexOutOfRangeException($"Індекси повинні бути в межах [0, {Order - 1}]");

        _matrix[i, j] = number;
    }

    public virtual void Fill(float[,] matrix)
    {
        if (matrix.GetLength(0) != Order || matrix.GetLength(1) != Order)
            throw new ArgumentException($"Матриця повинна бути розміру {Order}x{Order}");

        for (var i = 0; i < Order; i++)
        for (var j = 0; j < Order; j++)
            SetNumber(i, j, matrix[i, j]);
    }

    public virtual void PrintMatrix()
    {
        for (var i = 0; i < Order; i++)
        {
            for (var j = 0; j < Order; j++)
                Console.Write($"{GetNumber(i, j)} ");

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

public class TMatrix2(float[,] matrix) : TMatrix(2, matrix)
{
    public override int Order => 2;

    public override float Determinant()
    {
        return GetNumber(0, 0) * GetNumber(1, 1) - GetNumber(0, 1) * GetNumber(1, 0);
    }
}

public class TMatrix3(float[,] matrix) : TMatrix(3, matrix)
{
    public override int Order => 3;

    public override float Determinant()
    {
        float det = 0;

        det += GetNumber(0, 0) * (GetNumber(1, 1) * GetNumber(2, 2) - GetNumber(1, 2) * GetNumber(2, 1));
        det -= GetNumber(0, 1) * (GetNumber(1, 0) * GetNumber(2, 2) - GetNumber(1, 2) * GetNumber(2, 0));
        det += GetNumber(0, 2) * (GetNumber(1, 0) * GetNumber(2, 1) - GetNumber(1, 1) * GetNumber(2, 0));

        return det;
    }
}