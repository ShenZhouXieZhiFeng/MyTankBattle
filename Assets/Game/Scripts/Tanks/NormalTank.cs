using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTank : BaseUnit {

    public bool Move;
    public Transform Target;

	void Start () {

    }
	
	void Update () {
        if (Move)
        {
            goThere(Target.position);
        }
	}

    void goThere(Vector3 _target)
    {
        Vector3 res = Seek(_target);

        Vector3 steeringForce = res;
        Vector3 acceleration = steeringForce / Mass;
        acceleration = Vector3.ClampMagnitude(acceleration, 5);
        CurrentAcceleratedMove = acceleration;

        CurrentMove += CurrentAcceleratedMove;
        CurrentMove = Vector3.ClampMagnitude(CurrentMove, MaxSpeed);

        transform.position += new Vector3(CurrentMove.x, 0, CurrentMove.z) * Time.deltaTime;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, CurrentMove.normalized);
    }

    Vector3 Seek(Vector3 _targetPos)
    {
        Vector3 desirdVelocity = (_targetPos - transform.position).normalized * MaxSpeed;
        return (desirdVelocity - CurrentMove) * Time.deltaTime;
    }
}
