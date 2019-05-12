using System;
using Microsoft.ML;
using MyMLAppML.Model.DataModels;

namespace myMLApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
        }

        public static void ConsumeModel()
        {
            // Load the model
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use the code below to add input data
            var input = new ModelInput();
            input.SentimentText = "ML.NET rocks!";

            // Try model on sample data
            ModelOutput result = predEngine.Predict(input);
            Console.WriteLine("Result=" + result.Prediction);
        }
    }
}
