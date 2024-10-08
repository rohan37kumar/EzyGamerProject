using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour, ILevelSubject
{
    private List<ILevelObserver> observers = new List<ILevelObserver>();
    private List<Level> levels;
    private int currIndex = -1;
    
    public void Initialize(List<Level> generatedLevels)
    {
        levels = generatedLevels;
    }
    
    public void StartApp()
    {
        MoveToNextLevel();
    }
    //declaration of the methods in the Subject Interface
    public void AddObserver(ILevelObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(ILevelObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyLevelChanged(Level newLevel)
    {
        foreach (var observer in observers)
        {
            observer.OnLevelChanged(newLevel);
        }
    }

    public void NotifyAnswerSelected(string selectedOption)
    {
        bool isCorrect = selectedOption == levels[currIndex].correctOption;
        foreach (var observer in observers)
        {
            observer.OnAnswerSelected(selectedOption, isCorrect);
        }

        if (isCorrect)
        {
            Debug.Log("next level loading...");
            StartCoroutine(WaitAndMoveToNextLevel());
        }
        else
        {
            Debug.Log("wrong option selected");
            NotifyLevelChanged(levels[currIndex]);
        }
    }

    private System.Collections.IEnumerator WaitAndMoveToNextLevel()
    {
        yield return new WaitForSeconds(3.0f);
        MoveToNextLevel();
    }

    private void MoveToNextLevel()
    {
        currIndex++;
        if (currIndex < levels.Count)
        {
            NotifyLevelChanged(levels[currIndex]);
        }
        else
        {
            Debug.Log("all levels finished!");
        }
    }



}
