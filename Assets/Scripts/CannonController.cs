using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private float topSagSinir;
    private float topSolSinir;
    public float softAdjustment = 0.25f;
    public float cannonSpeedx;
    
    // Start is called before the first frame update
    void Start()
    {
        getCamPos();
        // Cannon'nun baslayacaðý yeri belirle.
        transform.position = new Vector3(0f, -4f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        setCamPos();
        cannonMov();
    }
    void getCamPos()
    {
        //Cameranýn sað ve sol uçlarýný bir vektöre atadýk
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        topSagSinir = sagUc.x - softAdjustment;
        topSolSinir = solUc.x + softAdjustment;
    }
    void setCamPos()
    {
        //getCamPos içinde alýnan sað ve sol sýnýr deðerlerini min ve maks olarak ayarlayýp cannonun hareket alanýný belirledik.
        float yeniX = Mathf.Clamp(transform.position.x, topSolSinir, topSagSinir);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
    }
    void cannonMov()
    {
        //Basýlan tusa göre hangi yöne gideceðine göre islem yaptýk.
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(cannonSpeedx * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(cannonSpeedx * Time.deltaTime, 0, 0);
        }
    }
}
