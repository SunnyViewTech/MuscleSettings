using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoCapHandBlend : MonoBehaviour
{
    public GameObject src;
    Dollars.MoCapSrc mcs;
    Dollars.MoCapVisibility mcv;
    public float MinVisibility = 0.4f;
    public float MaxVisibility = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        mcs = GetComponent<Dollars.MoCapSrc>();
        mcv = src.GetComponent<Dollars.MoCapVisibility>();
    }
    // Update is called once per frame
    void Update()
    {
        mcs.LeftHandWeight = Dollars.Utils.map(mcv.VisibilityLeftHand, MinVisibility, MaxVisibility, 0, 1);
        mcs.RightHandWeight = Dollars.Utils.map(mcv.VisibilityRightHand, MinVisibility, MaxVisibility, 0, 1);
    }
}
