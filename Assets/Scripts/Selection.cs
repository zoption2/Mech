using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Selection : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float duraction;
    private void OnEnable()
    {
        foreach (Transform segment in transform)
        {
            Vector3 startPosition = segment.localPosition;
            segment.localPosition = segment.localPosition - segment.right * offset;
            segment.DOLocalMove(segment.localPosition + segment.right * offset, duraction);
        }

        Rotate(); 
    }

    private void Rotate ()
    {
        transform.DOLocalRotate(transform.up * 3.6f, 0.1f, RotateMode.LocalAxisAdd).onComplete += Rotate;
    }
}
