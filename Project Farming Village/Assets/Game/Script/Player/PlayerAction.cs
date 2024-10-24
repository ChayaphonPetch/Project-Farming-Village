using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int positon = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

           
        }
    }
}
