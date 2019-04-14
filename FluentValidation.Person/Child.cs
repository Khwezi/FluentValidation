using System.Collections.Generic;

namespace FluentValidation.Person
{
    public class Child<TParent> where TParent : class, IParent
    {
        public List<IParent> Parents { get; set; }

        public Trait Inherited { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Child(string name, IParent mother, IParent father)
        {
            Parents.Add(mother);
            Parents.Add(father);

            Inherited.EyeColor = mother.Inherited.HairColour;
            Inherited.EyeColor = father.Inherited.EyeColor;
            Inherited.Gender = Sexes.Male;
            Inherited.Heigh = 40;

            Surname = father.Surname;
            Name = name;
        }

        public Child()
        {

        }
    }
}
