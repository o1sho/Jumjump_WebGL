using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;
    [SerializeField] private Animator _anim;


    private void Start()
    {
        isGround= false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround=true;
            _anim.SetBool("isGround", isGround);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = false;
            _anim.SetBool("isGround", isGround);
        }
    }
}
