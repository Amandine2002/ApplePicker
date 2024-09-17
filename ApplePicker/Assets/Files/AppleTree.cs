using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]

    public GameObject   applePrefab;
    public GameObject   rottenapplePrefab;

    public float        speed = 10f;

    public float        leftAndRightEdge = 24f;
 
    public float        changeDirChance = 0.1f;
 
    public float        appelDropDelay = 1f;
    public float        rottenappelDropDelay = 0.1f;

    void Start() {
        // Start dropping apples
        Invoke( "DropApple", 2f);
    }

    void DropApple() {
        GameObject apple;
        if (Random.value < rottenappelDropDelay) {
            apple = Instantiate(rottenapplePrefab);
        } else {
            apple = Instantiate(applePrefab);
        }
        apple.transform.position = transform.position;
        Invoke("DropApple", appelDropDelay);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);   // Move right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        }
    }


    void FixedUpdate() {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance) {
            speed *= -1; // Change direction
        }
    }
}
