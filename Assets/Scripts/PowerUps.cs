using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public class SPowerUps
    {
        internal static bool rocket = false;
        internal static bool jetpack = false;
        internal static bool shoes = false;
        internal static bool pills = false;
        internal static bool token = false;
    }

    public float ShoesSpeed;
    public int jetpackJumps;
    public float PillMass;
    private int Levens;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Pills();
        levens();
    }

    public void Pills()
    {
      if (SPowerUps.pills.Equals(true))
          rb.mass = PillMass;
    }

    public void levens()
    {
        if (SPowerUps.token.Equals(true))
            Levens += 1;
    }

    [System.Obsolete]
    public void OnCollisionEnter(Collision PowerUp)
    {
       if(PowerUp.gameObject.CompareTag("PowerUp"))
        {
            var name = PowerUp.gameObject.name;
            DestroyObject(PowerUp.gameObject);
            switch (name)
            {
                case "rocket":
                    SPowerUps.rocket = true;
                    break;
                case "jetpack":
                    SPowerUps.jetpack = true;
                    break;
                case "shoes":
                    SPowerUps.shoes = true;
                    break;
                case "pills":
                    SPowerUps.pills = true;
                    break;
                case "token":
                    SPowerUps.token = true;
                    break;
            }
        }

    }

}
