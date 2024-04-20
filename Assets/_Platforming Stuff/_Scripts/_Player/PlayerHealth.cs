using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 5;
    public float health;
    private Vector3 startPos;
    public TextMeshProUGUI healthText;
    void Start()
    {
        startPos = transform.position;
        health = maxHealth;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    private void Update()
    {

        SetHealthText();
        if (health <= 0) 
        {
            /*Destroy(gameObject);*/
            SceneManager.LoadScene("game over");
            //health = maxHealth;
            //transform.position = startPos;
        }
    }
    /*public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0) {Destroy(gameObject); }
    }*/

    
}
