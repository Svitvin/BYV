using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _creator;
    [SerializeField] private Button _button;
    [SerializeField] private Button _buttonResume;
    private MovePlayer _movePlayer1;
    private MovePlayer _movePlayer2;

    private void Awake()
    {
        _movePlayer1 = GameObject.Find("Player").GetComponent<MovePlayer>();
        _movePlayer2 = GameObject.Find("Enemy").GetComponent<MovePlayer>();
    }

    async void FixedUpdate()
    {
        
        if (_movePlayer1.IsDied)
        {
            _movePlayer2.IsDied = false;
            Time.timeScale = 1;
            _creator.active = true;
            _button.interactable = false;
            _buttonResume.interactable = false;
            _text.text = "Winner \n Player 2";
        }   
        if (_movePlayer2.IsDied)
        {
            _movePlayer2.IsDied = false;
            Time.timeScale = 1;
            _creator.active = true; 
            _button.interactable = false;
            _buttonResume.interactable = false;
            _text.text = "Winner \n Player 1";
        }
    }
}
