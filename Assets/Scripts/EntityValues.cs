using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityValues : MonoBehaviour
{
    [SerializeField] float health;
    public void ChangeHp(float delta)
    {
        health += delta;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
