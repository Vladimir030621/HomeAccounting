using HomeAccounting.Models;
using MaterialDesignColors.Recommended;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HomeAccounting.ViewModels
{
    class ChartViewModel
    {
        private DataManager dataManager;

        /// <summary> Gets the plot model. </summary>
        public PlotModel Model { get; private set; }

        public ChartViewModel()
        {
            dataManager = new DataManager();

            ChartArrange();
        }

        #region Chart Arranging

        private void ChartArrange()
        {
            /// <summary> Create plot model and axis </summary>
            var plotModel = new PlotModel();
            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM/yy" });
            plotModel.Axes.Add(new LogarithmicAxis { Position = AxisPosition.Left, StringFormat = "### ### ###" });


            /// <summary> Adding points to income line</summary>
            var incomeOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Income").OrderBy(o => o.Date);

            var incomes = new LineSeries { Title = "Income", MarkerType = MarkerType.Circle };

            foreach (Operation operation in incomeOperations)
            {
                incomes.Points.Add(new DataPoint(DateTimeAxis.ToDouble(operation.Date), Convert.ToDouble(operation.Sum)));
            }

            /// <summary> Adding points to expense line</summary>
            var expenseOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Expense").OrderBy(o => o.Date);

            var expenses = new LineSeries { Title = "Expense", MarkerType = MarkerType.Circle };

            foreach (Operation operation in expenseOperations)
            {
                expenses.Points.Add(new DataPoint(DateTimeAxis.ToDouble(operation.Date), Convert.ToDouble(operation.Sum)));
            }


            plotModel.Series.Add(incomes);
            plotModel.Series.Add(expenses);

            this.Model = plotModel;
        }

        #endregion

    }
}
