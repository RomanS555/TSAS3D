using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float timespeed = 1;
    [SerializeField] float sinnn;
    float time = 0;
    private void FixedUpdate() {
        time += Time.deltaTime * timespeed;
        transform.rotation = Quaternion.Euler(new Vector3(time,Mathf.Cos(sinnn * time)*20,0));
    }
}
