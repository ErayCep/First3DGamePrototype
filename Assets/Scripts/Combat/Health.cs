using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGProject.Movement;
namespace RPGProject.Combat
{
    public class Health : MonoBehaviour
    {

        [SerializeField]float health = 100f;
        float currentHealth;
        bool isDead = false;

        Animator animator;
        
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            if(health <= 0)
            {
                Die();
                
            }
        }

        void Die()
        {
            if(isDead) return;

            isDead = true;
            animator.SetTrigger("die");
        }
    }
}

