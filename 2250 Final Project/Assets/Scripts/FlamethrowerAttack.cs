using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Animator anim;


    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;

    public DialogueUI DialogueUI => dialogueUI;

    private FlamethrowerBehaviour flamethrowerBehaviour;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private int attackCount = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        flamethrowerBehaviour = GetComponent<FlamethrowerBehaviour>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            fireballs[0].GetComponent<FlamethrowerBehaviour>().Deactivate();
        }
        cooldownTimer += Time.deltaTime;

      
    }
    private void Attack()
    {
        attackCount++;
       // anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<FlamethrowerBehaviour>().SetDirection(Mathf.Sign(transform.localScale.x));

        // increases attack damage stat
        if (attackCount > 9)
        {
            attackCount = 0;
            dialogueUI.ShowDialogue(dialogueObject);
             flamethrowerBehaviour.damage++;
            

        }
    }
}
