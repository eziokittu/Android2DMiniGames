using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    GameManager gm;
    public Transform enemy;
    
    private void Awake() {
        gm = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        // Start the instantiation coroutine
        StartCoroutine(InstantiateSpriteCoroutine());
    }

    IEnumerator InstantiateSpriteCoroutine()
    {
        while (true)
        {
            // Wait 2 seconds before instantiating the sprite
            yield return new WaitForSeconds(gm.timeToWaitToSpawnEnemies);

            //Instantiate the sprite at the specified position
            Vector3 possible1 = new Vector3(Random.Range(gm.worldLeft, gm.worldRight), gm.worldTop, 0);
            Vector3 possible2 = new Vector3(Random.Range(gm.worldLeft, gm.worldRight), gm.worldBottom, 0);
            Vector3 possible3 = new Vector3(gm.worldLeft, Random.Range(gm.worldBottom, gm.worldTop), 0);
            Vector3 possible4 = new Vector3(gm.worldRight, Random.Range(gm.worldBottom, gm.worldTop), 0);
            float randomNumber = Random.Range(1,4);
            Vector3 randomPosition = possible4;
            if (randomNumber==1)
            {
                randomPosition = possible1;
            }
            else if (randomNumber==2)
            {
                randomPosition = possible2;
            }
            else if (randomNumber==3)
            {
                randomPosition = possible3;
            }
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }
}
