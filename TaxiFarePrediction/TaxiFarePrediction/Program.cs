using Microsoft.ML;
using PricePredictionML.Model.DataModels;
using System;

namespace PricePrediction
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
            input.Passenger_count = 4;
            input.Trip_distance = 2;

            // Try model on sample data
            ModelOutput result = predEngine.Predict(input);
            Console.WriteLine("Result=" + result.Score);
        }
    }
}
