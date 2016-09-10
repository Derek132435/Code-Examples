//Derek Edwards
//Neural Net Image Recognition
//8/10/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AIAssign3;

namespace NeuralNetTest
{
    public class NeuralNet
    {
        static void Main(string[] args)
        {
            //instantiate neural net inputs and outputs
            Net theNet = new Net();
            Neuron outO = new Neuron();
            theNet.AddOutput(outO);
            Neuron outX = new Neuron();
            theNet.AddOutput(outX);
            for (int i = 0; i < 64; i++)
            {
                theNet.AddInput(new Neuron());
            }

            //BEGIN TRAINING
            List<TrainingData> data = new List<TrainingData>();
            //input training files
            string fileName;
            for(int i =1; i < 56; i++)
            {
                fileName = "train" + i + ".txt";
                string inText = System.IO.File.ReadAllText(fileName);
                data.Add(new TrainingData(inText));
            }

            //train net
            theNet.Train(data.ToArray());

            //read in test files, convert to doubles, map to inputs
            for (int i = 0; i < 8; i++)
            {
                fileName = "Test" + i + ".txt";
                string inText = System.IO.File.ReadAllText(fileName);
                string[] result = inText.Split(new string[] { ",", " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < 65; j++)
                {
                    double temp = Convert.ToDouble(result[j]);
                    theNet.inputs[j - 1].Value = temp;
                }

                //evaluate the Net
                theNet.Evaluate();

                //output results
                System.Console.WriteLine("OutO = " + outO.Value);
                System.Console.WriteLine("OutX = " + outX.Value);
                System.Console.WriteLine("\r\n");
            }

            //send synapse weights to output file
            if (File.Exists("outputFile.txt"))
            {
                File.Delete("outputFile.txt");
            }
            FileStream outstream = new FileStream("outputFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outstream);
            string[] weights = theNet.getWeights();
            for(int i = 0; i < 128; i = i + 16)
            {
                for (int j = i; j < (i+16); j++)
                {
                    writer.Write(weights[j] + ", ");
                }
                writer.Write("\r\n");
            }
            writer.Close();

            //System.IO.File.WriteAllLines("outputFile.txt", theNet.synapses.Select(s => (s.Weight).ToString()));

            System.Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}