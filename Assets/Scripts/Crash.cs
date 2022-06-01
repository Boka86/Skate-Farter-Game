using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] private float _waitTimeToRestartLevel;
    [SerializeField] ParticleSystem headCrashEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            headCrashEffect.Play();
            Invoke("RestartLevel", _waitTimeToRestartLevel);
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }


}
