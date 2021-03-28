using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects", order = 1)]
[System.Serializable]
public class StartPosConfig : ScriptableObject {
    public int PosX;
    public int[] PosY;
    public ChessName Name;
}
