using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFollows : MonoBehaviour
{
    [SerializeField] private GameObject jacksPrefab;
    GameObject[] jacks;
    [SerializeField] GameObject goal;
    const int NUM_OF_JACKS = 30;
    const int RADIUS = 10;
    const int FOLLOW_DELTA = 1;

    // Start is called before the first frame update
    void Start() {

        jacks = new GameObject[NUM_OF_JACKS];
        for (int i = 0; i < NUM_OF_JACKS; i++) {
            jacks[i] = Object.Instantiate(jacksPrefab);
            jacks[i].transform.RotateAround(Vector3.zero, Vector3.up, i * (360 / NUM_OF_JACKS));
            jacks[i].transform.Translate(RADIUS, 0, 0, Space.Self);
            jacks[i].GetComponent<MoveCharacter>().speed = 0.05f;
            jacks[i].GetComponent<MoveCharacter>().distance = 5;
        }

        jacks[0].GetComponent<MoveCharacter>().moveGoal = goal.transform;
        jacks[0].transform.LookAt(goal.transform);
    }

    // Update is called once per frame
    void Update() {
        for (int i = 1; i < NUM_OF_JACKS; i++) {
            int toFollow = (i + FOLLOW_DELTA) % NUM_OF_JACKS;
            jacks[i].GetComponent<MoveCharacter>().moveGoal = jacks[toFollow].transform;
            jacks[i].transform.LookAt(jacks[toFollow].transform);
        }
    }
}
