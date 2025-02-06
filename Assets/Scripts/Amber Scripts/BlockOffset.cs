using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOffset : MonoBehaviour
{
    private float randomSpawnOffset;
    private float spawnOffset;
    private float randomRotate;
    // Start is called before the first frame update
    void Start()
    {
        randomSpawnOffset = Random.Range(-1, 2);
        print(randomSpawnOffset);
        if (randomSpawnOffset == -1)
        {
            spawnOffset = -1.6f;
        }
        else if (randomSpawnOffset == 0)
        {
            spawnOffset = 0;
        }
        else if (randomSpawnOffset == 1)
        {
            spawnOffset = 1.6f;
        }
        transform.position = new Vector2(this.transform.position.x + spawnOffset, this.transform.position.y);
        randomRotate = Random.Range(0, 3);
        if (randomRotate == 0)
        {
            transform.Rotate(0, 0, 90);
        }
        else if (randomRotate == 1)
        {
            transform.Rotate(0, 0, 180);
        }
        else if (randomRotate == 2)
        {
            transform.Rotate(0, 0, 270);
        }

    }

    
}
