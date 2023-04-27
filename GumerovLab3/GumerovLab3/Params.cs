using System;
using System.Drawing;
using System.Windows.Forms;

namespace GumerovLab3;

public partial class Params : Form
{
    private readonly Form1 _main;

    // флаги активной смены цвета
    private bool _changeP;
    private bool _changeS;

    // поля для запоминания предыдущего цвета
    public Color PrevColorP;
    public Color PrevColorS;

    // погрешность размера изображения во избежание исключения
    private const int Err = 4;

    public Params(Form1 main)
    {
        InitializeComponent();
        _main = main;
        PrevColorP = main.Curr.ColorPoint;
        PrevColorS = main.Curr.ColorSpline;

        ImageP.MouseDown += MouseDownPoint;
        ImageP.MouseMove += MouseMovePoint;
        ImageP.MouseUp += MouseUpPoint;
        
        ImageS.MouseDown += MouseDownSpline;
        ImageS.MouseMove += MouseMoveSpline;
        ImageS.MouseUp += MouseUpSpline;
    }

    // событие нажатия на мышка для PictureBox линии
    private void MouseDownSpline(object sender, MouseEventArgs e)
    {
        // меняем флаг на ture
        _changeS = true;
        
        // попытка смены цвета
        if(!TrySetColor(ImageS, e.Location, out var color)) return;
        _main.Curr.ColorSpline = color; // обновляем цвет рисунка
        
        if (!_main.Moving)
            _main.Refresh();
    }

    // событие движения мышки для PictureBox линии
    private void MouseMoveSpline(object sender, MouseEventArgs e)
    {
        if(!_changeS || !TrySetColor(ImageS, e.Location, out var color)) return;
        _main.Curr.ColorSpline = color;
        
        if (!_main.Moving)
            _main.Refresh();
    }

    // событие отпускания клавиши мышки для PictureBox линии
    private void MouseUpSpline(object sender, MouseEventArgs e)
    {
        // сбрасываем флаг
        _changeS = false;
    }

    // событие нажатия на мышка для PictureBox точки
    private void MouseDownPoint(object sender, MouseEventArgs e)
    {
        _changeP = true;
        
        if(!TrySetColor(ImageP, e.Location, out var color)) return;
        _main.Curr.ColorPoint = color;
        
        if (!_main.Moving)
            _main.Refresh();
    }

    // событие движения мышки для PictureBox точки
    private void MouseMovePoint(object sender, MouseEventArgs e)
    {
        if(!_changeP || !TrySetColor(ImageP, e.Location, out var color)) return;
        _main.Curr.ColorPoint = color;
        
        if (!_main.Moving)
            _main.Refresh();
    }

    // событие отпускания клавиши мышки для PictureBox точки
    private void MouseUpPoint(object sender, MouseEventArgs e)
    {
        _changeP = false;
    }

    // метод установки цвета при наведении на картинку
    private bool TrySetColor(PictureBox image, Point e, out Color color)
    {
        color = default;
        // находим центр изображения
        var axic = image.Width / 2;
        // высчитываем радиус круга изображения
        var r = (image.Width - Err) / 2;

        // если курсор вышел за пределы круга изображения, возвращаем defualt значение
        if ((e.X - axic) * (e.X - axic) + (e.Y - axic) * (e.Y - axic) > r * r)
            return false;
        
        // создаем объект Bitmap изображения
        var bitmap = new Bitmap(image.Image);
        var sX = bitmap.Width / (float)image.Width;
        var sY = bitmap.Height / (float)image.Height;

        // возвращаем новый цвет
        color = bitmap.GetPixel((int)(e.X * sX), (int)(e.Y * sY));
        return true;
    }

    // кнопка "Ок" под палитрой кнопки
    private void OkP_Click(object sender, EventArgs e)
    {
        // при нажатии Ок предыдущий цвет становится текущим цвета рисунка
        PrevColorP = _main.Curr.ColorPoint;
    }

    // кнопка "Отмена" под палитрой кнопки
    private void CancelP_Click(object sender, EventArgs e)
    {
        // при нажатии Отмена текущий цвет рисунка становится предыдущим
        _main.Curr.ColorPoint = PrevColorP;
        _main.Refresh();
    }

    // кнопка "Ок" под палитрой линии
    private void OkS_Click(object sender, EventArgs e)
    {
        PrevColorS = _main.Curr.ColorSpline;
    }

    // кнопка "Отмена" под палитрой линии
    private void CancelS_Click(object sender, EventArgs e)
    {
        _main.Curr.ColorSpline = PrevColorS;
        _main.Refresh();
    }

    // кнопка "По умолчанию"
    private void ResetColor_Click(object sender, EventArgs e)
    {
        // сбрасываем цвета по умолчанию
        _main.Curr.ColorPoint = Color.Black;
        _main.Curr.ColorSpline = Color.Brown;
        _main.Refresh();
    }
}