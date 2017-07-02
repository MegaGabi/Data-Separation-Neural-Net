using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using System.Drawing;
using System.Windows.Forms;

namespace NN_matricies
{
    //add editible iterations count, more hidden layers, online graph update
    class NeuralNetwork
    {
        int hidden_layers_count = 2;

        int input_size = 2,
            hidden_size = 20,
            output_size = 3;

        double alpha = -0.1;

        double[,] input,
                  output;

        double[][,] hidden;//layers

        double[,] input_weights;
        double[][,] hidden_weights;

        public NeuralNetwork()
        {
            input  = new double[1,  input_size + 1];

            hidden = new double[hidden_layers_count][,];
            for (int i = 0; i < hidden.GetLength(0); i++)
                hidden[i] = new double[1, hidden_size];

            output = new double[1, output_size];

            input_weights = Matrix.Random(input_size + 1,hidden_size, -1.0, 1.0);

            hidden_weights = new double[hidden_layers_count][,];
            for(int i = 0; i < hidden_weights.GetLength(0) - 1; i++)
                hidden_weights[i] = Matrix.Random(hidden_size + 1, hidden_size, -1.0, 1.0);
            hidden_weights[hidden_weights.GetLength(0) - 1] = Matrix.Random(hidden_size + 1, output_size, -1.0, 1.0);
        }

        public void Clear()
        {
            input_weights = Matrix.Random(input_size + 1, hidden_size, -1.0, 1.0);

            hidden_weights = new double[hidden_layers_count][,];
            for (int i = 0; i < hidden_weights.GetLength(0) - 1; i++)
                hidden_weights[i] = Matrix.Random(hidden_size + 1, hidden_size, -1.0, 1.0);
            hidden_weights[hidden_weights.GetLength(0) - 1] = Matrix.Random(hidden_size + 1, output_size, -1.0, 1.0);
        }

        public void Learn(Dictionary<PointF, double[]> data)
        {
            foreach (var tutor in data)
            {
                var ans = FeedForward(tutor.Key);
                var exp = tutor.Value.ToMatrix(true);

                Backprop(ans, exp);

                //MessageBox.Show(input.ToString(DefaultMatrixFormatProvider.CurrentCulture));
                //MessageBox.Show(output.ToString(DefaultMatrixFormatProvider.CurrentCulture));
            }
        }

        public double[,] FeedForward(PointF pt)//вродь правильно
        {
            input[0, 0] = pt.X;
            input[0, 1] = pt.Y;
            input[0, 2] = 1;

            hidden[0] = sigmoid(input.Dot(input_weights));
            hidden[0] = hidden[0].InsertColumn(new double[] { 1 });

            for (int i = 1; i < hidden.GetLength(0); i++)
            {
                hidden[i] = sigmoid(hidden[i - 1].Dot(hidden_weights[i - 1]));
                hidden[i] = hidden[i].InsertColumn(new double[] { 1 });
            }

            output = sigmoid(hidden[hidden.GetLength(0) - 1].Dot(hidden_weights[hidden_weights.GetLength(0) - 1]));
            return output;
        }

        private void Backprop(double[,] result, double[,] expected)
        {
            int hs = hidden_layers_count;

            double[][,] DeltaHiddenWeights = new double[hs][,];
            DeltaHiddenWeights[hs - 1] = new double[1, output_size];
            for (int i = hs - 2; i >= 0; i--)
            {
                DeltaHiddenWeights[i] = new double[1, hidden_size];
            }
            double[,] DeltaInputWeights   = new double[1,  hidden_size];

            var err = Error(result, expected);//вродь правильно

            DeltaHiddenWeights[hs - 1] = Elementwise.Multiply(sigmoid(output, true), err);//вродь правильно
            double[,] PreviousLayerError = DeltaHiddenWeights[hs - 1].Dot(hidden_weights[hs - 1].Transpose());//вродь правильно

            for (int i = hs - 2; i >= 0; i--)
            {
                DeltaHiddenWeights[i] = Elementwise.Multiply(sigmoid(hidden[i + 1].RemoveColumn(hidden[i].Columns() - 1), true), PreviousLayerError);
                PreviousLayerError = DeltaHiddenWeights[i].Dot(hidden_weights[i].Transpose());
            }

            DeltaInputWeights = Elementwise.Multiply(sigmoid(hidden[0].RemoveColumn(hidden[0].Columns() - 1), true), PreviousLayerError);

            for (int i = hs - 1; i >= 0; i--)
            {
                hidden_weights[i] = hidden_weights[i].Add(hidden[i].Transpose().Dot(DeltaHiddenWeights[i].Multiply(alpha)));
            }
            input_weights = input_weights.Add(input.Transpose().Dot(DeltaInputWeights.Multiply(alpha)));
        }

        private double[,] Error(double[,] y_real, double[,] y_exp, bool derivative = true)
        {
            if (derivative)
                return Elementwise.Subtract(y_real, y_exp);
            else
                return Elementwise.Multiply(0.5, Elementwise.Pow(Elementwise.Subtract(y_real, y_exp), 2));
        }

        private double[,] sigmoid(double[,] x, bool derivative = false)
        {
            if (derivative)
                return Elementwise.Multiply(x,Elementwise.Subtract(1,x));
            else
            {
                var buf = (x.Multiply(-1)).Exp();
                buf = buf.Add(1);
                buf = Elementwise.Divide(1,buf);
                return buf;
            }
        }
    }
}
