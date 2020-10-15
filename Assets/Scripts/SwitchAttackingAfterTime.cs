using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAttackingAfterTime : MonoBehaviour
{
    [SerializeField]
    HitBox hitBox = null;

    public HitBox HitBox
    {
        get
        {
            return hitBox;
        }
    }

    [SerializeField]
    SpriteRenderer hitBoxSprite = null;

    [SerializeField]
    float secondsAfterTime = 0;

    void SetSpriteAlpha(float alpha)
    {
        var color = hitBoxSprite.color;
        color.a = alpha;
        hitBoxSprite.color = color;
    }

    private void OnEnable()
    {
        SetSpriteAlpha(0);
    }

    public void Attack()
    {
        if (!hitBox.IsAttacking)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        SetSpriteAlpha(1);
        hitBox.IsAttacking = true;
        yield return new WaitForSeconds(secondsAfterTime);
        hitBox.IsAttacking = false;
        SetSpriteAlpha(0);
    }
}
