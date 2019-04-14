using System.Drawing;

namespace FluentValidation.Person
{
    public enum Sexes { Male, Female, Other }

    public interface ITrait
    {
        Color EyeColor { get; set; }
        Color HairColour { get; set; }
        int Heigh { get; set; }
        Sexes Gender { get; set; }
    }

    public class Trait : ITrait
    {
        public Color HairColour { get; set; }

        public Color EyeColor { get; set; }

        public int Heigh { get; set; }

        public Sexes Gender { get; set; }
    }
}
