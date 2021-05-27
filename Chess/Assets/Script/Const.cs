using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const : MonoBehaviour {

	public int [,] Pawn = {}; //1
    public int [,] King = {}; //2
    public int [,] Advisor = {}; //3
    public int[,] Elephant = { };//4
    public int[,] Horse = { };//5
    public int[,] Rook = { }; //6
    public int[,] Cannon = { }; //7
    public int ValueState(int[,] state, bool maximizingPlayer)
    {
        var val = 0;
        // quân đen
        if (maximizingPlayer)
        {
            for(int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++ )
                {
                    
                    if (state[i,j] == 8)
                    {
                        val = val + Pawn[10 - i,10 - j];
                    }
                    if (state[i, j] == 9)
                    {
                        val = val + King[10 - i, 10 - j];
                    }
                    if (state[i, j] == 10)
                    {
                        val = val + Advisor[10 - i, 10 - j];
                    }
                    if (state[i, j] == 11)
                    {
                        val = val + Elephant[10 - i, 10 - j];
                    }
                    if (state[i, j] == 12)
                    {
                        val = val + Horse[10 - i, 10 - j];
                    }
                    if (state[i, j] == 13)
                    {
                        val = val + Rook[10 - i, 10 - j];
                    }
                    if (state[i, j] == 14)
                    {
                        val = val + Cannon[10 - i, 10 - j];
                    }
                }
            }
        }
        else // quân đỏ
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {

                    if (state[i, j] == 1)
                    {
                        val = val + Pawn[i,j];
                    }
                    if (state[i, j] == 2)
                    {
                        val = val + King[i, j];
                    }
                    if (state[i, j] == 3)
                    {
                        val = val + Advisor[i, j];
                    }
                    if (state[i, j] == 4)
                    {
                        val = val + Elephant[i, j];
                    }
                    if (state[i, j] == 5)
                    {
                        val = val + Horse[i, j];
                    }
                    if (state[i, j] == 6)
                    {
                        val = val + Rook[i, j];
                    }
                    if (state[i, j] == 7)
                    {
                        val = val + Cannon[i, j];
                    }
                }
            }
        }

        return val;
    }
}
