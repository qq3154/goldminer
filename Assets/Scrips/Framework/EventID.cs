using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventID
{
	None = 0,
	OnHookRotate,
	OnHookShoot,
	OnHookRewind,
	OnHookFail,
	OnUseBomb,			
	OnGrabItem,	
	OnScore,
	OnBuyItem,
	OnLevelEnd,
}