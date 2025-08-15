using UnityEngine;

public class MathGame
{
    public static int PlusOrMinus(float x)
    {
        if (x > 0)
        {
            return 1;
        }
        if (x < 0)
        {
            return -1;
        }
        return 0;
    }
}