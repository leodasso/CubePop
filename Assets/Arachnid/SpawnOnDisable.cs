using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDisable : MonoBehaviour {

    public GameObject toSpawn;

	void OnDisable()
    {
        if (!toSpawn) return;
        Instantiate(toSpawn, transform.position, transform.rotation);
    }
}
