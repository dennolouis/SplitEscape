using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] levelScores = new int[5];
    public List<int> scoresList = new List<int>();
    public int adCount = 0;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1
    
}
