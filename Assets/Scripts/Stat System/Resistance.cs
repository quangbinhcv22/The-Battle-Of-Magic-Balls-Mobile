using System;

[Serializable]
public class Resistance
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
            if (value < 0f)
            {
                start = 0f;
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
            if (value < 0f)
            {
                perLevel = 0f;
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
            if (value > 1f)
            {
                current = 1f;
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

