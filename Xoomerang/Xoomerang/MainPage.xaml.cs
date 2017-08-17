using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;

namespace Xoomerang
{
    class GameState
    {
        public int score = 0;
    }
    public partial class MainPage : ContentPage
    {
        public int BoomerangSize = 20;

        private double ticks = 0;

        public MainPage()
        {
            InitializeComponent();

            Func<bool> gameLoop = GameLoop;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), gameLoop);
        }

        public bool GameLoop()
        {
            ticks += 0.01;
            var aBounds = AbsoluteLayout.GetLayoutBounds(Antiboomerang);
            aBounds.X = (Math.Cos(ticks) * 0.5d) + 0.5d;
            AbsoluteLayout.SetLayoutBounds(Antiboomerang, aBounds);

            var bBounds = AbsoluteLayout.GetLayoutBounds(Boomerang);
            bBounds.X = (-Math.Cos(ticks) * 0.5d) + 0.5d;
            AbsoluteLayout.SetLayoutBounds(Boomerang, bBounds);

            return true;
        }
    }
}
