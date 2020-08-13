using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBulan : MonoBehaviour
{
    DateTime lastNewMoonRecord;
    DateTime moonCycle;

    [SerializeField]
    float sdt = 0f;

    long mcticks;

    // Start is called before the first frame update
    void Start()
    {
        lastNewMoonRecord = new DateTime(2020, 7, 21, 4, 34, 0);
        moonCycle = new DateTime(2020, 8, 19, 12, 43, 12);//dihitung dari 29.53 hari sesudah lastNewMoonRecord
        mcticks = moonCycle.Ticks - lastNewMoonRecord.Ticks;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime now = DateTime.Now;
        
        long cmticks = now.Ticks % mcticks;
        sdt = (float)cmticks * 360f / (float)mcticks;
        gameObject.transform.eulerAngles = Vector3.up * -sdt;
    }
}
