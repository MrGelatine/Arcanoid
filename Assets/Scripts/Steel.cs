using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : BonusBase
{
    PlayerScript playerObj;
    BallScript BallObj;

    public override void BonusActivate()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerObj.force = 40;

        BallObj = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();

        var balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            var BallSprite = ball.GetComponent<SpriteRenderer>();
            BallSprite.color = Color.gray;
        }
    }
}
