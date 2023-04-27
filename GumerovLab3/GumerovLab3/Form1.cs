using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GumerovLab3.Models;

namespace GumerovLab3
{
    public partial class Form1 : Form
    {
        // список точек
        public ListPoints Curr = new ListPoints();

        // список точек для рисования правой кнопкой мыши
        public ListPoints DrawLine = new ListPoints();

        // окно параметров
        private Params _window;
        private bool _pIsOpen;

        // флаг, отвечающий за "разрешение" добавить точки
        private bool _setPoint;
        
        // флаг, отвечающий за рисование правой кнопкой мыши
        private bool _isDrawRightButton;
        
        // переменные для хранения перетаскиваемой точки
        private Point _iPointToDrag; // перетаскиваемая точка
        private int _indexOfDrag = -1; // индекс точки в списке
        private bool _bDrag; // флаг, отвечающий за движение точки

        // переменные, отвечающие за периодическое выполнение метода сдвига
        private readonly Timer _moveTimer;
        private int _tick = 50;
        public bool Moving; // флаг, отвечающий за движение фигуры

        // границы рисоввания
        private readonly int _leftBorder;
        private readonly int _rightBorder;
        private readonly int _upBorder;
        private readonly int _downBorder;

        public Form1()
        {
            InitializeComponent();
            _iPointToDrag = new Point();
            DrawLine.R = 3;
            
            // события нажатия мыши
            MouseClick += DrawPoint;
            MouseDown += FixPoint;
            MouseMove += MovePoint;
            MouseMove += UpdateTextLocation;
            MouseUp += RelocationPoint;

            // событие нажатия клавиш
            KeyPreview = true;
            KeyDown += ControlKeys;
            
            // установка таймера
            _moveTimer = new Timer();
            _moveTimer.Interval = 1000; // 1000 - 1 секунда
            _moveTimer.Tick += MoveTickOneDirection;
            _moveTimer.Tick += MoveTickDiffDirection;

            // событие перерисовки
            Paint += MainDraw;
            _leftBorder = 110;
            _upBorder = 0;
            _rightBorder = ClientSize.Width;
            _downBorder = ClientSize.Height;
        }

        private void UpdateTextLocation(object sender, MouseEventArgs e) => TextCursore.Text = $@"(X: {e.X}; Y: {e.Y})";

        // перерисовка фигур и точек
        private void MainDraw(object sender, PaintEventArgs e)
        {
            DrawPanel(ref Curr, e);
            DrawPanel(ref DrawLine, e);
        }
        
        // рисование фигур
        private void DrawPanel(ref ListPoints figure, PaintEventArgs e)
        {
            var pens = new Pen(figure.ColorPoint);
            var brush = new SolidBrush(figure.ColorPoint);
            foreach (var point in figure.List)
            {
                e.Graphics.DrawEllipse(pens, point.X - figure.R, point.Y - figure.R, figure.R * 2, figure.R * 2);
                e.Graphics.FillEllipse(brush, point.X - figure.R, point.Y - figure.R, figure.R * 2, figure.R * 2);
            }

            pens.Color = figure.ColorSpline;
            brush.Color = figure.ColorSpline;
            if (figure.Polygon && figure.List.Count >= 2)
                e.Graphics.DrawPolygon(pens, figure.ToArray());
            else figure.Polygon = false;

            if (figure.Curve && figure.List.Count >= 3)
                e.Graphics.DrawClosedCurve(pens, figure.ToArray());
            else figure.Curve = false;

            if (figure.Beziers && figure.List.Count % 3 == 1)
                e.Graphics.DrawBeziers(pens, figure.ToArray());
            else figure.Beziers = false;

            if (figure.FillCurve && figure.List.Count >= 3)
                e.Graphics.FillClosedCurve(brush, figure.ToArray());
            else figure.FillCurve = false;
        }

        // событие движения в одном направлении
        private void MoveTickOneDirection(object sender, EventArgs e)
        {
            foreach (var t in DrawLine.List)
            {
                var point = new Point(t.X + DrawLine.Ox, t.Y + DrawLine.Oy);
                
                if (point.X - DrawLine.R <= _leftBorder || point.X + DrawLine.R >= _rightBorder)
                {
                    DrawLine.Ox *= -1;
                    return;
                }

                if (point.Y - DrawLine.R <= _upBorder || point.Y + DrawLine.R >= _downBorder)
                {
                    DrawLine.Oy *= -1;
                    return;
                }
            }

            MoveFigures(ref DrawLine, DrawLine.Ox, DrawLine.Oy);
            
            if (!Moving)
                _moveTimer.Stop();
        }

