using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuestionDialogUI : MonoBehaviour
{
    public static QuestionDialogUI instance { get; private set; }
    private Button yesBtn;
    private Button noBtn;

    private void Awake()
    {
        instance = this;
        yesBtn = transform.Find("Yes").GetComponent<Button>();
        noBtn = transform.Find("No").GetComponent<Button>();


        ShowQuestion(() =>
        {
            Debug.Log("Yes");
        }, () =>
        {
            Debug.Log("No");
        });
    }

    public void ShowQuestion(Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);

        yesBtn.onClick.AddListener( () =>
        {
            Hide();
            yesAction();
        });
        noBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
