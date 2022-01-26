using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalBodyManager : MonoBehaviour {
	public static OrbitalBodyManager Instance { get; private set; }

    [SerializeField] public List<OrbitalBody> orbitalBodies;

	private void Awake() {
		Instance = this;
	}
}
