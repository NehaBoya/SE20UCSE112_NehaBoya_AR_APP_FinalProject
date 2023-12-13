using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBird : MonoBehaviour
{
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Transform MummaBird;

    // Start is called before the first frame update
    void Start()
    {
        //MummaBird = GameObject.FindGameObjectWithTag("MummaBird").GetComponent<Transform>();

        GameObject[] MummaBirds = GameObject.FindGameObjectsWithTag("MummaBird");
        int ChosenMummaBird = Random.Range(0, MummaBirds.Length);
        MummaBird = MummaBirds[ChosenMummaBird].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation of MummaBird towards Camera
        var rotation = Quaternion.LookRotation(MummaBird.transform.position - transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);

        //Baby Bird will follow Mumma Bird!
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, MummaBird.position, step);
    }
}
