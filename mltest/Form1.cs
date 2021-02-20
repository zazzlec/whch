using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mltest
{

   


    public partial class Form1 : Form
    {
        static readonly string DataPath = Path.Combine(Environment.CurrentDirectory,  "figure_full.csv");
        static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory,  "FastTree_Model.zip");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        void TrainAndSave()
        {
            MLContext mlContext = new MLContext();

            //准备数据
            var fulldata = mlContext.Data.LoadFromTextFile<FigureData>(path: DataPath, hasHeader: true, separatorChar: ',');
            var trainTestData = mlContext.Data.TrainTestSplit(fulldata, testFraction: 0.2);
            var trainData = trainTestData.TrainSet;
            var testData = trainTestData.TestSet;

            //训练 
           
            IEstimator<ITransformer> dataProcessPipeline = mlContext.Transforms.Concatenate("Features", new[] { "Height", "Weight" })
                .Append(mlContext.Transforms.NormalizeMeanVariance(inputColumnName: "Features", outputColumnName: "FeaturesNormalizedByMeanVar"));
            IEstimator<ITransformer> trainer = mlContext.BinaryClassification.Trainers.FastTree(labelColumnName: "Result", featureColumnName: "FeaturesNormalizedByMeanVar");
            IEstimator<ITransformer> trainingPipeline = dataProcessPipeline.Append(trainer);
            ITransformer model = trainingPipeline.Fit(trainData);

            //评估
            var predictions = model.Transform(testData);
            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Result", scoreColumnName: "Score");
            PrintBinaryClassificationMetrics(trainer.ToString(), metrics);

            //保存模型
            mlContext.Model.Save(model, trainData.Schema, ModelPath);
            Console.WriteLine($"Model file saved to :{ModelPath}");
        }


        public void PrintBinaryClassificationMetrics(string name, CalibratedBinaryClassificationMetrics metrics)
        {
            StringBuilder s =new StringBuilder();
            
            s.Append($"************************************************************");
            s.Append($"*       Metrics for {name} binary classification model      ");
            s.Append($"*-----------------------------------------------------------");
            s.Append($"*       Accuracy: {metrics.Accuracy:P2}");
            s.Append($"*       Area Under Curve:      {metrics.AreaUnderRocCurve:P2}");
            s.Append($"*       Area under Precision recall Curve:  {metrics.AreaUnderPrecisionRecallCurve:P2}");
            s.Append($"*       F1Score:  {metrics.F1Score:P2}");
            s.Append($"*       LogLoss:  {metrics.LogLoss:#.##}");
            s.Append($"*       LogLossReduction:  {metrics.LogLossReduction:#.##}");
            s.Append($"*       PositivePrecision:  {metrics.PositivePrecision:#.##}");
            s.Append($"*       PositiveRecall:  {metrics.PositiveRecall:#.##}");
            s.Append($"*       NegativePrecision:  {metrics.NegativePrecision:#.##}");
            s.Append($"*       NegativeRecall:  {metrics.NegativeRecall:P2}");
            s.Append($"************************************************************");

            MessageBox.Show(s.ToString());
        }

        void LoadAndPrediction()
        {
            var mlContext = new MLContext();
            ITransformer model = mlContext.Model.Load(ModelPath, out var inputSchema);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<FigureData, FigureDatePredicted>(model);

            FigureData test = new FigureData();
            test.Weight = 115;
            test.Height = 171;

            var prediction = predictionEngine.Predict(test);
            MessageBox.Show($"Predict Result :{prediction.PredictedLabel}");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Filename = Application.StartupPath+"\\figure_full.csv";
            StreamWriter sw = new StreamWriter(Filename, false);
            sw.WriteLine("Height,Weight,Result");

            Random random = new Random();
            float height, weight;
            int result;

            for (int i = 0; i < 2000; i++)
            {
                height = random.Next(150, 195);
                weight = random.Next(70, 200);

                if (height > 170 && weight < 120)
                    result = 1;
                else
                    result = 0;

                sw.WriteLine($"{height},{weight},{(int)result}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainAndSave();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadAndPrediction();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }



    class FigureData
    {
        [LoadColumn(0)]
        public float Height { get; set; }

        [LoadColumn(1)]
        public float Weight { get; set; }

        [LoadColumn(2)]
        public bool Result { get; set; }
    }

    class FigureDatePredicted : FigureData
    {
        public bool PredictedLabel;
    }
}
