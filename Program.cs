public abstract class Figure {
    public abstract double Square();

}

public class Circle : Figure {
    protected double radius;
    /// <summary>
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public double Radius {
        get => radius;
        set {
            if (RadiusCorrect(value)) {
                radius = value;
            }
            else {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }



    public Circle() { }
    public Circle(double radius) {
        try {
            Radius = radius;
        }
        catch (ArgumentOutOfRangeException aoore) {
            throw aoore;
        }
    }



    public override double Square() {
        return Math.PI * Math.Pow(Radius, 2);
    }



    protected static bool RadiusCorrect(int radius) {
        if (radius > 0) {
            return true;
        }

        return false;
    }

}

public class Triangle :Figure {
    protected double Side1 { get; set; } 
    protected double Side2 { get; set; } 
    protected double Side3 { get; set; }



    public Triangle(double side1, double side2, double side3) {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }



    /// 
    /// <exception cref="InvalidOperationException"></exception>
    public override double Square() {
        if (!Correct()) {
            throw new InvalidOperationException();
        }

        double perimeter = Perimeter();
        return Math.Sqrt(Math.PI) * (perimeter - Side1) * (perimeter - Side2) * (perimeter - Side3);
    }

    public double Perimeter() {
        return Side1 + Side2 + Side3;
    }

    public bool Correct() {
        if (Side1 <= 0) {
            return false;
        }
        if (Side2 <= 0) {
            return false;
        }
        if (Side3 <= 0) {
            return false;
        }

        if (Side1 >= Side2 + Side3 || Side2 >= Side1 + Side3 || Side3 >= Side2 + Side1) {
            return false;
        }

        return true;
    }   

    /// <summary>
    /// Return <see langword="true"/>, if the following triangle is "right".
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public bool IsRight() {
        if (!Correct()) {
            throw new InvalidOperationException();
        }

        return Side1 * Side1 == Side2 * Side2 + Side3 * Side3 || Side2 * Side2 == Side1 * Side1 + Side3 * Side3 || Side3 * Side3 == Side2 * Side2 + Side1 * Side1;
    }

}
