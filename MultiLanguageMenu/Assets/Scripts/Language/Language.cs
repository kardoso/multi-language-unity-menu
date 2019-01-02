//This class only contais the languages that will be on the game

public class Language
{
    private Language(string value) { Value = value; }

    public string Value { get; private set; }

    public static Language Portuguese { get { return new Language("Portuguese"); } }
    public static Language Spanish { get { return new Language("Spanish"); } }
    public static Language English { get { return new Language("English"); } }
    public static Language German { get { return new Language("German"); } }
    public static Language Japanese { get { return new Language("Japanese"); } }
}