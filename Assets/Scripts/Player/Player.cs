using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    int health = 0;

    bool canModifyHealth = true;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value < health)
            {
                health = Mathf.Max(value, 0);
            }
            else
            {
                health = value;
            }
            OnPlayerHealthUpdated.Invoke(health);
            if (health == 0)
            {
                //Die
                canModifyHealth = false;
            }
        }
    }

    public class HealthUpdate : UnityEvent<int> { }

    public HealthUpdate OnPlayerHealthUpdated = new HealthUpdate();


    [SerializeField]
    bool debug;

    [SerializeField]
    bool attackWithWasd = true;

    public bool AttackWithWasd
    {
        get
        {
            return attackWithWasd;
        }
    }

    public static bool AttackUsingWasd = false;

    private void Awake()
    {
        if (!debug)
        {
            attackWithWasd = AttackUsingWasd;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
