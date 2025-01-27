using System;
using UnityEngine;

public class MonoBehaviouringleton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public class CharacterLifeManagernotGeneric : MonoBehaviour
    {
        public const int MAX_LIFE_POINT = 8;
        [SerializeField]
        private int nbLifePoints = 8;

        public void TakeDamage()
        {
            nbLifePoints--;
            Debug.Log("-1 Point de Vie "+ nbLifePoints+" points restants");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
