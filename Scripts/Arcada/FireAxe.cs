using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAxe : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    [SerializeField] private Transform startMoveAxe;
    public async void GenerationAxe()
    {
        Instantiate(axe.transform, startMoveAxe.position, Quaternion.identity);
    }
}
