using System.Collections.Generic;

namespace FluentValidation.Person
{
    public class Child<TParent> where TParent : class, IParent
    {
        public List<IParent> Parents { get; set; }

        public Trait Inherited { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public Child(string name, IParent mother, IParent father)
        {
            Surname = father.Surname;
            Name = name;
            Parents = new List<IParent>();
            Parents.Add(mother);
            Parents.Add(father);

            Inherited = new Trait()
            {
                EyeColor = mother.Inherited.HairColor,
                HairColor = father.Inherited.EyeColor,
                Gender = Sexes.Male,
                Height = 40
            };
            Inherited.EyeColor = mother.Inherited.HairColor;
            Inherited.EyeColor = father.Inherited.EyeColor;                
        }

        public Child() => Inherited = new Trait();
    }
}
