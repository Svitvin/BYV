using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private RectTransform _rectTransform; 
    
    private bool isShield;
    private float time;

    public bool IsShield
    {
        get => isShield;
        set => isShield = value;
    }

    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShield)
        {
            time += Time.deltaTime;
            if (time >= timer)
            {
                _rectTransform.anchoredPosition = new Vector3(0, -20f, 0);
                time = 0;
                IsShield = false;
            }
        }
    }
}
