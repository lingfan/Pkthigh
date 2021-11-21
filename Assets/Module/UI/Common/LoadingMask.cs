using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMask : MonoBehaviour
{
    public Image logoIcon;
    public Image ring;

    [SerializeField] float speed = 500;
    [SerializeField] float iconSpeed = 250;

    private Vector3 logoIconRotation;
    private Vector3 ringRotation;

    // Start is called before the first frame update
    void Start()
    {
        logoIconRotation = logoIcon.transform.eulerAngles;
        ringRotation = ring.transform.eulerAngles;
    }

    void Update()
    {
        logoIcon.transform.Rotate(-logoIcon.transform.up * iconSpeed * Time.deltaTime);
        ring.transform.Rotate(-ring.transform.forward * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        logoIcon.transform.eulerAngles = logoIconRotation;
        ring.transform.eulerAngles = ringRotation;
    }
}