using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] Transform moveGoal;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float distance = 1.5f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GetComponent<Animator>().SetBool("near", false);

        Vector3 realGoal = new Vector3(moveGoal.position.x, transform.position.y, moveGoal.position.z);
        Vector3 direction = realGoal - transform.position;

        if (direction.magnitude >= distance) {
            Vector3 pushVector = direction.normalized * speed;
            transform.Translate(pushVector, Space.World);
        } else {
            GetComponent<Animator>().SetBool("near", true);
        }
    }
}