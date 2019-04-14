using FluentValidation.Person;
using NUnit.Framework;
using System;
using System.Drawing;

namespace FluentValidation.Tests
{
    [TestFixture]
    public class ChildTestFixture
    {
        public IParent Father { get; set; }

        public IParent Mother { get; set; }

        [SetUp]
        public void Initialise()
        {
            Father = new Parent()
            {
                Name = "Joe",
                Surname = "Soap Snr.",
                Age = 26,
                Inherited = new Trait()
                {
                    EyeColor = Color.Black,
                    Gender = Sexes.Male,
                    HairColor = Color.Black,
                    Height = 167
                }
            };

            Mother = new Parent()
            {
                Name = "Jane",
                Surname = "Due",
                Age = 23,
                Inherited = new Trait()
                {
                    EyeColor = Color.Brown,
                    Gender = Sexes.Female,
                    HairColor = Color.Black,
                    Height = 80
                }
            };
        }

        [TearDown]
        public void Dispose() => Father = Mother = null;

        [Test]
        public void Child_NewInstanceNoMemberAssignmentWithParents_FailValidation()
        {
            var child = new Child<IParent>("Wizzy", Mother, Father);
            var childValidator = new ChildValidator(Father, Mother);

            var validationResult = childValidator.Validate(child);

            Assert.That(validationResult.IsValid, Is.False);

            Console.WriteLine(validationResult.ToString());
        }

        [Test]
        public void Child_NewInstanceWithMemberAssignmentWithNoParents_FailValidation()
        {
            var child = new Child<IParent>("Wizzy", Father, Mother);                        
            var childValidator = new ChildValidator(Father, Mother);

            var validationResult = childValidator.Validate(child);

            Assert.That(validationResult.IsValid, Is.False);
            Assert.That(child.Name, Is.EqualTo("Wizzy"));

            Console.WriteLine(validationResult.ToString());
        }
    }
}
