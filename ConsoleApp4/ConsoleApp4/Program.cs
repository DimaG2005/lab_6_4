using System;
using System.Collections.Generic;

// Abstract base class for graphic primitives
public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public GraphicPrimitive(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Abstract method to draw the graphic primitive
    public abstract void Draw();

    // Method to move the graphic primitive
    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    // Method to scale the graphic primitive
    public abstract void Scale(float factor);
}

// Concrete class for a circle
public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with Radius {Radius}");
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

// Concrete class for a rectangle
public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height) : base(x, y)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with Width {Width} and Height {Height}");
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

// Concrete class for a triangle
public class Triangle : GraphicPrimitive
{
    public int SideLength { get; set; }

    public Triangle(int x, int y, int sideLength) : base(x, y)
    {
        SideLength = sideLength;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y}) with Side Length {SideLength}");
    }

    public override void Scale(float factor)
    {
        SideLength = (int)(SideLength * factor);
    }
}

// Concrete class for a group of graphic primitives
public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> members;

    public Group(int x, int y) : base(x, y)
    {
        members = new List<GraphicPrimitive>();
    }

    public void AddMember(GraphicPrimitive member)
    {
        members.Add(member);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");
        foreach (var member in members)
        {
            member.Draw();
        }
    }

    public override void Scale(float factor)
    {
        foreach (var member in members)
        {
            member.Scale(factor);
        }
    }
}

// Graphics editor class
public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives;

    public GraphicsEditor()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage:

        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle(10, 20, 5);
        Rectangle rectangle = new Rectangle(30, 40, 8, 12);
        Triangle triangle = new Triangle(50, 60, 10);

        Group group = new Group(0, 0);
        group.AddMember(circle);
        group.AddMember(rectangle);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        Console.WriteLine("Original Drawings:");
        editor.DrawAll();

        Console.WriteLine("\nScaling by factor of 2:");
        editor.ScaleAll(2);
        editor.DrawAll();
    }
}
