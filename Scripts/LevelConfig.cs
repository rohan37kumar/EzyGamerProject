using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Level Config", menuName = "Level Generator/Level Config")]
public class LevelConfig : ScriptableObject
{
    [Header("Sprites")]
    public Sprite questionImage;
    public Sprite incorrectImage;
    public Sprite correctImage;

    [Header("Question")]
    public string question;

    [Header("Word Options")]
    public string[] wordOptions;

    [Header("Correct Answer")]
    public string correctWord;

}
