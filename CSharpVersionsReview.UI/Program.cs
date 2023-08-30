using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpVersionsReview.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region C# 8.0

            #region Nullable Types Enhancements
            //Old Version
            int? nullableValueOld = null;
            int valueOld = nullableValueOld.HasValue ? nullableValueOld.Value : 0;

            //New Version
            int? nullableValueNew = null;
            int valueNew = nullableValueNew ?? 0;
            #endregion

            #region Indices and Ranges
            //Old Version
            int[] arrayOld = new int[] { 1, 2, 3, 4, 5 };
            int lastElementOld = arrayOld[arrayOld.Length - 1];
            //New Version
            int[] arrayNew = new int[] { 1, 2, 3, 4, 5 };
            int lastElementNew = arrayNew[^1];
            #endregion

            #region Using Declarations 
            //Old Version
            using (var resource2 = new MyResource())
            {
                //...
            }
            //New Version
            using var resource = new MyResource();
            //...
            #endregion

            #region Enhancements to Interpolated Strings
            //Old Version
            string nameOld = "Ali";
            string messageOld = "Hello, " + nameOld + "!";
            //New Version
            string nameNew = "Berk";
            string messageNew = $"Hello, {nameNew}!";
            #endregion

            #endregion

            #region C# 9.0

            #region Pattern Matching Enhancements
            //Old Version
            object obj = null;
            if (obj is int)
            {
                int intValueOld = (int)obj;
                // ...
            }
            //New Version
            if (obj is int intValueNew)
            {
                // intValue is available
                // ...
            }
            #endregion

            #region Local Functions : AddNumbers
            int x = 10;
            int y = 25;

            int result = AddNumbers(x, y);
            Console.WriteLine(result);

            int AddNumbers(int a, int b) // Yerel işlev tanımı
            {
                return a + b;
            }
            #endregion

            #region init
            /// <summary>
            /// In the given example, by using the init keyword for the property setters (FirstName, LastName, and Age), you indicate that these properties can only be assigned values when the object is being initialized. Once initialized, attempting to modify these properties will result in a compilation error, preventing unintentional changes to the object's state after creation.
            /// </summary>

            var person = new PersonInitSample
            {
                FirstName = "Ali", //Can not modify
                LastName = "Bal", //Can not modify
                Age = 30 //Can not modify
            };
            #endregion

            #region Static Lambda
            //Old Version
            int multiplier = 2;
            Action lambda = () => Console.WriteLine($"Result: {multiplier * 5}");
            lambda();

            //New Version
            Action staticLambda = static () => Console.WriteLine("This is a static lambda function.");
            staticLambda();

            #endregion

            #endregion

            #region C# 10.0

            #region Deconstruction
            //Old Version
            (var xOld, var yOld) = (0, 1);
            //New Version
            int xNew;
            (xNew, int yNew) = (1, 2);
            #endregion

            #region Range Literals
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var evenNumbers1 = numbers.Where(n => n % 2 == 0);
            #endregion

            #region Range Operators
            var evenNumbers2 = numbers.Where(n => n % 2 == 0).Select(n => n * n);
            #endregion

            #endregion
        }
        #region Helper Classes for Samples
        private class MyResource : IDisposable
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
        private class PersonInitSample
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public int Age { get; init; }
        }
        #endregion
    }
}

#region C# 8.0
#region Default Interface Implementations
//Old Version
interface IMyInterfaceOld
{
    void MyMethodOld();
}

class MyClassOld : IMyInterfaceOld
{
    public void MyMethodOld()
    {
        // ...
    }
}
//Old Version Sample
abstract class MyBaseClassOld : IMyInterfaceOld
{
    public virtual void MyMethodOld()
    {
        Console.WriteLine("Default implementation in IMyInterfaceOld");
    }
}
class MyClassOldSecond : MyBaseClassOld
{
    public override void MyMethodOld()
    {
        Console.WriteLine("Customized implementation in MyClassOldSecond");
    }
}
//New Version Sample
interface IMyInterfaceNew
{
    void MyMethodNew()
    {
        Console.WriteLine("Default implementation in IMyInterfaceNew");
    }
}
class MyClassNew : IMyInterfaceNew
{
    // You can override the default implementation in IMyInterfaceNew
    void MyMethodNew()
    {
        Console.WriteLine("Customized implementation in MyClassNew");
    }
}
#endregion
#endregion

#region C# 9.0
#region Record Type : Value Equality and Comparison Operations
//Old Version
class PersonOld : IEquatable<PersonOld>, IComparable<PersonOld>
{
    public string FirstNameOld { get; }
    public string LastNameOld { get; }
    public int AgeOld { get; }

    public PersonOld(string _firstName, string _lastName, int _age)
    {
        FirstNameOld = _firstName;
        LastNameOld = _lastName;
        AgeOld = _age;
    }

    public bool Equals(PersonOld other)
    {
        if (other == null) return false;
        return FirstNameOld == other.FirstNameOld && LastNameOld == other.LastNameOld && AgeOld == other.AgeOld;
    }

    public int CompareTo(PersonOld other)
    {
        if (other == null) return 1;
        int nameComparison = string.Compare(LastNameOld, other.LastNameOld, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;
        return AgeOld.CompareTo(other.AgeOld);
    }
}

//New Version
record PersonNew(string FirstNameNew, string LastNameNew, int AgeNew);
public class PersonNewSample
{
    static PersonNew person1 = new PersonNew("Ali", "Bal", 30);
    static PersonNew person2 = new PersonNew("Ali", "Bal", 30);

    bool areEqual = person1.Equals(person2); // true

    #endregion
#region Record : Copyability Enhancement

    static PersonNew person3 = new PersonNew("Can", "Durmaz", 25);
    static PersonNew person4 = person3 with { LastNameNew = "Bal" };
}
#endregion
#endregion

#region C# 10.0
#region Struct Record
// public record struct PersonStruck(string FirstNameStruct, string LastNameStruct, int AgeStruckt);
#endregion
#region Global Keyword
 // global using static System.Math;
#endregion
#endregion