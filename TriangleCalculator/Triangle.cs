using System;

namespace TriangleCalculator 
{
    class Triangle 
    {
        private double side_A, side_B, side_C;
        private string type, validity;

        // Constructor, accepts lengths of sides of triangle as doubles
        public Triangle(double side_A, double side_B, double side_C) 
        {            
            this.side_A = side_A;
            this.side_B = side_B;
            this.side_C = side_C;

            // Calculate if this is a valid triangle based on lengths
            this.is_valid();
            // Determine what type of triangle it is
            this.calc_type();
        }

        // Calculates whether the defined triangle is valid
        public void is_valid() 
        {
            if( this.side_A + this.side_B > this.side_C &&
                this.side_B + this.side_C > this.side_A &&
                this.side_C + this.side_A > this.side_B ) 
            {
                    this.validity = "a valid";
            } 
            else 
            {
                this.validity = "an invalid";

            }
        }

        // Calculates the angle opposite of length a
        public double get_angle(double a, double b, double c) 
        {
            // Angle oppsite a is b^2 + c^2 - a^2 / 2bc
            return ((b * b) + (c * c) - (a * a)) / (2 * b * c);
        }

        // Calculates the type of triangle
        public void calc_type() 
        {
            // If all sides are the same length
            if( this.side_A == this.side_B && 
                this.side_A == this.side_C ) 
            {
                this.type = " equilateral";
            }
            // If any angle is 90 degress
            else if(    this.get_angle(this.side_B, this.side_C, this.side_A) == 90 ||
                        this.get_angle(this.side_C, this.side_A, this.side_B) == 90 ||
                        this.get_angle(this.side_A, this.side_B, this.side_C) == 90) 
            {
                this.type = " right";
            }
            // If any two sides are the same length
            else if(    this.side_A == this.side_B || 
                        this.side_A == this.side_C || 
                        this.side_B == this.side_C) 
            {  
                this.type = " isosceles";
            } 
            else 
            {
                this.type = "";
            }
        }

        // Prints a string reporting the validity and type of triangle
        public override string ToString()
        {
            return "These side lengths produce " + this.validity +
                     this.type + " triangle.";
        }
    }
}