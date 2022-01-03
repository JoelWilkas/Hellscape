using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(playerPos.position.x, transform.position.y);
    }
}
