using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //le Player entre en collision avec le Weakspot
        {
            Destroy(objectToDestroy); //détruit le gameobject attribué dans l'Inspector
        }
    }
}
