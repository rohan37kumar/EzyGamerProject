using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelController levelController;
    [SerializeField] private UIController uiController;

    private List<Level> levels;
    private int currIndex = -1;


    private void Start()
    {
        InitializeApp();

        Debug.Log("apk started...");
    }
    
    private void InitializeApp()
    {
        //generating levels
        levels = levelGenerator.GenerateLevels();

        //Initialising LevelController
        levelController.Initialize(levels);

        //setting up observers
        levelController.AddObserver(uiController);
        //levelController.AddObserver(this);

        levelController.StartApp();

    }

    private void displayNextLevel()
    {
        currIndex++;
        if (currIndex < levels.Count)
        {
            levelController.NotifyLevelChanged(levels[currIndex]);
        }
        else
        {
            Debug.Log("finished all levels!");
        }
    }

}
