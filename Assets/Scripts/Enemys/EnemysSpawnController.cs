using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawnController : MonoBehaviour
{
    public GameObject[] Enemys;

    void Start()
    {
        Vector3 CurrentPosition = transform.position;
        for (int i = 0; i < Enemys.Length; i++)
        {
            GameObject Enemy = Instantiate(Enemys[i], CurrentPosition, Quaternion.identity);
            CurrentPosition.y -= 0.75f;
        }
    }
}
