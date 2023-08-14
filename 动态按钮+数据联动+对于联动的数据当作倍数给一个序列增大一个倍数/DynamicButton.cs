using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace WpfExercise03
{
    /// <summary>
    /// 动态按钮模块
    /// </summary>
    public class DynamicButton
    {
        public DynamicButton(Button button, double right, double bottom)
        {
            _button = button;
            _right = right;
            _bottom = bottom;
            timer = new Timer(50);
            timer.Elapsed += Timer_Elapsed;
        }

        public void SetEnable(bool flag)
        {
            if (flag)
            {
                //Canvas.SetLeft(_button, 0);
                //Canvas.SetTop(_button, 0);
                timer.Start();
            }
            else
            {
                timer.Stop();
                //Canvas.SetLeft(_button, 0);
                //Canvas.SetTop(_button, 0);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _button.Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(_button, Canvas.GetLeft(_button) + speedHorizontal);
                Canvas.SetTop(_button, Canvas.GetTop(_button) + speedVert);
                //speedHorizontal = Canvas.GetLeft(_button) > _right ? -5 : 5;
                //speedVert = Canvas.GetTop(_button) > _bottom ? -5 : 5;

                if (Canvas.GetTop(_button) > _bottom && speedVert > 0)
                {
                    speedVert *= -1;
                }
                else if(Canvas.GetTop(_button) < 0 && speedVert < 0)
                {
                    speedVert *= -1;
                }

                if (Canvas.GetLeft(_button) > _right && speedHorizontal > 0)
                {
                    speedHorizontal *= -1;
                }
                else if (Canvas.GetLeft(_button) < 0 && speedHorizontal < 0)
                {
                    speedHorizontal *= -1;
                }
            });
        }


        #region privatemembers

        private readonly Button _button;
        private readonly double _right;
        private readonly double _bottom;
        private readonly Timer timer;

        private double speedVert = 5f;
        private double speedHorizontal = 5f;
        #endregion
    }
}
