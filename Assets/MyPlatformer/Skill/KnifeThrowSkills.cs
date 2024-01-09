using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowSkills : MonoBehaviour 
{
    public GameObject Knifes;
    [SerializeField] private Transform transformKnife;
    [SerializeField] private float power;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            GameObject knife = Instantiate(Knifes, transformKnife.position, Knifes.transform.rotation);
            KnifeThrow(knife);
        }
    }

    private void KnifeThrow(GameObject knife)
    {
        knife.GetComponent<Rigidbody2D>().velocity = new Vector2(power, 0);
    }
}
