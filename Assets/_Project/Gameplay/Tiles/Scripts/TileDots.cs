using System;
using System.Collections.Generic;
using UnityEngine;

public class TileDots : MonoBehaviour
{
    [SerializeField] private List<TileDot> dots;

    private void OnValidate()
    {
        CheckDotConsistency();
        SetActiveDots();
    }

    private void Awake()
    {
        RemoveInactiveDots();
    }

    public IEnumerable<TileDot> Dots => dots;

    private void RemoveInactiveDots()
    {
        List<TileDot> newDots = new List<TileDot>();
        foreach (var dot in dots)
        {
            if (dot.IsActive)
                newDots.Add(dot);
        }
        dots = newDots;
    }

    // Throws an error if the positions of several dots coincide.
    private void CheckDotConsistency()
    {
        foreach (var dot1 in dots)
        {
            foreach (var dot2 in dots)
            {
                if (dot1 != dot2 && dot1.Position == dot2.Position)
                    throw new Exception("Identical position of the tile dots.");
            }
        }
    }

    // Activates and deactivates dots depending on their state.
    private void SetActiveDots()
    {
        foreach (var dot in dots)
        {
            dot.View?.gameObject.SetActive(dot.IsActive);
        }
    }
}
