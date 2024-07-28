using UnityEngine;

public class projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D  boxCollider;
    private Animator anim;
    private float direction;
    private float lifetime;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
   

    private void OnTriggerEnter2D(Collider2D collisoin) 
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collisoin.tag == "Enemy")
        {
            collisoin.GetComponent<health>().Takedamage(1);
        }
    }
    public void SetDirection (float direct)
    {
        lifetime=0; 
        direction = direct;
        gameObject.SetActive(true);
        hit = false;

        boxCollider.enabled=true ;

        float localScaleX =transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direct)
        {
            localScaleX = -localScaleX;
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
    private void Deactivate()   
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {

        if (hit) return;
        float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(movementspeed * transform.localScale.x, 0, 0);
        lifetime += Time.deltaTime;

        if (lifetime > 5)
            gameObject.SetActive(false);
    }
}
