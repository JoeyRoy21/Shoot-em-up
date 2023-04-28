using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Anything we want the object pooler we want it to spawn
public interface IPooledObject 
{
    void OnObjectSpawn();
}
