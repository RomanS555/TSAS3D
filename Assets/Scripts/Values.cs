
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    
    public static float SnickersV = 100;
    public static float HP = 100;
    [SerializeField] float speedsubS = 0.2f;
    [SerializeField] AudioClip getSnickers;
    [SerializeField] Slider slider;
    [SerializeField] Slider HPbar;
    AudioSource aS;
    public static float maxHP = 100;
    public const float maxSnickers = 100;

    private void Start() {
        aS = GetComponent<AudioSource>();
    }


    private void Update() {
        slider.value = SnickersV;
        HPbar.value = HP;
        HPbar.maxValue = maxHP;
        SnickersV -= Time.deltaTime*speedsubS;
        
    }



    private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Snickers"){
        aS.PlayOneShot(getSnickers);
        if(SnickersV +35 > 100){
            SnickersV = 100;
        }else {
            SnickersV += 35;
        }
        Destroy(other.gameObject);
    }
}

}
