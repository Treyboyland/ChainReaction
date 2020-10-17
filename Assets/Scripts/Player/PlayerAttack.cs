using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    SwitchAttackingAfterTime upAttack = null;

    [SerializeField]
    SwitchAttackingAfterTime rightAttack = null;

    [SerializeField]
    SwitchAttackingAfterTime downAttack = null;

    [SerializeField]
    SwitchAttackingAfterTime leftAttack = null;


    bool IsCurrentlyAttacking()
    {
        //return highAttack.HitBox.IsAttacking || midAttack.HitBox.IsAttacking || lowAttack.HitBox.IsAttacking;
        return upAttack.IsAttacking || rightAttack.IsAttacking || downAttack.IsAttacking || leftAttack.IsAttacking;
    }





    // Update is called once per frame
    void Update()
    {
        if (!IsCurrentlyAttacking())
        {
            if (Input.GetButton("UpAttack"))
            {
                upAttack.Attack();
            }
            else if (Input.GetButton("DownAttack"))
            {
                downAttack.Attack();
            }
            else if (Input.GetButton("RightAttack"))
            {
                rightAttack.Attack();
            }
            else if (Input.GetButton("LeftAttack"))
            {
                leftAttack.Attack();
            }
        }
    }
}
