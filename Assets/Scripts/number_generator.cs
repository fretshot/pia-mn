﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class number_generator : MonoBehaviour {

    public GameObject[] assets;
    public float tiempoMin = 2f;
    public float tiempoMax = 6f;

    private void Start() {
        NotificationCenter.DefaultCenter().AddObserver(this, "startGenerator");
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        NotificationCenter.DefaultCenter().AddObserver(this, "stopGenerator");
    }

    void Generar() {
        int numero = Random.Range(0, assets.Length);
        Instantiate(assets[numero], transform.position, Quaternion.identity);
        NotificationCenter.DefaultCenter().PostNotification(this, "agregar", numero);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }

    void stopGenerator(Notification notification) {
        CancelInvoke();
    }

    void startGenerator(Notification notification) {
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }
}
