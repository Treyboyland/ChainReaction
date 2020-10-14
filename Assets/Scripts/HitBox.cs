using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    bool isForPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (isForPlayer)
            {
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.LogWarning("Player Has hit enemy");
                    enemy.gameObject.SetActive(false);
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
    }
}
