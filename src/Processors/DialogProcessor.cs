using Draw.src.Model;
using Newtonsoft.Json;
using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Shape = Draw.src.Model.Shape;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {
        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Избран елемент.
        /// </summary>
        private List<Shape> selection = new List<Shape>();
        public List<Shape> Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        #region Drawing Shapes
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleShape shape = new RectangleShape(new Rectangle(x, y, 100, 200));
            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
        }

        /// <summary>
        /// Добавя примитив - на мястото на мишката върху клиентската област.
        /// </summary>
        public Shape AddRectangle(Point point, Size size, string name)
        {
            RectangleShape shape = new RectangleShape(new Rectangle(point, size));
            shape.Name = name;

            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
            return shape;
        }

        /// <summary>
        /// Добавя примитив - елипса на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape shape = new EllipseShape(new Rectangle(x, y, 100, 200));
            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
        }
        /// <summary>
        /// Добавя примитив - на мястото на мишката върху клиентската област.
        /// </summary>
        public Shape AddEllipse(Point point, Size size, string name)
        {
            EllipseShape shape = new EllipseShape(new Rectangle(point, size));
            shape.Name = name;

            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
            return shape;
        }

        /// <summary>
        /// Добавя примитив - триъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TriangleShape shape = new TriangleShape(new Rectangle(x, y, 100, 200));
            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
        }

        /// <summary>
        /// Добавя примитив - на мястото на мишката върху клиентската област.
        /// </summary>
        public Shape AddTriangle(Point point, Size size, string name)
        {
            TriangleShape shape = new TriangleShape(new Rectangle(point, size));
            shape.Name = name;

            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
            return shape;
        }

        public NewShape AddRandomNewShape()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            NewShape shape = new NewShape(new Rectangle(x, y, 200, 150));
            shape.Name = "test";

            shape.FillColor = Color.White;
            shape.OutlineColor = Color.Black;
            shape.Opacity = 255;
            shape.OutlineWidth = 1;

            ShapeList.Add(shape);
            return shape;
        }
        #endregion

        public GroupShape MakeGroup()
        {
            GroupShape group = new GroupShape(Selection);

            group.Name = "group";
            group.NameColor = Color.Purple;

            group.FillColor = Color.White;
            group.OutlineColor = Color.Black;
            group.Opacity = 255;
            group.OutlineWidth = 1;
            Selection.ForEach(x => x.NameColor = Color.Black);
            Selection.ForEach(x => ShapeList.Remove(x));
            Selection = new List<Shape>();

            ShapeList.Add(group);
            return group;
        }

        public List<GroupShape> Ungroup()
        {
            var groups = new List<GroupShape>();
            foreach (var shape in Selection)
            {
                if (shape is GroupShape)
                {
                    var group = shape as GroupShape;
                    groups.Add(group);
                    group.OutlineColor = Color.Black;
                    group.Shapes.ForEach(x => ShapeList.Add(x));
                    ShapeList.Remove(group);
                }
            }
            Selection = Selection.Intersect(ShapeList).ToList();
            return groups;
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {
                    //ShapeList[i].FillColor = Color.Red;

                    return ShapeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p">p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selection.Count != 0)
            {
                var points = new PointF[] { p };
                foreach (Shape shape in selection)
                {
                    if (shape is GroupShape)
                    {
                        var group = shape as GroupShape;
                        foreach (var groupShape in group.Shapes)
                        {
                            //groupShape.Matrix.TransformPoints(points);
                            groupShape.Location = new PointF(groupShape.Location.X + points[0].X - lastLocation.X, groupShape.Location.Y + points[0].Y - lastLocation.Y);
                            groupShape.NameLocation = new PointF(groupShape.Location.X, groupShape.Location.Y - 10);
                        }
                    }
                    else
                    {
                        //shape.Matrix.TransformPoints(points);
                        shape.Location = new PointF(shape.Location.X + points[0].X - lastLocation.X, shape.Location.Y + points[0].Y - lastLocation.Y);
                        shape.NameLocation = new PointF(shape.Location.X, shape.Location.Y - 10);
                    }
                }
                lastLocation = points[0];
            }
        }
        public void Rotate(float angle)
        {
            if (selection.Count != 0)
            {
                foreach (Shape shape in selection)
                {
                    //shape.Matrix.Rotate(angle/*, shape.Center */);
                    shape.Rotation += angle;
                }
            }
        }
        public void Scale(float scaleX, float scaleY)
        {
            if (selection.Count != 0)
            {
                foreach (Shape shape in selection)
                {
                    shape.Scale(scaleX, scaleY);
                }
            }
        }

        public List<Shape> DeleteSelection()
        {
            if (selection.Count != 0)
            {
                foreach (Shape shape in selection)
                {
                    ShapeList.Remove(shape);
                }
            }
            return selection;
        }
        #region Load, Save and Export
        public string Save()
        {
            return JsonConvert.SerializeObject(ShapeList, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
        }

        public string Copy(Point mouse)
        {
            var shapes = new List<Shape>();
            for (int i = 0; i < ShapeList.Count; i++)
            {
                if (ShapeList[i].Contains(mouse))
                {
                    shapes.Add(ShapeList[i]);
                    return JsonConvert.SerializeObject(shapes, typeof(List<Shape>), Formatting.Indented, new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.All,
                    });
                }
            }
            return null;
        }

        public string CopySelection()
        {
            return JsonConvert.SerializeObject(selection, typeof(Shape), Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
        }

        public List<Shape> Load(string json)
        {
            var list = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            foreach (var shape in list)
            {
                shape.NameColor = Color.Black;
                if (shape is RectangleShape)
                {
                    ShapeList.Add(shape as RectangleShape);
                }
                if (shape is TriangleShape)
                {
                    ShapeList.Add(shape as TriangleShape);
                }
                if (shape is EllipseShape)
                {
                    ShapeList.Add(shape as EllipseShape);
                }
                if (shape is GroupShape)
                {
                    ShapeList.Add(shape as GroupShape);
                }
            }
            return list;
        }

        public List<Shape> Paste(string json, int x, int y)
        {
            var shapes = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            });
            foreach (var shape in shapes)
            {
                shape.Location = new Point(x, y);
                if (shape is RectangleShape)
                {
                    ShapeList.Add(shape as RectangleShape);
                }
                if (shape is TriangleShape)
                {
                    ShapeList.Add(shape as TriangleShape);
                }
                if (shape is EllipseShape)
                {
                    ShapeList.Add(shape as EllipseShape);
                }
                if (shape is GroupShape)
                {
                    ShapeList.Add(shape as GroupShape);
                }
            }
            return shapes;
        }
        private IEnumerable<SvgPathBasedElement> ConvertElements(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                var transformations = new SvgTransformCollection
                {
                    new SvgRotate(shape.Rotation)
                };
                if (shape is RectangleShape)
                {
                    var rectangle = new SvgRectangle()
                    {
                        Height = shape.Height,
                        Width = shape.Width,
                        Transforms = transformations,
                        Opacity = shape.Opacity / 255,
                        X = new SvgUnit(SvgUnitType.Pixel, shape.Location.X),
                        Y = new SvgUnit(SvgUnitType.Pixel, shape.Location.Y),
                        Fill = new SvgColourServer(shape.FillColor),
                        Color = new SvgColourServer(shape.FillColor),
                        Stroke = new SvgColourServer(shape.OutlineColor),
                        StrokeWidth = new SvgUnit(SvgUnitType.Pixel, shape.OutlineWidth)
                    };
                    yield return rectangle;
                }
                if (shape is EllipseShape)
                {
                    var ellipse = new SvgEllipse()
                    {
                        CenterX = new SvgUnit(SvgUnitType.Pixel, shape.Location.X + shape.Width / 2),
                        CenterY = new SvgUnit(SvgUnitType.Pixel, shape.Location.Y + shape.Height / 2),
                        RadiusX = new SvgUnit(SvgUnitType.Pixel, shape.Width / 2),
                        RadiusY = new SvgUnit(SvgUnitType.Pixel, shape.Height / 2),
                        Transforms = transformations,
                        Opacity = shape.Opacity / 255,
                        FillRule = SvgFillRule.NonZero,
                        Fill = new SvgColourServer(shape.FillColor),
                        Color = new SvgColourServer(shape.FillColor),
                        Stroke = new SvgColourServer(shape.OutlineColor),
                        StrokeWidth = new SvgUnit(SvgUnitType.Pixel, shape.OutlineWidth)
                    };
                    yield return ellipse;
                }
                if (shape is TriangleShape)
                {
                    var triangle = new SvgPolygon()
                    {
                        Points = new SvgPointCollection()
                        {
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.X),
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.Y),
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.X),
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.Y + shape.Height),
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.X + shape.Width),
                            new SvgUnit(SvgUnitType.Pixel, shape.Location.Y + shape.Height),
                        },
                        Transforms = transformations,
                        Opacity = shape.Opacity / 255,
                        FillRule = SvgFillRule.NonZero,
                        Fill = new SvgColourServer(shape.FillColor),
                        Color = new SvgColourServer(shape.FillColor),
                        Stroke = new SvgColourServer(shape.OutlineColor),
                        StrokeWidth = new SvgUnit(SvgUnitType.Pixel, shape.OutlineWidth)
                    };
                    yield return triangle;
                }
                if (shape is GroupShape)
                {
                    var group = shape as GroupShape;
                    foreach (var svgShape in ConvertElements(group.Shapes))
                    {
                        yield return svgShape;
                    }
                }
            }
        }
        public SvgDocument ExportSvg(float width, float height)
        {
            SvgDocument svg = new SvgDocument();
            svg.Width = new SvgUnit(SvgUnitType.Pixel, width);
            svg.Height = new SvgUnit(SvgUnitType.Pixel, height);
            foreach (var shape in ConvertElements(ShapeList))
            {
                svg.Children.Add(shape);
            }

            return svg;
        }

        #endregion
    }
}
