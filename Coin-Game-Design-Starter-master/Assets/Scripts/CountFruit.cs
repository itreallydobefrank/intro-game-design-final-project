using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountFruit : MonoBehaviour
{

    private int health = 100;
    public Text countHealth;

    // Start is called before the first frame update
    void Start()
    {
        countHealth.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This is where it will determine what effect each food object will have on player health
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pear"))
        {
            health += 5;
            countHealth.text = "Health: " + health.ToString();
        }

        if (other.gameObject.CompareTag("Orange"))
        {
            health += 10;
            countHealth.text = "Health: " + health.ToString();
        }

        if (other.gameObject.CompareTag("Apple"))
        {
            health += 15;
            countHealth.text = "Health: " + health.ToString();
        }

        if (other.gameObject.CompareTag("Fries"))
        {
            health -= 10;
            countHealth.text = "Health: " + health.ToString();
        }

        if (other.gameObject.CompareTag("Pizza"))
        {
            health -= 15;
            countHealth.text = "Health: " + health.ToString();
        }
    }
}