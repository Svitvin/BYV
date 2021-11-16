using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int spead;
    [SerializeField] private bool isPlayer;
    [SerializeField] private GameObject partic;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem boomParticleSystem;
    [SerializeField] private ParticleSystem ricoshetParticleSystem;
    [SerializeField] private Sprite round;
    [SerializeField] private Sprite raketa;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private AudioSource rikoshet;
    private AudioSource metal;
    private AudioSource vzruv;
    private MovePlayer movePlayer;
    private AptechkaSc _aptechkaSc;
    private BoxShield _boxShield;
    private Shields _shieldses;
    private BasukaController _basukaController;
    private RectTransform shields;
    private float moveY;

    private void Awake()
    {
        vzruv = GameObject.Find("Vzruv").GetComponent<AudioSource>();
        rikoshet = GameObject.Find("Ricoshet").GetComponent<AudioSource>();
        metal = GameObject.Find("Metal").GetComponent<AudioSource>();
        if (isPlayer)
        {
            shields = GameObject.Find("ShieldPointPlayer").GetComponent<RectTransform>();
            movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
            _shieldses = GameObject.Find("shieldPlayer").GetComponent<Shields>();
        }
        else if (!isPlayer)
        {
            movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
            shields = GameObject.Find("ShieldPointEnemy").GetComponent<RectTransform>();
            _shieldses = GameObject.Find("shieldEnemy").GetComponent<Shields>();
        }
    }

    private void Start()
    {
        if (isPlayer)
        {
            movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
            _spriteRenderer.sprite = movePlayer.RoundSprite;
            movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
                    
        }
        else if (!isPlayer)
        {
            movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
            _spriteRenderer.sprite = movePlayer.RoundSprite;
            movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
        }
        Destroy(gameObject,2);
    }

    void Update()
    {
        _rigidbody2D.velocity = new Vector2(spead,moveY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            if (_spriteRenderer.sprite == round)
            {
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                movePlayer.Hp -= 3;
            }
            else if (_spriteRenderer.sprite == raketa)
            {
                vzruv.Play();
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                BOOOM();
                
                movePlayer.Hp -= 5;
                movePlayer.CheckTimer = true;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Title"))
        {
            if (_spriteRenderer.sprite == round)
            {
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                movePlayer.Hp -= 2;
            }
            else if (_spriteRenderer.sprite == raketa)
            {
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                vzruv.Play();
                BOOOM();
                movePlayer.Hp -= 5;
                movePlayer.CheckTimer = true;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Food"))
        {
            if (_spriteRenderer.sprite == round)
            {
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                movePlayer.Hp -= 1;
            }
            else if (_spriteRenderer.sprite == raketa)
            {
                vzruv.Play();
                BOOOM();
                Instantiate(_particleSystem.gameObject, other.gameObject.transform.position + Vector3.back, Quaternion.identity);
                movePlayer.Hp -= 5;
                movePlayer.CheckTimer = true;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Shoot"))
        {
            rikoshet.Play();
            Instantiate(ricoshetParticleSystem.transform, gameObject.transform.position, Quaternion.identity);
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            spead *= -1;
            moveY = -10;
            spead /= 2;
        }
        if (other.gameObject.CompareTag("Aptechka"))
        {
            _aptechkaSc = other.GetComponent<AptechkaSc>(); 
            _aptechkaSc.HitPoint--;
            _aptechkaSc.Scrollbar.size -= 0.11f;
            Destroy(gameObject);
            if (_aptechkaSc.HitPoint <= 0)
            {
                if (isPlayer)
                {
                    movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
                    movePlayer.Hp += 3;
                    movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
                    
                }
                else if (!isPlayer)
                {
                    movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
                    movePlayer.Hp += 3;
                    movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
                }
                _aptechkaSc.Item.anchoredPosition = new Vector3(0,-600,0);
                _aptechkaSc.Scrollbar.size = 1;
                _aptechkaSc.Text.text = "5";
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            GameObject gm;
            _boxShield = other.GetComponent<BoxShield>();
            _boxShield.HitPoint--;
            _boxShield.Scrollbar.size -= 0.11f;
            Destroy(gameObject);
            if (_boxShield.HitPoint <= 0)
            {
                shields.anchoredPosition = new Vector3(0, 3.5f, 0);
                _shieldses.IsShield = true;
                _boxShield.Item.anchoredPosition = new Vector3(0, -600, 0);
                _boxShield.Scrollbar.size = 1;
                _boxShield.Scrollbar.gameObject.active = true;
                _boxShield.Text.text = "5";
                Destroy(other.gameObject);
            }
        }   
        if (other.gameObject.CompareTag("Shields"))
        {
            spead /= 10;
        }  
        if (other.gameObject.CompareTag("Boom"))
        {
            metal.Play();
            rikoshet.Play();
            Rigidbody2D rigidbody2D = new Rigidbody2D();
            rigidbody2D = other.GetComponent<Rigidbody2D>();
            if (isPlayer) rigidbody2D.AddForce(new Vector2(0.5f,0), ForceMode2D.Impulse);
            else if (!isPlayer) rigidbody2D.AddForce(new Vector2(-0.5f,0), ForceMode2D.Impulse);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bosuka"))
        {
            _basukaController = other.GetComponent<BasukaController>();
            _basukaController.HitPoint--;
            _spriteRenderer.sprite = raketa;
            if (_basukaController.HitPoint <= 0)
            {
                _basukaController.Item.anchoredPosition = new Vector3(0, -600, 0);
                _basukaController.Scrollbar.size = 1;
                _basukaController.Scrollbar.gameObject.active = true;
                _basukaController.Text.text = "5";
                if (isPlayer)
                {
                    movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
                    movePlayer.IsBasuka = true;
                    movePlayer.RoundSprite = raketa;
                    movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
                    
                }
                else if (!isPlayer)
                {
                    movePlayer = GameObject.Find("Enemy").GetComponent<MovePlayer>();
                    movePlayer.IsBasuka = true;
                    movePlayer.RoundSprite = raketa;
                    movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
                }
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }  
    }
    private void BOOOM()
    {
        Instantiate(boomParticleSystem.transform, gameObject.transform.position + Vector3.back, Quaternion.identity);
        _particleSystem.Play();
    }
}
