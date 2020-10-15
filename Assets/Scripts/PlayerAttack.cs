using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    SwitchAttackingAfterTime highAttack = null;

    [SerializeField]
    SwitchAttackingAfterTime midAttack = null;

    [SerializeField]
    SwitchAttackingAfterTime lowAttack = null;

    bool IsCurrentlyAttacking()
    {
        return highAttack.HitBox.IsAttacking || midAttack.HitBox.IsAttacking || lowAttack.HitBox.IsAttacking;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCurrentlyAttacking() && Input.GetButtonDown("Attack"))
        {
            if (Input.GetButton("High"))
            {
                highAttack.Attack();
            }
            else if (Input.GetButton("Low"))
            {
                lowAttack.Attack();
            }
            else
            {
                midAttack.Attack();
            }
        }
    }
}
