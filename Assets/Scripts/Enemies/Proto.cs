using System.Linq;
using Random = UnityEngine.Random;

public class Proto : Enemy
{
    public override void Start()
    {
        
        for (int i = 0; i < GameplayManager.Instance.seedsbox.Length; i++)
        {
            
        }
        base.Start();
    }

    public override void Update() //Overriding the Update of Enemy class to change the target function
    {

        base.Update();
    }
}
