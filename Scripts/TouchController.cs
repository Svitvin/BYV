using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private MovePlayer MP; 
    private async void OnMouseDown()
    {
        if (!MP.FirstJump && !MP.SecondJump)
        {
            MP.FirstJump = true;
            _animator.SetBool("isJump", true);
            _animator.Play("JumpHero",-1,0);
            _rigidbody2D.AddForce(new Vector2(0,5f), ForceMode2D.Impulse);
            await Task.Delay(1000);
            _animator.SetBool("isJump", false);
            MP.FirstJump = false;
        }
        else if (MP.FirstJump && !MP.SecondJump)
        {
            MP.SecondJump = true;
            _animator.SetBool("isJump", true);
            _animator.Play("JumpHero",-1,0);
            _rigidbody2D.AddForce(new Vector2(0,5f), ForceMode2D.Impulse);
            await Task.Delay(1000);
            _animator.SetBool("isJump", false);
            MP.SecondJump = false;
        }
    }
}
