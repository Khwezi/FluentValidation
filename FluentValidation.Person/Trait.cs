using System.Drawing;

namespace FluentValidation.Person
{
    public enum Sexes { Male, Female, Other }

    public interface ITrait
    {
        Color EyeColor { get; set; }
        Color HairColor { get; set; }
        int Height { get; set; }
        Sexes Gender { get; set; }
    }

    public class Trait : ITrait
    {
        public Color HairColor { get; set; }

        public Color EyeColor { get; set; }

        public int Height { get; set; }

        public Sexes Gender { get; set; }
    }
}
