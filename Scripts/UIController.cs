using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour, ILevelObserver
{
    [SerializeField] private Image levelImage;
    [SerializeField] private Text questionText;
    [SerializeField] private Text[] optionTexts;
    [SerializeField] private Button[] optionButtons;
    [SerializeField] private LevelController levelController;

    private Level currLevel;

    private void Start()
    {
        optionButtons[0].onClick.AddListener(() => OnOptionButtonClicked(0));
        optionButtons[1].onClick.AddListener(() => OnOptionButtonClicked(1));
    }


    public void OnLevelChanged(Level level)
    {
        currLevel = level;
        UpdateUI();
    }

    public void OnAnswerSelected(string selectedOption, bool isCorrect)
    {
        levelImage.sprite = isCorrect ? currLevel.corrImage : currLevel.incImage;

        // Disable buttons after an answer is selected
        //optionButtons[0].interactable = false;
        //optionButtons[1].interactable = false;
    }

    private void UpdateUI()
    {
        levelImage.sprite = currLevel.qImage;
        questionText.text = HindiCorrector.Correct(currLevel.question);


        //updating buttons
        //also correcting the Hindi Font
        optionTexts[0].text = HindiCorrector.Correct(currLevel.wordOptions[0]);
        optionButtons[0].interactable = true;

        optionTexts[1].text = HindiCorrector.Correct(currLevel.wordOptions[1]);
        optionButtons[1].interactable = true;

    }

    private void OnOptionButtonClicked(int index)
    {
        string selectedOption = currLevel.wordOptions[index];
        levelController.NotifyAnswerSelected(selectedOption);
    }
}

