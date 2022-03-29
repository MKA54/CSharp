using System;
using System.Linq;
using System.Text;

namespace Vector
{
    internal class Vector
    {
        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"size: {size} <= 0");
            }

            Coordinates = new double[size];
        }

        public Vector(Vector vector) => Array.Copy(vector.Coordinates,
            Coordinates = new double[vector.Coordinates.Length], vector.Coordinates.Length);

        public Vector(double[] coordinates)
        {
            if (
                coordinates.Length == 0)
            {
                throw new ArgumentException($"invalid array length: {coordinates.Length}");
            }

            Array.Copy(coordinates, Coordinates = new double[coordinates.Length], coordinates.Length);
        }

        public Vector(int size, double[] coordinates)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"size: {size} <= 0");
            }

            if (size < coordinates.Length)
            {
                throw new ArgumentException($"size: {size} < Coordinates.Length");
            }

            Array.Copy(coordinates, Coordinates = new double[size], coordinates.Length);
        }

        public double[] Coordinates
        {
            get;
            set;
        }

        public int Size => Coordinates.Length;

        private void IncreaseArraySize(int newSize)
        {
            var newArray = Coordinates;
            Array.Resize(ref newArray, newSize);

            Coordinates = newArray;
        }

        public void Add(Vector vector)
        {
            if (vector.Coordinates.Length > Coordinates.Length)
            {
                IncreaseArraySize(vector.Coordinates.Length);
            }

            for (var i = 0; i < vector.Coordinates.Length; i++)
            {
                Coordinates[i] += vector.Coordinates[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.Coordinates.Length > Coordinates.Length)
            {
                IncreaseArraySize(vector.Coordinates.Length);
            }

            for (var i = 0; i < vector.Size; i++)
            {
                Coordinates[i] -= vector.Coordinates[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (var i = 0; i < Coordinates.Length; i++)
            {
                Coordinates[i] *= scalar;
            }
        }

        public void Reverse() => MultiplyByScalar(-1);

        public double Length => Coordinates.Sum();

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Coordinates.Length)
            {
                throw new IndexOutOfRangeException($"Index must be from 0 to {Coordinates.Length - 1}" +
                    $". Index = {index}");
            }
        }

        public double GetCoordinateByIndex(int index)
        {
            CheckIndex(index);

            return Coordinates[index];
        }

        public void SetCoordinateByIndex(int index, double coordinate)
        {
            CheckIndex(index);

            Coordinates[index] = coordinate;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.Add(vector2);

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.Subtract(vector2);

            return result;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            var result = 0.0;

            var length = Math.Min(vector1.Size, vector2.Size);

            for (var i = 0; i < length; i++)
            {
                result += vector1.Coordinates[i] * vector2.Coordinates[i];
            }

            return result;
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            foreach (var c in Coordinates)
            {
                stringBuilder.Append(c).Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != this.GetType())
            {
                return false;
            }

            if (Coordinates is null)
            {
                return false;
            }

            var v = (Vector)obj;

            return Enumerable.SequenceEqual(Coordinates, v.Coordinates);
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return Coordinates.Aggregate(0, (sum, v) => sum + v.GetHashCode() + prime);
        }
    }
}