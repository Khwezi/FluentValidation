namespace FluentValidation.Person
{
    public interface IParent
    {
        int Age { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        Trait Inherited { get; set; }
    }

    public class Parent : IParent
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public Trait Inherited { get; set; }
    }
}
