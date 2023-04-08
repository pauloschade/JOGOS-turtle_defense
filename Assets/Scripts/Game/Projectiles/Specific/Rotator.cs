using UnityEngine;

public class Rotator : Projectile
{
    public Transform spriteImg;
    //speed
    public float rotateSpeed;
    //Handle rotation and flying
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Rotate();
    }
    void Rotate()
    {
        spriteImg.Rotate(new Vector3(0,0,-rotateSpeed*Time.deltaTime));
    }

}