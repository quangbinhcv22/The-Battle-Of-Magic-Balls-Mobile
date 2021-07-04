using System;

[Serializable]
public class MoveSpeed
{
    private float start;
    private float perLevel;
    private float current;
    private float temporary;


    public float Start
    {
        get
        {
            return start;
        }

        set
        {
            if (value < 0)
            {
                start = 0;
            }
            else
            {
                start = value;
            }
        }
    }

    public float PerLevel
    {
        get
        {
            return perLevel;
        }

        set
        {
            if (value < 0)
            {
                perLevel = 0;
            }
            else
            {
                perLevel = value;
            }
        }
    }

    public float Current
    {
        get
        {
            return current;
        }

        set
        {
            if (value < 0)
            {
                current = 0;
            }
            else
            {
                current = value;
            }
        }
    }

    public float Temporary
    {
        get
        {
            return temporary;
        }

        set
        {
            temporary = value;
        }
    }
}
