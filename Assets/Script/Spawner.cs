
using System;
using System.Collections;
using CodeGraph.UnityCourse.Enemies.CharacterController;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject ennemy;
    public GameObject player;

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 _spawnHere = new Vector3(UnityEngine.Random.Range(-40f, 40f), 2.0f, UnityEngine.Random.Range(-40f, 40f));
            GameObject ennemy_spawn = Instantiate(ennemy, _spawnHere, Quaternion.identity);
            EnnemyController x = ennemy_spawn.GetComponent<EnnemyController>();
            x.player = player;
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Start()
    {
        StartCoroutine(SpawnRoutine());
}
}

