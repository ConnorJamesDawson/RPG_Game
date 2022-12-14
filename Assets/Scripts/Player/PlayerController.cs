using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask longGrassLayer;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;
    private SpriteRenderer renderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                renderer.flipX = false;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                renderer.flipX = true;
            }
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) //Removes Diagonal Input
                input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                Vector3 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }

        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {

        if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer) != null)
        {
            if(Random.Range(1, 101) < 10)
            {
                Debug.Log("Encounter!");
            }
        }

    }
}
