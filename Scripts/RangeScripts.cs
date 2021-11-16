using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeScripts : MonoBehaviour
{
    [SerializeField] private Bomba _bomba;
    private MovePlayer _movePlayer;
    private bool isHero;

    private void FixedUpdate()
    {
        if (isHero)
        {
            _bomba.Timer = 0;
            _movePlayer.CheckTimer = true;
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHero = true;
            _movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            isHero = true;
            _movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
        }
    }
}
