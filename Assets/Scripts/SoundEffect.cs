using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
    
{
    private AudioSource source;
    [SerializeField] AudioClip fartSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] private ParticleSystem fartFX;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            SoundEffectFart();

        }
    }



    void SoundEffectFart()
    {
        source.PlayOneShot(fartSound);
        fartFX.Play();
    }
    public void HitSound()
    {
        source.PlayOneShot(hitSound);
    }
}
