namespace CSharp14;

public struct Temperature(float value, string unit)
{
    public float Value { get; set; } = value;
    public string Unit { get; set; } = unit;

    public static Temperature operator +(Temperature a, Temperature b)
    {
        return a.Unit != b.Unit ? 
            throw new InvalidOperationException("Cannot add temperatures with different unit of measure.") : 
            new Temperature(a.Value + b.Value, a.Unit);
    }
    
    public void operator +=(Temperature b)
    {
        if (this.Unit != b.Unit)
            throw new InvalidOperationException("Cannot add temperatures with different unit of measure.");
        this.Value += b.Value;
    }

    public override string ToString() => $"{Value:F2} °{Unit}";
}

/*
var temp1 = new Temperature(6.0f, "C");
var temp2 = new Temperature(3.5f, "C");
var totalTemp = temp1 + temp2;
totalTemp += new Temperature(5.0f, "C");
*/

//Compound operations always assign the result back to the first operand.
//Since the current operator overloads always return new types, these operations cause unnecessary work, such as value copying.
//In earlier versions of C#, there’s no way to address these performance issues.