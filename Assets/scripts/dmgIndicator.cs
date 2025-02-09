
using JetBrains.Annotations;
using UnityEngine;

public class dmgIndicator : MonoBehaviour
{
    public static dmgIndicator instance;
    public GameObject damageText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void DisplayDamage(int damage, Vector3 position)
    {
        var obj = Instantiate(damageText, position, Quaternion.identity);

        obj.GetComponent<DmgText>().ChangeText(damage);
    }
}
