using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField]
    bool isOnEnemy = false;

    Enemy enemy = null;

    void GetEnemyComponent()
    {
        enemy = enemy == null ? GetComponentInParent<Enemy>() : enemy;
    }

    void CheckForCollision(Collider2D other)
    {
        if (isOnEnemy)
        {
            GetEnemyComponent();
            var playerHitBox = other.GetComponent<HitBox>();
            if (enemy != null && playerHitBox != null && playerHitBox.gameObject.activeInHierarchy && playerHitBox.IsForPlayer && playerHitBox.IsAttacking)
            {
                Debug.LogWarning("Player Has hit enemy");
                enemy.Damage(playerHitBox.DamagePerSecond);
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
        //Debug.LogWarning(gameObject.name + " Enter");
        if (gameObject.activeInHierarchy)
        {
            CheckForCollision(other);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.LogWarning(gameObject.name + " Stay");
        if (gameObject.activeInHierarchy)
        {
            CheckForCollision(other);
        }
    }
}
