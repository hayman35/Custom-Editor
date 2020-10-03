using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName="New Rouge Data", menuName="Character Data/Rouge")]
public class RougeData : CharacterData
{
   public RougeWpnType wpnType;
   public RougeStrategyType strategyType;
}
