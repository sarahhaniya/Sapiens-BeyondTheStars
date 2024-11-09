using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    public float damage = 1;

    private float direction;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<MonsterHealth>().TakeDamage(damage);
        }

    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleY = transform.localScale.y;
        if(Mathf.Sign(localScaleY) != _direction)
        {
            localScaleY = -localScaleY;
        }

        transform.localScale = new Vector3(transform.localScale.x, localScaleY, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
