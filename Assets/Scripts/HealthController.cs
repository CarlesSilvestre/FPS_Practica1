using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    public float MaxHP;
    public float MaxShield;

    private float mHp;
    private float mShield;

    // Start is called before the first frame update
    void Start()
    {
        mHp = MaxHP;
        mShield = MaxShield;
    }

    public void TakeDamage(float amount)
    {
        // If shield can take 75% of the damage
        if(mShield > amount * 0.75f)
        {
            mShield -= amount * 0.75f;
            mHp -= amount * 0.25f;
        }
        else // Else, take what it can and set it to 0
        {
            mHp -= amount - mShield;
            mShield = 0;
        }
        // Check negative values
        mShield = mShield <= 0 ? 0f : mShield;
        if (mHp <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("DIED");
    }

}
