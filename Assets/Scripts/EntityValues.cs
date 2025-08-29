using NaughtyAttributes;
using UnityEngine;

public class EntityValues : MonoBehaviour
{
    
    [SerializeField] float health;
    public void ChangeHp(float delta)
    {
        health += delta;
    }
    public void TakePlayerDamage(CurrentWeapon pl)
    {
        health -= pl.itemInhotbar.DamageWeapon;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
