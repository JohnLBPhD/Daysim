﻿using DaySim.Framework.ChoiceModels;
using DaySim.Framework.Core;
using DaySim.Framework.DomainModels.Wrappers;

namespace DaySim.ChoiceModels.Default.Models {
    class PSRC_WorkTourModeModel : WorkTourModeModel {
        protected override void RegionSpecificCustomizations(ChoiceProbabilityCalculator.Alternative alternative, ITourWrapper tour, int pathType, int mode)
        {
            //Global.PrintFile.WriteLine("Default PSRC_WorkTourModeModel.RegionSpecificCustomizations called");

            if (mode == Global.Settings.Modes.Transit && pathType != Global.Settings.PathTypes.LightRail && pathType != Global.Settings.PathTypes.CommuterRail && pathType != Global.Settings.PathTypes.Ferry){

                           alternative.AddUtilityTerm(200 + tour.OriginParcel.District, 1);//district specific transit calibration constant
                           alternative.AddUtilityTerm(300 + tour.DestinationParcel.District, 1);//district specific transit calibration constant
            }


        }
    }
}
