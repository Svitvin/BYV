using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private RectTransform spawnItemPoint;

    [SerializeField] private RectTransform[] items;

    [SerializeField] private float time;

    [SerializeField] private int countItem;

    private float timer;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= time && countItem > 0)
        {
            Instantiate(items[Random.Range(0, items.Length)], spawnItemPoint.transform);
            countItem--;
            timer = 0;
        }   
    }
}
