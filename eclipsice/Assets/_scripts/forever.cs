﻿using UnityEngine;
using System.Collections;

public class Forever : MonoBehaviour {

	private static Forever instance = null;
	public static Forever Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
