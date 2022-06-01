using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float _waitTimeToRestartLevel;
    [SerializeField] private ParticleSystem finishEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            finishEffect.Play();
            Invoke("RestartLevel", _waitTimeToRestartLevel);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
