﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GatherObject : MonoBehaviour
    {
        public Gatherable gatherable;

        private void OnMouseEnter()
        {
            // TODO: Enable outline?
        }

        private void OnMouseDown()
        {
            // TODO: Try Collect
        }
    }
}