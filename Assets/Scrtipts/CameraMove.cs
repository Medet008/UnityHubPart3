using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    public Transform PlayerTransform;
    [SerializeField]
    public Rigidbody PlayerRigitboy;
    [SerializeField]
    public List<Vector3> VelosityLists = new List<Vector3>();

    private void Start()
    {
        for (int i=0; i<10; i++)
        {
            VelosityLists.Add(Vector3.zero); 
        }
    }

    private void FixedUpdate()
    {
        VelosityLists.Add(PlayerRigitboy.velocity);
        VelosityLists.RemoveAt(0); 
    }

    void Update()
    {
        Vector3 summ = Vector3.zero; 
        for(int i=0; i<VelosityLists.Count; i++)
        {
            summ += VelosityLists[i]; 
        }
        transform.position = PlayerTransform.position;
        transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * 10f);
    }
}
