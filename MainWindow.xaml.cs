using Fanorona91G.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fanorona91G
{
    /// <summary>
    /// Interaction logic for MainWindow.x
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Nodo nodo = new Nodo();
            nodo.ChildrenGenerate(1, 3);
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            //< BeginStoryboard >
            //        < Storyboard >
            //            < ColorAnimationUsingKeyFrames Storyboard.TargetProperty = "(Ellipse.Fill).(SolidColorBrush.Color)"
            //                                          Duration = "0:0:2"
            //                                          FillBehavior = "HoldEnd"
            //                                          RepeatBehavior = "Forever" >
            //                < ColorAnimationUsingKeyFrames.KeyFrames >
            //                    < DiscreteColorKeyFrame KeyTime = "0:0:0" Value = "Red" />
            //                    < DiscreteColorKeyFrame KeyTime = "0:0:1" Value = "Blue" />
            //                </ ColorAnimationUsingKeyFrames.KeyFrames >
            //            </ ColorAnimationUsingKeyFrames >
            //        </ Storyboard >
            //    </ BeginStoryboard >

            Storyboard sb = new Storyboard();
            //DoubleAnimation da = new DoubleAnimation(100, 0, new Duration(new TimeSpan(0, 0, 3)));
            ////  Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Top)")); //Do not miss the '(' and ')'
            ///
            //Storyboard.SetTargetProperty(da, new PropertyPath("(Opacity)")); //Do not miss the '(' and ')'
            //sb.Children.Add(da);


            ColorAnimationUsingKeyFrames color = new ColorAnimationUsingKeyFrames();

            Storyboard.SetTargetProperty(color, new PropertyPath("(Fill)"));

            color.Duration = new Duration(new TimeSpan(0, 0, 2));
            color.FillBehavior = FillBehavior.HoldEnd;

            DiscreteColorKeyFrame keyFrame = new DiscreteColorKeyFrame();
            keyFrame.KeyTime = new TimeSpan(0, 0, 0);
            keyFrame.Value = Color.FromRgb(255, 255, 255);

            DiscreteColorKeyFrame keyFrame2 = new DiscreteColorKeyFrame();
            keyFrame2.KeyTime = new TimeSpan(0, 0, 2);
            keyFrame2.Value = Color.FromRgb(0, 0, 0);

            color.KeyFrames.Add(keyFrame);
            color.KeyFrames.Add(keyFrame2);


            ellipse.BeginStoryboard(sb);
        }
    }


   
}


