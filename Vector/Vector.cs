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

            _coordinates = new double[size];
        }

        public Vector(Vector vector) => Array.Copy(vector._coordinates,
            _coordinates = new double[vector._coordinates.Length], vector._coordinates.Length);

        public Vector(double[] coordinates)
        {
            if (
                coordinates.Length == 0)
            {
                throw new ArgumentException($"invalid array length: {coordinates.Length}");
            }

            Array.Copy(coordinates, _coordinates = new double[coordinates.Length], coordinates.Length);
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

            Array.Copy(coordinates, _coordinates = new double[size], coordinates.Length);
        }

        private double[] _coordinates;

        public int Size => _coordinates.Length;

        private void IncreaseArraySize(int newSize)
        {
            var newArray = new double[newSize];

            for (var i = 0; i < _coordinates.Length; i++)
            {
                newArray[i] = _coordinates[i];
            }

            _coordinates = newArray;
        }

        public void Add(Vector vector)
        {
            if (vector.Size > Size)
            {
                IncreaseArraySize(vector.Size);
            }

            for (var i = 0; i < vector.Size; i++)
            {
                _coordinates[i] += vector._coordinates[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.Size > Size)
            {
                IncreaseArraySize(vector.Size);
            }

            for (var i = 0; i < vector.Size; i++)
            {
                _coordinates[i] -= vector._coordinates[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (var i = 0; i < Size; i++)
            {
                _coordinates[i] *= scalar;
            }
        }

        public void Reverse() => MultiplyByScalar(-1);

        public double Length()
        {
            return Math.Sqrt(
                _coordinates
                .Select(x => Math.Pow(x, 2))
                .Sum());
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException($"Index must be from 0 to {Size - 1}" +
                    $". Index = {index}");
            }
        }

        public double this[int index]
        {
            get
            {
                CheckIndex(index);

                return _coordinates[index];
            }

            set
            {
                CheckIndex(index);

                _coordinates[index] = value;
            }
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.Add(vector2);

            return result;
        }

        public static Vector Substrate(Vector vector1, Vector vector2)
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
                result += vector1._coordinates[i] * vector2._coordinates[i];
            }

            return result;
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            foreach (var c in _coordinates)
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

            if (_coordinates is null)
            {
                return false;
            }

            var v = (Vector)obj;

            return Enumerable.SequenceEqual(_coordinates, v._coordinates);
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return _coordinates.Aggregate(0, (sum, v) => sum + v.GetHashCode() + prime);
        }
    }
}