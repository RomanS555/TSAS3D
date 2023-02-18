using UnityEngine.SceneManagement;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource aS;
    [SerializeField] float jumpforce;
    [SerializeField] AudioClip WeaponReload;
    [SerializeField] Sprite GelpiTS2;
    [SerializeField] AudioClip LvlUp;
    [SerializeField] float decceleration;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float acceleration;
    public bool isGround;
    
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        aS = GetComponent<AudioSource>();
        WeaponReload.LoadAudioData();
    }
    private void FixedUpdate() {
        
        Vector2 MoveVector = new Vector2(Input.GetAxis("Horizontal")*acceleration * Time.deltaTime, 0);
        rb.velocity += MoveVector;
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,0, decceleration * Time.deltaTime), rb.velocity.y);
        
    }
    private void Update() {
        isGround = Physics2D.OverlapCircle(GroundCheck.position,0.01f);
        if(Input.GetButtonDown("Jump") && isGround){
            rb.velocity += Vector2.up * jumpforce;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Weapon"){
           
           Destroy(other.gameObject);
           aS.PlayOneShot(WeaponReload);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<TriggerTranslate>()){
            TriggerTranslate ttrsl = other.gameObject.GetComponent<TriggerTranslate>();
            SceneManager.LoadScene(ttrsl.scene);
        } else if(other.gameObject.tag == "Snickers"){
            GetComponent<SpriteRenderer>().sprite = GelpiTS2;
            aS.PlayOneShot(LvlUp);
            Destroy(other.gameObject);
        }
        
    }
}
