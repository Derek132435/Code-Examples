//Derek Edwards
//Neural Net Image Recognition
//8/10/16

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AIAssign3
{
    public class Net
    {
        public Net()
        {
            inputs = new List<Neuron>();
            outputs = new List<Neuron>();
            synapses = new List<Synapse>();
        }

        public List<Neuron> inputs;
        private List<Neuron> outputs;
        public List<Synapse> synapses;

        public void AddInput(Neuron n) {
            //map each new input to all outputs
            foreach (Neuron O in outputs) { Connect(n, O, 0.0); }
            inputs.Add(n);
        }
        public void AddOutput(Neuron n) { outputs.Add(n); }
        public void Connect(Neuron from, Neuron to, double weight)
        {
            Synapse s = new Synapse();
            s.Axon = from;
            s.Dentrite = to;
            s.Weight = weight;
            synapses.Add(s);
        }
        public Synapse GetSynapse(Neuron from, Neuron to)
        {
            foreach (Synapse s in synapses)
            {
                if (s.Axon == from && s.Dentrite == to)
                    return s;
            }
            return null;
        }

        public string[] getWeights()
        {
            List<string> weights = new List<string>(synapses.Count);         
            foreach (Synapse aSynapse in synapses)
            {
                weights.Add(aSynapse.Weight.ToString("N6"));
            }
            //string[] theWeights = weights.ToString();
            string[] weightArray = weights.ToArray();
            return weightArray;
        }

        public void Evaluate()
        {
            foreach (Neuron outNeuron in outputs)
            {
                double value = 0.0;
                foreach (Neuron inNeuron in inputs)
                {
                    Synapse s = GetSynapse(inNeuron, outNeuron);
                    value += s.Weight * inNeuron.Value;
                }
                outNeuron.Value = value;
            }
        }

        public void Train(TrainingData[] data)
        {
            // set weights random
            Random r = new Random(0);
            foreach (Synapse s in synapses)
            {
                s.Weight = r.NextDouble() * 2 - 1.0;  // value between -1.0 and 1.0
            }

            // minimize the error
            double learningRate = 0.01;
            double precision = 0.01;
            double lastError;
            double currentError = double.MaxValue;
            do
            {
                lastError = currentError;
                currentError = 0.0;
                foreach (Synapse s in synapses)
                    s.dW = 0.0;

                // for each training point...
                foreach (TrainingData d in data)
                {
                    // for each output neuron...
                    for (int j = 0; j < outputs.Count; j++)
                    {
                        // calculate Yj from inputs and weights
                        outputs[j].Value = 0.0;
                        for (int i = 0; i < inputs.Count; i++)
                        {
                            Synapse s = GetSynapse(inputs[i], outputs[j]);
                            outputs[j].Value += s.Weight * d.X[i];
                        }

                        // determine error contribution from this output node and training point
                        currentError += Math.Pow(d.T[j] - outputs[j].Value, 2.0);

                        // determine weight gradient for each synapse
                        for (int i = 0; i < inputs.Count; i++)
                        {
                            Synapse s = GetSynapse(inputs[i], outputs[j]);
                            s.dW += (d.T[j] - outputs[j].Value) * d.X[i];
                        }
                    }
                }

                // update error for number of training points
                currentError /= data.Length;

                // adjust weights
                foreach (Synapse s in synapses)
                    s.Weight += learningRate * s.dW;
            }
            while (Math.Abs(currentError - lastError) > precision);
        }
    }

    public class Neuron
    {
        public double Value { get; set; }
    }

    public class Synapse
    {
        public Neuron Axon { get; set; }        // output
        public Neuron Dentrite { get; set; }    // input
        public double Weight { get; set; }
        public double dW { get; set; }          // for training only
    }

    public class TrainingData
    {
        public TrainingData()
        {
            X = new List<double>();
            T = new List<double>();
        }

        public TrainingData(double[] input, double[] expected)
        {
            X = new List<double>(input);
            T = new List<double>(expected);
        }

        public TrainingData(string testFile)
        {
            string[] result = testFile.Split(new string[] { ",", " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            double[] indicatorValue = { 0.0, 0.0 };
            //set first value in test file to expected output
            if (result[0] == "X")
            {
                indicatorValue[0] = 0.0;
                indicatorValue[1] = 1.0;
            }
            else
            {
                indicatorValue[0] = 1.0;
                indicatorValue[1] = 0.0;
            }
            //double[] indicatorValue = { (Convert.ToChar(result[0])), 0.0 };
            T = new List<double>(indicatorValue);
            //read input values into an list of doubles
            var inputList = new List<double>();
            for (int i = 1; i <= 64; i++)
            {
                double temp = Convert.ToDouble(result[i]);
                inputList.Add(temp);
            }
            X = new List<double>(inputList);
            //return new TrainingData((inputList.ToArray()), indicatorValue);
        }

        public List<double> X { get; set; }     // input values
        public List<double> T { get; set; }     // expected output values
    }
}