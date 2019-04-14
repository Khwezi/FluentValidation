namespace FluentValidation.Person
{
    public class ChildValidator : AbstractValidator<Child<IParent>>
    {
        public ChildValidator(IParent father, IParent mother)
        {
            RuleFor(child => child.Name).NotNull().NotEmpty().WithMessage("Child's name is required.");
            RuleFor(child => child.Surname).NotNull().NotEmpty().WithMessage("Child's surname is required.");
            RuleFor(child => child.Age).NotNull().InclusiveBetween(18, 100).WithMessage("Child's age must be between 18yr and 100yr.");

            RuleFor(child => child.Inherited).NotNull().WithMessage("Child missing inherited traits.");
            RuleFor(child => child.Inherited.EyeColor).NotNull().WithMessage("Child's EyeColor is not set.");
            RuleFor(child => child.Inherited.HairColor).NotNull().WithMessage("Child's HairColor is not set.");
            RuleFor(child => child.Inherited.Height).NotNull().InclusiveBetween(30, 200).WithMessage("Child's Height must be between 40cm and 200cm.");
            RuleFor(child => child.Inherited.Gender).IsInEnum().Must(t => t.Equals(Sexes.Female) || t.Equals(Sexes.Male) || t.Equals(Sexes.Other)).WithMessage("Child's Gender is not set, must be Male, Female or Other.");

            RuleFor(child => child.Parents).NotNull().Must(c => c.Count > 0 || c.Count == 2).WithMessage("Child must have at least two parents.");
            RuleFor(child => child.Surname).NotNull().Must(c => c.Equals(father.Surname)).WithMessage("Child's surname does not match the father's");
            RuleFor(child => child.Inherited.EyeColor).Must(c => c.Equals(mother.Inherited.EyeColor)).WithMessage("Child's inherited EyeColor does not match the mother's EyeColor.");
            RuleFor(child => child.Inherited.HairColor).Must(c => c.Equals(father.Inherited.HairColor)).WithMessage("Child's inherited EyeColor does not match the father's EyeColor.");
        }
    }
}
