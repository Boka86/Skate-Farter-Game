using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skate : MonoBehaviour
{
 
    Rigidbody2D rb;
    [SerializeField] private ParticleSystem crushfx;
    SoundEffect soundEffect;
    Player player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Gordo").GetComponent<Player>();
        soundEffect = GameObject.Find("Gordo").GetComponent<SoundEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obs"))
        {
           
           // rb.AddForce(-Vector2.right*40,ForceMode2D.Impulse);
            transform.parent = null;
            crushfx.Play();
            player.HitObsEffect();
            soundEffect.HitSound();
            StartCoroutine(RestartLevel());

            
        }
    }


    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(0);
    }
}
