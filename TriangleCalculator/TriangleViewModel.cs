using System;
using System.ComponentModel;

namespace TriangleCalculator
{
    internal class TriangleViewModel : INotifyPropertyChanged
    {
        private double _SideA;
        public double SideA
        {
            get
            {
                return _SideA;
            }
            set
            {
                _SideA = value;
                OnPropertyChanged("SideA");
                Calculate();
            }
        }

        private double _SideB;
        public double SideB
        {
            get
            {
                return _SideB;
            }
            set
            {
                _SideB = value;
                OnPropertyChanged("SideB");
                Calculate();
            }
        }

        private double _SideC;
        public double SideC
        {
            get
            {
                return _SideC;
            }
            set
            {
                _SideC = value;
                OnPropertyChanged("SideC");
                Calculate();
            }
        }

        private string _Result;
        public string Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                OnPropertyChanged("Result");
            }
        }

        /// <summary>
        /// Initializes a new instance of the TriangleViewModel class
        /// </summary>
        public TriangleViewModel()
        {
            _Tri = new Triangle();

            Calculate();

            Result = ToString();
        }

        private Triangle _Tri;
        /// <summary>
        /// Gets the triangle instance
        /// </summary>
        public Triangle Tri
        {
            get
            {
                return _Tri;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CanUpdate {
            get
            {
                if(Tri == null)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Result);
            }
        }

        
        /// <summary>
        /// Saves changes made to the Triangle instance
        /// </summary>
        public void SaveChanges()
        {
            Result = ToString();
        }

        /// <summary>
        /// Calculates the angle opposite of length a
        /// </summary>
        /// <param name="a">Side A of triangle</param>
        /// <param name="b">Side B of triangle</param>
        /// <param name="c">Side C of triangle</param>
        /// <returns>Angle opposite of side represented by param a</returns>
        public double GetAngle(double a, double b, double c)
        {
            // Angle oppsite a is b^2 + c^2 - a^2 / 2bc
            return ((b * b) + (c * c) - (a * a)) / (2 * b * c);
        }

        /// <summary>
        /// Calculates whether the defined triangle is valid
        /// </summary>
        public void IsValid()
        {
            if (SideA + SideB > SideC &&
                SideB + SideC > SideA &&
                SideC + SideA > SideB)
            {
                Tri.Validity = true;
            }
            else
            {
                Tri.Validity = false;

            }
        }

        /// <summary>
        /// Calculates the type of triangle
        /// </summary>
        public void CalcType()
        {
            // If all sides are the same length
            if (SideA == SideB &&
                SideA == SideC)
            {
                Tri.TriangleType = " equilateral";
            }
            // If any angle is 90 degress
            else if (GetAngle(SideB, SideC, SideA) == 90 ||
                        GetAngle(SideC, SideA, SideB) == 90 ||
                        GetAngle(SideA, SideB, SideC) == 90)
            {
                Tri.TriangleType = " right";
            }
            // If any two sides are the same length
            else if (SideA == SideB ||
                        SideA == SideC ||
                        SideB == SideC)
            {
                Tri.TriangleType = " isosceles";
            }
            else
            {
                Tri.TriangleType = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Calculate()
        {
            // Calculate if this is a valid triangle based on lengths
            this.IsValid();
            // Determine what type of triangle it is
            this.CalcType();

            Result = ToString();
        }

        /// <summary>
        /// Formats the details of the given triangle
        /// </summary>
        /// <returns>A string that describes the attributes of the triangle</returns>
        public override string ToString()
        {
            return "These side lengths produce " +
                    (Tri.Validity ? "a valid" + Tri.TriangleType : "an invalid") +
                    " triangle.";
        }

        #region INotifyPropertyChanged Members;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
