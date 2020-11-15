using Microsoft.Msagl.Core.Layout;

namespace Blazor.Diagrams.Core.Layout
{
    public interface ILayoutCalculator
    {
        LayoutAlgorithmSettings LayoutAlgorithmSettings { get; }
        void CalculateLayout(GeometryGraph geometryGraph);
    }
}