using Unity.VisualScripting;
using UnityEngine;

public class PlayerAmountManager : MonoBehaviour
{
    [SerializeField] private int[] BaseAmount = new int[3];
    [SerializeField] private Vector2Int[] Inventory = new Vector2Int[3]; // x : số đạn hiện tại, y : số băng đạn hiện tại

    private void Start()
    {
        BaseAmount[0] = 30;
        BaseAmount[1] = 7;
        BaseAmount[2] = 7;
        for(int i = 0; i < BaseAmount.Length; i++)
        {
            Inventory[i] = new Vector2Int(BaseAmount[i], 4);
        }
    }

    private void Update()
    {
        if (Inventory[(int)ChoiceGun.currGun].x == 0)
        {
            PlayerShootingState.state = PlayerState.NoShot;
        }
        else if(Inventory[(int)ChoiceGun.currGun].x != 0 && PlayerShootingState.state == PlayerState.NoShot)
        {
            PlayerShootingState.state = PlayerState.Shoot;
        }
    }
    
    public void IncAmount()
    {
        Inventory[(int)ChoiceGun.currGun].x--;
    }

    
}
