using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxShield : MonoBehaviour
{
    [SerializeField] private bool startTimer;
    [SerializeField] private float timer;
    [SerializeField] private int hitPoint;
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
        Item = GameObject.Find("ItemBar").GetComponent<RectTransform>();
        Text = GameObject.Find("TimersText").GetComponent<Text>();
        Scrollbar = GameObject.Find("Scrolbar").GetComponent<Scrollbar>();
    }
    
    void Start()
    {
        startTimer = false;
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        if (startTimer)
        {
            Item.anchoredPosition = new Vector3(0,-240,0);
            Debug.Log(item.position);
            Text.text = ""+(int)timer;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Item.anchoredPosition = new Vector3(0,-600,0);
                Scrollbar.size = 1;
                Text.text = "5";
                Destroy(gameObject);
            }
        }
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
