using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Bomba : MonoBehaviour
{
    [SerializeField] private bool startTimer;
    [SerializeField] private float timer;
    [SerializeField] private int hitPoint;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject bomba;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private RectTransform _rectTransform;
    private AudioSource vzruv;

    public float Timer
    {
        get => timer;
        set => timer = value;
    }

    private Text _text;
    private Scrollbar _scrollbar;

    private RectTransform item;

    public Text Text
    {
        get => _text;
        set => _text = value;
    }

    public RectTransform Item
    {
        get => item;
        set => item = value;
    }

    public Scrollbar Scrollbar
    {
        get => _scrollbar;
        set => _scrollbar = value;
    }

    public int HitPoint
    {
        get => hitPoint;
        set => hitPoint = value;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        vzruv = GameObject.Find("Vzruv").GetComponent<AudioSource>();
        Item = GameObject.Find("ItemBar").GetComponent<RectTransform>();
        Text = GameObject.Find("TimersText").GetComponent<Text>();
        Scrollbar = GameObject.Find("Scrolbar").GetComponent<Scrollbar>();
    }
    
    void Start()
    {
        startTimer = false;
    }

    // Update is called once per frame
    async void FixedUpdate()
    {

        if (startTimer)
        {
            _scrollbar.gameObject.active = false;   
            Item.anchoredPosition = _rectTransform.anchoredPosition + (Vector2)new Vector3(40,40,-1);
            Debug.Log(item.position);
            Text.text = ""+(int)Timer;
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {   
                startTimer = false;
                BOOOM();
            }
        }
    }

    private void BOOOM()
    {
        vzruv.Play();
        Instantiate(_particleSystem.transform, gameObject.transform.position + Vector3.back, Quaternion.identity);
        _spriteRenderer.color = Color.clear;
        Item.anchoredPosition = new Vector3(0,-600,0);
        Scrollbar.size = 1;
        Text.text = "5";
        _particleSystem.Play();
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            startTimer = true;
            _scrollbar.gameObject.active = false;
        }
    }
}
