using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Miscellaneous;

namespace Blazor.Diagrams.Core.Layout
{
    public class SugiyamaLayoutCalculator : ILayoutCalculator
    {
        public LayoutAlgorithmSettings LayoutAlgorithmSettings =>
            new SugiyamaLayoutSettings()
            {
                NodeSeparation = 30,
                Transformation = PlaneTransformation.Rotation(Math.PI / 2),
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.SugiyamaSplines }
            };

        public void CalculateLayout(GeometryGraph geometryGraph)
        {
            LayoutHelpers.CalculateLayout(geometryGraph, LayoutAlgorithmSettings, null);
        }
    }
}
