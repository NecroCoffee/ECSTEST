using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellData
{
    NONE=0,

    WHITE_PAWN=1,
    WHITE_ARCHER=2,
    WHITE_CAVALRY=3,
    WHITE_TREBUCHET=4,

    BLACK_PAWN=5,
    BLACK_ARCHER=6,
    BLACK_CAVALRY=7,
    BLACK_TREBUCHET=8,
}

public class TrebuchetData
{
    
}

public class TrebuchetSystem : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;

    private int cellWidth = 15;
    private int cellHeight = 15;

    [SerializeField] public int[,] cellDatas;

    
    private void Awake()
    {
        
        InitCell();
    }

    void InitCell()
    {
        cellDatas = new int[cellWidth, cellHeight];


        for (int i = 0; i < cellWidth;i++)
        {
            for (int j = 0; j < cellHeight;j++)
            {
                cellDatas[i, j] = (int)CellData.NONE;
                Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity, this.gameObject.transform);
            }
        }
    }
}
