using Game___Capture.model.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game___Capture.util
{
    public static class IntersectionCheck
    {
        public static bool IsIntersected(Segment segment1, Segment segment2)
        {
            int o1 = PointRelativePosition(segment1, segment2.Start);
            int o2 = PointRelativePosition(segment1, segment2.End);
            int o3 = PointRelativePosition(segment2, segment1.Start);
            int o4 = PointRelativePosition(segment2, segment1.End);

            if (o1 != o2 && o3 != o4)
                return true;
            if (o1 == 0 && IsPointInSegmentArea(segment1, segment2.Start))
                return true;
            if (o2 == 0 && IsPointInSegmentArea(segment1, segment2.End))
                return true;
            if (o3 == 0 && IsPointInSegmentArea(segment2, segment1.Start))
                return true;
            if (o4 == 0 && IsPointInSegmentArea(segment2, segment1.End))
                return true;

            return false;
        }

        public static Point GetPointOfIntersection(Segment AB, Segment CD)
        {
            Point A = AB.Start;
            Point B = AB.End;
            Point C = CD.Start;
            Point D = CD.End;

            //Scalar product of AB & AC
            double Z1 = (B.X - A.X) * (C.X - A.X) + (B.Y - A.Y) * (C.Y - A.Y);

            //Scalar product of AB & AD
            double Z2 = (B.X - A.X) * (D.X - A.X) + (B.Y - A.Y) * (D.Y - A.Y);

            double Px = C.X + (D.X - C.X) * Math.Abs(Z1) / Math.Abs(Z2 - Z1);
            double Py = C.Y + (D.Y - C.Y) * Math.Abs(Z1) / Math.Abs(Z2 - Z1);

            return new Point(Px, Py);
        }

        private static int PointRelativePosition(Segment segment, Point point)
        {
            double val = (segment.End.Y - segment.Start.Y) * (point.X - segment.End.X) - (segment.End.X - segment.Start.X) * (point.Y - segment.End.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private static double Min(params double[] values)
        {
            return values.Min();
        }

        private static double Max(params double[] values)
        {
            return values.Max();
        }

        private static bool IsPointInSegmentArea(Segment segment, Point point)
        {
            return point.X <= Max(segment.Start.X, segment.End.X) &&
                point.X >= Min(segment.Start.X, segment.End.X) &&
                point.Y <= Max(segment.Start.Y, segment.End.Y) &&
                point.Y >= Min(segment.Start.Y, segment.End.Y);
        }
    }
}
