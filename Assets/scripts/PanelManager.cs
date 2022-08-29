using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    private bool ishorizental;
    [SerializeField] private float angle;
    [SerializeField] private int id;
    public float Angle { get => angle; set => angle = value; }
    [SerializeField] Vector3 scale;
    [SerializeField] string direction;
    [SerializeField] int x, y;
    [SerializeField] Material m_Material;
    [SerializeField] private Transform Joint;
    [SerializeField] private Transform MovingPart;
    [SerializeField] private Transform SolarPanel;
    //private InstantiationPanels _instantiationPanels;
    private Structs structs;
    public Structs Structs { get => structs; set => structs=value; }
    // Start is called before the first frame update
    void Start()
    {
            //_instantiationPanels = GameObject.FindObjectOfType<InstantiationPanels>();
            //Debug.Log(_instantiationPanels.AllPanels[5].transform.localScale);
            id = structs.id;
            
            direction = structs.structDirection;
            x = structs.panelsNumber[0];
            y = structs.panelsNumber[1];
            //Debug.Log(structs.structDirection);
            //Debug.Log(y);
            ChangeAngle(angle);
            if (structs.structDirection == "H")
            {
                ishorizental = true;

            }
            else
            {
                ishorizental = false;
            }
            

        
        
        AdjustPanel(x, y, ishorizental);


        //Joint=transform.GetChild(0)
    }


    private void ChangeAngle(float angle)
    {
        var rotationVector = Joint.rotation.eulerAngles;
        rotationVector.x = angle;
        Joint.rotation = Quaternion.Euler(rotationVector);

    }
    private void AdjustPanel(int x, int y, bool direction)
    {   
        if (ishorizental)
        {
            scale = MovingPart.GetComponent<Transform>().localScale;
            MovingPart.localScale = new Vector3(scale.x * x, scale.y, scale.z * y);


            m_Material = SolarPanel.GetComponent<Renderer>().material;
            m_Material.mainTextureScale = new Vector2((float)x / 4, (float)y / 8);
        }
        
        else{
            scale = MovingPart.GetComponent<Transform>().localScale;
            MovingPart.localScale = new Vector3(scale.x * y, scale.y, scale.z * x);


            m_Material = SolarPanel.GetComponent<Renderer>().material;
            m_Material.mainTextureScale = new Vector2((float)y / 4, (float)x / 8);
            //Debug.Log("false===");


            Quaternion rotationY = Quaternion.AngleAxis(90, new Vector3(0f, 1f, 0f));
            MovingPart.transform.localRotation = rotationY;
        }
    }
}

