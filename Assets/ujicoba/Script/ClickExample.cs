using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ClickExample : MonoBehaviour
{
    public Button buttonMulai, buttonKeluar;

    void Start()
    {
        Button btn = buttonMulai.GetComponent<Button>();
        btn.onClick.AddListener(TaskMulai);
        Button btn2 = buttonKeluar.GetComponent<Button>();
        btn.onClick.AddListener(TaskKeluar);
    }

    private void TaskKeluar()
    {
        Application.Quit();
    }

    void TaskMulai()
    {
        SceneManager.LoadScene(1);
    }
}