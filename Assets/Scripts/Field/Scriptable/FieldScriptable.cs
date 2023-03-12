using UnityEngine;

[CreateAssetMenu(fileName = "FieldData", menuName = "Field/Field Scriptable")]

public class FieldScriptable : ScriptableObject{

    public Vector2 MapSize;
    
    public Vector2 CellSize;

    public Vector2 CellDistance;

    public PlantScriptable PlantData;

    public FieldCell CellPrefab;
    public GameObject PickUpPrefab;

    public Vector3 StartPos{
        get{
            return new Vector3(
            -((CellSize.x * MapSize.x) + ( (MapSize.x-1) * CellDistance.x ))/2 + CellSize.x/2,
            0,
            -((CellSize.y * MapSize.y) + ( (MapSize.y-1) * CellDistance.y ))/2 + CellSize.y/2
            );
        }
    }
    public Vector3 GetPosition(float x, float y){
        return new Vector3(
            CellSize.x * x + CellDistance.x * x ,
            0,
            CellSize.y * y + CellDistance.y * y
        );
    }


    
}
