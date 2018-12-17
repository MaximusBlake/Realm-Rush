using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] int health=10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    [SerializeField] AudioClip losingHealthSFX;


    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        health-=healthDecrease;
        healthText.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(losingHealthSFX);
    }
}
