using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    [SerializeField] double maxEffectedRadius;
    [SerializeField] float shipMass;

    const double G = 6.67e-11;

    void Update() {
        foreach (OrbitalBody o in OrbitalBodyManager.Instance.orbitalBodies) {
            Vector3d direction = new Vector3d(o.transform.position - transform.position).normalized;
            double r = (o.transform.position - transform.position).magnitude;

            double RSquared = r * r;
            double oneOverRSquared = 1 / RSquared;

            if (r < maxEffectedRadius) {
                double gForceMag = G * shipMass * o.mass * oneOverRSquared;
                Vector3d gForce = direction * gForceMag;

                // todo: custom verlet phsyics
                GetComponent<Rigidbody>().AddForce(new Vector3((float)gForce.x, (float)gForce.y, (float)gForce.z));
            }
		}
    }
}
