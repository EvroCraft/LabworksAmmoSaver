﻿using Labworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Labworks.Utilities
{
    public class SaveParsing
    {
        /// <summary>
        /// Returns true if the save point is not 0, 0, 0 and has a level barcode.
        /// </summary>
        /// <param name="savePoint"></param>
        /// <returns></returns>
        public static bool IsSavePointValid(LabworksSaving.SavePoint savePoint, out bool hasSpawnPoint)
        {
            if (new Vector3(savePoint.PositionX, savePoint.PositionY, savePoint.PositionZ) == Vector3.zero)
                hasSpawnPoint = false;
            else
                hasSpawnPoint = true;

            if (savePoint.LevelBarcode == string.Empty)
                return false;

            return true;
        }

        public static bool DoesSavedAmmoExist(string levelBarcode)
        {
            if (LabworksSaving.LoadedAmmoSaves == null)
                return false;

            if (LabworksSaving.LoadedAmmoSaves.Count == 0)
                return false;

            if (LabworksSaving.LoadedAmmoSaves.Any(x => x.LevelBarcode == levelBarcode))
                return true;

            return false;
        }

        public static LabworksSaving.AmmoSave GetSavedAmmo(string levelBarcode)
        {
            return LabworksSaving.LoadedAmmoSaves.FirstOrDefault(x => x.LevelBarcode == levelBarcode);
        }
    }
}
