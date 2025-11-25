using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Dictionary<int, string[]> _talkData { get; private set; }

    private void Awake()
    {
        _talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        _talkData.Add(1000, new []{"Test"});
    }
}
