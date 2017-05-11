using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStat {
	float getStat ();
	float increaseStat(float increaseAmount);
	float decreaseStat(float decreaseAmount);
}
