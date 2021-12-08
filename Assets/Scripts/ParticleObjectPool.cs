using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ParticleObjectPool : MonoBehaviour
{
    private Queue<GameObject> fountainObjectPool;
    private float timer = 1f;
    private float returntimer = 5f;
    [SerializeField] private GameObject particle;

    private void Start()
    {
        ObjectPool();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            var go = FountainObjectPoolSpawn();
            go.transform.position = Random.insideUnitSphere * 1;
        }
        timer = 1f;
        returntimer -= Time.deltaTime;
        if (returntimer < 0.0f)
        {
            ObjectPoolReturn(particle);
        }

        /*
        timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(particle, Random.insideUnitSphere * 2, Quaternion.identity);
            }
            timer = 1f;
        }
        */
    }

    private void ObjectPool()
    {
        fountainObjectPool = new Queue<GameObject>();

        for (var i = 0; i < 10; i++)
        {
            var go = Instantiate(particle);
            go.GetComponent<MeshRenderer>().enabled = true;
            fountainObjectPool.Enqueue(go);
        }
    }


    public GameObject FountainObjectPoolSpawn()
    {
        if (fountainObjectPool.Count > 0)
        {
            var result = fountainObjectPool.Dequeue();
            result.GetComponent<MeshRenderer>().enabled = true;
            return result;
        }

        return Instantiate(particle);
    }

    public void ObjectPoolReturn(GameObject go)
    {
        go.GetComponent<MeshRenderer>().enabled = false;
        fountainObjectPool.Enqueue(go);
    }
}



