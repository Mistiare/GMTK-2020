//////////////////////////////////////////////////
// Christopher Robertson 2020.
// https://github.com/Koltonix
// Copyright (c) 2020. All rights reserved.
//////////////////////////////////////////////////
using System;
using UnityEngine;
using UnityEngine.Events;

namespace LegDay.Events
{
    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { };

    [Serializable]
    public class StringEvent : UnityEvent<String> { };

    [Serializable]
    public class IntEvent : UnityEvent<int> { };

}

