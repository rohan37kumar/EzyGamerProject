using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelController levelController;

    private void Start()
    {
        List<Level> generatedLevels = levelGenerator.GenerateLevels();
        levelController.Initialize(generatedLevels);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    
}
