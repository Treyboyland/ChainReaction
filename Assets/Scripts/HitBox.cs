using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    bool isForPlayer = false;

    [SerializeField]
    int damagePerSecond = 0;

    public int DamagePerSecond
    {
        get
        {
            return damagePerSecond;
        }
    }

    public bool IsForPlayer
    {
        get
        {
            return isForPlayer;
        }
    }

    public bool IsAttacking { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void CheckForCollision(Collider2D other)
    {
        if (!IsAttacking)
        {
            return;
        }
        if (isForPlayer)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.LogWarning("Player Has hit enemy");
                enemy.ApplyDamageOverTime(damagePerSecond, int.MaxValue);
                IsAttacking = false; //TODO: This means that only one monster can be hit per attack
            }
        }
        else
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                //player.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            CheckForCollision(other);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.LogWarning(gameObject.name + " Stay");
        if (gameObject.activeInHierarchy)
        {
            CheckForCollision(other);
        }
    }
}
