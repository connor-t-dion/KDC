using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public int MapSize = 30;
    public GameObject Block;
    public GameObject Hole;
    private GameObject[,] BaseMap;

    // Start is called before the first frame update
    void Start()
    {
        //we create 3 matrices that span the board. The first entry (0,0) represents
        //the most forward corner of the map. That is designated as "the point of origin
        BaseMap = new GameObject[MapSize, MapSize];

        //here we just generate the ground, all regular blocks, nothing fancy
        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                //initialize at a height of 1 
                Vector3 pos = new Vector3(i*2.4f, 0, j*2.4f);
                BaseMap[i, j] = Instantiate(Block, pos, Quaternion.identity);
            }
        }

        //this special bit of code allows us to randomly replace one of those blocks with the hole.
        int pos_x = (int) Random.Range(1f, MapSize - 1);
        int pos_y = (int) Random.Range(1f, MapSize - 1);

        Vector3 pos2 = new Vector3(pos_x*2.4f-.03f, 1.1f, pos_y*2.4f+1.28f);
        Destroy(BaseMap[pos_x, pos_y]);
        BaseMap[pos_x, pos_y] = Instantiate(Hole, pos2, Quaternion.identity);
        BaseMap[pos_x, pos_y].transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