        // событие движение в разных направлениях
        private void MoveTickDiffDirection(object sender, EventArgs e)
        {
            var temp = new List<Point>();

            for (var i = 0; i < Curr.List.Count; i++)
            {
                var dx = Curr.Dirs[i].Item1;
                var dy = Curr.Dirs[i].Item2;
                var point = new Point(Curr.List[i].X + dx, Curr.List[i].Y + dy);
                
                if (point.X - Curr.R <= _leftBorder || point.X + Curr.R >= _rightBorder)
                {
                    Curr.Dirs[i] = (-dx, dy);
                    point.X -= dx;
                    point.Y -= dy;
                }

                if (point.Y - Curr.R <= _upBorder || point.Y + Curr.R >= _downBorder)
                {
                    Curr.Dirs[i] = (dx, -dy);
                    point.X -= dx;
                    point.Y -= dy;
                }

                temp.Add(point);
            }

            Curr.List = temp;
            Refresh();
            
            if (!Moving)
                _moveTimer.Stop();
        }
        
        // кнопка "Точки"
        private void Points_Click(object sender, EventArgs e)
        {
            // переключаем возможность добавлять точки
            if(Moving) return;
            _setPoint = !_setPoint;
            FillButton(Points, _setPoint);
        }

        // кнопка "Параметры"
        private void Params_Click(object sender, EventArgs e)
        {
            _pIsOpen = !_pIsOpen;
            if (_pIsOpen)
            {
                _window = new Params(this);
                _window.Show();
            }
            else
            {
                Curr.ColorPoint = _window.PrevColorP;
                Curr.ColorSpline = _window.PrevColorS;
                _window.Close();
                Refresh();
            }
            FillButton(ParamsBut, _pIsOpen);
        }

        // кнопка "Ломанная"
        private void Polyline_Click(object sender, EventArgs e)
        {
            if(Curr.List.Count < 2) return;
            Curr.Polygon = !Curr.Polygon;
            Refresh();            
            FillButton(Polyline, Curr.Polygon);
        }

        // кнопка "Кривая"
        private void Curve_Click(object sender, EventArgs e)
        {
            if(Curr.List.Count < 3) return;
            Curr.Curve = !Curr.Curve;
            Refresh();
            FillButton(Curve, Curr.Curve);
        }

        // кнопка "Бейзер"
        private void Beziers_Click(object sender, EventArgs e)
        {
            if (Curr.List.Count == 1 || Curr.List.Count % 3 != 1) return;
            Curr.Beziers = !Curr.Beziers;
            Refresh();
            FillButton(Beziers, Curr.Beziers);
        }

        // кнопка "Закрашенная"
        private void Painted_Click(object sender, EventArgs e)
        {
            if(Curr.List.Count < 3) return;
            Curr.FillCurve = !Curr.FillCurve;
            Refresh();
            FillButton(Painted, Curr.FillCurve);
        }
        
        // кнопка "Движение"
        private void Moves_Click(object sender, EventArgs e)
        {
            Moving = !Moving;
            FillButton(Moves, Moving);
            if (Moving)
            {
                _setPoint = false;
                FillButton(Points, _setPoint);
            }
            
            if(!Moving) return;
            
            var rndDir = new[] { -Curr.R, 0, Curr.R };
            var rnd = new Random();

            #region DiffDirection_CurrentFigure
            Curr.Dirs = new (int, int)[Curr.List.Count];

            for (int i = 0; i < Curr.Dirs.Length; i++)
            {
                while (Curr.Dirs[i].Item1 == 0 && Curr.Dirs[i].Item2 == 0)
                    Curr.Dirs[i] = (rndDir[rnd.Next(0, 3)], rndDir[rnd.Next(0, 3)]);
            }
            #endregion

            #region OneDirection_DrawLine
            DrawLine.Ox = DrawLine.Oy = 0;

            while (DrawLine.Ox == 0 && DrawLine.Oy == 0)
            {
                DrawLine.Ox = rndDir[rnd.Next(0, 3)];
                DrawLine.Oy = rndDir[rnd.Next(0, 3)];
            }
            #endregion
            _moveTimer.Start();
        }

        // кнопка "Очистить"
        private void Clear_Click(object sender, EventArgs e)
        {
            // очищаем список точек
            Curr.Clear();
            DrawLine.Clear();
            Moving = false;
            if (_pIsOpen)
            {
                _pIsOpen = false;
                _window.Close();
            }
            
            Refresh();
            UpdateButton();
        }

        // метод покраски кнопок
        private void FillButton(Button button, bool flag)
        {
            button.BackColor = flag ? Color.Green : Color.Red;
        }

        // общий метод покраски для всех кнопок
        private void UpdateButton()
        {
            FillButton(Points, _setPoint);
            FillButton(Polyline, Curr.Polygon);
            FillButton(Curve, Curr.Curve);
            FillButton(Beziers, Curr.Beziers);
            FillButton(Painted, Curr.FillCurve);
            FillButton(Moves, Moving);
            FillButton(ParamsBut, _pIsOpen);
        }
        
