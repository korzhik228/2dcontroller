using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskUtil 
{
  public static bool LayerMaskContainsLayer(
      LayerMask layerMask, int layer)
    {
        if (layerMask == (layerMask | 1 << layer))
                return true;
        return false;
    }
}
