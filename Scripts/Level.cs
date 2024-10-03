using UnityEngine;

public class Level
{
    public Sprite qImage { get; private set; }
    public Sprite incImage { get; private set; }
    public Sprite corrImage { get; private set; }
    public string question {  get; private set; }
    public string[] wordOptions { get; private set; }
    public string correctOption { get; private set; }

    public Level(Sprite qImage, Sprite incImage, Sprite corrImage, string question, string[] wordOptions, string correctOption)
    {
        this.qImage = qImage;
        this.incImage = incImage;
        this.corrImage = corrImage;
        this.question = question;
        this.wordOptions = wordOptions;
        this.correctOption = correctOption;
    }
}
