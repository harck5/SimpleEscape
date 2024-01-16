using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableEnemi : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float distnaceToScale = 5f, maxScale = 3f, upDistance = 1f;
    private Vector3 scaleUp, scaleDown, correctionHeight, normalPosition, scalePosition;

    private void Start()
    {
        scaleUp = new Vector3(maxScale, maxScale, maxScale);
        scaleDown = new Vector3(1, 1, 1);
        correctionHeight = new Vector3(0, upDistance, 0);
        normalPosition = transform.position;
        scalePosition = transform.position + correctionHeight;
    }

    void Update()
    {
        float distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);

       if (distanciaAlPlayer <= distnaceToScale)
        {
            transform.localScale = scaleUp;
            transform.position = scalePosition;
        }
        else
        {
            transform.localScale = scaleDown;
            transform.position = normalPosition;
        }
    }
}
