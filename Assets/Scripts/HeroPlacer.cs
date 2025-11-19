using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

public class HeroPlacer : MonoBehaviour
{
    private HeroController _hero;
    private void Start()
    {
        _hero = FindObjectOfType<HeroController>();
        if (_hero != null)
        {
            Debug.Log("Я работаю");
            _hero.transform.position = transform.position;
            _hero.transform.rotation = transform.rotation;
            _hero.gameObject.SetActive(true);
        }
    }
}
