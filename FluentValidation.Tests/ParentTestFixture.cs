using FluentValidation.Person;
using NUnit.Framework;
using System;
using System.Drawing;

namespace FluentValidation.Tests
{
    [TestFixture]
    public class ParentTestFixture
    {
        [Test]
        public void Parent_NewInstanceNoMemberAssignment_MustFailValidation()
        {
            var parent = new Parent();
            var validator = new ParentValidator();

            var validationResult = validator.Validate(parent);

            Assert.That(validationResult.IsValid, Is.False, "All validations passed");

            Console.WriteLine(validationResult.ToString());
        }

        [Test]
        public void Parent_NewInstanceWithMemberAssignment_MustPassValidation()
        {
            var parent = new Parent()
            {
                Name = "Joe",
                Surname = "Soap",
                Age = 26,
                Inherited = new Trait()
                {
                    EyeColor = Color.Black,
                    Gender = Sexes.Male,
                    HairColor = Color.Black,
                    Height = 167
                }
            };
            var validator = new ParentValidator();

            var validationResult = validator.Validate(parent);

            Assert.That(validationResult.IsValid, Is.True, () => validationResult.ToString());
        }
    }
}
