using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Image levelImage;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] optionTexts;
    [SerializeField] private Button[] optionButtons;
    //[SerializeField] private Button nextLevelButton;

    private List<Level> levels;
    private int currLevel = -1;

    public void Initialize(List<Level> levelObj)
    {
        levels = levelObj;
        //nextLevelButton.onClick.AddListener(dispNextLevel);
        dispNextLevel();
    }

    private void dispNextLevel()
    {
        currLevel++;
        if (currLevel >= levels.Count)
        {
            Debug.Log("all levels completed");
            //stop all options' interaction.
            optionButtons[0].onClick.RemoveAllListeners();
            optionButtons[1].onClick.RemoveAllListeners();
            return;
        }
        //levels[currLevel] is the current level to be displayed
        Level level = levels[currLevel];
        displayLevel(level);
    }

    private void displayLevel(Level activeLevel)
    {
        levelImage.sprite = activeLevel.qImage;
        questionText.text = activeLevel.question;

        //changing the images accordingly


        //randomly displaying the options
        Unity.Mathematics.Random random = new Unity.Mathematics.Random(1983);
        int v = random.NextInt(0, 2);
        int ind = v;
        optionTexts[ind].text = activeLevel.wordOptions[0];
        ind = 1 - ind;
        optionTexts[ind].text = activeLevel.wordOptions[1];
        optionButtons[0].onClick.AddListener(() => optionSelected(optionTexts[0].text));
        optionButtons[1].onClick.AddListener(() => optionSelected(optionTexts[1].text));

    }

    private void optionSelected(string option)
    {
        if (option == levels[currLevel].correctOption)
        {
            levelImage.sprite = levels[currLevel].corrImage;
            optionButtons[0].onClick.RemoveAllListeners();
            optionButtons[1].onClick.RemoveAllListeners();
            Debug.Log("Correct answer");
            Invoke("dispNextLevel", 3.0f);
        }
        else
        {
            levelImage.sprite = levels[currLevel].incImage;
            Debug.Log("Wrong Answer");
        }
    }
}
