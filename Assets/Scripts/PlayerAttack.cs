using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject highAttack = null;

    [SerializeField]
    GameObject midAttack = null;

    [SerializeField]
    GameObject lowAttack = null;

    bool IsCurrentlyAttacking()
    {
        return highAttack.activeInHierarchy || midAttack.activeInHierarchy || lowAttack.activeInHierarchy;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCurrentlyAttacking() && Input.GetButtonDown("Attack"))
        {
            if (Input.GetButton("High"))
            {
                highAttack.SetActive(true);
            }
            else if (Input.GetButton("Low"))
            {
                lowAttack.SetActive(true);
            }
            else
            {
                midAttack.SetActive(true);
            }
        }
    }
}
