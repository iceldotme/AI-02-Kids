using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private GameObject jacksPrefab;
    GameObject[] jacks;
    [SerializeField] GameObject goal;
    const int NUM_OF_JACKS = 90;
    const int NUM_OF_CIRCLES = 3;

    const int RADIUS = 30;

    // Start is called before the first frame update
    void Start() {
        for (int k = 0; k < NUM_OF_CIRCLES; k++) {
            jacks = new GameObject[NUM_OF_JACKS];
            for (int i = 0; i < NUM_OF_JACKS; i++) {
                jacks[i] = Object.Instantiate(jacksPrefab);
                jacks[i].transform.RotateAround(Vector3.zero, Vector3.up, i * (360 / NUM_OF_JACKS));

                jacks[i].transform.Translate(RADIUS + 3 * k + Random.Range(1, k + 1), 0, 0, Space.Self);
                jacks[i].transform.LookAt(goal.transform);

                jacks[i].GetComponent<MoveCharacter>().moveGoal = goal.transform;
                jacks[i].GetComponent<MoveCharacter>().speed = 0.05f;
                jacks[i].GetComponent<MoveCharacter>().distance = 5 + k;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
