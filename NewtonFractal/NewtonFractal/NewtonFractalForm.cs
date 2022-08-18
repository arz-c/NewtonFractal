using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NewtonFractal {
    public partial class NewtonFractalForm : Form {
        private const double EPSILON = 0.0001; // Amount of leeway given for root approximations
        private const int MAX_ITERATIONS = 100;
        private const double INITIAL_COMPLEX_PLANE_RADIUS = 4; // Half the sidelength of the square complex plane
        private const double ZOOM_FACTOR = 1.5;
        private const int NUM_OF_DECIMALS_SHOWN = 3;

        private Bitmap newtonFractalBitmap;
        private double[] chosenPolynomial;
        private double complexPlaneRadius;

        #region Constructor
        public NewtonFractalForm() {
            InitializeComponent();

            polynomialTextbox.Text = "-1,0,0,1";
            newtonFractalBitmap = new Bitmap(800, 800);

            complexPlaneRadius = INITIAL_COMPLEX_PLANE_RADIUS;
            complexPlaneRadiusLabel.Text = complexPlaneRadius.ToString();
            colouringMethodComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Main Logic
        public Complex[] NewtonsApproximationMethod(double[] polynomial, Complex initialGuess, int maxIterations, double epsilon) {
            Complex guess = initialGuess;
            double iterationCount = 0;
            double[] derivative = DifferentiatePolynomial(polynomial);

            do {
                Complex derivativeAtPrevGuess = EvaluatePolynomialAt(derivative, guess);
                if(derivativeAtPrevGuess != 0) {
                    guess = guess - EvaluatePolynomialAt(polynomial, guess) / derivativeAtPrevGuess;
                    iterationCount++;
                } else {
                    iterationCount = maxIterations;
                }
            } while(Complex.Abs(EvaluatePolynomialAt(polynomial, guess)) > epsilon && iterationCount < maxIterations);

            // Signal to caller that Newton's method is undefined given initial guess since derivative was 0 at some point
            if(iterationCount == maxIterations)
                guess = double.NaN;

            return new Complex[] { guess, iterationCount };
        }

        private void DrawNewtonFractal(double[] polynomial, Bitmap newtonFractalBitmap, double complexPlaneRadius) {
            Complex[] roots = new Complex[polynomial.Length - 1];
            Color[] colours = null;

            if(colouringMethodComboBox.Text == "Wavelength Partitioning") {
                colours = GetsColourArray_WavelengthPartitioning(polynomial);
            } else if(colouringMethodComboBox.Text == "Hue Partitioning") {
                colours = GetColorArray_HuePartitioning(polynomial);
            } else if(colouringMethodComboBox.Text == "Iteration Count") {
                colours = new Color[] { };
            }

            int rootsFoundCount = 0;

            for(int x = 0; x < newtonFractalBitmap.Width; x++) {
                for(int y = 0; y < newtonFractalBitmap.Height; y++) {

                    Complex[] result = NewtonsApproximationMethod(polynomial,
                        ToComplexCoords(newtonFractalBitmap, complexPlaneRadius, new Point(x, y)),
                        MAX_ITERATIONS, EPSILON
                    );

                    Complex root = result[0];
                    int iterationCount = (int) result[1].Real;

                    if(!Double.IsNaN(root.Real)) {

                        if(colours.Length > 0) { // Wavelength or hue partitioning colouring method was selected

                            int i = 0;
                            while(i < rootsFoundCount) {
                                double delta = Complex.Abs(root - roots[i]);
                                if(delta < EPSILON) {
                                    newtonFractalBitmap.SetPixel(x, y, colours[i]);
                                    i = roots.Length + 1; // Signal that existing root was found
                                } else {
                                    i++;
                                }
                            }

                            // New root was found (no existing root was within 'EPSILON' of the new root)
                            if(i != roots.Length + 1) {
                                newtonFractalBitmap.SetPixel(x, y, colours[i]);
                                roots[rootsFoundCount] = root;
                                rootsFoundCount++;
                            }

                        } else { // Iteration count colouring method was selected
                            newtonFractalBitmap.SetPixel(x, y, GetColor_IterationCount(iterationCount, MAX_ITERATIONS));
                        }
                    }
                }
            }

            newtonFractalPictureBox.Refresh();
        }

        /*
        * Visible light ranges roughly from 380 to 780 nanometers.
        * This colouring method partitions the spectrum into as many parts
        * as there are roots of the polynomial.
        * The colour for each root is the midpoint (average) of each partition.
        * This way, the colours are distinct from each other.
        */
        private Color[] GetsColourArray_WavelengthPartitioning(double[] polynomial) {
            Color[] colours = new Color[polynomial.Length - 1];
            double partitionSize = (double) (780 - 380) / (colours.Length);

            for(int i = 0; i < colours.Length; i++) {
                double meanValue = (partitionSize * i + partitionSize * (i + 1)) / 2;
                double wavelength = 380 + meanValue;
                colours[i] = WavelengthToColour(wavelength);
            }

            return colours;
        }

        /*
         * The same logic as 'GetsColourArray_WavelengthPartitoning' is used,
         * only this time with hue instead of wavelength.
         * Hue is based on degrees around the colour wheel, which is why the
         * interval ranges from 0 to 360.
        */
        private Color[] GetColorArray_HuePartitioning(double[] polynomial) {
            Color[] colours = new Color[polynomial.Length - 1];
            float partitionSize = (float) 360 / (colours.Length);

            for(int i = 0; i < colours.Length; i++) {
                float meanValue = (partitionSize * i + partitionSize * (i + 1)) / 2;
                colours[i] = ColorFromHSL(meanValue, 1f, 0.5f);
            }

            return colours;
        }

        /*
         * Colouring by iteration count is different from the partitioning methods
         * in that points are coloured on a spectrum as opposed to a discrete set.
         * For this reason, the method returns a single colour based on the given 'iterationCount'
         * instead of an array of colours.
         * Graph comparing the colour regression models used/considered: https://www.desmos.com/calculator/duqcfvez9t
        */
        private Color GetColor_IterationCount(int iterationCount, int maxIterations) {
            double factor = (double) iterationCount / maxIterations;
            return Color.FromArgb(
                (int) Math.Round(( (8/7) / Math.Pow((factor + 1), 3) - (1/7) ) * 255),
                0,
                (int) Math.Round((factor * 255))
            );
        }
        #endregion

        #region Helper Methods
        public Complex EvaluatePolynomialAt(double[] polynomial, Complex input) {
            Complex result = 0;
            for(int i = 0; i < polynomial.Length; i++) {
                result += polynomial[i] * Complex.Pow(input, i);
            }
            return result;
        }

        public double[] DifferentiatePolynomial(double[] polynomial) {
            double[] derivative = new double[polynomial.Length - 1];
            for(int i = 1; i < polynomial.Length; i++) {
                derivative[i - 1] = polynomial[i] * i;
            }
            return derivative;
        }

        private string FormatCoordPair(double x, double y, int decToRoundTo) {
            return '(' + Math.Round(x, decToRoundTo).ToString() + ", " + Math.Round(y, decToRoundTo).ToString() + ')';
        }

        private Complex ToComplexCoords(Bitmap bitmap, double planeRadius, Point point) {
            double halfWidth = bitmap.Width / 2;
            double halfHeight = bitmap.Height / 2;

            return new Complex(
                (planeRadius / halfWidth) * (point.X - halfWidth),
                (planeRadius / halfHeight) * -(point.Y - halfHeight)
            );
        }

        // NOT MINE! (Source: https://academo.org/demos/wavelength-to-colour-relationship/)
        private Color WavelengthToColour(double wavelength) {
            double gamma = 0.80;
            double factor, red, green, blue;

            if((wavelength >= 380) && (wavelength < 440)) {
                red = -(wavelength - 440) / (440 - 380);
                green = 0.0;
                blue = 1.0;
            } else if((wavelength >= 440) && (wavelength < 490)) {
                red = 0.0;
                green = (wavelength - 440) / (490 - 440);
                blue = 1.0;
            } else if((wavelength >= 490) && (wavelength < 510)) {
                red = 0.0;
                green = 1.0;
                blue = -(wavelength - 510) / (510 - 490);
            } else if((wavelength >= 510) && (wavelength < 580)) {
                red = (wavelength - 510) / (580 - 510);
                green = 1.0;
                blue = 0.0;
            } else if((wavelength >= 580) && (wavelength < 645)) {
                red = 1.0;
                green = -(wavelength - 645) / (645 - 580);
                blue = 0.0;
            } else if((wavelength >= 645) && (wavelength < 781)) {
                red = 1.0;
                green = 0.0;
                blue = 0.0;
            } else {
                red = 0.0;
                green = 0.0;
                blue = 0.0;
            };

            // Let the intensity fall off near the vision limits
            if((wavelength >= 380) && (wavelength < 420)) {
                factor = 0.3 + 0.7 * (wavelength - 380) / (420 - 380);
            } else if((wavelength >= 420) && (wavelength < 701)) {
                factor = 1.0;
            } else if((wavelength >= 701) && (wavelength < 781)) {
                factor = 0.3 + 0.7 * (780 - wavelength) / (780 - 700);
            } else {
                factor = 0.0;
            };
            if(red != 0) {
                red = Math.Round(255 * Math.Pow(red * factor, gamma));
            }
            if(green != 0) {
                green = Math.Round(255 * Math.Pow(green * factor, gamma));
            }
            if(blue != 0) {
                blue = Math.Round(255 * Math.Pow(blue * factor, gamma));
            }
            return Color.FromArgb((int) red, (int) green, (int) blue);
        }

        // Formula is from 'RapidTables'. (Source: https://www.rapidtables.com/convert/color/hsl-to-rgb.html)
        private static Color ColorFromHSL(float H, float S, float L) {
            Color color = Color.Empty;
            if(H >= 0 && H <= 360 &&
               S >= 0 && S <= 1 &&
               L >= 0 && L <= 1) {
                float floatC = (1 - Math.Abs(2 * L - 1)) * S;
                int C = (int) Math.Round(floatC);
                int X = (int) Math.Round(floatC * (1 - Math.Abs((H / 60) % 2 - 1)));
                int m = (int) Math.Round(L - floatC / 2);
                
                if(H <= 60) {
                    color = Color.FromArgb(C, X, 0);
                } else if(H <= 120) {
                    color = Color.FromArgb(X, C, 0);
                } else if(H <= 180) {
                    color = Color.FromArgb(0, C, X);
                } else if(H <= 240) {
                    color = Color.FromArgb(0, X, C);
                } else if(H <= 300) {
                    color = Color.FromArgb(X, 0, C);
                } else {
                    color = Color.FromArgb(C, 0, X);
                }
                
                color = Color.FromArgb((color.R + m) * 255, (color.G + m) * 255, (color.B + m) * 255);
            } 
            return color;
        }
        #endregion

        #region Event Handlers
        private void newtonFractalPictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(newtonFractalBitmap, 0, 0);
        }

        private void displayNewtonFractalButton_Click(object sender, EventArgs e) {
            string[] stringPolynomial = polynomialTextbox.Text.Split(',');
            chosenPolynomial = new double[stringPolynomial.Length];
            
            int i = 0;

            while(i < stringPolynomial.Length) {
                if(!Double.TryParse(stringPolynomial[i], out chosenPolynomial[i])) {
                    i = stringPolynomial.Length + 1;
                } else {
                    i++;
                }
            }

            if(i < stringPolynomial.Length + 1) {
                DrawNewtonFractal(chosenPolynomial, newtonFractalBitmap, complexPlaneRadius);
            } else {
                MessageBox.Show(
                    "Incorrect format used for entering polynomial.\n" +
                    "Please enter coefficients from 0th to nth power separated by commas.",
                    "Error"
                );
            }
        }

        private void newtonFractalPictureBox_MouseMove(object sender, MouseEventArgs e) {
            mouseCoordinatesLabel.Text = FormatCoordPair(e.X, e.Y, NUM_OF_DECIMALS_SHOWN);

            Complex complexCoords = ToComplexCoords(newtonFractalBitmap, complexPlaneRadius, e.Location);
            complexPlaneCoordinatesLabel.Text = FormatCoordPair(complexCoords.Real, complexCoords.Imaginary, NUM_OF_DECIMALS_SHOWN);
        }
        private void IncreaseComplexPlaneRadiusButton_Click(object sender, EventArgs e) {
            complexPlaneRadius *= ZOOM_FACTOR;
            complexPlaneRadiusLabel.Text = Math.Round(complexPlaneRadius, NUM_OF_DECIMALS_SHOWN).ToString();
        }

        private void DecreaseComplexPlaneRadiusButton_Click(object sender, EventArgs e) {
            if(complexPlaneRadius / ZOOM_FACTOR > Math.Pow(10, -NUM_OF_DECIMALS_SHOWN)) {
                complexPlaneRadius /= ZOOM_FACTOR;
                complexPlaneRadiusLabel.Text = Math.Round(complexPlaneRadius, NUM_OF_DECIMALS_SHOWN).ToString();
            } else {
                MessageBox.Show("Cannot zoom in further.", "Error");
            }
        }
        #endregion
    }
}
