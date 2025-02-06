using UnityEngine;
using System.Collections.Generic;

namespace Dollars
{
  public class FaceCapResult : MonoBehaviour
  {
    public Dictionary<string, float> values = new Dictionary<string, float>();

    public void Start()
    {
      for (var i = 0; i < LiveLinkTrackingData.Names.Length; i++)
      {
        values.Add(LiveLinkTrackingData.Names[i], 0f);
      }
    }
  }
}
