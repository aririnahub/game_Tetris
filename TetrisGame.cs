using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;

namespace TetrisGame
{
    public class TetrisGame
    {
        public List<Rectangle> TetrisBlocks { get; private set; }
        private Grid gameGrid;

        public TetrisGame(Grid grid)
        {
            TetrisBlocks = new List<Rectangle>();
            gameGrid = grid;
            // инициализация игровых элементов
            // начальное создание фигур
            CreateTetromino();
        }

        private void CreateTetromino()
        {
            // создание случайной фигуры, например, квадрата
            Rectangle block = new Rectangle
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Blue
            };
            TetrisBlocks.Add(block); // добавляем фигуру в коллекцию
            gameGrid.Children.Add(block); // добавляем фигуру на игровое поле
            Canvas.SetTop(block, 0); // устанавливаем начальное положение
            Canvas.SetLeft(block, 140);
        }

        public void MoveLeft()
        {
            foreach (Rectangle block in TetrisBlocks)
            {
                double left = Canvas.GetLeft(block);
                if (left > 0)
                {
                    Canvas.SetLeft(block, left - 20); // сдвигаем фигуру влево на 20 пикселей
                }
            }
        }

        public void MoveRight()
        {
            foreach (Rectangle block in TetrisBlocks)
            {
                double left = Canvas.GetLeft(block);
                if (left < 280) // ширина игрового поля - ширина фигуры
                {
                    Canvas.SetLeft(block, left + 20); // сдвигаем фигуру вправо на 20 пикселей
                }
            }
        }

        public void MoveDown()
        {
            foreach (Rectangle block in TetrisBlocks)
            {
                double top = Canvas.GetTop(block);
                if (top < 480) // высота игрового поля - высота фигуры
                {
                    Canvas.SetTop(block, top + 20); // сдвигаем фигуру вниз на 20 пикселей
                }
                else
                {
                    CheckLines(); // проверяем заполненные линии
                    CreateTetromino(); // создаем новую фигуру
                }
            }
        }

        public void Rotate()
        {
            // поворот фигуры
        }

        private void CheckLines()
        {
            for (int i = 480; i > 0; i -= 20)
            {
                bool lineFilled = true;
                foreach (Rectangle block in TetrisBlocks)
                {
                    if (Canvas.GetTop(block) == i)
                    {
                        lineFilled = false;
                        break;
                    }
                }

                if (lineFilled)
                {
                    RemoveLine(i);
                    i += 20;
                }
            }
        }

        private void RemoveLine(double line)
        {
            List<Rectangle> blocksToRemove = TetrisBlocks.FindAll(block => Canvas.GetTop(block) == line);
            foreach (Rectangle block in blocksToRemove)
            {
                TetrisBlocks.Remove(block);
                gameGrid.Children.Remove(block);
            }

            foreach (Rectangle block in TetrisBlocks)
            {
                double top = Canvas.GetTop(block);
                if (top < line)
                {
                    Canvas.SetTop(block, top + 20);
                }
            }
        }
    }
}
