namespace TimeSavers
{
    internal class ObjectBrowser
    {
    }
    /// <summary>
    /// Represents a person with a name and age.
    /// </summary>
    /// <remarks>
    /// This class provides basic information about a person.
    /// </remarks>
    /// <example>
    /// Here's how you can create a new person and access their properties:
    /// <code>
    /// // Create a new person
    /// Person person = new Person("John", 30);
    /// 
    /// // Access properties
    /// string name = person.Name;
    /// int age = person.Age;
    /// </code>
    /// </example>
    public class Person
    {
        /// <summary>
        /// Gets or sets the person's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the person's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="_name">The name of the person.</param>
        /// <param name="age">The age of the person.</param>
        public Person(string _name, int age)
        {

            Name = _name;

            Age = age;
        }
    }


}
