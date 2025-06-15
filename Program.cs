using System;
public abstract class TVector
{
    public abstract double GetLength();
    public static double ScalarProduct(TVector v1, TVector v2)
    {
        if (v1.GetType() != v2.GetType())
        {
            throw new ArgumentException("Вектори повинні бути однакової розмірності для обчислення скалярного добутку.");
        }
        return 0;
    }
    public abstract void PrintVector();
}
public class R2Vector : TVector
{
    public double X { get; set; }
    public double Y { get; set; }

    public R2Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
    public override double GetLength()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
    public static double ScalarProduct(R2Vector v1, R2Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }
    public override void PrintVector()
    {
        Console.WriteLine($"Вектор R2: ({X}, {Y})");
    }
}
public class R3Vector : TVector
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public R3Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public override double GetLength()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    public static double ScalarProduct(R3Vector v1, R3Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }
    public override void PrintVector()
    {
        Console.WriteLine($"Вектор R3: ({X}, {Y}, {Z})");
    }
}
public class ProgramVectors
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n--- Вектори в R3 ---");
        R3Vector a = new R3Vector(1, 2, 3);
        R3Vector b = new R3Vector(4, 5, 6);
        a.PrintVector();
        b.PrintVector();
        double scalarProduct_ab = R3Vector.ScalarProduct(a, b);
        Console.WriteLine($"Скалярний добуток (a,b) в R3: {scalarProduct_ab}");
        double length_a_R3 = a.GetLength();
        Console.WriteLine($"Довжина вектора |a| в R3: {length_a_R3}");
        Console.WriteLine("\n--- Вектори в R2 ---");
        R2Vector c = new R2Vector(7, 8);
        R2Vector d = new R2Vector(9, 10);
        c.PrintVector();
        d.PrintVector();
        double scalarProduct_cd = R2Vector.ScalarProduct(c, d);
        Console.WriteLine($"Скалярний добуток (c,d) в R2: {scalarProduct_cd}");
        double final_length_a_R3 = a.GetLength();
        double S = scalarProduct_ab + scalarProduct_cd + final_length_a_R3;
        Console.WriteLine($"\nОбчислюємо вираз S = (a,b)+(c,d)+|a|:");
        Console.WriteLine($"Де (a,b) = {scalarProduct_ab} (для R3)");
        Console.WriteLine($"Де (c,d) = {scalarProduct_cd} (для R2)");
        Console.WriteLine($"Де |a| = {final_length_a_R3} (для R3)");
        Console.WriteLine($"S = {scalarProduct_ab} + {scalarProduct_cd} + {final_length_a_R3} = {S}");
        Console.ReadKey();
    }
}