        // событие MouseClick
        private void DrawPoint(object sender, MouseEventArgs e)
        {
            // если стоит запрет на добавление точек или происходит перетаскивание точки, то выходим из метода
            if (_setPoint == false || _bDrag || Moving) return;
            
            if (e.Button == MouseButtons.Right)
                return;

            if (StepOutMap(e.Location, Curr.R)) return;
            
            // если новая точка пересекается с уже существующей, то не добавляем
            if (Curr.List.Any(point => e.X >= point.X - Curr.R * 2 && e.X <= point.X + Curr.R * 2
                                                                    && e.Y >= point.Y - Curr.R * 2 &&
                                                                    e.Y <= point.Y + Curr.R * 2))
                return;

            // добавляем точку в список
            Curr.List.Add(e.Location);
            
            Refresh();
            UpdateButton();
        }

        // событие MouseDown
        private void FixPoint(object sender, MouseEventArgs e)
        {
            if(Moving) return;
            
            if (e.Button == MouseButtons.Right && _setPoint)
            {
                _isDrawRightButton = true;
                return;
            }

            for (var i = 0; i < Curr.List.Count; i++)
            {
                var point = Curr.List[i];
                
                // если курсор попал в окрестности какой-либо точки
                if (e.X >= point.X - Curr.R && e.X <= point.X + Curr.R
                                                      && e.Y >= point.Y - Curr.R &&
                                                      e.Y <= point.Y + Curr.R)
                {
                    // запоминаем точку и выходим из метода
                    _bDrag = true;
                    _iPointToDrag = point;
                    _indexOfDrag = i;
                    return;
                }
            }
        }
        
        // событие MouseMove
        private void MovePoint(object sender, MouseEventArgs e)
        {
            // если новое положение точки пересекается с какой-либо, выходим из метода
            if (Curr.List.Any(point => e.X >= point.X - Curr.R * 2 && e.X <= point.X + Curr.R * 2
                                                                        && e.Y >= point.Y - Curr.R * 2 &&
                                                                        e.Y <= point.Y + Curr.R * 2))
                return;
            
            if (_isDrawRightButton && !StepOutMap(e.Location, DrawLine.R))
            {
                DrawLine.List.Add(e.Location);
                Refresh();
                return;
            }

            // если флаг передвижения не активен или мы достигли границы окна, выходим из метода
            if(!_bDrag || StepOutMap(e.Location, Curr.R)) return;

            // переопределяем значение перетаскиваемой точки
            _iPointToDrag = e.Location;
            Curr.List[_indexOfDrag] = e.Location;
            Refresh();
        }
        
        // событие MouseCup
        private void RelocationPoint(object sender, MouseEventArgs e)
        {
            if (_isDrawRightButton)
            {
                _isDrawRightButton = false;
                Refresh();
                return;
            }
            
            if(!_bDrag) return;

            // обновляем положение точки в списке
            Curr.List[_indexOfDrag] = _iPointToDrag;
            _indexOfDrag = -1; // сбрасываем индекс перетаскиваемой точки
            _bDrag = false; // сбрасываем флаг перетаскивания
            Refresh();
            UpdateButton();
        }
        
        // событие KeyDown
        private void ControlKeys(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Clear_Click(sender, e);
                    break;
                
                case Keys.Space:
                    Moves_Click(sender, e);
                    break;
                
                case Keys.Add:
                    if (_moveTimer.Interval - _tick > 0)
                        _moveTimer.Interval -= _tick;
                    break;
                
                case Keys.Subtract:
                    _moveTimer.Interval += _tick;
                    break;
            }
            
            e.Handled = true;
        }

        // событие KeyDown для стрелок
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Moving) return false;

            switch (keyData)
            {
                case Keys.Left:
                    MoveFigures(ref Curr, -Curr.R, 0);
                    break;
                
                case Keys.Right:
                    MoveFigures(ref Curr, Curr.R, 0);
                    break;
                
                case Keys.Up:
                    MoveFigures(ref Curr, 0, -Curr.R);
                    break;
                
                case Keys.Down:
                    MoveFigures(ref Curr, 0, Curr.R);
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // метод проверки выхода за границы
        private bool StepOutMap(Point point, int r)
        {
            return point.X - r <= _leftBorder || point.Y - r <= _upBorder || point.X + r >= _rightBorder ||
                   point.Y + r >= _downBorder;
        }
        
        // метод движения фигур
        private void MoveFigures(ref ListPoints figure, int x, int y)
        {
            var temp = new List<Point>();
            
            foreach (var point in figure.List.Select(t => new Point(t.X + x, t.Y + y)))
            {
                if(StepOutMap(point, figure.R))
                    return;
                        
                temp.Add(point);
            }

            figure.List = temp;
            Refresh();
        }
    }
}