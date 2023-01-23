using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject                   applePrefab;
    public float                        speed = 1f;
    public float                        leftAndRightEdge = 10f;
    public float                        chanceToChangeDirections = .1f;
    public float                        secondsBetweenAppleDrops = 1f;
    private List<DifficultyLevel>       difficultyLevels = new List<DifficultyLevel>();
    private int                         dLCounter = 0;
    private int                         dLLevel = 0;


    private void Start() {
        Invoke("DropApple", 2f);

        DifficultyLevel df;
        df = new DifficultyLevel();
        difficultyLevels.Add(df);
        df = new DifficultyLevel(15f, .02f, .9f);
        difficultyLevels.Add(df);
        df = new DifficultyLevel(15f, .01f, .8f);
        difficultyLevels.Add(df); 
        df = new DifficultyLevel(17f, .01f, .7f);
        difficultyLevels.Add(df); 
        df = new DifficultyLevel(20f, .01f, .5f);
        difficultyLevels.Add(df);        
    }

    private void Update() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) {
            speed *= -1;
        }

        dLCounter++;
        if ((dLCounter / 500 == 1) && (dLLevel < difficultyLevels.Count-1)) {
            dLCounter = 0;
            dLLevel++;

            DifficultyLevel dL = difficultyLevels[dLLevel];
            speed = dL.speed;
            chanceToChangeDirections = dL.chanceToChangeDirections;
            secondsBetweenAppleDrops = dL.secondsBetweenAppleDrops;
        }
    }


    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }


    private class DifficultyLevel {
        public float        speed;
        public float        chanceToChangeDirections;
        public float        secondsBetweenAppleDrops;

        public DifficultyLevel(float speed = 10f, float chanceToChangeDirections = .02f,
                                    float secondsBetweenAppleDrops = 1f) {
            this.speed = speed;
            this.chanceToChangeDirections = chanceToChangeDirections;
            this.secondsBetweenAppleDrops = secondsBetweenAppleDrops;
        }
    }
}
