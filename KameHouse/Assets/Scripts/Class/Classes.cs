using UnityEngine;

[CreateAssetMenu(menuName = "Classes/Nouvelle classe", order = 0, fileName = "new class")]
public class Classes : ScriptableObject
{
   public string className;
   public ClassType classType;
   public enum ClassType { Physic, Magic }
   
   
   
}
