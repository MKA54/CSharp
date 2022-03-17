using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Vector
    {
        public Vector(int Size)
        {
            if (Size <= 0)
            {
                throw new ArgumentException("size: " + Size + " <= 0");
            }

            Coordinates = new double[Size];
        }

        public Vector(Vector Vector) => Array.Copy(Vector.Coordinates, Coordinates = new double[Vector.Coordinates.Length], Vector.Coordinates.Length);

        public Vector(double[] Coordinates)
        {
            if (Coordinates.Length == 0)
            {
                throw new ArgumentException("invalid array length: " + Coordinates.Length);
            }

            Array.Copy(Coordinates, this.Coordinates = new double[Coordinates.Length], Coordinates.Length);
        }

        public Vector(int Size, double[] Coordinates)
        {
            if (Size <= 0)
            {
                throw new ArgumentException("size: " + Size + " <= 0");
            }

            if (Size < Coordinates.Length)
            {
                throw new ArgumentException("size: " + Size + " < Coordinates.Length");
            }

            Array.Copy(Coordinates, this.Coordinates = new double[Size], Coordinates.Length);
        }

        public double[] Coordinates
        {
            get;
            set;
        }

        public int GetSize() => Coordinates.Length;

        private void IncreaseArraySize(int NewSize)
        {
            var NewArray = Coordinates;
            Array.Resize(ref NewArray, NewSize);

            Coordinates = NewArray;
        }

        public void Add(Vector Vector)
        {
            if (Vector.Coordinates.Length > Coordinates.Length)
            {
                IncreaseArraySize(Vector.Coordinates.Length);
            }

            for (var i = 0; i < Vector.Coordinates.Length; i++)
            {
                Coordinates[i] += Vector.Coordinates[i];
            }
        }

        public void Subtract(Vector Vector)
        {
            if (Vector.Coordinates.Length > Coordinates.Length)
            {
                IncreaseArraySize(Vector.Coordinates.Length);
            }

            for (var i = 0; i < Vector.GetSize(); i++)
            {
                Coordinates[i] -= Vector.Coordinates[i];
            }
        }

        public void MultiplyByScalar(double Scalar)
        {
            for (var i = 0; i < Coordinates.Length; i++)
            {
                Coordinates[i] *= Scalar;
            }
        }

        public void Reverse() => MultiplyByScalar(-1);

        public double GetLength()
        {
            var Sum = 0.0;

            for (var i = 0; i < Coordinates.Length - 1; i++)
            {
                Sum += Coordinates[i];
            }

            return Sum;
        }

        private void CheckIndex(int Index)
        {
            if (Index < 0 || Index >= Coordinates.Length)
            {
                throw new IndexOutOfRangeException("Index must be from 0 to " + (Coordinates.Length - 1) + ". Index = " + Index);
            }
        }

        public double GetCoordinateByIndex(int Index)
        {
            CheckIndex(Index);

            return Coordinates[Index];
        }

        public void SetCoordinateByIndex(int Index, double Coordinate)
        {
            CheckIndex(Index);

            Coordinates[Index] = Coordinate;
        }

        public static Vector GetSum(Vector Vector1, Vector Vector2)
        {
            var Result = new Vector(Vector1);

            Result.Add(Vector2);

            return Result;
        }

        public static Vector GetDifference(Vector Vector1, Vector Vector2)
        {
            var Result = new Vector(Vector1);

            Result.Subtract(Vector2);

            return Result;
        }

        public static double GetScalarProduct(Vector Vector1, Vector Vector2)
        {
            var result = 0.0;

            var length = Math.Min(Vector1.GetSize(), Vector2.GetSize());

            for (var i = 0; i < length; i++)
            {
                result += Vector1.Coordinates[i] * Vector2.Coordinates[i];
            }

            return result;
        }
        public override string ToString()
        {
            StringBuilder StringBuilder = new StringBuilder();

            StringBuilder.Append("{");

            foreach (var C in Coordinates)
            {
                StringBuilder.Append(C).Append(", ");
            }

            StringBuilder.Remove(StringBuilder.Length - 2, 2);
            StringBuilder.Append("}");

            return StringBuilder.ToString();
        }

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(Obj, this))
            {
                return true;
            }

            if (ReferenceEquals(Obj, null) || Obj.GetType() != this.GetType())
            {
                return false;
            }

            var V = (Vector) Obj;

            return Enumerable.SequenceEqual(Coordinates, V.Coordinates);
        }

        public override int GetHashCode()
        {
            var Prime = 37;
            var Hash = 1;

            return Prime * Hash + Coordinates.GetHashCode();
        }
    }
}