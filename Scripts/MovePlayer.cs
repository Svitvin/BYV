using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class MovePlayer : MonoBehaviour
{
    [SerializeField] private int HP;

    [SerializeField] private bool firstJump;
    [SerializeField] private bool secondJump;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Rigidbody2D titleRigidbody2D;
    [SerializeField] private float forces;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private Rigidbody2D[] _rigidbody2Ds;
    [SerializeField] private bool isDied;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Image[] HPImages;
    [SerializeField] private Text _text;
    [SerializeField] private Rigidbody2D[] _rigidbodies;
    [SerializeField] private GameObject ragdollsBoom;
    [SerializeField] private Sprite round;
    [SerializeField] private Sprite raketa;
    [SerializeField] private SpriteRenderer itemGun;
    [SerializeField] private Sprite basuka;
    [SerializeField] private Sprite gun;
    private float timeRound;
    private bool isBasuka; 
    private Sprite roundSprite;
    private int tempHp;
    private int startHp;
    private bool checkTimer;

    public bool IsBasuka
    {
        get => isBasuka;
        set => isBasuka = value;
    }

    public Sprite RoundSprite
    {
        get => roundSprite;
        set => roundSprite = value;
    }

    public bool CheckTimer
    {
        get => checkTimer;
        set => checkTimer = value;
    }

    public bool IsDied
    {
        get => isDied;
        set => isDied = value;
    }

    public int TempHp
    {
        get => tempHp;
        set => tempHp = value;
    }

    public int StartHp
    {
        get => startHp;
        set => startHp = value;
    }

    public int Hp
    {
        get => HP;
        set => HP = value;
    }

    public bool FirstJump
    {
        get => firstJump;
        set => firstJump = value;
    }

    private void Start()
    {
        Time.timeScale = 1;
        itemGun.sprite = gun;
        RoundSprite = round;
        StartHp = Hp;
        TempHp = Hp;
    }

    private void FixedUpdate()
    {
        timeRound += Time.deltaTime;
        if (isBasuka)
        {
            itemGun.sprite = basuka;
            if (timeRound >= 5)
            {
                RoundSprite = round;
                itemGun.sprite = gun;
                isBasuka = false;
            }
        }
        else if (!isBasuka) timeRound = 0;
        Boom();
        HPController();
        if (Hp < 0 ) Hp = 0;
        if (Hp > 5 ) Hp = 5;
        int temp;
        temp = StartHp - Hp;
        for (int i = 0; i < StartHp; i++)
        {
            HPImages[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < Hp; i++)
        {
            HPImages[i].color = new Color(1, 1, 1, 1);  
        }
    }   

    public bool SecondJump
    {
        get => secondJump;
        set => secondJump = value;
    }

    private void HPController()
    {
        if (Hp <= 0 && !IsDied)
        {
            hero.active = false;
            ragdoll.active = true;
            titleRigidbody2D.AddForce(new Vector2(forces, 0.1f), ForceMode2D.Impulse);
            _boxCollider2D.size = new Vector2(0, 0);
            isDied = true;
        }
    }

    private void Boom()
    {
        if (checkTimer)
        {
            hero.active = false;
            ragdollsBoom.active = true; 
            checkTimer = false;
            IsDied = true;
            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].AddForce(new Vector3(forces/ Random.Range(10 , 21), Random.Range(0, 3),0), ForceMode2D.Impulse);
            }
        }
    }
}
