using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Build;
    [SerializeField] private GameObject GoodBuild;
    [SerializeField] private GameObject BadBuild;
    public BuildingCheck _bc;
    
    void Start()
    {
        Build.SetActive(false);
        GoodBuild.SetActive(false);
        BadBuild.SetActive(false);
    }

    void Update()
    {
        
    }

    public void BuildGood()
    {
        Build.SetActive(false);
        GoodBuild.SetActive(true);
        BadBuild.SetActive(false);
    }
    public void BuildBad()
    {
        Build.SetActive(false);
        GoodBuild.SetActive(false);
        BadBuild.SetActive(true);
    }

    public void BuildFinish()
    {
        Build.SetActive(true);
        GoodBuild.SetActive(false);
        BadBuild.SetActive(false);
    }
}
