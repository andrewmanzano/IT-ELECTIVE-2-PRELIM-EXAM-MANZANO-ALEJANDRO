namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 2: Encapsulation - Validation in Property Setter
// The Ingredient class has basic properties, but the setter for 'Quantity'
// has no validation. Your task:
// - Ensure 'Quantity' cannot be set to a negative number (throw ArgumentOutOfRangeException)
// - Ensure 'Name' cannot be set to null or empty (throw ArgumentException)

public class Ingredient
{
    private string name;
    private double quantity;
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be set to null or empty.");
            }
            name = value;
        }
    }
    public string Measure { get; set; }
    public double Quantity
    {
        get => quantity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Quanttity cannot be a negative number.");
            }
            quantity = value;
        }
    }

    public Ingredient()
    {
        name = "Unknown";
        Measure = "";
        quantity = 0;
    }

    public Ingredient(string name, string measure, double quantity)
    {
        Name = name;
        Measure = measure;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Quantity} {Measure} of {Name}";
    }
}
