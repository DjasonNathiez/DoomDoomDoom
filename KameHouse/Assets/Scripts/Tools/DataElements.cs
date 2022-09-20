using System;

[Serializable] public class DataElements
{ 
    public int endurance;
    public int force;
    public int agility;
    public int intellect;
}

[Serializable] public class SecondaryDataElements
{
    public SecondaryData secondaryData;
    public int value;
    public enum SecondaryData
    {
        Mastery,
        CriticalStrike,
        Versatility,
        Haste
    }
}


