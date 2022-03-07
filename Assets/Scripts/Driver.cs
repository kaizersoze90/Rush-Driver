using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed, moveSpeed, delayOfDestroy;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] Color32 hasPackageColor, noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    bool hasPackage;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, speedAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Got it!");
            hasPackage = true;
            Destroy(other.gameObject, delayOfDestroy);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            Debug.Log("Here it is, sir!");
            hasPackage = false;
        }
        if (other.name == "Speed-up")
        {
            moveSpeed = boostSpeed;
        }
        if (other.name == "Slow-down")
        {
            moveSpeed = slowSpeed;
        }
    }
}
