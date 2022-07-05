using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGProject.Movement;
using RPGProject.Core;

namespace RPGProject.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;

        Health target;
        Animator animator;
        float timeSinceLastAttack = 0;
        float damage = 20f;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if(target == null) return;
            if(target.IsDead() == true) return;

            if(!IsInRange())
            {
                GetComponent<PlayerMovement>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<PlayerMovement>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                //This will trigget Hit() event
                AttackTrigger();
                timeSinceLastAttack = 0;
            }
        }

        private void AttackTrigger()
        {
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
        }

        void Hit()
        {
            if(target == null)return;
            target.TakeDamage(damage);
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAciton(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("cancelAttack");
        }

        public bool CanAttack(GameObject combatDetector)
        {
            if(combatDetector == null){return false;}
            Health targetToTest = combatDetector.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

    }
}



