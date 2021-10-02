namespace CrazyBird
{
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
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
    {

        // create a new instance of the timer class called game timer
        readonly DispatcherTimer gameTimer = new DispatcherTimer();
        // new gravity integer hold the vlaue 8
        int gravity = 8;
        // score keeper
        double score;
        // new rect class to help us detect collisions
        Rect FlappyRect;
        // new boolean for checking if the game is over or not
        bool gameover = false;
 
        public MainWindow()
        {
            InitializeComponent();
 
            // set the default settings for the timer
            gameTimer.Tick += GameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); // set the interval to 20 miliseconds
 
            // run the start game function
            StartGame();
 
        }
 
 
        private void Canvas_KeyisDown(object sender, KeyEventArgs e)
        {
            // if the space key is pressed
            if (e.Key == Key.Space)
            {
                // rotate the bird image to -20 degrees from the center position
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2);
                // change gravity so it will move upwards
                gravity = -8;
            }
            if (e.Key == Key.R && gameover == true)
            {
                // if the r key is pressed AND game over boolean is set to true
                // run the start game function
                StartGame();
            }
        }
 
        private void Canvas_KeyisUp(object sender, KeyEventArgs e)
        {
            // if the keys are released then we will change the rotation of the flappy bird to 5 degrees from the center
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);
            // change the gravity to 8 so the bird will go downwards and not up
            gravity = 8;
        }
 
        private void StartGame()
        {
            // this is the start game function 
            // this function will load all of the default values to start this game
 
            // first make a temp integer with the value 200
            int temp = 200;
 
            // set score to 0
            score = 0;
            // set the flappy bird top position to 100 pixels
            Canvas.SetTop(flappyBird, 100);
            // set game over to false
            gameover = false;
 
            // the loop below will simply check for each image in this game and set them to their default positions
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                // set obs1 pipes to its default position
                if (x is Image && (string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                // set obs2 pipes to its default position
                if (x is Image && (string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                // set obs3 pipes to its default position
                if (x is Image && (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1000);
                }
                // set the clouds to its default position
                if (x is Image && (string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, (300 + temp));
                    temp = 800;
                }
 
            }
            // start the main game timer
            gameTimer.Start();
 
        }
 
        private void GameEngine(object sender, EventArgs e)
        {
            // this is the game engine event linked to the timer
 
            // first update the score text label with the score integer
            scoreText.Content = "Score: " + score;
 
            // link the flappy bird image to the flappy rect class
            FlappyRect = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width -12, flappyBird.Height - 6);
 
            // set the gravity to the flappy bird image in the canvas
            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity);
 
            // check if the bird has either gone off the screen from top or bottom
            if (Canvas.GetTop(flappyBird) + flappyBird.Height > 490 || Canvas.GetTop(flappyBird) < -30)
            {
                // if it has then we end the game and show the reset game text
                gameTimer.Stop();
                gameover = true;
                scoreText.Content += "   Press R to Try Again";
            }
 
            // below is the main loop, this loop will go through each image in the canvas
            // if it finds any image with the tags and follow the instructions with them
 
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
 
                    // if we found an image with the tag obs1,2 or 3 then we will move it towards left of the scree
 
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
 
                    // create a new rect called pillars and link the rectangles to it
                    Rect pillars = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
 
                    // if the flappy rect and the pillars rect collide
                    if (FlappyRect.IntersectsWith(pillars))
                    {
                        // stop the timer, set the game over to true and show the reset text
                        gameTimer.Stop();
                        gameover = true;
                        scoreText.Content += "   Press R to Try Again";
                    }
 
                }
 
                // if the first layer of pipes leave the scene and go to -100 pixels from the left
                // we need to reset the pipe to come back again
                if ((string)x.Tag == "obs1" && Canvas.GetLeft(x) < -100)
                {
                    // reset the pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score += .5;
 
                }
                // if the second layer of pipes leave the scene and go to -200 pixels from the left
                if ((string)x.Tag == "obs2" && Canvas.GetLeft(x) < -200)
                {
                    // we set that pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score += .5;
                }
                // if the third layer of pipes leave the scene and go to -250 pixels from the left
                if ((string)x.Tag == "obs3" && Canvas.GetLeft(x) < -250)
                {
                    // we set the pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score += .5;
 
                }
 
                // if find any of the images with the clouds tag on it
                if ((string)x.Tag == "clouds")
                {
                    // then we will slowly move the cloud towards left of the screen
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - .6);
 
 
                    // if the clouds have reached -220 pixels then we will reset it
                    if (Canvas.GetLeft(x) < -220)
                    {
                        // reset the cloud images to 550 pixels
                        Canvas.SetLeft(x, 550);
                    }
                }
            }
        }
 
 
    }
}