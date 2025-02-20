﻿using UnityEngine;

public class Planet : MonoBehaviour
{

    public float planetGroundOffset = 0.5f;

    GameManager gameManager;
    Car car;
    SphereCollider sc;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        car = gameManager.Car;
        sc = GetComponent<SphereCollider>();
    }

    public void PositionCar()
    {
        var carDir = (car.transform.position - transform.position).normalized;
        var planetSurfaceRadius = transform.localScale.x * sc.radius + planetGroundOffset;
        var localGravityOrigin = carDir * planetSurfaceRadius;
        var newCarPosition = transform.position + localGravityOrigin;
        car.transform.position = newCarPosition;
    }

    public void RotateCar()
    {
        var targetBottomVector = (transform.position - car.transform.position).normalized;
        var bottomVector = -car.transform.up;

        car.transform.rotation = Quaternion.FromToRotation(bottomVector, targetBottomVector) * car.transform.rotation;
    }

}
