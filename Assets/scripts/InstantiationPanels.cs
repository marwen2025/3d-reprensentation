
using UnityEngine;
using System.Collections.Generic;

public class InstantiationPanels : MonoBehaviour
{
    public TextAsset jsonFile;
    public StructsList myStructsList = new StructsList();
    public List<GameObject> AllPanels = new List<GameObject>();
    public int test;
    public GameObject myPrefab;
    void Start()
    {
        ReadJsonFile();
        for (int i = 0; i < myStructsList.structs.Length; i++)
        {


            //AllPanels.Add( );
            GameObject Panel = Instantiate(myPrefab, new Vector3(myStructsList.structs[i].coordinates[0], 0, myStructsList.structs[i].coordinates[1]), Quaternion.identity);
            Panel.GetComponent<PanelManager>().Structs = myStructsList.structs[i];
            Panel.GetComponent<PanelManager>().Angle = myStructsList.angle;



        }

    }
    void ReadJsonFile()
    {
        myStructsList = JsonUtility.FromJson<StructsList>(jsonFile.text);

        //Debug.Log(myStructsList.structs[2].id);
        //Debug.Log(myStructsList.structs[20].coordinates[1]);

    }
    

}