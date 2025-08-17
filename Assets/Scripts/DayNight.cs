using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float timespeed = 1, angleOfSun = 50;
    private void FixedUpdate() {

        angleOfSun += Time.deltaTime * timespeed;
        transform.rotation = Quaternion.Euler(new Vector3(angleOfSun,0,0));
    }
}
