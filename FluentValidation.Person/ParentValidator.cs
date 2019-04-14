namespace FluentValidation.Person
{
    public class ParentValidator : AbstractValidator<IParent>
    {
        public ParentValidator()
        {
            RuleFor(parent => parent.Name).NotNull().NotEmpty().WithMessage("Parent name is required.");
            RuleFor(parent => parent.Surname).NotNull().NotEmpty().WithMessage("Parent surname is required.");
            RuleFor(parent => parent.Age).NotNull().InclusiveBetween(18, 100).WithMessage("Parent's age must be between 18yr and 100yr.");

            RuleFor(parent => parent.Inherited).NotNull().WithMessage("Parent missing inherited traits.");
            RuleFor(parent => parent.Inherited.EyeColor).NotNull().WithMessage("Parent's EyeColor is not set.");
            RuleFor(parent => parent.Inherited.HairColor).NotNull().WithMessage("Parent's HairColor is not set.");
            RuleFor(parent => parent.Inherited.Height).NotNull().InclusiveBetween(40, 200).WithMessage("Parent's Height must be between 40cm and 200cm.");
            RuleFor(parent => parent.Inherited.Gender).IsInEnum().Must(t => t.Equals(Sexes.Female) || t.Equals(Sexes.Male) || t.Equals(Sexes.Other)).WithMessage("Parent's Gender is not set, must be Male, Female or Other.");
        }
    }
}
