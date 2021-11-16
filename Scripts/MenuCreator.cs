using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCreator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _gameObject;

    public void Menu()
    {
        Time.timeScale = 0;
        _gameObject.active = true;
        _button.interactable = false;
    }

    public void Play()
    {
        Time.timeScale = 1;
        _button.interactable = true;
        _gameObject.active = false;
    }
}
