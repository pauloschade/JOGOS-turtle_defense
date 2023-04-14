using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TankTowerSelector : TowerSelector
{
  protected override Vector3Int[] GetCellPositions(Vector3Int cellPosition)
  {
    return new Vector3Int[] { cellPosition, cellPosition + Vector3Int.right };
  }
}