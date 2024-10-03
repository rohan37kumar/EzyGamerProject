using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int nosLevels;
    [SerializeField] private LevelConfig[] levelConfigs;

    List<Level> levels;

    private void Start()
    {
        //GenerateLevels();
    }

    public List<Level> GenerateLevels()
    {
        levels = new List<Level>(levelConfigs.Length);

        foreach (LevelConfig levData in levelConfigs)
        {
            levels.Add(new Level(levData.questionImage, levData.incorrectImage, levData.correctImage, levData.question, levData.wordOptions, levData.correctWord));
        }

        return levels;
    }

    //now in LevelController use levels[] for display & stuff...
}
